using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InstructionMemory : MonoBehaviour
{
    private List<string> Instruções;
    private string InstruçãoAtual;

    public TMP_Text OPCodeInput;
    public TMP_Text Reg1Input;
    public TMP_Text Reg2Input;
    public TMP_Text Reg3Input;
    public TMP_Text IMMGenInput;
    public TMP_Text ULAControlInput;
    public TMP_Text NomeInstrução;

    private string OpCodeValue, Reg1Value, Reg2Value, Reg3Value;
    private string[] ULAControlValue = new string[2];

    public void SetInstruções(List<string> inst)
    {
        Instruções = inst;
    }

    public string GetOpCodeValue()
    {
        return OpCodeValue;
    }

    public string GetReg1Value()
    {
        return Reg1Value;
    }

    public string GetReg2Value()
    {
        return Reg2Value;
    }

    public string GetReg3Value()
    {
        return Reg3Value;
    }

    public string GetInstrucaoAtual()
    {
        return InstruçãoAtual;
    }

    public string[] GetULAControlValue()
    {
        return ULAControlValue;
    }

    private string SetNovaInstrução(int posição)
    {
        return Instruções[posição];
    }

    public void SetNumeroInstrução(string PCValor)
    {
        InstruçãoAtual = SetNovaInstrução((Int32.Parse(PCValor) / 4));
    }

    public int GetQuantidadeInstrucoes()
    {
        return Instruções.Count;
    }

    public void PropagarValoresInstrução()
    {
        IMMGenInput.text = InstruçãoAtual;

        ParseInstrução();

        NomeInstrução.text = GetInstruçãoNome();

        OPCodeInput.text = OpCodeValue;

        int TempInteger = Convert.ToInt32(Reg1Value, 2);
        Reg1Input.text = Reg1Value + " (x" + TempInteger.ToString().PadLeft(2, '0') + ")";

        TempInteger = Convert.ToInt32(Reg2Value, 2);
        Reg2Input.text = Reg2Value + " (x" + TempInteger.ToString().PadLeft(2, '0') + ")";

        TempInteger = Convert.ToInt32(Reg3Value, 2);
        Reg3Input.text = Reg3Value + " (x" + TempInteger.ToString().PadLeft(2, '0') + ")";

        ULAControlInput.text = "[" + ULAControlValue[0] + ", " + ULAControlValue[1] + "]";
    }

    private void ParseInstrução()
    {
        OpCodeValue = GetSubstringFromInstrução(25, 7);

        Reg1Value = GetSubstringFromInstrução(12, 5);

        Reg2Value = GetSubstringFromInstrução(7, 5);

        Reg3Value = GetSubstringFromInstrução(20, 5);

        ULAControlValue[0] = GetSubstringFromInstrução(1, 1);
        ULAControlValue[1] = GetSubstringFromInstrução(17, 3);   
    }

    private string GetSubstringFromInstrução(int PosiçãoInicial, int QuantidadeACopiar)
    {
        return InstruçãoAtual.Substring(PosiçãoInicial, QuantidadeACopiar);
    }

    private string GetInstruçãoNome()
    {
        int DecOPCode = Convert.ToInt32(OpCodeValue, 2);

        switch(DecOPCode)
        {
            case 3:
                return "LW";
            case 35:
                return "SW";
            case 19:
                return "ADDI";
            case 99:
                if (Convert.ToInt32(ULAControlValue[1], 2) == 0)               
                    return "BEQ";
                return "BNE";
            case 51:
                if (Convert.ToInt32(ULAControlValue[1], 2) == 0)
                {
                    if (Convert.ToInt32(ULAControlValue[0], 2) == 0)
                        return "ADD";
                    return "SUB";
                }
                else
                {
                    if (Convert.ToInt32(ULAControlValue[1], 2) == 6)
                        return "OR";
                    return "AND";
                }
        }
        return "null";
    }
}
