using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsHolder : MonoBehaviour
{
    private List<string> Instrucoes;

    private void Awake()
    {
        DontDestroyOnLoad(this.transform.gameObject);
    }

    public void SetInstructionsList(List<string> inst)
    {
        Instrucoes = inst;
    }

    public List<string> GetInstructionsList()
    {
        return Instrucoes;
    }
}
