using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float timeLeft = 0.0f;
    public bool timerOn = false;
    public bool gameOver = false;

    public TextMeshProUGUI TimerTxt;
    public GameObject timer;
    public GameObject GameOverPanel;

    void Start()
    {
        timerOn = true;
        timer = GameObject.Find("Timer");
        DontDestroyOnLoad(timer);

    }
    // void Awake() {
    //     DontDestroyOnLoad(timer);
    //     timer = GameObject.Find("Timer");
    // }
    // Update is called once per frame
    void Update()
    {
        if(timerOn){
            if(timeLeft > 0){
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
                //Debug.Log(TimerTxt.text);
            }
            else{
                Debug.Log("Sunset");
                timeLeft = 0;
                timerOn = false;
                gameOver = true;
                showGameOver(false);
            }
        }
    }

    void updateTimer(float currentTime){
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    void showGameOver(bool gameOver){
        GameOverPanel.SetActive(true);
    }
}
