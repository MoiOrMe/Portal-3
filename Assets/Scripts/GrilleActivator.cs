using UnityEngine;

public class GrilleActivator : MonoBehaviour
{
    public Animator animatorGrille;
    public string animationGrille = "AnimationName";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube goes flying")
        {
            if (animatorGrille != null)
            {
                animatorGrille.Play(animationGrille);
            }
            else
            {
                Debug.LogWarning("Animator non assigné sur " + gameObject.name);
            }
        }
    }
}
