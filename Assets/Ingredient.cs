using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ingredient : MonoBehaviour
{
    // Start is called before the first frame update
    public string SceneName;
    
    public PlayerDetailsSO playerdetailSo;
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ResetScriptableObject();
        }
    }

    private void ResetScriptableObject()
    {
        playerdetailSo.sceneName = "";
        playerdetailSo.checkpointNumber = 0;
        playerdetailSo.checkpointPosition = Vector3.zero;
        print("playerdetailsso sceneName"+playerdetailSo.sceneName);
        print("checkpointNumbers" + playerdetailSo.checkpointNumber);

        SaveSystem.SavePlayerData(playerdetailSo);
         SceneManager.LoadScene(SceneName);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
