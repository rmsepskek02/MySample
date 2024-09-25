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

        // 카메라는 위아래 회전 (X축 회전)

        float mouseY = Input.GetAxis("Mouse Y") * sensivity;
        rotateX -= mouseY * Time.deltaTime;  // 마우스 위아래 반전
        rotateX = Mathf.Clamp(rotateX, minX, maxX); // 각도 제한
        transform.localRotation = Quaternion.Euler(rotateX, 0f, 0f);
    }
}
