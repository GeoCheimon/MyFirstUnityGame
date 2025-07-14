using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class GymClient : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float turnSpeed = 250f;
    private Animator animator;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    private bool isRunning;

    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();  // Initializes the Animator component
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //διαβάσουμε τις τιμές από το πληκτρολόγιό μας και ας τις αποθηκεύσουμε στις παρακατω μεταβλητές
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isRunning = Input.GetKey(KeyCode.LeftShift); // if the left shift key is held down then the player should be running

        // Determine movement speed
        float currentSpeed = isRunning ? runSpeed : walkSpeed;
        
        Vector3 moveDirection = transform.forward * verticalInput * currentSpeed;

        // Move the character
        characterController.Move(moveDirection * Time.deltaTime);

        // Rotate the character
        transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);

        
        //προσθέτουμε την κινηση του παικτη
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * currentSpeed);
        transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);
        
        
        //trasform: είναι το συστατικό μετασχηματισμού ενός object. Περιέχει πληροφορίες για position=θέση, rotation=περιστροφή και scale=κλιμακα.
        //Translate: embended method που επιτρεπει την μετακίνηση του object σε μια συγκεκριμένη απόσταση σε μια συγκεκριμένη κατεύθυνση.
        //Vector3.forward: είναι η κίνηση ενος object προς τα εμπρος, και κινείται προς την κατεύθυνση που βλέπει.
        //Time.deltaTime: είναι ο χρόνος που έχει περάσει από το τελευταίο καρέ. Χρησιμοποιείται για την ομαλή κίνηση, ανεξάρτητα από το πόσο γρήγορο ή αργο είναι το Pc.
        //verticalInput: είναι η τιμή που παιρνει από το πληκτρολόγιο, για να προχωρήσει το object ή να πάει πίσω.
    
        float movementMagnitude = new Vector2(horizontalInput, verticalInput).magnitude;

        if (animator != null)
        {
            // Set the "Speed" parameter based on movement magnitude
            animator.SetFloat("Speed", movementMagnitude);

            // Set the "RunSpeed" parameter for running animation
            animator.SetFloat("RunSpeed", isRunning ? 1f : 0f); // Set to 1 for running, 0 for not running

        }
    
    
    }
}
