using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImmediateGenerator : MonoBehaviour
{
    private string InstrucaoAtual;
    public TMP_Text ImmGenToULA;
    public TMP_Text ImmGenToPC;

    public void SetInstructionToImmGen(string Instrucao)
    {
        InstrucaoAtual = Instrucao;
    }

    public string GetImmGenValueToULA()
    {
        return ImmGenToULA.text;
    }

    public string GetImmGenValueToPC()
    {
        return ImmGenToPC.text;
    }

    public void PropagarImmGenValue()
    {

    }
}
