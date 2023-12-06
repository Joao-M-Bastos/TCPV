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
        defenceCombo = new CombosInputs(3, 3, 3, 2,  2);
        backoffCombo = new CombosInputs(4, 4, 3, 2, 1);
        combos = new CombosInputs[4] { walkCombo, attackCombo, defenceCombo, backoffCombo };
    }

    public bool Verificar(int input, int currentCombo, int intervaloAtual)
    {
        return combos[currentCombo].isCorrectInput(input, intervaloAtual);
    }
}
