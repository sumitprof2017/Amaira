using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yak : Friend
{
    [SerializeField]
    float moveSpeed; 
    
    [SerializeField]
    Transform playerPositionOnYak;

    public override void Move()
    {
        gameObject.transform.position += new Vector3(moveSpeed, 0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(letStartMoving)
        Move();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Collided with Player!");
            StartYakATtack(collision.gameObject);
            // Additional logic here
        }
    }
    bool letStartMoving = false;
   
    GameObject playerRef;
    void StartYakATtack(GameObject player)
    {
        AudioController.instance.YakAttackClip(friendlyBgClip);
        player.GetComponent<PlayerMovement>().enabled = false;
        player.transform.position = playerPositionOnYak.position;
        player.transform.parent = transform;
        playerRef = player;
        letStartMoving = true;
        StartCoroutine(EndYakAttack());
    }

    private IEnumerator EndYakAttack()
    {
        yield return new WaitForSeconds(8f);
        AudioController.instance.PlayBgClip();

        playerRef.GetComponent<PlayerMovement>().enabled = true;

        letStartMoving = false;
        playerRef.transform.parent = null;
        gameObject.SetActive(false);

    }
}
