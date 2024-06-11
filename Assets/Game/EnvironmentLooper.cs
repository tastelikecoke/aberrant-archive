using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentLooper : MonoBehaviour
{
    public GameObject player;
    public GameObject baseUnit;
    
    [NonSerialized]
    public List<GameObject> units;
    [NonSerialized]
    public List<GameObject> unused;
    
    public float unitIncrement = 5f;
    public float maxDistToSpawnGround = 20f;

    public string seed = "Seed";

    private void Start()
    {
        units = new List<GameObject>();
        unused = new List<GameObject>();
        var firstUnit = Instantiate(baseUnit, this.transform);
        firstUnit.SetActive(true);
        units.Add(firstUnit);
    }
    private void Update()
    {
        if (units.Count > 0)
        {
            if (player.transform.position.x + maxDistToSpawnGround > units[^1].transform.position.x)
            {
                GameObject nextUnit = null;
                if (unused.Count > 0)
                {
                    nextUnit = unused[0];
                    unused.RemoveAt(0);
                }
                else
                {
                    nextUnit = Instantiate(baseUnit, this.transform);
                }

                var nextPosition = units[^1].transform.position;
                nextPosition.x += unitIncrement;
                nextUnit.transform.position = nextPosition;
                nextUnit.SetActive(true);
                units.Add(nextUnit);
            }

            if (player.transform.position.x - maxDistToSpawnGround < units[0].transform.position.x)
            {
                GameObject nextUnit = null;
                if (unused.Count > 0)
                {
                    nextUnit = unused[0];
                    unused.RemoveAt(0);
                }
                else
                {
                    nextUnit = Instantiate(baseUnit, this.transform);
                }

                var nextPosition = units[0].transform.position;
                nextPosition.x -= unitIncrement;
                nextUnit.transform.position = nextPosition;
                nextUnit.SetActive(true);
                units.Insert(0, nextUnit);
            }
            
            if (player.transform.position.x - maxDistToSpawnGround*2 > units[0].transform.position.x)
            {
                units[0].SetActive(false);
                unused.Add(units[0]);
                units.RemoveAt(0);
            }
            if (player.transform.position.x + maxDistToSpawnGround*2 < units[^1].transform.position.x)
            {
                units[^1].SetActive(false);
                unused.Add(units[^1]);
                units.RemoveAt(units.Count - 1);
            }
        }

    }
}
