using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryUIController : MonoBehaviour
{
    public GameObject MemoryCanvas;
    public ScrollRect ScrollView;
    public GameObject ScrollContent;
    public GameObject NodePrefab;

    private List<GameObject> MemoryNodes = new List<GameObject>();

    private void Start()
    {
        GenerateNodes(255);
    }

    void GenerateNodes(int QuantidadeNodes)
    {
        for (int i = 0; i < QuantidadeNodes; i++)
        {
            GameObject ScrollItem = Instantiate(NodePrefab);
            ScrollItem.transform.SetParent(ScrollContent.transform, false);
            ScrollItem.GetComponent<MemoryNodeController>().AddMemoryContent(i, "000000");
            ScrollItem.SetActive(true);
            MemoryNodes.Add(ScrollItem);
        }
        ScrollView.verticalNormalizedPosition = 1;
    }

    public void UpdateMemoryNode(int MemAddress)
    {
        // MemAddress pode ser 0 até 254
        if((MemAddress > -1) && (MemAddress < 255))
            MemoryNodes[MemAddress].GetComponent<MemoryNodeController>().AddMemoryContent(MemAddress, "000000");
    }

    public void UpdateMemoryNode(int MemAddress, string MemValue)
    {
        // MemAddress pode ser 0 até 254
        if ((MemAddress > -1) && (MemAddress < 255))
            MemoryNodes[MemAddress].GetComponent<MemoryNodeController>().AddMemoryContent(MemAddress, MemValue);
    }

    public void OpenMemoryCanvas()
    {
        if(!MemoryCanvas.activeSelf)
        {
            MemoryCanvas.SetActive(true);
        }
    }

    public void CloseMemoryCanvas()
    {
        if (MemoryCanvas.activeSelf)
        {
            MemoryCanvas.SetActive(false);
        }
    }
}
