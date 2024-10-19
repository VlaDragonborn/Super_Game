using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject monstr;
    public GameObject scream;

    private bool OneExit = true;
    void Awake()
    {
        monstr.SetActive(false);
        scream.SetActive(false);
    }

    
    void Update()
    {     
    }

    void OnTriggerEnter () {
        if (OneExit) {
            monstr.SetActive(true);
            scream.SetActive(true);
            OneExit = false;
        }
    }
}
