using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
   public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(0);
    }
}
