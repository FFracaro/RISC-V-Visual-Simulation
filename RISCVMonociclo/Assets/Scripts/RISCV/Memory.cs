using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Memory : MonoBehaviour
{
    public TMP_Text MemToMuxResult;
    public MemoryUIController MemUIController;
    public BinaryToDecimal Bin2Dec;
    private string ULAValue, Reg2Result, MemToMux;
    private int MemWrite, MemRead;

    public void SetMemoryValues(string ULAresult, string Reg2Data, int WriteFlag, int ReadFlag)
    {
        ULAValue = ULAresult;
        Reg2Result = Reg2Data;
        MemWrite = WriteFlag;
        MemRead = ReadFlag;
    }

    public string GetMemoryValueRead()
    {
        return MemToMux;
    }

    public void PropagarMemoryValues()
    {
        MemToMuxResult.text = MemoryOperations();

    }

    private string MemoryOperations()
    {
        if (MemWrite == 1)
        {
            int AddressDec = ConvertStringToDecimal(ULAValue);
            MemUIController.WriteToMemory(AddressDec, Reg2Result);
            MemUIController.UpdateMemoryUIValues("" + MemWrite, "" + MemRead, ULAValue, Reg2Result, "000000");
            return "000000";
        }
        else
        {
            if (MemRead == 1)
            {
                int AddressDec = ConvertStringToDecimal(ULAValue);
                MemToMux = MemUIController.ReadFromMemory(AddressDec);

                MemUIController.UpdateMemoryUIValues("" + MemWrite, "" + MemRead, ULAValue, "000000", MemToMux);

                return MemToMux;
            }
        }

        MemUIController.UpdateMemoryUIValues("" + MemWrite, "" + MemRead, ULAValue, "000000", "000000");
        return "000000";
    }

    private int ConvertStringToDecimal(string value)
    {
        if (value.IndexOf('-') != -1)
        {
            string[] s = value.Split('-');
            return Int32.Parse(s[1]) * -1;
        }
        return Bin2Dec.BinToDec(value);
    }
}
