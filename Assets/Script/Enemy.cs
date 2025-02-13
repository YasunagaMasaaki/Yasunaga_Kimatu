using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] float fallSpeed;
    

    void Start()
    {
        this.fallSpeed = 0.005f;
        
    }

    void Update()
    {
        transform.Translate(0, -fallSpeed, 0, Space.World);

        if (transform.position.y < -5.5f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
