using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string moveAxisName = "Horizontal";
    public string rotateAxisName = "Vertical";
    public string fireButtonName = "Fire1";
    public string reloadButtonName = "Reload";

    public Vector2 moveInput { get; private set; }
    public bool fire { get; private set; }
    public bool reload { get; private set; }

    public Camera mainCam;

    public LayerMask whatIsGround;
    public Vector3 mousePos { get; private set; }

    private void Awake()
    {
        mainCam = Camera.main;
    }

    public Action OnFirePressed = null;

    void Update()
    {
        moveInput = new Vector2(Input.GetAxis(moveAxisName), Input.GetAxis(rotateAxisName));
        if (moveInput.sqrMagnitude > 1) moveInput = moveInput.normalized;

        fire = Input.GetButton(fireButtonName);
        reload = Input.GetButtonDown(reloadButtonName);

        if(fire)
        {
            OnFirePressed?.Invoke();
        }
    }

    public bool GetMouseWorldPosition(out Vector3 point)
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        float depth = Camera.main.farClipPlane;

        point = Vector3.zero;
        if (Physics.Raycast(cameraRay, out hit, depth))
        {
            point = hit.point;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(mousePos, 0.5f);
    }
}