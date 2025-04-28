using UnityEngine;

public class PlateformeActivator : MonoBehaviour
{
    public Animator animatorPlatefrome;
    public string animationPlateforme = "AnimationName";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube is draggable")
        {
            if (animatorPlatefrome != null)
            {
                animatorPlatefrome.Play(animationPlateforme);
            }
            else
            {
                Debug.LogWarning("Animator non assigné sur " + gameObject.name);
            }
        }
    }
}
