using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentRandomizer : MonoBehaviour
{
    public float chanceOfExistence = 0f;
    public float chanceOfHole = 0f;

    public GameObject[] listOfRandomizables;
    public GameObject holeable;

    public void Randomize()
    {
        for (int i = 0; i < listOfRandomizables.Length; i++)
        {
            listOfRandomizables[i].SetActive(chanceOfExistence > Random.Range(0f, 1f));
        }
        holeable.SetActive(chanceOfHole < Random.Range(0f, 1f));
    }
}
