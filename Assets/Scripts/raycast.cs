using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    float RaycastDistancia = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * RaycastDistancia, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, RaycastDistancia))
        {
            if (hitInfo.collider.gameObject.tag == "Player")
            {
                AgentScript.Instance.patrullando = false;
                AgentScript.Instance.jugadorEnVision = true;
                AgentScript.Instance.tiempoSinVision = 0; 
            }
        }
        if (!AgentScript.Instance.patrullando)
        {
            AgentScript.Instance.jugadorEnVision = false;
        }
    }
}
