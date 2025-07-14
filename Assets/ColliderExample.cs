using UnityEngine;

public class ColliderExample : MonoBehaviour
{
    // Define a value for the upward force calculation
    public float hoverForce = 12f;

    // Whenever another collider is in contact with this trigger collider...
    private void OnTriggerEnter(Collider other)
    {
        // Check if the other collider has a Rigidbody component
        
        Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();
        if (otherRigidbody != null)
        {
            // Apply an upward force to simulate hovering
            otherRigidbody.AddForce(Vector3.up * hoverForce, ForceMode.Force);
        }
    }
}
