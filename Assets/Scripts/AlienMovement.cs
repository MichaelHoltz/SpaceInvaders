using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AlienMovement : MonoBehaviour
{
    private int moveDirection = 1;
    private float _moveMagnitude = 0f;
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _stepDownAmount = 0.2f;
    [SerializeField] private BoxCollider2D _outerBoundry;
    
    private int _childrenCount = 0;

    private void Start()
    {
        _moveMagnitude = Math.Abs(_moveSpeed);
        ResizeBoxCollider();
    }



    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.right * _moveSpeed * Time.deltaTime);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.layer == 6)
        {
            //Debug.Log($"Y position: {transform.position.y} StepDownAmount = {_stepDownAmount}");
            transform.position = new Vector3(transform.position.x, transform.position.y -_stepDownAmount, transform.position.y);
            moveDirection *= -1;
            _moveSpeed = _moveMagnitude * moveDirection;
        }
        if(collision.gameObject.layer == 8) //Laser
        {
            
            if (_childrenCount != transform.childCount)
            {
                _childrenCount = transform.childCount;
                _moveMagnitude += 0.3f;
                _stepDownAmount += 0.02f;
                Debug.Log($"AlienMovement Trigger detected: {collision.gameObject}. MoveSpeed: {_moveSpeed}");
            }
        }
    }
    private void ResizeBoxCollider()
    {
        if (_outerBoundry == null) return;

        float minX = float.MaxValue;
        float maxX = float.MinValue;
        bool hasChildren = false;
        
        foreach (Transform child in transform)
        {
            hasChildren = true;
            Collider2D childCollider = child.GetComponent<Collider2D>();
            if (childCollider != null)
            {
                float childMinX = child.position.x - (childCollider.bounds.size.x );
                float childMaxX = child.position.x + (childCollider.bounds.size.x );

                if (childMinX < minX) minX = childMinX;
                if (childMaxX > maxX) maxX = childMaxX;
            }
        }

        if (!hasChildren)
        {
            // No children, reset the size
            _outerBoundry.size = new Vector2(1, _outerBoundry.size.y);
            _outerBoundry.offset = Vector2.zero;
        }
        else
        {
            // Resize the BoxCollider2D based on children positions
            float newWidth = maxX - minX;
            _outerBoundry.size = new Vector2(newWidth, _outerBoundry.size.y);
            _outerBoundry.offset = new Vector2((minX + maxX) / 2 - transform.position.x, _outerBoundry.offset.y);
        }
    }

    private void OnTransformChildrenChanged()
    {
        Debug.Log("AlienMovement: OnTransformChildrenChanged");
        ResizeBoxCollider();
    }
}
