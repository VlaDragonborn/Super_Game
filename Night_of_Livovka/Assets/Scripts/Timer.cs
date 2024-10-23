using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;

    public int min = 1;
    public int sec = 30;
    
    [SerializeField] GameObject imGameOver;

    private float gameTime;

    void Update()
    {   
        if ((min > 0) || (sec > 0))
        {
        
            if ((sec > 9) && (min < 10))
            {
                timer.text = "Осталось времени:    0" + min + ":" + sec;
            }
            else if ((sec < 10) && (min > 9)) 
            {
                timer.text = "Осталось времени:    " + min + ":0" + sec;
            }
            else if ((sec < 10) && (min < 10)) 
            {
                timer.text = "Осталось времени:    0" + min + ":0" + sec;
            }
            else 
            {
                timer.text = "Осталось времени:    " + min + ":" + sec;
            }
            
            gameTime += 1 * Time.deltaTime;

            if (gameTime >= 1) 
            {
                if (sec > 0) 
                {
                    sec -= 1;
                }
                else if ((min > 0) && (sec == 0))
                {
                    sec += 59;
                    min -= 1;
                }
                gameTime = 0;
            }
        }
        else
        {
            if (imGameOver)
            {
                imGameOver.SetActive(true);
            }
        }
    }
}
