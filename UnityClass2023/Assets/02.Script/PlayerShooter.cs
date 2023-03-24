using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Gun gun;
    private PlayerInput playerInput;
    private PlayerMovement playerMovement;



    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();

        playerInput.OnFirePressed += FireButtonHandle;   
    }

    private void FireButtonHandle()
    {
        playerMovement.SetRotation();
        gun.Fire();

    }

    private void Update()
    {
        if (playerInput.reload)
        {
            gun.Reload();
        }
    }
}
