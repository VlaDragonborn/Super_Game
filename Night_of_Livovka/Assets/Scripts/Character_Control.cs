using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Control : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10f;
    public float gravity = -9.81f;

    public Transform groundCheck; //проверка, что персонаж находится на земле
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){  //сбрасывает скорость падения, если перс на земле
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal"); //считывает координаты персонажа
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right  * x + transform.forward * z; //направление движения с учетом поворота камеры

        controller.Move(move * speed * Time.deltaTime); //перемещение WASD

        velocity.y += gravity * Time.deltaTime; // гравитация 

        controller.Move(velocity * Time.deltaTime); //падение персонажа
    }
}
