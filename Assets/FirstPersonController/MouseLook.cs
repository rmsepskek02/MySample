using UnityEngine;

namespace MySample
{
    public class MouseLook : MonoBehaviour
    {
        #region Variables
        public Transform player;

        //마우스 움직임 보정값
        [SerializeField] private float sensivity = 100f;

        //
        [SerializeField] private float maxX = 20f;
        [SerializeField] private float minX = -90f;
        private float rotateX = 0f;                     //카메라 x축 회전값
        #endregion

        private void Start()
        {
            //마우스 커서
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            //좌우 입력 받아 플레이어를 좌우로 회전
            float mouseX = Input.GetAxis("Mouse X") * sensivity;
            player.Rotate(Vector3.up * Time.deltaTime * mouseX);

            //위아래 입력 받아 카메라를 위아래 회전
            float mouseY = Input.GetAxis("Mouse Y") * sensivity;
            //카메라 회전
            rotateX -= mouseY * Time.deltaTime;
            rotateX = Mathf.Clamp(rotateX, minX, maxX);
            this.transform.localRotation = Quaternion.Euler(rotateX, 0f, 0f);
        }

    }
}