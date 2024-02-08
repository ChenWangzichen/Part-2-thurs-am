using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float speed = 10;
    Rigidbody2D rbw;
    

    void Start()
    {
        rbw = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rbw.MovePosition(rbw.position + (Vector2)transform.up * speed * Time.deltaTime);
    }
    void Update()
    {
        if ()
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 1);
        Destroy(gameObject);
    }
    
}
