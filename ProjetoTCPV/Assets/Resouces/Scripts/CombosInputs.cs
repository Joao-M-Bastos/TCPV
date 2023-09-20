using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombosInputs
{
    int[] inputs;

    bool canStillBeChosen;
    int timesChosen;

    int completeCode;

    public CombosInputs(int cod, int input1, int input2, int input3, int input4)
    {
        completeCode = cod;
        inputs = new int[4] {input1, input2, input3, input4};
        ResetValues();
    }


    public bool GetStillChosen()
    {
        return canStillBeChosen;
    }
    public void SetStillChosenToFalse()
    {
        canStillBeChosen = false;
    }

    public void ResetValues()
    {
        canStillBeChosen = true;
        timesChosen = 0;
    }

    public bool isCorrectCombo(int input)
    {
        if(timesChosen >= 4)
        {
            return false;
        }
        bool correct = inputs[timesChosen] == input;
        timesChosen++;
        return correct;
    }

    public int ReturnCompleteCode()
    {
        return completeCode;
    }

    public bool ReturnCompleted()
    {
        return timesChosen >= 4;
    }
}
