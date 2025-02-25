using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPostionThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Vector2 currentPosition;
    Rigidbody2D rigidb;
    public float speed;
    public AnimationCurve landing;
    float landingTimer;
    SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public bool land;




    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0,transform.position + new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f));

        GetComponent<Transform>().rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));

        rigidb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[Random.Range(0,4)];
        speed = Random.Range(1, 3);
    }

    private void FixedUpdate()
    {
        currentPosition = transform.position;
        if(points.Count > 0 )
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2( direction.x, direction.y ) * Mathf.Rad2Deg;
            rigidb.rotation = -angle;
        }
        rigidb.MovePosition(rigidb.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    private void Update()
    {
        if(land == true)
        {

            landingTimer += 0.5f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);
            if (transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        }

        lineRenderer.SetPosition(0, transform.position);
        if (points.Count > 0 )
        {
            if (Vector2.Distance(currentPosition, points[0]) < newPostionThreshold) 
            {
                points.RemoveAt(0);

                for (int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }
        }

        if (transform.position.x > 15 || transform.position.x < -15 || transform.position.y > 7 || transform.position.y < -7)
        {
            Destroy(gameObject) ;
        }
    }

    private void OnMouseDown()
    {
        points = new List<Vector2>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDrag()
    {
        Vector2 newPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(lastPosition, newPostion) > newPostionThreshold )
        {
            points.Add(newPostion);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPostion);
            lastPosition = newPostion;
        }
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        spriteRenderer.color = Color.red;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(Vector3.Distance(transform.position, other.transform.position) < 0.5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = Color.white;
    }
}
