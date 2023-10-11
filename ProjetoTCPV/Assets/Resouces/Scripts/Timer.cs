using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    int feverCounter;

    [SerializeField] SimplePlayer simplePlayer;
    [SerializeField] ManagerScrpt gameManager;
    [SerializeField] Text feverCounterTXT;

    TimerSoundEffects timerSoundEffects;

    [SerializeField] Animator BorderAnimator;

    bool isCountingTimer;
    bool intervaloTocado;


    float tempoInicial;

    float tempoAtual;

    
    float tempoIntervalo;

    public int intervaloAtual;

    private void Awake()
    {
        tempoIntervalo = 1 / (gameManager.GetBPM() / 60);
        timerSoundEffects = this.gameObject.GetComponent<TimerSoundEffects>();
        BorderAnimator.SetFloat("BPM", gameManager.GetBPM() / 60);
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
        simplePlayer.ResetMarchar();
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
            simplePlayer.PlayMarchAnimation();
            BorderAnimator.SetTrigger("Marchar");

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
        {
            StartTimer();
        }
    }

    public void StopTime(bool v)
    {
        isCountingTimer = false;
        simplePlayer.ResetMarchar();
        BorderAnimator.ResetTrigger("Marchar");

        if (v)
        {
            feverCounter++;
            timerSoundEffects.PlayCorrect();
        }
        else
        {
            simplePlayer.PlayMistakeAnimation();
            feverCounter = 0;
            timerSoundEffects.PlayWrong();
        }

        feverCounterTXT.text = "Combos: " + feverCounter;
    }

    public void CorrectInput(int actionCode)
    {

        if (IsInTimer())
        {
            intervaloTocado = true;
            CallManagerforComboAction(actionCode);
        }
        else
            StopTime(false);
    }

    private void CallManagerforComboAction(int actionCode)
    {
        gameManager.DealWithCombo(actionCode);
    }

    public bool IsInTimer()
    {
        return !intervaloTocado;
    }
}
