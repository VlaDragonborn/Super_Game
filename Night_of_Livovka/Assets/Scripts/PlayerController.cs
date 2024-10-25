using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumping;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            transform.Translate(Vector3.forward * 0);
            transform.Translate(Vector3.right * 0);
        }
    }
}
