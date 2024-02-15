using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
    public AnimationCurve animationCurve;
    public Transform startPosition;
    public Transform endPosition;
    public float lerpTimer;
    public Color colStart;
    public Color colEnd;
    public SpriteRenderer spriteRenderer;
   
    // Update is called once per frame
    void Update()
    {
        float interpolation = animationCurve.Evaluate(lerpTimer);
        transform.position = Vector3.Lerp(startPosition.position, endPosition.position, lerpTimer);
        lerpTimer += Time.deltaTime;

        spriteRenderer.color = Color.Lerp(colStart, colEnd, interpolation);
    }
}
