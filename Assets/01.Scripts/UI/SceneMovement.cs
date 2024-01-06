using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMovement : MonoBehaviour
{
    public void SceneMove(int value)
    {
        SceneManager.LoadScene(value);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
