using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
/// <summary>
/// Fait apparaitre des monstres.
/// </summary>
public class SpawnerMonstre : MonoBehaviour
{
    [SerializeField] private GameObject monstre;
    [SerializeField] private Text nombreMonstreTxt;
    [SerializeField] private AffichageEcran affichage;

    private NavMeshAgent _meshAgent;
    private Vector3 spawnPoint;
    public static int nombreMonstreUI { get; private set; }
    private int nombreMonstre;
    private float tempDeRefroidissement = 1f;
    // Start is called before the first frame update
    void Start()
    {
        nombreMonstre = 25;
        nombreMonstreUI = nombreMonstre;
        _meshAgent = monstre.GetComponent<NavMeshAgent>();
        spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z - 8);
        StartCoroutine(SpawnCooldown());
    }
    
    // Update is called once per frame
    void Update()
    {
        nombreMonstreTxt.text = "" + nombreMonstreUI;
        if (nombreMonstreUI == 0)
        {
            affichage.Victoire();
        }
    }
    /// <summary>
    /// coroutine qui fait apparaitre les monstre a chaque 5 secondes.
    /// </summary>
    /// <returns></returns>
    public IEnumerator SpawnCooldown()
    {

        for (int i = 0; i < nombreMonstre; i++)
        {
            SpawnMonstre();
            yield return new WaitForSeconds(tempDeRefroidissement);
            if (GestionnaireDeJeu.Instance().isOver)
            {
                break;
            }
        }
    }
    /// <summary>
    /// méthode pour faire apparaitre un monstre a coté de la hutte pour monstre.
    /// </summary>
    public void SpawnMonstre()
    {
        GameObject nouveauMonstre = GameObject.Instantiate(monstre);
        _meshAgent.Warp(spawnPoint);
    }
    /// <summary>
    /// Soustrait un monstre au nombre de monstres total.
    /// </summary>
    public static void SoustraireMonstre()
    {
        nombreMonstreUI--;
    }
}
