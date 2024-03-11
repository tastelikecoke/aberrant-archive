using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Okay : MonoBehaviour
{
    public void Ok()
    {
        SceneManager.LoadScene("Splash");
    }

    public void Error()
    {
        
        SceneManager.LoadScene("NetworkCheck");
    }
}
