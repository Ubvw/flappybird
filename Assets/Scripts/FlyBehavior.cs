using UnityEngine;

public class FlyBehavior : MonoBehaviour
{
    // Encapsulation: The direction variable is private, meaning it cannot be accessed directly from outside this class.
    // This ensures that movement logic remains controlled within this class.
    private Vector3 direction;

    // Encapsulation: Gravity and strength are private but accessible through properties.
    // Using [SerializeField] allows them to be modified in the Unity Inspector without exposing them as public fields.
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float strength = 5f;

    // Encapsulation: These properties control access to the private fields gravity and strength.
    // This prevents unintended modifications while allowing controlled access.
    public float Gravity
    {
        get => gravity;
        set => gravity = value;
    }

    public float Strength
    {
        get => strength;
        set => strength = value;
    }

    private void Update()
    {
        // Abstraction: Instead of handling input, gravity, and movement directly in Update(),
        // separate methods are used to organize the logic, improving readability and maintainability.
        HandleInput();
        ApplyGravity();
        MoveBird();
    }

    private void HandleInput()
    {
        // Abstraction: This method abstracts the logic for detecting user input,
        // so the Update() method doesn't have to deal with raw input handling directly.
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ||
            (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            direction = Vector3.up * strength; // Apply upward force when input is detected.
        }
    }

    private void ApplyGravity()
    {
        // Abstraction: This method encapsulates the gravity application logic,
        // making it easier to adjust or modify without affecting other parts of the class.
        direction.y += gravity * Time.deltaTime;
    }

    private void MoveBird()
    {
        // Abstraction: Instead of modifying the position directly in Update(), 
        // this method abstracts the movement logic, improving code structure.
        transform.position += direction * Time.deltaTime;
    }

    private void OnEnable()
    {
        // Encapsulation: The ResetPosition() method ensures the player's position is reset
        // whenever the object is enabled, hiding the logic inside the method.
        ResetPosition();
    }

    private void ResetPosition()
    {
        // Encapsulation: This method resets the player's position and velocity.
        // It prevents direct manipulation of position from outside the class.
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Encapsulation: The collision handling logic is self-contained in this method,
        // ensuring that only this class decides how to respond to collisions.
        if (other.CompareTag("Obstacle"))
        {
            // Abstraction: Instead of handling game-over logic here, 
            // it delegates the responsibility to the Manager class.
            FindAnyObjectByType<Manager>().GameOver();
        }
        else if (other.CompareTag("Scoring"))
        {
            // Abstraction: Delegates the responsibility of score management to the Manager class.
            FindAnyObjectByType<Manager>().IncreaseScore();
        }
    }
}
