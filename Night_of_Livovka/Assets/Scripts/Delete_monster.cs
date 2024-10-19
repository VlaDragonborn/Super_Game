using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_monster : MonoBehaviour
{
    public float TimeLive = 0.3f;
    private float RespawnTime = 0;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RespawnTime += Time.deltaTime;
        if (RespawnTime >= TimeLive){
            Destroy(gameObject);
        }
    }
}
