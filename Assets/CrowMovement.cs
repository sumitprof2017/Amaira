using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CrowMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject splineParent1, splineParent2;

    public Vector3[] splineFirstCrowMovementPath, splineSecondCrowMovementPath;

    public GameObject ingredient;
    public float timeForFirstSpline,timeForSecondSpline;
    void Start()
    {
        // Populate the first crow movement path
      

    }
    private void OnEnable()
    {
        splineFirstCrowMovementPath = new Vector3[splineParent1.transform.childCount];
        int index = 0;
        foreach (Transform child in splineParent1.transform)
        {
            splineFirstCrowMovementPath[index] = child.position;
            index++;
        }

        // Populate the second crow movement path (if needed)
        splineSecondCrowMovementPath = new Vector3[splineParent2.transform.childCount];
        index = 0;
        foreach (Transform child in splineParent2.transform)
        {
            splineSecondCrowMovementPath[index] = child.position;
            index++;
        }
        gameObject.LeanMoveSplineLocal(splineFirstCrowMovementPath, timeForFirstSpline).setOnComplete(() => {
            ingredient.gameObject.transform.parent = gameObject.transform.GetChild(0).gameObject.transform;
            ingredient.gameObject.transform.localPosition = Vector3.zero;

            gameObject.LeanMoveSplineLocal(splineSecondCrowMovementPath, timeForSecondSpline).setOnComplete(() =>
            {

                ingredient.gameObject.transform.parent = null;
                ingredient.gameObject.layer = LayerMask.NameToLayer("Default");

                ingredient.GetComponent<Ingredient>().enabled = true;
                gameObject.SetActive(false);


            });
        });
    }
}
