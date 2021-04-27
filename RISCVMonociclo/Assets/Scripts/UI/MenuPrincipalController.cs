using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuPrincipalController : MonoBehaviour
{
    public string SceneToLoad;
    public GameObject PopUpMsg;
    public TMP_InputField CaminhoArquivo;
    private List<string> Instrucoes = new List<string>();
    
    public void CloseApplication()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                 Application.Quit();
        #endif
    }

    public void IniciarSimulacao()
    {
        Debug.Log(CaminhoArquivo.text);
        if(File.Exists(@CaminhoArquivo.text))
        {
            // Read file using StreamReader. Reads file line by line  
            using (StreamReader file = new StreamReader(@CaminhoArquivo.text))
            {
                int counter = 0;
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    Instrucoes.Add(ln);
                    counter++;
                }

                file.Close();
            }

            InstructionsHolder[] test = FindObjectsOfType(typeof(InstructionsHolder)) as InstructionsHolder[];

            test[0].SetInstructionsList(Instrucoes);

            StartCoroutine(LoadSceneAsync());
        }
        else
        {
            ShowPopUpMsg();
        }
    }

    public void ShowPopUpMsg()
    {
        if (!PopUpMsg.activeSelf)
            PopUpMsg.SetActive(true);
    }

    public void FecharPopUpMsg()
    {
        if (PopUpMsg.activeSelf)
            PopUpMsg.SetActive(false);
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneToLoad);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
