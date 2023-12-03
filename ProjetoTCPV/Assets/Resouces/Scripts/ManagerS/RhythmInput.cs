using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmInput : MonoBehaviour
{
    Timer timer;
    VerifyCombos verifyCombos;

    int currentCombo = 1;

    private void Awake()
    {
        verifyCombos = new VerifyCombos();
        timer = this.gameObject.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        int intervaloAtual = timer.IntervaloAtual;


        if (!timer.IsCountingTimer)
        {
            if (Input.GetKeyDown(KeyCode.Z))
                currentCombo = 0;

            if (Input.GetKeyDown(KeyCode.X))
                currentCombo = 1;

            if (Input.GetKeyDown(KeyCode.C))
                currentCombo = 2;

            if (Input.GetKeyDown(KeyCode.V))
                currentCombo = 3;

            timer.SetComboAction(currentCombo);
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
}
