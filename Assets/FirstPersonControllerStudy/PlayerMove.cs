using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    #region Varibales
    CharacterController cc;
    [SerializeField] private float moveSpeed = 10f;
    // �߷� ���ӵ�
    [SerializeField] private float gravity = -9.81f;
    // �÷��̾� �ӵ� - �߷¸� ����
    [SerializeField] private Vector3 velocity;
    // �׶��� üũ
    [SerializeField] private bool isGround = false;
    // ����
    [SerializeField] private float jumpHeight = 1f;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGround = cc.isGrounded;
        if (isGround && velocity.y < 0f)
        {
            velocity.y = -9.81f;
        }
        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);

        Move();
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
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
        velocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
    }
}


/*
ĳ���� ��Ʈ��
 - ��Ʈ�� Character Controller : Character Controller + Collider 
  = �̵�
  = �׶��� üũ
  = �浹 üũ
  = ���
  = ����
    . slope limit   - ���� �� �ִ� ��� ���� �ִ� ����
    . step offset   - ���� �� �ִ� ����� �ִ� ����
    . skin width    - �浹�� �߻� ���� �� �浹ü���� �Ÿ�, �浹ü ���̿��� ���� ���� ����
    . min move distance - �ּ����� �̵��Ÿ�, ������ ���� ��� �̵����� ����

 - Rigidbody : ���̳���
 - Rigidbody : Ű�׸�ƽ

  
 */