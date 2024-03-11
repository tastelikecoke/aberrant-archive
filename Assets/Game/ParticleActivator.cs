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
        int pulls = PlayerPrefs.GetInt("aberrantarchive.pulls", 0);
        PlayerPrefs.SetInt("aberrantarchive.pulls", pulls+1);
        //psystem.Stop();

        if (pulls >= 20 && pulls % 20 == 1)
        {
            whiteOut.SetTrigger("Begin2");
        }
        else if (Random.Range(0, 1f) > 0.05)
        {
            whiteOut.SetTrigger("Begin");
        }
        else
        {
            whiteOut.SetTrigger("Begin2");
        }
    }
}
