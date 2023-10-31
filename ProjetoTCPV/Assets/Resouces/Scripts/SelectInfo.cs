using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectInfo : MonoBehaviour
{
    private string fase;
    private List<string> personagens;
    
    private static GameObject instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
            instance = gameObject;
        else
            Destroy(gameObject);
    }

    public void SetFase(string str)
    {
        fase = str;
    }

    public void SetPersonagens(List<string> list)
    {
        personagens = list;
    }

    public string GetFase()
    {
        return fase;
    }

    public List<string> GetPersonagens()
    {
        return personagens;
    }
}
