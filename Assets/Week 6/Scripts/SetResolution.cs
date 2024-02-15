using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResolution : MonoBehaviour
{
    public void sixN()
    {
        Screen.SetResolution(1600, 900, false);
    }

    public void FullHD()
    {
        Screen.SetResolution(1920,1080, false);
    } 
}
