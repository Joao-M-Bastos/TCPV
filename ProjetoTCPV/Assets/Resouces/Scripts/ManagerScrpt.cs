using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScrpt : MonoBehaviour
{
    [SerializeField] SimplePlayer simplePlayer;


    [SerializeField] float BPMSerialize;
    
    static float BPM;

    private void Awake()
    {
        BPM = BPMSerialize;
    }

    public void DealWithCombo(int comboCode)
    {
        simplePlayer.DoActionBasedOnCode(comboCode);
    }

    public static float GetBPS()
    {
        return BPM / 60;
    }
}
