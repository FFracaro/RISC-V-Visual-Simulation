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
    public BinaryToDecimal Bin2Dec;

    private string OpCodeValue, ImmediateValue;

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

    public string GetImmGenValueBinary()
    {
        return ImmediateValue;
    }

    public string GetImmGenValueBinaryShiftLeft()
    {
        return ShiftLeft(ImmediateValue);
    }

    public void PropagarImmGenValue()
    {
        ParseInstrucao();

        ImmGenToULA.text = Bin2Dec.BinToDec(ImmediateValue).ToString().PadLeft(6, '0');

        ImmGenToPC.text = Bin2Dec.BinToDec(ShiftLeft(ImmediateValue)).ToString().PadLeft(6, '0');
    }

    private void ParseInstrucao()
    {
        OpCodeValue = GetSubstringFromInstrução(InstrucaoAtual, 25, 7);

        ParseOPCode();
    }

    private string GetSubstringFromInstrução(string binary, int PosiçãoInicial, int QuantidadeACopiar)
    {
        return binary.Substring(PosiçãoInicial, QuantidadeACopiar);
    }

    private void ParseOPCode()
    {
        int DecOPCode = Convert.ToInt32(OpCodeValue, 2);

        switch (DecOPCode)
        {
            case 3 | 19: // Load e Addi
                GetImmediateValueTipoRI();
                break;
            case 35: // Store
                GetImmediateValueTipoS();
                break;
            case 99: // Beq e Bne
                GetImmediateValueTipoB();
                break;
            case 51: // Add, sub, and e or
                GetImmediateValueTipoRI();
                break;
        }
    }

    private void GetImmediateValueTipoRI()
    {
        // Não existe Immediate no tipo R.
        // Colocou-se nas saídas do Imm Gen
        // um valor similar aos do tipo I

        // Immediate tipo I = 12 primeiros bits da insturção

        string TempImmediateValue = GetSubstringFromInstrução(InstrucaoAtual, 0, 12);

        string sinal = GetSubstringFromInstrução(InstrucaoAtual, 0, 1);

        // Extensão do sinal (12 bits sinalizado para 32 bits sinalizado)
        ImmediateValue = ExtenderSinal(TempImmediateValue, sinal);
    }

    private void GetImmediateValueTipoS()
    {
        string TempImmediateValue1 = GetSubstringFromInstrução(InstrucaoAtual, 0, 7);
        string TempImmediateValue2 = GetSubstringFromInstrução(InstrucaoAtual, 20, 5);

        string TempImmediateValue = TempImmediateValue1 + TempImmediateValue2;

        string sinal = GetSubstringFromInstrução(ImmediateValue, 0, 1);

        // Extensão do sinal (12 bits sinalizado para 32 bits sinalizado)
        ImmediateValue = ExtenderSinal(TempImmediateValue, sinal);
    }

    private void GetImmediateValueTipoB()
    {
        string sinal = GetSubstringFromInstrução(InstrucaoAtual, 0, 1);

        string Imm11 = GetSubstringFromInstrução(InstrucaoAtual, 24, 1);
        string Imm4_1 = GetSubstringFromInstrução(InstrucaoAtual, 20, 4);
        string Imm10_5 = GetSubstringFromInstrução(InstrucaoAtual, 1, 6);

        string TempImmediateValue = sinal + Imm11 + Imm10_5 + Imm4_1;

        ImmediateValue = ExtenderSinal(TempImmediateValue, sinal);
    }

    private string ExtenderSinal(string Value, string sinal)
    {
        if (sinal == "0")
            return "00000000000000000000" + Value;
        else
            return "11111111111111111111" + Value;
    }

    private string ShiftLeft(string value)
    {
        string TempValue = GetSubstringFromInstrução(ImmediateValue, 1, 31);
        return TempValue + "0";
    }
}
