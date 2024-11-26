using UnityEngine;

public class TriggerColliderDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check for "Player" tag
        {
            Debug.Log("Player entered the trigger zone.");

            // Get the PlayerController component and call Respawn
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.Respawn();
            }
            else
            {
                Debug.LogError("PlayerController is missing on the Player object.");
            }
        }
    }
}
