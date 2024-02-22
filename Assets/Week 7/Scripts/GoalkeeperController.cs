using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{
    public Rigidbody2D rbGoalkeeper;
    float offGoalLine = 3;
    public Transform goalCenter;
    Vector2 position;
    Player selectedPlayer;
    Vector2 distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        selectedPlayer = Controller.selectedPlayer;
        if (selectedPlayer == null) return;
        distance = selectedPlayer.transform.position - goalCenter.position;
        if (distance.magnitude >= offGoalLine*2) 
        {
            position = (Vector2)goalCenter.position + distance.normalized*offGoalLine;
        }
        else
        {
            position = (goalCenter.position + selectedPlayer.transform.position) / 2;
        }


        rbGoalkeeper.MovePosition(position);
    }
    
 


}
