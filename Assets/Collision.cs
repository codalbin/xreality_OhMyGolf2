using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{

    public float forceMultiplier = 10f; // Multiplieur pour ajuster la force appliquée

    private Rigidbody rb;

    private Dictionary<Collider, float> ignoredCollisions = new Dictionary<Collider, float>();

    void Start()
    {
        // Obtenir le Rigidbody de l'objet
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        List<Collider> toReactivate = new List<Collider>();

        foreach (var entry in ignoredCollisions)
        {
            if (Time.time - entry.Value >= 0.05f)
            {
                Physics.IgnoreCollision(entry.Key, GetComponent<Collider>(), false); // Reactive la collision
                toReactivate.Add(entry.Key); // Ajoute a la liste de suppression
            }
        }

        foreach (var collider in toReactivate)
        {
            ignoredCollisions.Remove(collider);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider otherCollider = collision.collider;

        if (ignoredCollisions.ContainsKey(otherCollider))
        {
            // Ignore la collision
            return;
        }

        if (otherCollider.CompareTag( "Enemy"))
        {
            Debug.Log("Golf collision enemy");
            // Calculer la force de la collision
            Vector3 collisionForce = collision.impulse / Time.fixedDeltaTime;

            // Appliquer une force proportionnelle à l'impact, ajustée par le multiplicateur
            rb.AddForce(collisionForce * forceMultiplier, ForceMode.Impulse);

            Physics.IgnoreCollision(otherCollider, GetComponent<Collider>(), true);
            ignoredCollisions[otherCollider] = Time.time;
        }
    }
}
