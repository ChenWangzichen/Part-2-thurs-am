using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color originalColor;
    
    // Start is called before the first frame update
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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

}
