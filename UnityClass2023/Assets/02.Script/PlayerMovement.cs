using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private PlayerInput playerInput;
    private Animator animator;

    private Camera followCam;

    public float targetSpeed = 6f;
    public float rotateSpeed = 4f;

    public float currentSpeed => new Vector2(characterController.velocity.x, characterController.velocity.z).magnitude;

    void Start()
    {
        //컴포넌트 가져오기
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        followCam = Camera.main;
    }

    private void FixedUpdate()
    {
        if (currentSpeed > 0.2f) Rotate();
        Move(playerInput.moveInput);
    }

    void Update()
    {
        UpdateAnimation(playerInput.moveInput);
    }

    public void Move(Vector2 moveInput)
    {
        //방향
        var moveDirection = Vector3.Normalize(transform.forward * moveInput.y + transform.right * moveInput.x);

        var velocity = moveDirection * targetSpeed;
        characterController.Move(velocity * Time.deltaTime);
    }

    public void Rotate()
    {
        /*var targetRatation = followCam.transform.eulerAngles.y;
        transform.eulerAngles = Vector3.up * targetRatation;*/

        Vector3 target = playerInput.mousePos;
        target.y = 0;
          
        Vector3 v = target - transform.position;

        float degree = Mathf.Atan2(v.x, v.z) * Mathf.Rad2Deg;
        float rot = Mathf.LerpAngle(transform.eulerAngles.y, degree, Time.deltaTime * rotateSpeed);

        transform.eulerAngles = new Vector3(0, rot, 0);
    }

    public void SetRotation()
    {
        //var targetRotation = followCam.transform.eulerAngles.y;
        //transform.eulerAngles = Vector3.up * targetRotation;

        Vector3 target;
        bool isHit = playerInput.GetMouseWorldPosition(out target);

        if (isHit)
        {
            Vector3 dir = target - transform.position;
            dir.y = 0;
            transform.rotation = Quaternion.LookRotation(dir.normalized);
        }
    }

    private void UpdateAnimation(Vector2 moveInput)
    {
        animator.SetFloat("Vertical Move", moveInput.y);
        animator.SetFloat("Horizontal Move", moveInput.x);
    }
}