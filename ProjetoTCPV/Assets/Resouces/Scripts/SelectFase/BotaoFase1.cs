using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoFase1 : MonoBehaviour
{
    public void OnClick()
    {
        GameObject.Find("SelectInfo").GetComponent<SelectInfo>().SetFase("Fase1");
        SceneManager.LoadScene("SelectPersonagens");
    }
}
