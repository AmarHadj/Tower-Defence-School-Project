using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Place les tours en cliquant sur le bouton puis sur le sol.
/// </summary>
public class PlacementTour : MonoBehaviour
{
    [SerializeField] private GameObject tourelle;
    [SerializeField] private Collider colliderPlan;
    [SerializeField] private AffichageEcran affichage;

    private bool cliquer;

    // Update is called once per frame
    void Update()
    {
        AjouterTourelle();
        if (LockTourelle.tourelles.Length == 0)
        {
            affichage.Defaite();
        }
    }
    /// <summary>
    /// Ajoute une tourelle sur le terrain.
    /// </summary>
    public void AjouterTourelle()
    {
        if (Input.GetMouseButtonDown(0) && cliquer)
        {
            Vector3 position = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(position);
            RaycastHit hit = new RaycastHit();
            Physics.Raycast(ray, out hit);

            if (hit.collider == colliderPlan && GestionnaireDeJeu.Instance().isPaused == false && GestionnaireDeJeu.Instance().isOver == false)
            {
                int nombreTour = SliderFull.nombreTour;
                if (nombreTour > 0)
                {
                    Instantiate(tourelle, hit.point, Quaternion.identity);
                    SliderFull.SoustraireTours();
                }
            }
            cliquer = false;
        }
    }
    /// <summary>
    /// Active le bouton pour ajouter une tour.
    /// </summary>
    public void OnClick()
    {
        cliquer = true;
    }
    

}
