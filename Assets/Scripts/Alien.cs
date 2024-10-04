using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Alien Trigger detected: {collision.gameObject}");
        //Debug.Log($"Laser Trigger detected: {collision.gameObject}");
        if (collision.gameObject.layer == 8)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
}
