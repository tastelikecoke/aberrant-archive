using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private bool doingForwardMovement = false;

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = cameraOffset + model.position;
        if(Input.GetKeyDown(KeyCode.W))
        {
            doingForwardMovement = true;
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            doingForwardMovement = false;
        }

        if (doingForwardMovement)
        {
            animator.SetBool("Run", true);
        }
        
        if(Input.GetKey(KeyCode.A))
        {
            model.rotation = model.rotation * Quaternion.Euler(0,-1f, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            model.rotation = model.rotation * Quaternion.Euler(0,1f, 0);
        }

        if (model.position.y < -50f)
        {
            SceneManager.LoadScene("Gacha");
        }
    }
}
