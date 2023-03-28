using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Gun gun;
    private PlayerInput playerInput;
    private PlayerMovement playerMovement;

    private Animator playerAnimator;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();

        playerInput.OnFirePressed += FireButtonHandle;   
        playerAnimator = GetComponent<Animator>();
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
            if (gun.Reload())
            {
                playerAnimator.SetTrigger("Reload");
            }
            //gun.Reload();
        }
    }
}
