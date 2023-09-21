using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 100f;

    private CharacterController controller;
    private Camera playerCamera;
    private float xRotation = 0f;


    public float Speed = 12f;
    public float Gravity = 20f;
    private Vector3 m_Velocity;

    public float GroundDistance;
    public LayerMask GroundMask;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        if (!MainGame.Instance.isWalking)
            return;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;


       bool m_IsGrounded = Physics.CheckSphere(this.transform.position, GroundDistance, GroundMask);//检测体m_groundcheck与layerMask层接触后则返回一个true
        if (m_IsGrounded && m_Velocity.y < 0)
        {
            m_Velocity.y = -2;
        }
        m_Velocity.y -= Time.deltaTime * Gravity;

        controller.Move(m_Velocity * Time.deltaTime);


        controller.Move(move * moveSpeed * Time.deltaTime);
    }
}
