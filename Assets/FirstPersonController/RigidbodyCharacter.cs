using UnityEngine;

namespace MySample
{
    public class RigidbodyCharacter : MonoBehaviour
    {
        #region Variables
        private Rigidbody rigidbody;

        //입력값
        private Vector3 inputDirection = Vector3.zero;

        //이동속도
        [SerializeField] private float moveSpeed = 10f;

        //점프
        [SerializeField] private float jumpHeight = 1f;

        //그라운드 체크
        [SerializeField] private bool isGround = false;
        public Transform groundCheck;
        [SerializeField] private float checkRange = 0.2f;
        [SerializeField] private LayerMask groundMask;
        #endregion

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            //그라운드 체크
            isGround = IsGroundCheckRay();

            //move 입력 처리
            inputDirection = Vector3.zero;
            inputDirection.x = Input.GetAxis("Horizontal");
            inputDirection.z = Input.GetAxis("Vertical");

            //jump 입력 처리
            if(Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                Jump();
            }

        }

        private void FixedUpdate()
        {
            //이동 처리
            Move();
        }

        private void Move()
        {
            Vector3 newPosition = transform.position + transform.TransformDirection(inputDirection * Time.deltaTime * moveSpeed);
            rigidbody.MovePosition(newPosition);
        }

        private void Jump()
        {
            rigidbody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * (-2f) * Physics.gravity.y), ForceMode.VelocityChange);
        }

        private bool IsGroundCheck()
        {
            return Physics.CheckSphere(groundCheck.position, checkRange, groundMask);
        }

        private bool IsGroundCheckRay()
        {
            RaycastHit hitInfo;

#if UNITY_EDITOR
            Debug.DrawLine(groundCheck.position + (Vector3.up * 0.1f), groundCheck.position + (Vector3.up * 0.1f) + (Vector3.down * checkRange));
#endif

            if(Physics.Raycast(groundCheck.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo,
                checkRange, groundMask))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
