using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController; 
    private PlayerInput playerInput; 
    private Animator animator; 

    private Camera followCam; 

    public float targetSpeed = 6f;

   public float currentSpeed => new Vector2(characterController.velocity.x, characterController.velocity.z).magnitude;



    // Start is called before the first frame update
    void Start()
    {
        //컴포넌트 가져오기
 

    }

    private void FixedUpdate() 
    {
       
    }


    // Update is called once per frame
    void Update()
    {
     
    }

    public void Move(Vector2 moveInput)
    {


    }

    public void Rotate()
    {
        
    }

     private void UpdateAnimation(Vector2 moveInput)
    {
        
    }

}
