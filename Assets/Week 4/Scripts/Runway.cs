using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runway : MonoBehaviour
{
    public float score = 0;
    bool landed;
    Collider2D runway;
    
    // Start is called before the first frame update
    void Start()
    {
        runway = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (runway.OverlapPoint(collision.gameObject.transform.position))
        {
            collision.gameObject.GetComponent<Plane>().land = true;
            landed = true;
        }
       
    }

   private void OnTriggerEnter2D(Collider2D collision)
   {
        if (landed == true)
        {
            score++;
            Debug.Log(score);
        }
        
    }

}
