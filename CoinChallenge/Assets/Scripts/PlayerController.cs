using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    //Movements
    [SerializeField] float forwardMaximumSpeed, strafeSpeed;
    Vector3 inputDir;
    float currentVelocity;
    float smoothTime = 0.05f;

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
        float playerAnglesDamp = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0, playerAnglesDamp, 0);
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        bool grounded = Physics.SphereCast(ray, 0.3f, 0.3f);
        Debug.Log(grounded);
        
        //Debug.DrawRay(transform.position + Vector3.up * 0.05f, Vector3.down, Color.red, 0.1f);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            Debug.Log("Player is jumping");
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }


    }

}
