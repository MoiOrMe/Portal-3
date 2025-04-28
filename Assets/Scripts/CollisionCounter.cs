using UnityEngine;
using UnityEngine.UI;

public class CollisionCounter : MonoBehaviour
{
    public Text collisionText; // UI pour afficher le nombre de collisions
    private int collisionCount = 0;

    void Start()
    {
        collisionCount = 0;
        UpdateCollisionText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            collisionCount++;
            UpdateCollisionText();
        }
    }

    public void IncrementErrorCount()
    {
        collisionCount++;
        UpdateCollisionText();
    }

    // Getter pour obtenir le nombre de collisions
    public int GetCollisionCount()
    {
        return collisionCount;
    }

    void UpdateCollisionText()
    {
        collisionText.text = "Erreurs : " + collisionCount;
    }
}
