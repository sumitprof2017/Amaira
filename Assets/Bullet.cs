using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      //  BulletController.instance.RestoreBulletFunction(gameObject, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
