using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject BGPanel;
    public GameObject Menu;
    public GameObject SideMenu;
    public GameObject RealMenu;
    public string SceneToLoad;

    public void OpenMenu()
    {
        if(!BGPanel.activeSelf)
            if(!Menu.activeSelf)
                if(!SideMenu.activeSelf)
                {
                    BGPanel.SetActive(true);
                    Menu.SetActive(true);
                    SideMenu.SetActive(true);
                    RealMenu.SetActive(false);
                }
    }

    public void CloseMenu()
    {
        if (BGPanel.activeSelf)
            if (Menu.activeSelf)
                if (SideMenu.activeSelf)
                {
                    BGPanel.SetActive(false);
                    Menu.SetActive(false);
                    SideMenu.SetActive(false);
                    RealMenu.SetActive(true);
                }
    }

    public void CloseApplication()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                         Application.Quit();
        #endif
    }

    public void AbrirTelaInicial()
    {
        InstructionsHolder[] test = FindObjectsOfType(typeof(InstructionsHolder)) as InstructionsHolder[];
        test[0].DestroyThisObject();

        StartCoroutine(LoadSceneAsync());
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
