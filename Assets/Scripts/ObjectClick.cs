using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    public float force = 3;

    private bool etatF = false;
    private bool etatO = true;

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            var rig = selection.GetComponent<Rigidbody>();

            if (hit.collider.gameObject.name == "Cube is pushed")
            {
                if (Input.GetMouseButton(0))
                {
                    Vector3 flatForward = Camera.main.transform.forward;
                    flatForward.y = 0;
                    flatForward.Normalize();

                    rig.AddForce(flatForward * 10);
                }
            }

            if (hit.collider.gameObject.name == "Cube goes flying")
            {
                if (Input.GetMouseButton(0))
                {
                    rig.AddForce(rig.transform.up * force, ForceMode.Impulse);
                }
            }

            if (hit.collider.gameObject.name == "Door Start")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    DoorManager doorManager = hit.collider.GetComponent<DoorManager>();

                    if (doorManager != null)
                    {
                        doorManager.ToggleDoor();
                    }
                    else
                    {
                        Debug.LogWarning("Pas de DoorManager sur l'objet cliqué.");
                    }
                }
            }

            if (hit.collider.gameObject.name == "Bouton Pont")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    DoorManager doorManager = hit.collider.GetComponent<DoorManager>();

                    if (doorManager != null)
                    {
                        doorManager.ToggleDoor();
                    }
                    else
                    {
                        Debug.LogWarning("Pas de DoorManager sur l'objet cliqué.");
                    }
                }
            }
        }
    }
}
