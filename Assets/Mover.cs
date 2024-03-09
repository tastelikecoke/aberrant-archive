using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Animator>().SetBool("Run", true);
            
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            GetComponent<Animator>().SetBool("Run", false);
            
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.rotation = transform.rotation * Quaternion.Euler(0,-1f, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.rotation = transform.rotation * Quaternion.Euler(0,1f, 0);
        }
    }
}
