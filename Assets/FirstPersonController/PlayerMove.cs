using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class PlayerMove : MonoBehaviour
    {
        #region Variables
        //ĳ���� ��Ʈ�ѷ�
        private CharacterController controller;

        //�̵� �ӵ�
        [SerializeField] private float moveSpeed = 10f;

        //�߷� ���ӵ�
        [SerializeField] private float gravity = -9.81f;
        //�÷��̾��� �ӵ� - �߷¸� ����
        [SerializeField] private Vector3 velocity;
        //�׶��� üũ
        [SerializeField] private bool isGround = false;

        //����
        [SerializeField] private float jumpHeight = 1f;
        #endregion

        private void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            //�׶��� üũ
            isGround = controller.isGrounded;
            if(isGround && velocity.y < 0f)
            {
                velocity.y = 0f;
            }

            //�̵�
            Move();

            //����
            if(Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                Jump();
            }

            //�߷� ���ӵ�
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        private void Move()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            Vector3 move = transform.right * moveX + transform.forward * moveY;

            controller.Move(move * Time.deltaTime * moveSpeed);
        }

        private void Jump()
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}

/*
ĳ���� ��Ʈ�� : �̵� + �浹 üũ

- ��Ʈ�� Character Cotroller :  Character Cotroller + Collider
. �̵�
. �׶��� üũ
. �浹 üũ
. ���
. ����

- Rigidbody : ���̳���
- Rigidbody : Ű�׸�ƽ




*/