using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{

    public float forceMultiplier = 10f; // Multiplieur pour ajuster la force appliquée

    private Rigidbody rb;

    //private Dictionary<Collider, float> ignoredCollisions = new Dictionary<Collider, float>();

    void Start()
    {
        // Obtenir le Rigidbody de l'objet
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //List<Collider> toReactivate = new List<Collider>();

        //foreach (var entry in ignoredCollisions)
        //{
        //    if (Time.time - entry.Value >= 0.05f)
        //    {
        //        Physics.IgnoreCollision(entry.Key, GetComponent<Collider>(), false); // Reactive la collision
        //        toReactivate.Add(entry.Key); // Ajoute a la liste de suppression
        //    }
        //}

        //foreach (var collider in toReactivate)
        //{
        //    ignoredCollisions.Remove(collider);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider otherCollider = collision.collider;

        //if (ignoredCollisions.ContainsKey(otherCollider))
        //{
        //    // Ignore la collision
        //    return;
        //}

        if (otherCollider.CompareTag( "Enemy"))
        {
            Rigidbody clubRb = collision.rigidbody; // Get the Rigidbody of the club
            ClubVelocityTracker clubTracker = otherCollider.GetComponent<ClubVelocityTracker>();

            if (clubRb != null && clubTracker != null)
            {
                Vector3 clubVelocity = collision.transform.TransformDirection(clubTracker.calculatedVelocity);
                float hitStrength = clubVelocity.magnitude * 2f; // Ajuster le multiplicateur si nécessaire

                Debug.Log("Relative Velocity Magnitude: " + clubVelocity.magnitude);
                Debug.Log("Hit Strength: " + hitStrength);

                // Calculer la direction de l'impact
                Vector3 hitDirection = collision.transform.InverseTransformPoint(transform.position);
                //Vector3 hitDirection = transform.position - collision.transform.position;
                hitDirection.Normalize();
                //float hitDirectionx = hitDirection.x;
                //hitDirection.x = hitDirection.z;
                //hitDirection.z *= 0.15f;
                //hitDirection.z = hitDirectionx;
                //hitDirection.z = 0;

                Vector3 worldHitDirection = collision.transform.TransformDirection(hitDirection);

                Vector3 clubScale = collision.transform.lossyScale;

                Vector3 scaledHitDirection = Vector3.Scale(worldHitDirection, clubScale);
                scaledHitDirection.Normalize(); 

                Debug.Log("hitDirection: " + scaledHitDirection);
                scaledHitDirection.y = 0f; // Pas de force vers le haut

                // Appliquer la force calculée
                rb.AddForce(scaledHitDirection * hitStrength, ForceMode.Impulse);
            }

            //Rigidbody clubRb = collision.rigidbody; // Get the Rigidbody of the club
            //if (clubRb != null)
            //{
            //    // Calculate hit direction and strength based on club velocity
            //    Vector3 collisionForce = collision.impulse / Time.fixedDeltaTime;
            //    Vector3 hitDirection = transform.position - collision.transform.position; // Direction from club to ball
            //    //hitDirection.Normalize(); // Normalize direction vector

            //    Debug.Log("collisionForce : " + collisionForce);
            //    float hitStrength = clubRb.velocity.magnitude * 10f; // Adjust multiplier as needed
            //    Debug.Log("clubRb.velocity.magnitude : " + clubRb.velocity.magnitude);
            //    rb.AddForce(hitDirection * (float)0.1, ForceMode.Impulse);

            //    Vector3 contactPoint = collision.contacts[0].point;
            //    Vector3 collisionNormal = collision.contacts[0].normal;
            //    Vector3 forceDirection = -collisionNormal.normalized;

            //    float forceMagnitude = 1000f;

            //    rb.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);

            //}

            //Debug.Log("Golf collision enemy");
            //// Calculer la force de la collision
            //Vector3 collisionForce = collision.impulse / Time.fixedDeltaTime;
            //collisionForce.Normalize();

            //Debug.Log("collisionForce : " + collisionForce);
            //// Appliquer une force proportionnelle à l'impact, ajustée par le multiplicateur
            //rb.AddForce(collisionForce * forceMultiplier, ForceMode.Impulse);

            ////Physics.IgnoreCollision(otherCollider, GetComponent<Collider>(), true);
            ////ignoredCollisions[otherCollider] = Time.time;
        }
    }
}
