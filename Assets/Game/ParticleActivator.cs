using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleActivator : MonoBehaviour
{
    public ParticleSystem psystem;
    public Animator whiteOut;
    public AudioSource gachaSound;
    void Activate()
    {
        psystem.Play();
    }
    void GachaSound()
    {
        gachaSound.Play();
    }
    void AfterActivate()
    {
        //psystem.Stop();
        whiteOut.SetTrigger("Begin");

    }
}
