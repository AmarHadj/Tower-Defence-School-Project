using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Fait bouger la camera
/// </summary>
public class mouvementCamera : MonoBehaviour
{
    [SerializeField] private float vitesse;
    [SerializeField] private float vitesseDescente;
    [SerializeField] private float vitesseMontante;
    [SerializeField] private float vitesseSprint;

    private CharacterController _charControl;
    // Start is called before the first frame update
    void Start()
    {
        _charControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float sprint = Input.GetAxis("Sprint") * vitesse * Time.deltaTime * vitesseSprint;
        float x = Input.GetAxis("Horizontal") * vitesse * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * vitesse * Time.deltaTime;
        float y = 0;
        if (Input.GetButtonDown("descendre") && GestionnaireDeJeu.Instance().isPaused == false && GestionnaireDeJeu.Instance().isOver == false)
        {
            y = transform.position.y * vitesseDescente * Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump") && GestionnaireDeJeu.Instance().isPaused == false && GestionnaireDeJeu.Instance().isOver == false)
        {
            y = transform.position.y * vitesseMontante * Time.deltaTime;
        }

        if (Input.GetButton("Sprint") && Input.GetButton("w") && GestionnaireDeJeu.Instance().isPaused == false && GestionnaireDeJeu.Instance().isOver == false)
        {
            Vector3 deltaSprint = transform.TransformDirection(new Vector3(x, y, sprint));
            _charControl.Move(deltaSprint);
        }
        if (Input.GetButton("Sprint") && Input.GetButton("s") && GestionnaireDeJeu.Instance().isPaused == false && GestionnaireDeJeu.Instance().isOver == false)
        {
            Vector3 deltaSprint = transform.TransformDirection(new Vector3(x, y, -sprint));
            _charControl.Move(deltaSprint);
        }
        if (Input.GetButton("Sprint") && Input.GetButton("d") && GestionnaireDeJeu.Instance().isPaused == false && GestionnaireDeJeu.Instance().isOver == false)
        {
            Vector3 deltaSprint = transform.TransformDirection(new Vector3(sprint, y, z));
            _charControl.Move(deltaSprint);
        }
        if (Input.GetButton("Sprint") && Input.GetButton("a") && GestionnaireDeJeu.Instance().isPaused == false && GestionnaireDeJeu.Instance().isOver == false)
        {
            Vector3 deltaSprint = transform.TransformDirection(new Vector3(-sprint, y, z));
            _charControl.Move(deltaSprint);
        }

        Vector3 delta = transform.TransformDirection(new Vector3(x, y, z));
        if (GestionnaireDeJeu.Instance().isPaused == false && GestionnaireDeJeu.Instance().isOver == false)
        {
            _charControl.Move(delta);
        }
        
    }

}
