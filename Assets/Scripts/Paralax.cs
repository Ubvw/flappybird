using UnityEngine;

public class Paralax : MonoBehaviour
{
    // Encapsulation: meshRenderer is a private variable, preventing direct modification from other classes.
    // This ensures that only this class controls how the mesh renderer is accessed.
    private MeshRenderer meshRenderer;

    // Encapsulation: animationSpeed is private but accessible through a property.
    // [SerializeField] allows it to be modified in the Unity Inspector without exposing it as a public variable.
    [SerializeField] private float animationSpeed = 0.6f;

    // Encapsulation: Property for safely accessing and modifying animationSpeed.
    // This provides controlled access, ensuring that animationSpeed is modified intentionally.
    public float AnimationSpeed
    {
        get => animationSpeed;
        set => animationSpeed = value;
    }

    private void Awake()
    {
        // Encapsulation: The reference to the MeshRenderer component is initialized here.
        // Other classes don’t need to know how this component is retrieved.
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        // Abstraction: The scrolling behavior is encapsulated within Update().
        // Other parts of the program don't need to know how texture movement works.
        ScrollTexture();
    }

    private void ScrollTexture()
    {
        // Abstraction: This method abstracts the logic for moving the background texture.
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
