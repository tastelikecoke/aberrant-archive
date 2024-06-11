using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentLooper : MonoBehaviour
{
    public GameObject player;
    public GameObject baseUnit;
    public List<GameObject> units;

    private void Start()
    {
        units = new List<GameObject>();
        var firstUnit = Instantiate(baseUnit, this.transform);
        firstUnit.SetActive(true);
        units.Add(firstUnit);
    }
    private void Update()
    {
        if (units.Count > 0)
        {
            if ((units[^1].transform.position.x - player.transform.position.x) < 20f)
            {
                GameObject nextUnit = null;
                if (!units[0].activeSelf)
                {
                    nextUnit = units[0];
                    units.RemoveAt(0);
                }
                else
                {
                    nextUnit = Instantiate(baseUnit, this.transform);
                }
                var nextPosition = units[^1].transform.position;
                nextPosition.x += 5f;
                nextUnit.transform.position = nextPosition;
                nextUnit.SetActive(true);
                units.Add(nextUnit);
            }
            if ((units[^1].transform.position.x - player.transform.position.x) < 9f)
            {
                var nextUnit = Instantiate(baseUnit, this.transform);
                var nextPosition = units[^1].transform.position;
                nextPosition.x += 5f;
                nextUnit.transform.position = nextPosition;
                nextUnit.SetActive(true);
                units.Add(nextUnit);
            }

            if ((units[0].transform.position.x - player.transform.position.x) > 80f)
            {
                units[0].SetActive(false);
            }
        }
    }
}
