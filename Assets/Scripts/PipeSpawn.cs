using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab; // The pipe prefab to be spawned.
    public float spawnRate = 1f; // Determines how frequently pipes spawn.
    public float minHeight = -1.6f; // The minimum height at which pipes can spawn.
    public float maxHeight = 2f; // The maximum height at which pipes can spawn.

    private void OnEnable()
    {
        // Abstraction: This method starts the spawning process.
        // Other parts of the game do not need to know how or when spawning happens.
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        // Abstraction: Stops the spawning process when the object is disabled.
        // Other scripts only need to disable the Spawner component to stop spawning.
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        // Abstraction: This method encapsulates the logic for spawning a pipe.
        // The way pipes are instantiated and positioned is hidden from the rest of the game logic.
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);

        // Adds a random vertical offset to the spawned pipe, making gameplay less predictable.
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
