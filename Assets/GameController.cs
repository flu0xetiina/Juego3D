using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Transform spawnPoint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Makes the GameController persist across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent multiple instances
        }
    }

    public void Respawn()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.Respawn(); // Use PlayerController's respawn logic
            }
            else
            {
                Debug.LogError("PlayerController component is missing on the Player object.");
            }
        }
        else
        {
            Debug.LogError("No Player object found with the 'Player' tag.");
        }
    }
}
