using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color originalColor;
    Rigidbody2D rbPlayer;
    public float speed = 100;
    // Start is called before the first frame update
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rbPlayer = GetComponent<Rigidbody2D>();
        Selected(false);
    }
    private void OnMouseDown()
    {
        Controller.SetSelectedPlayer(this);
    }
    public void Selected(bool isSeclected)
    {
        if (isSeclected)
        {
            spriteRenderer.color = Color.blue;
        } else 
        { 
            spriteRenderer.color = originalColor;
        }
    }

    public void Move(Vector2 direction) 
    {
        rbPlayer.AddForce(direction * speed);
    }

}
