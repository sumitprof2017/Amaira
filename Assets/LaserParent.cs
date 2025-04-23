using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserParent : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject refrenceGameObject;
    void Start()
    {
       RecurssiveLoop();
    }

    void RecurssiveLoop()
    {
        StartCoroutine(ToggleOddThenEven());
    }
    [SerializeField]
    float time;
    int index = 0;
    IEnumerator ToggleOddThenEven()
        {

        foreach (Transform t in transform) { 
        
        t.gameObject.SetActive(false);

        }
        int count = transform.childCount;
        

        if(index % 2 == 0)
        {

            for (int i = 0; i < count; i++)
            {
                bool isEven = i % 2 == 0;
                transform.GetChild(i).gameObject.SetActive(isEven);
            }
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                bool isOdd = i % 2 != 0;
                transform.GetChild(i).gameObject.SetActive(isOdd);
            }
        }
        
        // Step 1: Turn on odd-indexed, turn off even-indexed
      

        // Step 2: Wait
        yield return new WaitForSeconds(time);
        index++;
        // Step 3: Turn on even-indexed, turn off odd-indexed
     
        RecurssiveLoop();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
