using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {

    }

    //public Vector3 moveDirection = new Vector3(1, 0, 0); // Direction du mouvement
    //public float moveSpeed = 5f; // Vitesse du mouvement

    //void OnCollisionEnter(Collision collision)
    //{
    //    // V�rifie si l'objet qui entre en collision a le tag souhait�
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        // Applique un mouvement � cet objet
    //        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    //    }
    //}

    public float forceMultiplier = 10f; // Multiplieur pour ajuster la force appliqu�e

    private Rigidbody rb;

    public GameObject golfFlag;  // R�f�rence � l'objet golf_flag
    private Renderer golfFlagRenderer;

    void Start()
    {
        // Obtenir le Rigidbody de l'objet
        rb = GetComponent<Rigidbody>();

        // S'assurer qu'on a une r�f�rence � l'objet golf_flag et obtenir son Renderer
        if (golfFlag != null)
        {
            golfFlagRenderer = golfFlag.GetComponent<Renderer>();
        }
        else
        {
            Debug.LogError("golfFlag n'est pas assign� dans l'inspecteur.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Golf collision enemy");
            // Calculer la force de la collision
            Vector3 collisionForce = collision.impulse / Time.fixedDeltaTime;

            // Appliquer une force proportionnelle � l'impact, ajust�e par le multiplicateur
            rb.AddForce(collisionForce * forceMultiplier, ForceMode.Impulse);
        }

        if (collision.gameObject.name == "hole")
        {
            // V�rifier si le Renderer de golf_flag existe
            if (golfFlagRenderer != null)
            {
                // Changer la couleur de l'objet "golf_flag" en une couleur sp�cifique
                golfFlagRenderer.material.color = Color.green;  // Par exemple, changer la couleur en rouge
            }
            else
            {
                Debug.LogError("Le Renderer de golfFlag est introuvable.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "hole")
        {
            // V�rifier si le Renderer de golf_flag existe
            if (golfFlagRenderer != null)
            {
                // Changer la couleur de l'objet "golf_flag" en une couleur sp�cifique
                golfFlagRenderer.material.color = Color.green;  // Par exemple, changer la couleur en rouge
            }
            else
            {
                Debug.LogError("Le Renderer de golfFlag est introuvable.");
            }
        }
    }
}
