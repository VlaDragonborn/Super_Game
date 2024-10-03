
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/MouseLook")]

public class MovingCamera : MonoBehaviour
{
    public enum RotationAxes {MouseXandY = 0, MouseX = 1, MouseY = 1}; //��������� ���� ��������
    public RotationAxes axes = RotationAxes.MouseXandY;
    
    public float sensX = 2f; //���������������� ����
    public float sensY = 2f;

    public float minX = -360f; //������� �������� ������
    public float maxX = 360f;
    public float minY = -360f;
    public float maxY = 360f;

    float rotationX = 0f; //������� ���� ��������
    float rotationY = 0f;

    Quaternion originalRotation; //���� ������ ���������

    void Start()
    {
        if(GetComponent<Rigidbody>()) {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
        originalRotation = transform.localRotation;
    }


    public static float ClampAngle(float angle, float min, float max)
    {
        if(angle < -360f) angle += 360f;
        if(angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }

    // Update is called once per frame
    void Update()
    {
        if(axes == RotationAxes.MouseXandY){
            rotationX += Input.GetAxis("Mouse X") * sensX;
            rotationY += Input.GetAxis("Mouse Y") * sensY;

            rotationX = ClampAngle(rotationX, minX, maxX);
            rotationY = ClampAngle(rotationY, minY, maxY);

            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);

            transform.localRotation = originalRotation * xQuaternion * yQuaternion;
        }
        else if(axes == RotationAxes.MouseX){
            rotationX += Input.GetAxis("Mouse X") * sensX;
            rotationX = ClampAngle(rotationX, minX, maxX);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation = originalRotation * xQuaternion;
        }
        else if(axes == RotationAxes.MouseY){
            rotationY += Input.GetAxis("Mouse Y") * sensY;
            rotationY = ClampAngle(rotationY, minY, maxY);
            Quaternion yQuaternion = Quaternion.AngleAxis(-rotationY, Vector3.right);
            transform.localRotation = originalRotation * yQuaternion;
        }
    }
}
