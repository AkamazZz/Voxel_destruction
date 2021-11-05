using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField] private GameObject _mesh;
    private float _cubeWidth;
    private float _cubeHeight;
    private float _cubeDepth;

    [SerializeField] private float _cubeScale = 0.3f;

    private void Start()
    {
        InitializeCubeSize();
        
    }
    private void InitializeCubeSize()
    {
        _cubeWidth = transform.localScale.z;
        _cubeHeight = transform.localScale.y;
        _cubeDepth = transform.localScale.x;
        _mesh.gameObject.GetComponent<Transform>().localScale = new Vector3(_cubeScale, _cubeScale, _cubeScale);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            CreateCubes();
            onTouchDeleteInitial();
        }
    }
    private void onTouchDeleteInitial()
    {
        Destroy(gameObject);
    }
    private void CreateCubes()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;    
        for (float x=0;x<_cubeWidth;x +=_cubeScale)
        {
            for (float y=0; y<_cubeHeight; y+=_cubeScale)
            {
                for (float z = 0; z<_cubeDepth; z+=_cubeScale)
                {
                    Vector3 currentPosition = transform.position;
                    GameObject cubes = (GameObject) Instantiate(_mesh, currentPosition + new Vector3(x, y, z), Quaternion.identity);
                    cubes.gameObject.GetComponent<MeshRenderer>().material = gameObject.GetComponent<MeshRenderer>().material;
                }
            }
        }
    }
}
