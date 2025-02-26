using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetResolution(int resolutionIndex)
    {
        switch (resolutionIndex)
        {
            case 0: Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow); break;
            case 1: Screen.SetResolution(2560, 1440, FullScreenMode.FullScreenWindow); break;
            case 2: Screen.SetResolution(1600, 900, FullScreenMode.FullScreenWindow); break;
            default: Debug.LogWarning("Invalid resolution index!"); break;
        }
        Debug.Log($"Resolution set to index {resolutionIndex}");
    }


}
