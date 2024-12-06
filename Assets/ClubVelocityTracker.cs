using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubVelocityTracker : MonoBehaviour
{
    private Vector3 previousPosition; // Derni�re position de la canne
    private Quaternion previousRotation; 
    public Vector3 calculatedVelocity { get; private set; } // V�locit� calcul�e

    void Start()
    {
        previousPosition = transform.position; // Initialiser la position
        previousRotation = transform.rotation;
        calculatedVelocity = Vector3.zero; // Initialiser la v�locit�
    }

    void FixedUpdate()
    {
        // Calculer la v�locit� en fonction du d�placement
        calculatedVelocity = (transform.position - previousPosition) / Time.fixedDeltaTime;
        previousPosition = transform.position; // Mettre � jour la derni�re position
        previousRotation = transform.rotation; 
    }

}
