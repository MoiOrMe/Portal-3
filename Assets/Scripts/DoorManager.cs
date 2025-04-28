using UnityEngine;

public class DoorManager : MonoBehaviour
{
    private Animator anim;
    private bool isOpen = true;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void ToggleDoor()
    {
        if (isOpen)
        {
            anim.Play("DoorClose");
        }
        else
        {
            anim.Play("DoorOpen");
        }

        isOpen = !isOpen;
    }
}
