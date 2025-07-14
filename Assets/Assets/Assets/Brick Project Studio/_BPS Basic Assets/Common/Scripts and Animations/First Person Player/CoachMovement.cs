using UnityEngine;

public class CoachController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    void Start()
    {
        // Initialize the Animator and Rigidbody components
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        // Ensure the coach character starts at the correct height above the floor
        Vector3 startPosition = transform.position;
        startPosition.y = 1.0f; // Adjust this value based on your floor height
        transform.position = startPosition;

        // Freeze position Y and rotation to prevent the character from moving or tipping over
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        // Example: Trigger the arm stretching animation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("ArmStretchTrigger");
        }
    }
}
