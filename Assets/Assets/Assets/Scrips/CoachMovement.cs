using UnityEngine;

public class CoachMovement : MonoBehaviour
{
    private Animator animator;
    private const string ANIMATION_NAME = "Arm Stretching"; // Ensure this matches your animation state name

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator component not found on the coach.");
        }
    }

    void Update()
    {
        if (animator != null)
        {
            if (animator.HasState(0, Animator.StringToHash(ANIMATION_NAME)))
            {
                animator.Play(ANIMATION_NAME);
            }
            else
            {
                Debug.LogError($"Animation state '{ANIMATION_NAME}' not found in Animator Controller.");
            }
        }
    }
}
