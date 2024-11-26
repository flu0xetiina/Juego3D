using UnityEngine;

public class TriggerColliderDetector : MonoBehaviour
{
    // This will be called when another collider enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger has a specific tag
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered the trigger zone.");
        }
    }

    // This will be called when another collider stays inside the trigger
    private void OnTriggerStay(Collider other)
    {
        // Check if the object staying in the trigger is the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is still in the trigger zone.");
        }
    }

    // This will be called when another collider exits the trigger
    private void OnTriggerExit(Collider other)
    {
        // Check if the object exiting the trigger is the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has exited the trigger zone.");
        }
    }
}
