using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Affiche la pause, la defaite et la victoire.
/// </summary>
public class AffichageEcran : MonoBehaviour
{
    [SerializeField] private GameObject victoireUI;
    [SerializeField] private GameObject defaiteUI;
    [SerializeField] private GameObject pauseUI;

    private float tempsAvantQuitter = 5f;

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (GestionnaireDeJeu.Instance().isPaused && GestionnaireDeJeu.Instance().isOver == false)
            {
                Resume();
            }
            else if(GestionnaireDeJeu.Instance().isOver == false)
            {
                Pause();
            }
        }

    }
    /// <summary>
    /// Lance une coroutine afin d'afficher la victoire du joueur.
    /// </summary>
    public void Victoire()
    {
        StartCoroutine(Quitter(victoireUI));
    }
    /// <summary>
    /// Lance une coroutine afin d'afficher la défaite du joueur.
    /// </summary>
    public void Defaite()
    {
        StartCoroutine(Quitter(defaiteUI));
    }
    /// <summary>
    /// Met en pause le jeu lorsque le joueur appuye sur la touche echape.
    /// </summary>
    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        GestionnaireDeJeu.Instance().isPaused = true;

    }
    /// <summary>
    /// Reprend la partie apres avoir appuyer sur echape si le jeu est en pause.
    /// </summary>
    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        GestionnaireDeJeu.Instance().isPaused = false;

    }
    /// <summary>
    /// Coroutine qui affiche le message de victoire ou de defaite et qui quitte le jeu apres 5 secondes.
    /// </summary>
    /// <param name="gameObjectUI"></param>
    /// <returns></returns>
    public IEnumerator Quitter(GameObject gameObjectUI)
    {
        gameObjectUI.SetActive(true);
        GestionnaireDeJeu.Instance().isOver = true;
        yield return new WaitForSeconds(tempsAvantQuitter);
        Application.Quit();
    }
}
