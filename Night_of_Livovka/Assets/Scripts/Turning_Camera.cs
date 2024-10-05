using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning_Camera : MonoBehaviour
{
    public float mouseSens = 100f; //чувствительность мыши
    
    public Transform playerBody; //ссылка на объект персонажа

    float xRotation = 0f; //поворот вокруг оси у


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //блокировка курсора
    }

    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime; //положение курсора
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f); //определение угла по оси у с ограничением подъема головы

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //поворот камеры вокруг оси х
        playerBody.Rotate(Vector3.up * mouseX); //поворот всего персонажа вокруг оси у
    }
}
