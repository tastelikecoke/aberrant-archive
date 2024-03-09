using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleActivator : MonoBehaviour
{
    public ParticleSystem psystem;
    void Activate()
    {
        psystem.Play();
    }
}
