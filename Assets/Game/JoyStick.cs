using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private Camera _camera;

    private bool trackMovement = false;
    public Transform model;
    public Animator animator;
    public void OnPointerDown(PointerEventData eventData)
    {
        trackMovement = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        trackMovement = false;
    }
    public void Update()
    {
        if (!trackMovement)
        {
            
            animator.SetBool("Run", false);
            return;
        }
        
        Vector3 buttonPos = _camera.WorldToScreenPoint(transform.position);
        Vector3 offset =  buttonPos - Input.mousePosition;
        offset.z = offset.y;
        offset.y = 0f;
        offset.z = -offset.z;

        Quaternion direction = Quaternion.FromToRotation(offset, Vector3.forward) * Quaternion.AngleAxis(30, Vector3.up);
        model.rotation = direction;
        animator.SetBool("Run", true);
    }
}
