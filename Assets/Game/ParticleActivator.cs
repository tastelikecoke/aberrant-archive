using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleActivator : MonoBehaviour
{
    public ParticleSystem psystem;
    public Animator whiteOut;
    void Activate()
    {
        psystem.Play();
    }
    void AfterActivate()
    {
        psystem.Stop();
        whiteOut.SetTrigger("Begin");

    }
}
