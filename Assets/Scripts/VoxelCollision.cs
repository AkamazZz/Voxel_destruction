using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelCollision : MonoBehaviour
{
    private Collider[] _hitColliders;
    [SerializeField] private float _blastRadius;
    [SerializeField] private float _explosionPower;
    [SerializeField] private LayerMask _explosionLayers;


    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.transform.root.CompareTag("Box"))
        {
            Explode(collision.contacts[0].point);
        }
    }
    private void Explode(Vector3 explosionPoint)
    {
        _hitColliders = Physics.OverlapSphere(explosionPoint, _blastRadius, _explosionLayers);
        foreach(Collider hitCollider in _hitColliders)
        {
            if(hitCollider.GetComponent<Rigidbody>() == null)
            {
                hitCollider.GetComponent<MeshRenderer>().enabled = true;
                hitCollider.gameObject.AddComponent<Rigidbody>();

                hitCollider.GetComponent<Rigidbody>().mass = 500;
                hitCollider.GetComponent<Rigidbody>().isKinematic = false;

                hitCollider.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * 5;
                hitCollider.GetComponent<Rigidbody>().AddExplosionForce(_explosionPower, explosionPoint, _blastRadius, 1, ForceMode.Impulse);

                
            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
