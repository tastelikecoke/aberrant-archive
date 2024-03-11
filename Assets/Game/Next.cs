using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public AudioSource beep;
    public void NextThing()
    {
        beep.Play();
    }
    public void NextScene1()
    {
        SceneManager.LoadScene("Dialogue");
    }
}
