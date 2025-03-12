using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ingredient : MonoBehaviour
{
    // Start is called before the first frame update
    public string SceneName;
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            SceneManager.LoadScene(SceneName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
