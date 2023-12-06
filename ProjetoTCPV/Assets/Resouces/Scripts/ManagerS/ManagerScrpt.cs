using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScrpt : MonoBehaviour
{
    [SerializeField] SimplePlayer simplePlayer;
    [SerializeField] TimerSoundEffects soundEffects;

    [SerializeField] float BPMSerialize;

    [SerializeField] GameObject canvas, winCanvas, lostCanvas, pauseCanvas;
    
    static float BPM;

    public static int feverValue;

    public bool gameOver;

    private void Awake()
    {
        BPM = BPMSerialize;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOver)
        {
            Pause();
        }

        if (Input.anyKeyDown && gameOver && Time.timeScale == 0)
        {
            ReturnToMenu();
        }

        if (Input.anyKeyDown && gameOver)
        {
            Time.timeScale = 0;
            canvas.SetActive(false);
            winCanvas.SetActive(true);
        }
    }

    private void Pause()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseCanvas.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pauseCanvas.SetActive(true);
        }
        
    }

    public void DealWithCombo(int comboCode)
    {
        simplePlayer.DoActionBasedOnCode(comboCode);
    }

    public static float GetBPS()
    {
        return BPM / 60;
    }

    public void GameOver(bool win)
    {
        gameOver = true;

        if (!win) {
            Time.timeScale = 0;
            canvas.SetActive(false);
            lostCanvas.SetActive(true);
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
