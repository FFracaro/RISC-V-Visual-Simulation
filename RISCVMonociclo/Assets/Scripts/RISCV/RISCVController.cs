using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RISCVController : MonoBehaviour
{
    public ProgramCounter PC;
    public Adder Adder1;
    public Adder Adder2;
    public InstructionMemory InstMem;
    public Control ControlUnit;
    public Registers RegistersBank;
    public string value;

    private bool instrucoes = false;

    public void ClockCycle()
    {
        string g = "11111111111111111111111111110110";
        Debug.Log(binaryToDecimal(g));



        if (!instrucoes)
        {
            string a = "01000000001000001000101000110011";

            string b = "00000000000100010010101010100011";

            List<string> c = new List<string>();
            c.Add(a);
            c.Add(b);

            //Lista proveniente do parse do arquivo
            InstMem.SetInstruções(c);
        }

        instrucoes = true;

        ///////////////////////////////////

        RegistersBank.HideArrowsFromRegisters();

        PC.PropagarValorPC();

        Adder1.SetValorEntrada1Adder(PC.GetPCAtualValue());
        Adder1.PropagarValorAdder(); // Soma do PC address com o nº 4

        Adder2.SetValorEntrada1Adder(PC.GetPCAtualValue()); // Não pode propagar ainda pois não possui o valor do IMM Gen

        InstMem.SetNumeroInstrução(PC.GetPCAtualValue());
        InstMem.PropagarValoresInstrução(); // Envia os valores contidos em uma instrução para as saídas da memória de instrução

        ControlUnit.SetOpCodeValue(InstMem.GetOpCodeValue());
        ControlUnit.PropagarValoresControl(); // Utiliza o OPCode para setar as flags na saída da unidade de controle

        RegistersBank.SetRegistersToUse(InstMem.GetReg1Value(), InstMem.GetReg2Value(), InstMem.GetReg3Value());
        RegistersBank.SetRegWriteValueInRegister(ControlUnit.GetRegWriteValue());
        RegistersBank.PropagarRegisterValues(); // Após receber os registradores e o regwrite, coloca na saída o conteúdo dos registradores 1 e 2

        //Adder2.SetValorEntrada2Adder(IMMGen.GetValorResultado());
        //Adder2.PropagarValorAdder();

        //RegistersBank.SetValueToRegister3(MUXResultValue);

        //PC.SetPCProximoValue(MUXPC.GetPCValue());
        PC.SetPCProximoValue(value);
        
    }

    int binaryToDecimal(String n)
    {
        String num = n;
        int dec_value = 0;

        // Initializing base value to 1,
        // i.e 2^0
        int base1 = 1;

        int len = num.Length;
        for (int i = len - 1; i >= 0; i--)
        {
            if (num[i] == '1')
                dec_value += base1;
            base1 = base1 * 2;
        }

        return dec_value;
    }
}
