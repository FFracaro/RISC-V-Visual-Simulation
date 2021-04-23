using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RISCVController : MonoBehaviour
{
    public ProgramCounter PC;
    public Adder Adder1;
    public Adder Adder2;
    public string value;

    public void ClockCycle()
    {
        PC.PropagarValorPC();

        PC.SetPCProximoValue(value);
    }
}
