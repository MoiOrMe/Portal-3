using UnityEngine;
using UnityEngine.SceneManagement; // Optionnel selon ce que tu veux faire après

#if UNITY_EDITOR
using UnityEditor;
#endif

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Victoire ! Le joueur a atteint la ligne d'arrivée.");

#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
