using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    // Start is called before the first frame update
    public static DialogueBox instance;

    [Header("DialogueRelated")]

    [SerializeField]
    private TMP_Text tmp_DialogueField;
    [SerializeField]

    private GameObject canvasForDialogue;
    void Start()
    {
        instance = this;
    }
    public void PopUpDialogueBox(string msg,Vector3 positionToSpawn,float waitTime = 5)
    {
        StartCoroutine(waitForSecondsPopUpAndDissolve(msg,positionToSpawn, waitTime));
    }

    private IEnumerator waitForSecondsPopUpAndDissolve(string msg,Vector3 postionToSpawn, float waitTime = 5)
    {
        tmp_DialogueField.text = msg;
        canvasForDialogue.transform.position = postionToSpawn;
        canvasForDialogue.SetActive(true);
        yield return new WaitForSeconds(waitTime);

        canvasForDialogue.SetActive(false);


    }

    public void OnPopUpDialogueBox(string msg)
    {
        tmp_DialogueField.text = msg;
        canvasForDialogue.SetActive(true);

    }
    public void DeactivateDialogueBox()
    {
        canvasForDialogue.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
