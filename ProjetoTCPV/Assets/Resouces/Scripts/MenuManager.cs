using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnJogarClick()
    {
        SceneManager.LoadScene("2_Jogo");
    }

    public void OnControleClick()
    {
        SceneManager.LoadScene("1_Controles");
    }

    public void OnCreditosClick()
    {
        SceneManager.LoadScene("3_Creditos");
    }

    public void OnSairClick()
    {
        Application.Quit();
    }
}
