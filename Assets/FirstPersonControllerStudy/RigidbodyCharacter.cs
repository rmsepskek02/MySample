using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyCharacter : MonoBehaviour
{
    private Vector3 inputDirection = Vector3.zero;
    private Rigidbody rigidbody;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpHeight = 1f;
    [SerializeField] private bool isGround = false;
    public Transform groundCheck;
    [SerializeField] private float checkRange = 0.2f;
    [SerializeField] private LayerMask groundMask;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isGround = IsGroundCheckRay();
        // 涝仿贸府   
        inputDirection = Vector3.zero;
        inputDirection.x = Input.GetAxis("Horizontal");
        inputDirection.z = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();    
        }
    }

    private void FixedUpdate()
    {
        // 捞悼贸府
        Move();
    }
    private void Jump()
    {
        rigidbody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * (-2f) * Physics.gravity.y), ForceMode.VelocityChange);
    }
    private void Move()
    {
        Vector3 newPosition = transform.position + transform.TransformDirection(inputDirection * Time.deltaTime * moveSpeed);
        rigidbody.MovePosition(newPosition);
    }
    private bool IsGroundCheck()
    {
        return Physics.CheckSphere(groundCheck.position, checkRange, groundMask);
    }

    private bool IsGroundCheckRay()
    {
        RaycastHit hitInfo;
#if UNITY_EDITOR
        Debug.DrawLine(groundCheck.position + (Vector3.up * 0.1f), groundCheck.position + (Vector3.up * 0.3f),Color.red);
#endif
        if (Physics.Raycast(groundCheck.position + (Vector3.up *0.1f),Vector3.down, out hitInfo, checkRange, groundMask))
        {
            return true;
        }
        else
        {

            return false;
        }
    }
}
