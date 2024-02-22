using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    bool cherryIn;
    int score = 0;
    public GameObject cherry;
    public TextMeshProUGUI scoreText;

    private void Update()
    {
        scoreText.text = score.ToString();
        if (score == 60)
        {
            SceneManager.LoadScene(3);
        }
    }
    private void FixedUpdate()
    {
        if(cherryIn && cherry.activeInHierarchy)
        {
            score++;
            Debug.Log(score);
            cherry.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        cherryIn = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        cherryIn = false;
    }
}
