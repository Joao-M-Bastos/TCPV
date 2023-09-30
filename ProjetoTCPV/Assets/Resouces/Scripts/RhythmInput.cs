using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmInput : MonoBehaviour
{
    Timer timer;
    VerifyCombos verifyCombos;

    private void Awake()
    {
        verifyCombos = new VerifyCombos();
        timer = this.gameObject.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.intervaloAtual == 0)
        {
            ResetCombos();
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

        if (keyToVerify != 0 )
        {
            if (verifyCombos.Verificar(keyToVerify))
            {
                timer.CorrectInput(verifyCombos.VerifyCompletion());
            }
        }

        
    }

    private void ResetCombos()
    {
        verifyCombos.ResetValues();
    }
}
