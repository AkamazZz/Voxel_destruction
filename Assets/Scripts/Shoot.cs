using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private float _speed = 5;

   
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
        {
            var spawnFurther = _point.transform.position;
         
            GameObject bullet = Instantiate(_projectile, spawnFurther, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward*_speed, ForceMode.Impulse);
        }
    }
}
