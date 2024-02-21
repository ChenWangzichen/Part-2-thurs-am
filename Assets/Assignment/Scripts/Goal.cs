using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Goal : MonoBehaviour
{
    bool cherryIn;
    int score = 0;
    private void FixedUpdate()
    {
        if(cherryIn == true)
        {
            score++;
            Debug.Log(score);
            cherryIn = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<JellyBean>().NoCharry();
        cherryIn = true;
    }
}
