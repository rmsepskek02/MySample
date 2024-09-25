using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    #region Varibales
    CharacterController cc;
    [SerializeField] private float moveSpeed = 10f;
    // 중력 가속도
    [SerializeField] private float gravity = -9.81f;
    // 플레이어 속도 - 중력만 적용
    [SerializeField] private Vector3 velocity;
    // 그라운드 체크
    [SerializeField] private bool isGround = false;
    // 점프
    [SerializeField] private float jumpHeight = 1f;

    // 그라운드 체크
    public Transform groundCheck;
    [SerializeField] private float checkRange = 0.2f;
    [SerializeField] private LayerMask groundMask;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(IsGroundCheck());
        if (IsGroundCheck() && velocity.y < 0f)
        {
            velocity.y = -9.81f;
        }
        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);

        Move();
        if (Input.GetKeyDown(KeyCode.Space) && IsGroundCheck())
        {
            Jump();
        }
    }

    private void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector3 moveVector = transform.right * moveX + transform.forward * moveY;
        cc.Move(moveVector * moveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (IsGroundCheck() == false) return;
        velocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
    }

    private bool IsGroundCheck()
    {
        return Physics.CheckSphere(groundCheck.position, checkRange, groundMask);
    }
}


/*
캐릭터 컨트롤
 - 빌트인 Character Controller : Character Controller + Collider 
  = 이동
  = 그라운드 체크
  = 충돌 체크
  = 계산
  = 경사면
    . slope limit   - 오를 수 있는 경사 면의 최대 각도
    . step offset   - 오를 수 있는 계단의 최대 높이
    . skin width    - 충돌이 발생 했을 때 충돌체와의 거리, 충돌체 사이에서 끼임 현상 방지
    . min move distance - 최소한의 이동거리, 값보다 적을 경우 이동하지 않음

 - Rigidbody : 다이나믹
 - Rigidbody : 키네메틱

  
 */