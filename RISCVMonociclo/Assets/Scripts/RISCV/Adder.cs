using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Adder : MonoBehaviour
{
    string EntradaValue1;
    string EntradaValue2 = "004";
    public TMP_Text Saida;

    public void SetValorEntrada1Adder(string value)
    {
        EntradaValue1 = value;
    }

    public void SetValorEntrada2Adder(string value)
    {
        EntradaValue1 = value;
    }

    public string GetValorSaidaAdder()
    {
        return Saida.text;
    }

    public void PropagarValorAdder()
    {
        int InValue1 = Int32.Parse(EntradaValue1);
        int InValue2 = Int32.Parse(EntradaValue2);
        int result = InValue1 + InValue2;

        Saida.text = result.ToString().PadLeft(3, '0');
    }
}
