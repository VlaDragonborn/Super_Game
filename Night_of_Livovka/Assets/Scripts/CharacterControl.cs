using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float speed = 4.0f; // �������� ���������
    public float gravitation = 20.0f; // ����������

    private Vector3 moveDir = Vector3.zero; // ��� ������ �������� ������ �� ���������
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        if (controller.isGrounded) {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;
        }

        moveDir.y -= gravitation * Time.deltaTime;

        controller.Move(moveDir * Time.deltaTime);
    }
}
