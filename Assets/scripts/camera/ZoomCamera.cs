using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// zoom et dezoom la camera
/// </summary>
public class ZoomCamera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && GestionnaireDeJeu.Instance().isPaused == false && GestionnaireDeJeu.Instance().isOver == false)
        {
            GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z + 0.3f);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && GestionnaireDeJeu.Instance().isPaused == false && GestionnaireDeJeu.Instance().isOver == false)
        {
            GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z - 0.3f);
        }
    }
}
