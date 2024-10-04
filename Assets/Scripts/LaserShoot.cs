using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{
    [SerializeField] private GameInput _gameInput;
    [SerializeField] private GameObject _laserPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_gameInput.IsFireButtonPressed())
        {
            Vector3 gunPosition = new Vector3(transform.position.x, transform.position.y + 0.7f, 0);
            Instantiate(_laserPrefab, gunPosition, Quaternion.identity);
        }
    }


}
