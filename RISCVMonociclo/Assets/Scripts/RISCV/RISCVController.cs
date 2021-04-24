﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RISCVController : MonoBehaviour
{
    public ProgramCounter PC;
    public Adder Adder1;
    public Adder Adder2;
    public InstructionMemory InstMem;
    public string value;

    private bool instrucoes = false;

    public void ClockCycle()
    {
        if(!instrucoes)
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

        PC.PropagarValorPC();

        Adder1.SetValorEntrada1Adder(PC.GetPCAtualValue());
        Adder1.PropagarValorAdder(); // Soma do PC address com o nº 4

        Adder2.SetValorEntrada1Adder(PC.GetPCAtualValue()); // Não pode propagar ainda pois não possui o valor do IMM Gen

        InstMem.SetNumeroInstrução(PC.GetPCAtualValue());
        InstMem.PropagarValoresInstrução(); // Envia os valores contidos em uma instrução para as saídas da memória de instrução

        //Adder2.SetValorEntrada2Adder(IMMGen.GetValorResultado());
        //Adder2.PropagarValorAdder();

        //PC.SetPCProximoValue(MUXPC.GetPCValue());
        PC.SetPCProximoValue(value);
        
    }
}