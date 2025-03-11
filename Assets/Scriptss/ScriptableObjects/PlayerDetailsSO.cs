using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInitialDetail", menuName = "Game/PlayerDetail")]
public class PlayerDetailsSO : ScriptableObject
{
    // Start is called before the first frame update
    public string sceneName; 
    public int checkpointNumber;
    public string playerSkin;
    public Vector3 checkpointPosition;
    public bool isContinueButtonClicked;
}
