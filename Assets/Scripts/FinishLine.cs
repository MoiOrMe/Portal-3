using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinishLine : MonoBehaviour
{
    public GameObject victoryCanvas;
    public TextMeshProUGUI finalTimeText;
    public TextMeshProUGUI finalCollisionText;
    public TextMeshProUGUI messageText;

    public TimerManager timerManager;
    public CollisionCounter collisionCounter;

    public AudioSource audioSource;
    public AudioClip arrivalSound;

    private bool hasFinished = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasFinished)
        {
            hasFinished = true;

            timerManager.StopTimer();
            victoryCanvas.SetActive(true);

            finalTimeText.text = "Temps : " + timerManager.GetFinalTime();
            finalCollisionText.text = "Erreurs : " + collisionCounter.GetCollisionCount();

            int errors = collisionCounter.GetCollisionCount();
            float finalTime = timerManager.GetTimeAsFloat();

            if (errors < 2 && finalTime < 30f)
            {
                messageText.text = "Mission accomplie !";
            }
            else if (errors < 2 || finalTime < 30f)
            {
                messageText.text = "Bien, mais essayez encore !";
            }
            else
            {
                messageText.text = "Nul ! Recommence.";
            }

            if (audioSource != null && arrivalSound != null)
            {
                audioSource.PlayOneShot(arrivalSound);
            }

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
