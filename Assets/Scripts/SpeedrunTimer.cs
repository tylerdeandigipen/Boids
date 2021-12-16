using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class SpeedrunTimer : MonoBehaviour
{
    public bool SpeedRunActive;
    float timer = 0;
    public TextMeshProUGUI TimerText;
    Gamemanager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<Gamemanager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SpeedrunTimerUpdate();
        if (gm.currentLevel == 17)
        {
            SpeedRunActive = false;
        }
    }
    public void StartStopTimer()
    {
        if (SpeedRunActive == true)
        {
            SpeedRunActive = false;
        }
        else
            SpeedRunActive = true;
        timer = 0f;
    }
    void SpeedrunTimerUpdate()
    {
        if (SpeedRunActive == true)
        {
            timer += Time.deltaTime;
            timer = Mathf.Round(timer * 100f) / 100f;
            TimerText.text = timer.ToString();
        }
    }
    public void HideTimer()
    {
        this.gameObject.SetActive(false);
    }

}
