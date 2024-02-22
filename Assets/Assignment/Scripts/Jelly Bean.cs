using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JellyBean : MonoBehaviour
{
    Vector2 destination;
    Vector2 movement;
    public float speed = 5f;
    Rigidbody2D jelly;
    public GameObject cherry;
    int currentCherry;
    int charryLife = 5;
    bool hit;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentCherry = charryLife;
        jelly = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        destination = (Vector2)transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (movement.x !=0 || movement.y != 0)
        {
            animator.SetFloat("Horizontal",movement.normalized.x);
            animator.SetFloat("Vertical", movement.normalized.y);
        }

        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        movement = destination - (Vector2)transform.position;

        if(movement.magnitude < 0.1f )
        {
            movement = Vector2.zero;
        }
        jelly.MovePosition(jelly.position + movement.normalized * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (cherry.activeInHierarchy)
        {
            SendMessage("LoseCherry", 1);
        }
        
        
    }
    public void WithCharry()
    {
        cherry.SetActive(true);
    }

    public void LoseCherry(int oneCherry)
    {
        
        currentCherry -= oneCherry;
        currentCherry = Mathf.Clamp(currentCherry, 0, charryLife);
        cherry.SetActive(false);

        if (currentCherry == 0 )
        {
            SceneManager.LoadScene(2);
        }
    }
}
