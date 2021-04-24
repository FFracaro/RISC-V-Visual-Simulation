using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgramCounter : MonoBehaviour
{
    public TMP_Text PCAtual;
    public TMP_Text PCProximo;
    public TMP_Text[] SaidasPC;

    public void SetPCProximoValue(string PCAddress)
    {
        PCProximo.text = PCAddress;
    }

    public string GetPCAtualValue()
    {
        return PCAtual.text;
    }

    public void PropagarValorPC()
    {
        PCAtual.text = PCProximo.text;

        foreach(TMP_Text saida in SaidasPC)
        {
            saida.text = PCAtual.text;
        }
    }
}
