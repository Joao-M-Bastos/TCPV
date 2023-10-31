using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifyCombos
{
    CombosInputs walkCombo, attackCombo, backoffCombo, defenceCombo;
    CombosInputs[] combos;

    

    public VerifyCombos()
    {
        walkCombo = new CombosInputs(1, 1, 2, 3, 4);
        attackCombo = new CombosInputs(2, 2, 2, 3, 3);
        backoffCombo = new CombosInputs(3, 4, 3, 2, 1);
        defenceCombo = new CombosInputs(4, 3, 3, 2,  2);
        combos = new CombosInputs[4] { walkCombo, attackCombo, defenceCombo, backoffCombo };
    }

    public bool Verificar(int input, int currentCombo)
    {
        return combos[currentCombo].isCorrectCombo(input);
    }

    public int VerifyCompletion(int currentCombo)
    {
        int atLeastOne = 0;

        if (combos[currentCombo].ReturnCompleted())
            atLeastOne = combos[currentCombo].ReturnCompleteCode();

        return atLeastOne;
    }

    public void ResetValues()
    {
        foreach (CombosInputs c in combos)
        {
            c.ResetValues();
        }
    }
}
