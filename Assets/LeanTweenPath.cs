using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLeanTweenPath", menuName = "ScriptableObjects/LeanTweenPath", order = 1)]
public class LeanTweenPath : ScriptableObject
{
    public Vector3[] pathPoints;
}