using System.Collections.Generic;
using UnityEngine;

public class ResetBoxes : MonoBehaviour
{
    private Dictionary<GameObject, Vector3> originalPositions = new Dictionary<GameObject, Vector3>();
    private CollisionCounter collisionCounter;
    private AudioSource audioSource;

    public AudioClip clickSound;

    void Start()
    {
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (GameObject box in boxes)
        {
            originalPositions.Add(box, box.transform.position);
        }

        collisionCounter = FindObjectOfType<CollisionCounter>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    ResetAllBoxes();
                    if (collisionCounter != null)
                    {
                        collisionCounter.IncrementErrorCount();
                    }
                    if (audioSource != null && clickSound != null)
                    {
                        audioSource.PlayOneShot(clickSound);
                    }
                }
            }
        }
    }

    private void ResetAllBoxes()
    {
        foreach (var entry in originalPositions)
        {
            entry.Key.transform.position = entry.Value;
            Rigidbody rb = entry.Key.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
