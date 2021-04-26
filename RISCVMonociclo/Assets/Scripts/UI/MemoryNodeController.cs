using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MemoryNodeController : MonoBehaviour
{
    public TMP_Text MemoryContent;

    public void AddMemoryContent(int MemAddress, string MemValue)
    {
        MemoryContent.text = MemAddress + " - " + MemValue;
    }

    public string ReadMemoryContent()
    {
        string[] TempResult = MemoryContent.text.Split('-');
        return TempResult[1].Substring(1);
    }
}
