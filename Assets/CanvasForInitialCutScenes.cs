using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasForInitialCutScenes : MonoBehaviour
{
    // Start is called before the first frame update

    public float time; 
    void Start()
    {
        StartCoroutine(StartCutScenes());
    }

    public IEnumerator StartCutScenes()
    {
        foreach(Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(true);

            yield return new WaitForSeconds(time);
        }
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
