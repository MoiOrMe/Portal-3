using UnityEngine;

public class OutsideMap : MonoBehaviour
{
    public Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (spawnPoint != null)
            {
                Debug.Log("Joueur détecté : Téléportation au spawnPoint.");

                CharacterController controller = other.GetComponent<CharacterController>();
                if (controller != null)
                {
                    controller.enabled = false;
                    other.transform.position = spawnPoint.position;
                    controller.enabled = true;
                }
                else
                {
                    Debug.LogWarning("Le joueur n'a pas de CharacterController !");
                    other.transform.position = spawnPoint.position;
                }
            }
            else
            {
                Debug.LogWarning("SpawnPoint non assigné dans OutsideMap.");
            }
        }
    }
}
