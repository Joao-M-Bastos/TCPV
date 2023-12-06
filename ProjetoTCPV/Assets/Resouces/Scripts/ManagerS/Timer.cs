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
    
    public bool IsCountingTimer => isCountingTimer;

    bool intervaloTocado, gotWrongInput, gotAnyInput;

    float tempoInicial;
    float tempoAtual;
    float tempoIntervalo;

    int intervaloAtual;
    public int IntervaloAtual => intervaloAtual;

    int currentCombo;

    private void Awake()
    {
        timerSoundEffects = this.gameObject.GetComponent<TimerSoundEffects>();
    }

    private void Start()
    {
        BorderAnimator.SetFloat("BPM", ManagerScrpt.GetBPS());
        tempoIntervalo = 1 / ManagerScrpt.GetBPS();
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
        gotWrongInput = false;
        intervaloTocado = true;
        gotAnyInput = false;
    }

    internal void AtLeatOneClick()
    {
        gotAnyInput = true;
    }

    public void RunningTime()
    {
        
        tempoAtual += Time.deltaTime;
        
        if (tempoAtual >= (tempoInicial + (tempoIntervalo * intervaloAtual)))
        {
            
            simplePlayer.PlayMarchAnimation();

            BorderAnimator.SetTrigger("Marchar");

            intervaloAtual += 1;

            if (intervaloTocado)
                intervaloTocado = false;
            else
            {
                WrongInputs();
            }

            timerSoundEffects.PlayCompass(tempoIntervalo / 2);
        }
        if (intervaloAtual >= 5)
        {
            StopTime();
        }
    }

    private void StopedTime()
    {
        //if (!timerSoundEffects.IsCorrectPlaying() && !simplePlayer.IsWrongPlaying())
        if (!timerSoundEffects.IsCorrectPlaying() && !timerSoundEffects.IsWrongPlaying())
        {
            StartTimer();
        }
    }

    public void StopTime()
    {
        isCountingTimer = false;
        simplePlayer.ResetMarchar();
        BorderAnimator.ResetTrigger("Marchar");

        if (!gotWrongInput && gotAnyInput)
        {
            CallManagerforComboAction(currentCombo);
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
        ManagerScrpt.feverValue = feverCounter;
    }

    internal void SetComboAction(int _currentCombo)
    {
        currentCombo = _currentCombo + 1;
    }

    public void CorrectInput()
    {
        if (IsInTimer())
        {
            intervaloTocado = true;
        }
        else
        {
            WrongInputs();
        }
    }

    public void WrongInputs()
    {
        gotWrongInput = true;
    }

    public void CallManagerforComboAction(int actionCode)
    {
        gameManager.DealWithCombo(actionCode);
    }

    public bool IsInTimer()
    {
        return !intervaloTocado;
    }
}
