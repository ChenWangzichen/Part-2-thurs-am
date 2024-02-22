using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class Rotateanimation : MonoBehaviour
{
    public AnimationCurve animationCurve;
    
    public float time;

    // Start is called before the first frame update

    private void Start()
    {
        animationCurve = GetComponent<AnimationCurve>();
        
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().rotation = Quaternion.Euler(0f,0f,360f);
        time += Time.deltaTime;
    }
}
