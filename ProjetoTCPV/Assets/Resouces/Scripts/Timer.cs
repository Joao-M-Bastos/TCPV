using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    int feverCounter;

    [SerializeField] SimplePlayer simplePlayer;
    [SerializeField] Text feverCounterTXT;

    TimerSoundEffects timerSoundEffects;

    bool isCountingTimer;
    bool intervaloTocado;

    float tempoInicial;

    float tempoAtual;

    [SerializeField] float tempoIntervalo;

    public int intervaloAtual;

    private void Awake()
    {
        timerSoundEffects = this.gameObject.GetComponent<TimerSoundEffects>();
    }

    private void Start()
    {
        StartTimer();
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Quit();

        if (isCountingTimer)
            RunningTime();
        else
            StopedTime();
    }

    private void StartTimer()
    {
        isCountingTimer = true;
        tempoInicial = Time.time;
        tempoAtual = tempoInicial;
        intervaloAtual = 0;
        intervaloTocado = true;
    }

    public void RunningTime()
    {
        tempoAtual += Time.deltaTime;
        if (tempoAtual >= (tempoInicial + (tempoIntervalo * intervaloAtual)))
        {
            if (intervaloTocado)
            {
                intervaloAtual += 1;
                intervaloTocado = false;
                timerSoundEffects.PlayCompass(tempoIntervalo/2);
            }
            else
                StopTime(false);
        }
        if (intervaloAtual >= 5)
        {
            StopTime(true);
        }
    }

    private void StopedTime()
    {
        if (!timerSoundEffects.IsCorrectPlaying() && !timerSoundEffects.IsWrongPlaying())
            StartTimer();
    }

    public void StopTime(bool v)
    {
        if (v)
        {
            feverCounter++;
            timerSoundEffects.PlayCorrect();
        }
        else
        {
            feverCounter = 0;
            timerSoundEffects.PlayWrong();
        }

        feverCounterTXT.text = "Combos: " + feverCounter;

        isCountingTimer = false;
    }

    public void CorrectInput(int actionCode)
    {

        if (IsInTimer())
        {
            intervaloTocado = true;
            DoPlayerAction(actionCode);
        }
        else
            StopTime(false);
    }

    private void DoPlayerAction(int actionCode)
    {
        simplePlayer.DoActionBasedOnCode(actionCode);
    }

    public bool IsInTimer()
    {
        return !intervaloTocado;
    }
}
