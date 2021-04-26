using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArithmeticLogicUnit : MonoBehaviour
{
    public TMP_Text ULAToMem;
    public TMP_Text ULAToMux;
    public TMP_Text ULAToZero;
    public BinaryToDecimal Bin2Dec;
    private string Value1, Value2, ULAControlValue, ULAResult;
    private int Zero = 0;

    public void SetULAValues(string value1, string value2, string control)
    {
        Value1 = value1;
        Value2 = value2;
        ULAControlValue = control;
    }

    public string GetULAResult()
    {
        return ULAResult;
    }

    public int GetZeroValue()
    {
        return Zero;
    }

    public void PropagarULAValues()
    {
        CalculateValues();

        ULAToMem.text = ULAResult;
        ULAToMux.text = ULAResult;
        ULAToZero.text = "" + Zero;
    }

    private void CalculateValues()
    {
        int ULAControlValueDec = Bin2Dec.BinToDec(ULAControlValue);
        switch (ULAControlValueDec)
        {
            case 0: // AND 0000
                CalcAND();
                break;
            case 1: // OR 0001
                CalcOR();
                break;
            case 2: // ADD 0010
                CalcADD();
                break;
            case 6: // SUB 0110
                CalcSUB();
                break;
        }
    }

    private int ConvertStringToDecimal(string value)
    {
        if(value.IndexOf('-') != -1)
        {
            string[] s = value.Split('-');
            return Int32.Parse(s[1]) * -1;
        }
        return Bin2Dec.BinToDec(value);
    }

    private void CalcAND()
    {
        int result = ConvertStringToDecimal(Value1) & ConvertStringToDecimal(Value2);
        if (result == 0)
            Zero = 1;

        ULAResult = result.ToString().PadLeft(6, '0');
    }

    private void CalcOR()
    {
        int result = ConvertStringToDecimal(Value1) | ConvertStringToDecimal(Value2);
        if (result == 0)
            Zero = 1;

        ULAResult = result.ToString().PadLeft(6, '0');
    }

    private void CalcADD()
    {
        int result = ConvertStringToDecimal(Value1) + ConvertStringToDecimal(Value2);
        if (result == 0)
            Zero = 1;

        ULAResult = result.ToString().PadLeft(6, '0');
    }

    private void CalcSUB()
    {
        int result = ConvertStringToDecimal(Value1) - ConvertStringToDecimal(Value2);
        if (result == 0)
            Zero = 1;

        ULAResult = result.ToString().PadLeft(6, '0');
    }
}
