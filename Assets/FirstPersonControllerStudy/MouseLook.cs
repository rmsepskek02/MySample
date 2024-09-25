using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MouseLook : MonoBehaviour
{
    #region Variables
    public Transform player;
    [SerializeField] private float sensivity = 100f;
    [SerializeField] private float maxX = 20f;
    [SerializeField] private float minX = -90f;
    private float rotateX = 0f;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensivity;
        player.Rotate(Vector3.up * mouseX * Time.deltaTime);

        // ī�޶�� ���Ʒ� ȸ�� (X�� ȸ��)

        float mouseY = Input.GetAxis("Mouse Y") * sensivity;
        rotateX -= mouseY * Time.deltaTime;  // ���콺 ���Ʒ� ����
        rotateX = Mathf.Clamp(rotateX, minX, maxX); // ���� ����
        transform.localRotation = Quaternion.Euler(rotateX, 0f, 0f);
    }
}
