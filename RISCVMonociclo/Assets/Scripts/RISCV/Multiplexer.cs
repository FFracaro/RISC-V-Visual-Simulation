using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Multiplexer : MonoBehaviour
{
    public bool MuxPC;
    public TMP_Text SaidaMux;
    private string Valor1, Valor2, ResultadoSaida;
    private int Flag;

    public void SetValuesEntradaMux(string value1, string value2, int flag)
    {
        Valor1 = value1;
        Valor2 = value2;
        Flag = flag;
    }

    public string GetSaidaMuxResult()
    {
        return ResultadoSaida;
    }

    public void PropagarMux()
    {
        if(MuxPC)
        {
            if (Flag == 0)
            {
                ResultadoSaida = Int32.Parse(Valor1).ToString().PadLeft(3, '0');
            }
            else
            {
                ResultadoSaida = Int32.Parse(Valor2).ToString().PadLeft(3, '0');
            }
        }
        else
        {
            if (Flag == 0)
            {
                ResultadoSaida = Valor1;
            }
            else
            {
                ResultadoSaida = Valor2;
            }
        }

        SaidaMux.text = ResultadoSaida;
    }
}
