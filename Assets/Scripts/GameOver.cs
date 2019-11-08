using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Restart GO2");
        loadScene(0);
    }

    private void loadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}