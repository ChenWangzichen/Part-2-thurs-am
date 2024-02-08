using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float speed = 10;
    Rigidbody2D rbw;
    

    void Start()
    {
        rbw = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5);
    }

    private void FixedUpdate()
    {
        rbw.MovePosition(rbw.position + (Vector2)transform.up * speed * Time.deltaTime);
    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 1);
        Destroy(gameObject);
    }

    
}
