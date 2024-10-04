using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Laser : MonoBehaviour
{
    public static Laser StaticInstance;
    //public event EventHandler OnEnemyHit;

    [SerializeField] private float _moveSpeed = 4f;
    [Tooltip("1 = up, -1 = down")]
    [SerializeField] private int _moveDirection = 1;

    private void Awake()
    {
        StaticInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * _moveDirection * _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 6) //If miss and going into the void
        { 
            Destroy(gameObject);
        }
    }
}
