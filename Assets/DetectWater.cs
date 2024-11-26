using UnityEngine;

public class TriggerColliderDetector : MonoBehaviour
{
    // This will be called when another collider enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger has a specific tag
        if (other.tag == "Player")
        {
            Debug.Log("Player has entered the trigger zone.");
            GameController.Respawn();
        }
    }

}