using UnityEngine;

namespace MySample
{
    public class MouseLook : MonoBehaviour
    {
        #region Variables
        public Transform player;

        //���콺 ������ ������
        [SerializeField] private float sensivity = 100f;

        //
        [SerializeField] private float maxX = 20f;
        [SerializeField] private float minX = -90f;
        private float rotateX = 0f;                     //ī�޶� x�� ȸ����
        #endregion

        private void Start()
        {
            //���콺 Ŀ��
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            //�¿� �Է� �޾� �÷��̾ �¿�� ȸ��
            float mouseX = Input.GetAxis("Mouse X") * sensivity;
            player.Rotate(Vector3.up * Time.deltaTime * mouseX);

            //���Ʒ� �Է� �޾� ī�޶� ���Ʒ� ȸ��
            float mouseY = Input.GetAxis("Mouse Y") * sensivity;
            //ī�޶� ȸ��
            rotateX -= mouseY * Time.deltaTime;
            rotateX = Mathf.Clamp(rotateX, minX, maxX);
            this.transform.localRotation = Quaternion.Euler(rotateX, 0f, 0f);
        }

    }
}