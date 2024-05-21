using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Dirige le projectile sur la cible
/// </summary>
public class Tirer : MonoBehaviour
{

    [SerializeField] private float vitesse;
    [SerializeField] private float hauteur;
    [SerializeField] private float degat;

    private Transform cible;
    private GestionPv ciblePv;
    private Vector3 cibleVector3;
    private Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        DirigerProjectile();
    }

    /// <summary>
    /// Choisit la cible du tire 
    /// </summary>
    /// <param name="_cible"></param>
    public void SetCible(Transform _cible)
    {
        cible = _cible;
        ciblePv = cible.GetComponent<GestionPv>();
        cibleVector3 = new Vector3(cible.transform.position.x, cible.transform.position.y + hauteur, cible.transform.position.z);
    }

    /// <summary>
    /// Enleve les points de vie sur la cible et supprime le projectile.
    /// </summary>
    private void Touche()
    {
        ciblePv.SubirDommage(degat);
        Destroy(gameObject);
    }

    /// <summary>
    /// retourne les degats.
    /// </summary>
    /// <returns></returns>
    public float GetDegat()
    {
        return degat;
    }

    /// <summary>
    /// Dirige le projectile vers sa cible.
    /// </summary>
    private void DirigerProjectile()
    {
        if (cible == null)
        {
            Destroy(gameObject);
        }
        if (cible != null)
        {
            if (hauteur != 0)
            {
                direction = cibleVector3 - transform.position;
            }
            else
            {
                direction = cible.position - transform.position;
            }

            float distance = vitesse * Time.deltaTime;
            if (direction.magnitude <= distance)
            {
                Touche();
            }

            transform.Translate(direction.normalized * distance, Space.World);
        }
    }
}
