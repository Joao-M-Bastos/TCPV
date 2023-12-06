using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombosInputs
{
    int[] inputs;

    int completeCode;

    public CombosInputs(int cod, int input1, int input2, int input3, int input4)
    {
        completeCode = cod;
        inputs = new int[4] {input1, input2, input3, input4};
    }

    public bool isCorrectInput(int input, int intervaloAtual)
    {
        if(intervaloAtual >= 4)
        {
            return false;
        }
        bool correct = inputs[intervaloAtual] == input;
        return correct;
    }

    public int ReturnCompleteCode()
    {
        return completeCode;
    }
}
