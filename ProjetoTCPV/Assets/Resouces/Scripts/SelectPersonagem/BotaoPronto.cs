using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoPronto : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene(GameObject.Find("SelectInfo").GetComponent<SelectInfo>().GetFase());
    }
}
