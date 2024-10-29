using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    //Movements
    [SerializeField] float forwardMaximumSpeed, strafeSpeed;
    Vector3 inputDir;
    float currentVelocity;
    float smoothTime = 0.05f;

    Collider[] result = new Collider[10];
    [SerializeField] LayerMask _ground;

    [SerializeField] Animator animator;

    [SerializeField] GameObject cam;


    //Jump Variables
    public float jumpForce = 4;


    void Start()
    {

    }

    void Update()
    {
        inputDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        inputDir.Normalize();

        UpdateAnimations();

        Jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    void UpdateAnimations()
    {
        animator.SetFloat("ForwardDir", inputDir.z); 
        animator.SetFloat("StrafeDir", inputDir.x);
    }

    void Move()
    {
        Vector3 forwardDir = transform.forward * inputDir.z;
        forwardDir.Normalize();
        forwardDir *= forwardMaximumSpeed; //equivaut à forwardDir = forwardDir * forwardSpeed;

        Vector3 strafeDir = Vector3.Cross(Vector3.up, transform.forward) * inputDir.x;
        strafeDir.Normalize();
        strafeDir *= strafeSpeed;

        Vector3 moveDir = forwardDir + strafeDir;

        rb.MovePosition(transform.position + (moveDir * Time.deltaTime));

        float targetRotation = cam.transform.eulerAngles.y;
        smoothTime = inputDir.z != 0 ? 0.1f : 0.5f;
        float playerAnglesDamp = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref currentVelocity, smoothTime);
        if (!Input.GetMouseButton(0)) transform.rotation = Quaternion.Euler(0, playerAnglesDamp, 0);
    }

    void Jump()
    {
        int count = Physics.OverlapSphereNonAlloc(transform.position, 0.2f, result, _ground);

        if (Input.GetButtonDown("Jump") && count > 0)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

}
