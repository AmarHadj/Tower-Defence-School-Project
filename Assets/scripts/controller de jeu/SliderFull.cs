using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Barre de progression pour placer les tourelles.
/// </summary>
public class SliderFull : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Text nombreTourTxt;

    private float valeurSlide = 0.1f;
    public static int nombreTour { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0f;
        StartCoroutine(RemplireSlide());
    }

    /// <summary>
    /// Coroutine qui remplie sans cesse la barre de progression tant que le jeu est encore en cours de fonctionnement.
    /// </summary>
    /// <returns></returns>
    private IEnumerator RemplireSlide()
    {

        while (GestionnaireDeJeu.Instance().isOver == false)
        {
            slider.value += valeurSlide;
            if (slider.value == 1)
            {
                nombreTour++;
                slider.value = 0;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    // Update is called once per frame.
    void Update()
    {
        nombreTourTxt.text = nombreTour.ToString();
    }

    /// <summary>
    /// Soustrait une tour au nombre de tours total.
    /// </summary>
    public static void SoustraireTours()
    {
        nombreTour--;
    }
    
}
