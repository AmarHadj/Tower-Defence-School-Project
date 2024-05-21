using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Choisis une cible pour le cannon, et la fait tirer dessus.
/// </summary>
public class CannonTir : MonoBehaviour
{
    [SerializeField] private GameObject boulletDeCannon;
    [SerializeField] private GameObject shootPoint;// l'endroit ou le boulet de cannon va etre creer.
    [SerializeField] private float portee = 0f;
    [SerializeField] private float cadenceTire;

    private Transform positionEnnemi;
    private GameObject bouleTempo;
    private string tagEnnemi = "ennemi";
    private float compteurTire = 0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateCible", 0f, 0.5f);
    }
    //Update is called once per frame
    void Update()
    {
        TirerCible();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, portee);
    }
    /// <summary>
    /// Met a jour la cible pour que la tourelle ne se concentre uniquement sur la cible la plus proche.
    /// </summary>
    public void UpdateCible()
    {
        GameObject[] ennemis = GameObject.FindGameObjectsWithTag(tagEnnemi);
        float distancePlusProche = Mathf.Infinity;
        GameObject ennemiPlusProche = null;
        foreach (GameObject ennemi in ennemis)
        {
            float distanceEnnemi = Vector3.Distance(transform.position, ennemi.transform.position);
            if (distanceEnnemi < distancePlusProche)
            {
                distancePlusProche = distanceEnnemi;
                ennemiPlusProche = ennemi;
            }
        }

        if (ennemiPlusProche != null && distancePlusProche <= portee)
        {
            positionEnnemi = ennemiPlusProche.transform;
        }
        else
        {
            positionEnnemi = null;
        }
    }
    /// <summary>
    /// Cree une boulet de canon en face du canon.
    /// </summary>
    public void CreerBoule()
    {
        if (positionEnnemi != null)
        {
            bouleTempo = Instantiate(boulletDeCannon, shootPoint.transform.position, Quaternion.identity);
            Tirer boule = bouleTempo.GetComponent<Tirer>();
            if (boule != null)
            {
                boule.SetCible(positionEnnemi);
            }
        }

    }
    /// <summary>
    /// Tire sur la cible de maniere reguliere.
    /// </summary>
    public void TirerCible()
    {
        if (positionEnnemi == null)
            return;
        if (compteurTire <= 0f)
        {
            CreerBoule();
            compteurTire = 1f / cadenceTire;
        }

        compteurTire -= Time.deltaTime;
    }
}
