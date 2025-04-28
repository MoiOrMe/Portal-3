using UnityEngine;

public class DoorManager : MonoBehaviour
{
    private Animator anim;
    private bool isOpen = true;

    public AudioSource doorAudioSource;
    public AudioClip doorOpenSound;
    public AudioClip doorCloseSound;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        if (doorAudioSource == null)
        {
            doorAudioSource = GetComponent<AudioSource>();
        }
    }

    public void ToggleDoor()
    {
        if (isOpen)
        {
            anim.Play("DoorClose");
            PlaySound(doorCloseSound);
        }
        else
        {
            anim.Play("DoorOpen");
            PlaySound(doorOpenSound);
        }
        isOpen = !isOpen;
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            doorAudioSource.PlayOneShot(clip);
        }
    }
}
