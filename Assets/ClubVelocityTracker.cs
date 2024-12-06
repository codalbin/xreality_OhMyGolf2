using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubVelocityTracker : MonoBehaviour
{
    private Vector3 previousPosition; // Dernière position de la canne
    private Quaternion previousRotation; 
    public Vector3 calculatedVelocity { get; private set; } // Vélocité calculée

    void Start()
    {
        previousPosition = transform.position; // Initialiser la position
        previousRotation = transform.rotation;
        calculatedVelocity = Vector3.zero; // Initialiser la vélocité
    }

    void FixedUpdate()
    {
        // Calculer la vélocité en fonction du déplacement
        calculatedVelocity = (transform.position - previousPosition) / Time.fixedDeltaTime;
        previousPosition = transform.position; // Mettre à jour la dernière position
        previousRotation = transform.rotation; 
    }

}
