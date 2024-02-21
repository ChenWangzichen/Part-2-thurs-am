using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public class Fly : MonoBehaviour
{
    Vector2 destination;
    Vector2 movement;
    public float speed = 12f;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(movement.magnitude < 1)
        {
            destination = new Vector2(Random.Range(-8.5f, 8.5f), Random.Range(-4f, 4f));
        }

        movement = destination - (Vector2)transform.position;
        rb2d.MovePosition(rb2d.position + movement.normalized * speed * Time.deltaTime);
    }
}
