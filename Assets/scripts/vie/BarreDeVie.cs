using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// La barre de vie des tours et des monstres.
/// </summary>
public class BarreDeVie : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }


    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
