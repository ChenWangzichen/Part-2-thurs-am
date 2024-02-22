using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{
    Rigidbody2D rbBall;
    public Vector2 spot;
    // Start is called before the first frame update
    
    void Start()
    {
        rbBall = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Controller.score++;
        rbBall.position = spot;
        rbBall.velocity = Vector2.zero;
    }
}
