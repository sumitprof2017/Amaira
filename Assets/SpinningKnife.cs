using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningKnife : MonoBehaviour
{
    public GameObject splineParent;
    // Start is called before the first frame update
    public Vector3 rotationSpeed = new Vector3(0, 0, 200); // degrees per second

    Vector3[] arrayForSpline;

    GameObject visualEffectsToSpin;

    public float timeForSplineMovement;
    private void Start()
    {
        visualEffectsToSpin = transform.GetChild(0).gameObject;
        arrayForSpline = new Vector3[splineParent.gameObject.transform.childCount];
        int i = 0;
        foreach (Transform child in splineParent.gameObject.transform)
        {
            arrayForSpline[i] = child.transform.position;
            i++;
        }
        MoveInASpline();
    }

    void MoveInASpline()
    {
        gameObject.LeanMoveSplineLocal(arrayForSpline, timeForSplineMovement).setOnComplete(() =>
        {

            MoveInASpline();
        });

    }

    void FixedUpdate()
    {
        // Time.fixedDeltaTime ensures smooth rotation in FixedUpdate
        visualEffectsToSpin.transform.Rotate(rotationSpeed * Time.fixedDeltaTime);
    }
}
