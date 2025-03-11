using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update

    public PlayerDetailsSO playerDetailSo; // Reference to the ScriptableObject

    GameObject canvasGameObject;

    string currentSceneName;
    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        playerDetailSo.sceneName = currentSceneName;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContinueGame()
    {
        if (playerDetailSo == null || playerDetailSo.sceneName.Equals("")) return;
        if (Camera.main != null)
        {
            Camera.main.gameObject.SetActive(false);
        }
        playerDetailSo.isContinueButtonClicked = true;
        // Load the scene additively
        SceneManager.LoadScene(playerDetailSo.sceneName);
    }

    public void StartGame(string Scename)
    {
        if (Camera.main != null)
        {
            Camera.main.gameObject.SetActive(false);
        }

        // Load the scene additively
        SceneManager.LoadScene(Scename);
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
