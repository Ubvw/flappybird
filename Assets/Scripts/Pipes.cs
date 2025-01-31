using UnityEngine;

// Inheritance: Pipes inherits from Movable, meaning it automatically gets movement behavior from Movable.
public class Pipes : Movable
{
    private void Update()
    {
        // Polymorphism: Pipes uses Move() from Movable without needing to redefine it.
        Move();

        CheckOutOfBounds();
    }

    private void CheckOutOfBounds()
    {
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}

// Inheritance: Movable is a base class that provides movement functionality to Pipes and other potential subclasses.
public abstract class Movable : MonoBehaviour
{
    // Encapsulation: These fields are protected, meaning only Movable and its subclasses can access them.
    [SerializeField] protected float speed = 5f;
    protected float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    // Polymorphism: Move() can be used by any class that inherits from Movable, without rewriting movement logic.
    protected void Move()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
