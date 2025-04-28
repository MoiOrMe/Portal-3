using UnityEngine;

public class PontActivator : MonoBehaviour
{
    public Animator animatorPont;
    public string animationPont = "AnimationName";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube is pushed")
        {
            if (animatorPont != null)
            {
                animatorPont.Play(animationPont);
            }
            else
            {
                Debug.LogWarning("Animator non assigné sur " + gameObject.name);
            }
        }
    }
}
