using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lerpSmooth;
    [SerializeField] private Camera mainCamera;

    public Vector3 difference;
    public bool canMove = true;
    public Rigidbody rb;

    private Vector3 firstPos;
    private Vector3 lastPos;

    private float one = 1f;
    private float halfOne = 0.5f;
    private bool isMoving = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        GetInput();
    }
    private void FixedUpdate()
    {
        Movement(difference);
    }
    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        }
        if (Input.GetMouseButton(0))
        {
            lastPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            difference = lastPos - firstPos;
            //to kept difference.x between -0.5 and 0.5
            difference.Normalize();
        }
    }
    private void Movement(Vector3 difference)
    {
        if (canMove)
        {
            IsVelocityZero();

            if (difference.y > 0 && difference.x > -halfOne && difference.x < halfOne && isMoving)
            {
                rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX |
                    RigidbodyConstraints.FreezePositionY;
                rb.velocity = new Vector3(0, 0, one * speed);
            }
            if (difference.y < 0 && difference.x > -halfOne && difference.x < halfOne && isMoving)
            {
                rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX |
                    RigidbodyConstraints.FreezePositionY;
                rb.velocity = new Vector3(0, 0, -one * speed);
            }
            if (difference.x > 0 && difference.y > -halfOne && difference.y < halfOne && isMoving)
            {
                rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ |
                    RigidbodyConstraints.FreezePositionY;
                rb.velocity = new Vector3(one * speed, 0, 0);
            }
            if (difference.x < 0 && difference.y > -halfOne && difference.y < halfOne && isMoving)
            {
                rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ |
                    RigidbodyConstraints.FreezePositionY;
                rb.velocity = new Vector3(-one * speed, 0, 0);
            }
        } 
    }
    private bool IsVelocityZero()
    {
        if(rb.velocity == Vector3.zero)
        {
            return isMoving = true;
        }
        return isMoving = false;
    }  
}
