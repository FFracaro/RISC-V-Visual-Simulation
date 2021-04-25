using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Control : MonoBehaviour
{
    public TMP_Text TipoInstrução;
    public TMP_Text RegWriteInput;
    public TMP_Text BranchInput;
    public TMP_Text MemReadInput;
    public TMP_Text MemToRegInput;
    public TMP_Text ALUOpInput;
    public TMP_Text MemWriteInput;
    public TMP_Text ALUSrcInput;

    public TMP_Text RegWriteOutput;
    public TMP_Text BranchOutput;
    public TMP_Text MemReadOutput;
    public TMP_Text MemToRegOutput;
    public TMP_Text ALUOpOutput;
    public TMP_Text MemWriteOutput;
    public TMP_Text ALUSrcOutput;

    private string OpCodeValue;

    public void SetOpCodeValue(string OPCode)
    {
        this.OpCodeValue = OPCode;
    }

    public int GetRegWriteValue()
    {
        return Convert.ToInt32(RegWriteInput.text, 2);
    }

    public int GetBranchValue()
    {
        return Convert.ToInt32(BranchInput.text, 2);
    }

    public int GetMemReadValue()
    {
        return Convert.ToInt32(MemReadInput.text, 2);
    }

    public int GetMemToRegValue()
    {
        return Convert.ToInt32(MemToRegInput.text, 2);
    }

    public string GetALUOpValue()
    {
        return ALUOpInput.text;
    }

    public int GetMemWriteValue()
    {
        return Convert.ToInt32(MemWriteInput.text, 2);
    }

    public int GetALUSrcValue()
    {
        return Convert.ToInt32(ALUSrcInput.text, 2);
    }

    public void PropagarValoresControl()
    {
        ParseOPCode();
    }

    private void ParseOPCode()
    {
        int DecOPCode = Convert.ToInt32(OpCodeValue, 2);

        switch (DecOPCode)
        {
            case 3:
                SetValues("I", 1, 0, 1, 1, "00", 0, 1);
                break;
            case 35:
                SetValues("S", 0, 0, 0, 0, "00", 1, 1);
                break;
            case 99:
                SetValues("B", 0, 1, 0, 0, "01", 0, 0);
                break;
            case 51:
                SetValues("R", 1, 0, 0, 0, "10", 0, 0);
                break;
        }
    }

    private void SetValues(string TipoInst, int RegWrite, int Branch, int MemRead, 
        int MemToReg, string ALUOp, int MemWrite, int ALUSrc)
    {
        TipoInstrução.text = "Tipo: " + TipoInst;

        RegWriteInput.text = "" + RegWrite;
        RegWriteOutput.text = RegWriteInput.text;

        BranchInput.text = "" + Branch;
        BranchOutput.text = BranchInput.text;

        MemReadInput.text = "" + MemRead;
        MemReadOutput.text = MemReadInput.text;

        MemToRegInput.text = "" + MemToReg;
        MemToRegOutput.text = MemToRegInput.text;

        ALUOpInput.text = ALUOp;
        ALUOpOutput.text = ALUOpInput.text;

        MemWriteInput.text = "" + MemWrite;
        MemWriteOutput.text = MemWriteInput.text;

        ALUSrcInput.text = "" + ALUSrc;
        ALUSrcOutput.text = ALUSrcInput.text;
    }
}
