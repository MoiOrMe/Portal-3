using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Text timerText;  // UI pour afficher le temps
    private float startTime;
    private bool timerStarted = false;
    private bool timerStopped = false;

    public static TimerManager instance; // Singleton pour y acc�der facilement

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Update()
    {
        // Si le timer n'est pas encore d�marr�, on attend qu'une touche soit press�e
        if (!timerStarted)
        {
            if (Input.anyKeyDown)
            {
                timerStarted = true;
                startTime = Time.time;
            }
        }
        // Si le timer est d�marr� et pas encore arr�t�, on le met � jour
        else if (!timerStopped)
        {
            float t = Time.time - startTime;  // Calcul du temps �coul�
            int minutes = (int)(t / 60);
            int seconds = (int)(t % 60);
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }

    // M�thode pour arr�ter le timer
    public void StopTimer()
    {
        timerStopped = true;
        // R�initialiser l'affichage du timer
        timerText.text = "00:00";
    }

    // Retourner le temps final au format MM:SS
    public string GetFinalTime()
    {
        float t = Time.time - startTime;
        int minutes = (int)(t / 60);
        int seconds = (int)(t % 60);
        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    // M�thode pour r�initialiser le timer (au cas o� tu recommences)
    public void ResetTimer()
    {
        startTime = 0f;
        timerStarted = false;
        timerStopped = false;
        timerText.text = "00:00";  // Afficher 00:00 d�s le d�but
    }

    public float GetTimeAsFloat()
    {
        return Time.time - startTime;  // Retourner le temps �coul� en secondes
    }

}
