using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject planePrefab;
    public Transform spawner;
    float timerValue;
    float timerTarget;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timerValue += Time.deltaTime;
        if (timerValue > timerTarget)
        {
            Instantiate(planePrefab,new Vector3(Random.Range(-5,5), Random.Range(-5,5),0), Quaternion.Euler(0f,0f,Random.Range(-180f,180f)));
            timerValue = 0;
            timerTarget = Random.Range(1,5);
        }

    }
}
