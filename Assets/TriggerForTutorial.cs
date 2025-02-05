using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForTutorial : MonoBehaviour
{
    // Start is called before the first frame update

    public string msg;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DialogueBox.instance.OnPopUpDialogueBox(msg);
        print("ontrigger for collisin fopr dialogue box");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
