using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyBean : MonoBehaviour
{
    Vector2 destination;
    Vector2 movement;
    public float speed = 5f;
    Rigidbody2D jelly;
    public GameObject cherry;
    int currentCherry;
    int charryLife = 5;
    public bool withCharry;
    
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentCherry = charryLife;
        jelly = GetComponent<Rigidbody2D>();
        NoCharry();
        destination = (Vector2)transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
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
        currentCherry -= 1;
        currentCherry = Mathf.Clamp(currentCherry, 0, charryLife);
        NoCharry();
    }
    public void WithCharry()
    {
        cherry.SetActive(true);
        withCharry = true;
    }
    

    public void NoCharry() 
    {
        cherry.SetActive(false);
        withCharry = false;
    }
}
