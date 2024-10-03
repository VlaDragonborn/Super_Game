using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float speed = 4.0f; // скорость персонажа
    public float gravitation = 20.0f; // гравитация

    private Vector3 moveDir = Vector3.zero; // при старте персонаж никуда не двигается
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
