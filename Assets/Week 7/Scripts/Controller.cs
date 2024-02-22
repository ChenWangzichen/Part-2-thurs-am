using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    public Slider chargeSlider;
    float chargeValue;
    public float chargeMax = 1;
    Vector2 direction;

    public static int score;
    public TextMeshProUGUI scoreText;
    
    public static Player selectedPlayer { get; private set; }

    public static void SetSelectedPlayer(Player player)
    {
        if (selectedPlayer != null)
        {
            selectedPlayer.Selected(false);
        }
        selectedPlayer = player;
        selectedPlayer.Selected(true);
    }
    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            selectedPlayer.Move(direction);
            direction = Vector2.zero;
            chargeValue = 0;
            chargeSlider.value = chargeValue;
        }
    }

    private void Update()
    {
        if (selectedPlayer == null) return;

        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            chargeValue = 0;
            direction = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            chargeValue += Time.deltaTime;
            chargeValue = Mathf.Clamp(chargeValue, 0, chargeMax);
            chargeSlider.value = chargeValue;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)selectedPlayer.transform.position).normalized * chargeValue;
        }

        scoreText.text = score.ToString();
    }
}
