using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
/// <summary>
/// Dirige les monstre, les fait choisir une cible et les fait tirer dessus.
/// </summary>
public class LockTourelle : MonoBehaviour
{
    [SerializeField] private GameObject bouleDeFeu;
    [SerializeField] private GameObject shootPoint;// l'endroit ou la boule de feu va etre creer.
    [SerializeField] private float vitesse;
    [SerializeField] private float portee;
    [SerializeField] private float cadenceTire;

    private Transform positionTourelle;
    private GameObject bouleTempo;
    private NavMeshAgent _meshAgent;
    private string tagTourelle = "tourDefense";
    private float compteurTire = 0f;
    
    public static GameObject[] tourelles { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        _meshAgent = GetComponent<NavMeshAgent>();
        _meshAgent.speed = vitesse;
        tourelles = GameObject.FindGameObjectsWithTag(tagTourelle);
        InvokeRepeating("UpdateCible", 0f, 0.5f);
    }
    //Update is called once per frame
    void Update()
    {
        Deplacement();
        TirerCible();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, portee);
    }
    /// <summary>
    /// Met a jour la cible pour que le monstre ne se concentre uniquement sur la cible la plus proche.
    /// </summary>
    public void UpdateCible()
    {
        tourelles = GameObject.FindGameObjectsWithTag(tagTourelle);
        float distancePlusProche = Mathf.Infinity;
        GameObject ennemiPlusProche = null;
        foreach (GameObject ennemi in tourelles)
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
            _meshAgent.speed = 0;
            positionTourelle = ennemiPlusProche.transform;
        }
        else
        {
            _meshAgent.speed = vitesse;
            positionTourelle = null;
        }
    }
    /// <summary>
    /// Cree une boule de feu en face du monstre.
    /// </summary>
    public void CreerBoule()
    {
        if (positionTourelle != null)
        {
            bouleTempo = Instantiate(bouleDeFeu, shootPoint.transform.position, Quaternion.identity);
            Tirer boule = bouleTempo.GetComponent<Tirer>();
            if (boule != null)
            {
                boule.SetCible(positionTourelle);
            }
        }

    }
    /// <summary>
    /// Tire sur la cible de maniere reguliere.
    /// </summary>
    public void TirerCible()
    {
        if (positionTourelle == null)
            return;
        if (compteurTire <= 0f)
        {
            CreerBoule();
            compteurTire = 1f / cadenceTire;
        }

        compteurTire -= Time.deltaTime;
    }
    /// <summary>
    /// Fait deplacer les ennemis vers les tourelles.
    /// </summary>
    public void Deplacement()
    {
        try
        {
            if (tourelles.Length == 1 && tourelles[0] != null)
            {
                _meshAgent.destination = tourelles[0].transform.position;
            }
            else if (tourelles[0] != null)
            {
                _meshAgent.destination = tourelles[tourelles.Length - 1].transform.position;
            }
        }
        catch (IndexOutOfRangeException)
        {
            _meshAgent.isStopped = true;
        }
        catch (MissingReferenceException)
        {
            return;
        }
    }
}
