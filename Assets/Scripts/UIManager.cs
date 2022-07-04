using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] UI_panels;
    public GameManager g_manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void isGamePaused(bool status)
    {
        UI_panels[0].SetActive(status);
        if (!status)
        {
            UI_panels[1].SetActive(status);
        }
        
    }

    public  void OnContinueClick() 
    {
        foreach (GameObject panel in UI_panels)
        {
            panel.SetActive(false);
            g_manager.ResumeGame();
        }
    }

    public void OnSettingsClick()
    {
        UI_panels[0].SetActive(false);
        UI_panels[1].SetActive(true);
    }
    public void OnBackClick()
    {
        UI_panels[0].SetActive(true);
        UI_panels[1].SetActive(false);
    }
    public void OnExitClick()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
        if (Application.isPlaying)
        {
            Application.Quit();
        }
    }
 }
