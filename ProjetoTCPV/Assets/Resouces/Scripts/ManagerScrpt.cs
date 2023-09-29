using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScrpt : MonoBehaviour
{
    [SerializeField] SimplePlayer simplePlayer;

    public void DealWithCombo(int comboCode)
    {
        simplePlayer.DoActionBasedOnCode(comboCode);
    }
}
