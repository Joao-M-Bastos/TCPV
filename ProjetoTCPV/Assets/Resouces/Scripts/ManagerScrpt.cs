using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScrpt : MonoBehaviour
{
    [SerializeField] SimplePlayer simplePlayer;

    
    [SerializeField] float BPM;

    public void DealWithCombo(int comboCode)
    {
        simplePlayer.DoActionBasedOnCode(comboCode);
    }

    public float GetBPM()
    {
        return BPM;
    }
}
