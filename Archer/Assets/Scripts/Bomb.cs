using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionForce;
    public float explosionRadius;
    public GameObject explosion;
    public LayerMask layer;

   

    public  void Explosion()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Debug.Log("Patladý");
        Collider[] objects = UnityEngine.Physics.OverlapSphere(transform.position, explosionRadius,layer);
        foreach (Collider h in objects)
        {
            Rigidbody r = h.GetComponent<Rigidbody>();
            if (r != null)
            {
                r.AddExplosionForce(explosionForce, transform.position, explosionRadius,layer);
            }
        }
        gameObject.SetActive(false);
        Invoke("Destroy", 3f);
    }

    void Destroy()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
    
}
