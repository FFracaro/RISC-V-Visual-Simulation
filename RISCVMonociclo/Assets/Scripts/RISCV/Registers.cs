using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Registers : MonoBehaviour
{
    public TMP_Text Reg1Output;
    public TMP_Text[] Reg2Output;

    public List<GameObject> RegistersArrows;
    public List<TMP_Text> RegistersContent;

    private string[] RegistersToUse = new string[3];
    private int RegWriteValue = 0;

    private bool AreRegisterBeingUsed = false;

    public void SetRegistersToUse(string reg1, string reg2, string reg3)
    {
        RegistersToUse[0] = reg1;
        RegistersToUse[1] = reg2;
        RegistersToUse[2] = reg3;

        AreRegisterBeingUsed = true;
        ShowArrowsOnRegisters(Convert.ToInt32(RegistersToUse[0], 2), 
            Convert.ToInt32(RegistersToUse[1], 2), Convert.ToInt32(RegistersToUse[2], 2));
    }

    public void SetRegWriteValueInRegister(int RegValue)
    {
        RegWriteValue = RegValue;
    }

    public void SetValueToRegister3(string value)
    {
        if (RegWriteValue == 1)
            SetContentToRegister(Convert.ToInt32(RegistersToUse[3], 2), value);
    }

    public void HideArrowsFromRegisters()
    {
        if(AreRegisterBeingUsed)
        {
            HideArrowsOnRegisters(Convert.ToInt32(RegistersToUse[0], 2),
                Convert.ToInt32(RegistersToUse[1], 2), Convert.ToInt32(RegistersToUse[2], 2));
        }
    }

    public string GetContentFromRegister1()
    {
        return GetContentFromRegister(Convert.ToInt32(RegistersToUse[0], 2));
    }

    public string GetContentFromRegister2()
    {
        return GetContentFromRegister(Convert.ToInt32(RegistersToUse[1], 2));
    }

    public void PropagarRegisterValues()
    {
        Reg1Output.text = GetContentFromRegister(Convert.ToInt32(RegistersToUse[0], 2));

        int TempReg2Value = Convert.ToInt32(RegistersToUse[1], 2);

        Reg2Output[0].text = GetContentFromRegister(TempReg2Value);
        Reg2Output[1].text = GetContentFromRegister(TempReg2Value);
    }

    private string GetContentFromRegister(int reg)
    {
        return RegistersContent[reg].text;
    }

    private void SetContentToRegister(int reg, string content)
    {
        RegistersContent[reg].text = content;
    }

    private void ShowArrowsOnRegisters(int reg1, int reg2, int reg3)
    {
        RegistersArrows[reg1].SetActive(true);
        RegistersArrows[reg2].SetActive(true);
        RegistersArrows[reg3].SetActive(true);
    }

    private void HideArrowsOnRegisters(int reg1, int reg2, int reg3)
    {
        RegistersArrows[reg1].SetActive(false);
        RegistersArrows[reg2].SetActive(false);
        RegistersArrows[reg3].SetActive(false);
    }
}
