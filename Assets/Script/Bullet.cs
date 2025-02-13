using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(0, 0.03f, 0);
        if(transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        GameObject.Find("Canvas").GetComponent<UI>().AddScore();

        Destroy(coll.gameObject);
        Destroy(gameObject);
    }
}
