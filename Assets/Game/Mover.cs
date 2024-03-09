using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Animator animator;
    public Camera cam;
    public Transform model;
    private Vector3 cameraOffset;
    // Start is called before the first frame update
    void Awake()
    {
        cameraOffset = cam.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = cameraOffset + model.position;
        if(Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("Run", true);
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("Run", false);
        }
        if(Input.GetKey(KeyCode.A))
        {
            model.rotation = model.rotation * Quaternion.Euler(0,-1f, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            model.rotation = model.rotation * Quaternion.Euler(0,1f, 0);
        }
    }
}
