using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AND : MonoBehaviour
{
    public TMP_Text SaidaAND;
    private int BranchValue, ULAZero, ANDResult;

    public void SetBranchAndZeroValues(int branch, int zero)
    {
        BranchValue = branch;
        ULAZero = zero;
    }

    public int GetANDResult()
    {
        return ANDResult;
    }

    public void PropagarANDValue()
    {
        ANDResult = BranchValue & ULAZero;

        SaidaAND.text = ANDResult.ToString();
    }
}
