using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Gere les barres de vie des ennemis et des tourelles.
/// </summary>
public class GestionPv : MonoBehaviour
{
    [SerializeField] private BarreDeVie barDeVie;

    private float vieMax;
    private float vie;

    private string tagMonstre = "ennemi";
    // Start is called before the first frame update
    void Start()
    {
        vieMax = 1;
        vie = vieMax;
        barDeVie.SetMaxHealth(vieMax);
    }
    /// <summary>
    /// Fait subir des degat au point de vie de la tourelle ou du monstre.
    /// </summary>
    /// <param name="degat"></param>
    public void SubirDommage(float degat)
    {
        vie -= degat;
        if (vie <= 0 && gameObject != null)
        {
            if (gameObject.tag == tagMonstre)
            {
                SpawnerMonstre.SoustraireMonstre();
            }
            Destroy(gameObject);
        }
        else
        {
            barDeVie.SetHealth(vie);
        }
    }
}
