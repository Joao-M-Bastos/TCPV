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
        combos = new CombosInputs[4] { walkCombo, attackCombo, backoffCombo, defenceCombo };
        
    }

    public bool Verificar(int input)
    {
        bool atLeastOne = false;

        foreach(CombosInputs c in combos)
        {
            if (VerifyActiveCombos(c, input))
                atLeastOne = true;
        }

        return atLeastOne;
    }

    public int VerifyCompletion()
    {
        int atLeastOne = 0;

        foreach (CombosInputs c in combos)
        {
            if (c.ReturnCompleted())
                atLeastOne = c.ReturnCompleteCode();
        }

        return atLeastOne;
    }

    public void ResetValues()
    {
        foreach (CombosInputs c in combos)
        {
            c.ResetValues();
        }
    }

    public bool VerifyActiveCombos(CombosInputs currentCombo, int input)
    {
        if (currentCombo.GetStillChosen() && currentCombo.isCorrectCombo(input))
            return true;

        currentCombo.SetStillChosenToFalse();
        return false;
    }
}
