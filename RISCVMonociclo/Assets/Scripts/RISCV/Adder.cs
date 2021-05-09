using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Adder : MonoBehaviour
{
    public bool IsJumpAdder;
    string EntradaValue1;
    string EntradaValue2 = "004";
    string EntradaValue2Binary;
    public TMP_Text Saida;

    public BinaryToDecimal Bin2Dec;

    public void SetValorEntrada1Adder(string value)
    {
        EntradaValue1 = value;
    }

    public void SetValorEntrada2Adder(string value)
    {
        EntradaValue2 = value;
    }

    public void SetValorEntrada2BinaryAdder(string value)
    {
        EntradaValue2Binary = value;
    }

    public string GetValorSaidaAdder()
    {
        return Saida.text;
    }

    public void PropagarValorAdder()
    {
        int result = 0;

        int InValue1 = Int32.Parse(EntradaValue1);

        if(IsJumpAdder)
        {
            result = InValue1 + Bin2Dec.BinToDec(EntradaValue2Binary) + 4;
            Saida.text = result.ToString().PadLeft(6, '0');
        }
        else
        {
            int InValue2 = Int32.Parse(EntradaValue2);
            result = InValue1 + InValue2;
            Saida.text = result.ToString().PadLeft(3, '0');
        }     
    }
}
