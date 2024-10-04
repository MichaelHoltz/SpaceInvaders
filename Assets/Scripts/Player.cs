using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private GameInput _gameInput;
    [SerializeField] private bool _allowMovementUpDown = false;
    
    // Update is called once per frame
    private void FixedUpdate()
    {

        if (_allowMovementUpDown)
        {
            Vector2 inputVector = _gameInput.GetMovementVectorNormalized();


            //If allow movement up and down else only move left and right
            Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0);
            transform.position += moveDir * Time.deltaTime * _moveSpeed;
        }
        else
        {
            Vector2 inputVector = _gameInput.GetMovementVectorNormalized();
            float sign = 0;
            if(inputVector.x > 0)
            {
                sign = 1;
            }
            else if (inputVector.x < 0)
            {
                sign = -1;
            }

            //If allow movement up and down else only move left and right
            Vector3 moveDir = new Vector3(inputVector.magnitude * sign, 0, 0);
            transform.position += moveDir * Time.deltaTime * _moveSpeed;

        }
    }
}
