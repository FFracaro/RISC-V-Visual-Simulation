using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ALUControl : MonoBehaviour
{
    public TMP_Text ALUControlToALUResult;

    private string ALUopValues;
    private string[] ULAControlValues;
    private string ALUControlResult;

    public void SetValuesToALUControl(string ControlFlags, string[] InstMemControlValues)
    {
        ALUopValues = ControlFlags;
        ULAControlValues = InstMemControlValues;
    }

    public string GetOperacaoValueFromULAControl()
    {
        return ALUControlResult;
    }

    public void PropagarValueFromULAControl()
    {
        ParseValues();

        ALUControlToALUResult.text = Convert.ToInt32(ALUControlResult, 2).ToString().PadLeft(2, '0');
    }

    private void ParseValues()
    {
        switch(ALUopValues)
        {
            case "00":
                ALUControlResult = "0010";
                break;
            case "01":
                ALUControlResult = "0110";
                break;
            case "11":
                ALUControlResult = "0110";
                break;
            case "10":
                if(ULAControlValues[0] == "1")
                {
                    ALUControlResult = "0110";
                }
                else
                {
                    int Funct3Dec = Convert.ToInt32(ULAControlValues[1], 2);

                    if (Funct3Dec == 0)
                    {
                        ALUControlResult = "0010";
                    }
                    else
                    {
                        if (Funct3Dec == 6)
                            ALUControlResult = "0001";

                        ALUControlResult = "0000";
                    }
                }
                break;
        }
    }
}
