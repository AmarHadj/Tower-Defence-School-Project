using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionnaireDeJeu
{
    private static GestionnaireDeJeu _instance = new GestionnaireDeJeu();

    public bool isPaused
    {
        get;
        set;
    }
    public bool isOver
    {
        get;
        set;
    }

    private GestionnaireDeJeu()
    {
        isPaused = false;
        isOver = false;
    }

    public static GestionnaireDeJeu Instance()
    {
        return _instance;
    }
}
