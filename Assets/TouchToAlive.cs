using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchToAlive : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [Header("DialogRelatedStuff")]
    [SerializeField]
    Transform dialogSpawnPosition;
    public string msg;
    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Prakriti"))
        {
            print("returned");
            return;
        }
        int layer = LayerMask.NameToLayer("UI");
        if (layer != -1) // -1 means the layer name is invalid
        {
            gameObject.layer = layer;
        }


        spriteRenderer.color = Color.white;
        if (dialogSpawnPosition != null)
        {

            DialogueBox.instance.PopUpDialogueBox(msg, dialogSpawnPosition.position, waitTime);
        }
    }
  /*  public void OnCollisionEnter2D(Collision2D collision)
    {
      //  print("collision is called" + collision.gameObject.name);
        if (collision.gameObject.layer != LayerMask.NameToLayer("Prakriti"))
        {
            print("returned");
            return;
        }
        spriteRenderer.color = Color.white;
        if (dialogSpawnPosition != null)
        {

            DialogueBox.instance.PopUpDialogueBox(msg, dialogSpawnPosition.position, 3);
        }
    }*/

   

  
}
