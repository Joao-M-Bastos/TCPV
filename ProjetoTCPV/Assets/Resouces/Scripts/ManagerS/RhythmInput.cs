using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RhythmInput : MonoBehaviour
{
    Timer timer;
    VerifyCombos verifyCombos;

    [SerializeField] Text[] hintTXT;

    int currentCombo = 1;
    public int CurrentCombo => currentCombo;

    private void Awake()
    {
        verifyCombos = new VerifyCombos();
        timer = this.gameObject.GetComponent<Timer>();
        timer.SetComboAction(currentCombo);
    }

    // Update is called once per frame
    void Update()
    {
        int intervaloAtual = timer.IntervaloAtual - 1;

        if (!timer.IsCountingTimer && !timer.timerSoundEffects.IsWhistlePlaying())
        {
            int newCombo = currentCombo;
            if (Input.GetKeyDown(KeyCode.Z))
                newCombo = 0;

            if (Input.GetKeyDown(KeyCode.X))
                newCombo = 1;

            if (Input.GetKeyDown(KeyCode.C))
                newCombo = 2;

            if (Input.GetKeyDown(KeyCode.V))
                newCombo = 3;

            if(newCombo != currentCombo)
            {
                currentCombo = newCombo;
                ShowCorrectHint();
                timer.simplePlayer.PlayWhistleAnimation();
                timer.SetComboAction(currentCombo);
                timer.timerSoundEffects.ShutUp();
                timer.timerSoundEffects.PlayWhistle();
            }
        }



        int keyToVerify = 0;

        if (Input.GetKeyDown(KeyCode.A))
            keyToVerify = 1;

        if (Input.GetKeyDown(KeyCode.S))
            keyToVerify = 2;

        if (Input.GetKeyDown(KeyCode.D))
            keyToVerify = 3;

        if (Input.GetKeyDown(KeyCode.F))
            keyToVerify = 4;

        if (keyToVerify != 0)
        {
            timer.AtLeatOneClick();
            if (verifyCombos.Verificar(keyToVerify, currentCombo, intervaloAtual))
                timer.CorrectInput();
            else
                timer.WrongInputs();
            
        }
    }

    private void ShowCorrectHint()
    {
        for(int i =0; i < hintTXT.Length; i++)
        {
            hintTXT[i].gameObject.SetActive(false);
        }
        
        hintTXT[currentCombo].gameObject.SetActive(true);
    }
}
