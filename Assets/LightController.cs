using UnityEngine;

public class LightController : MonoBehaviour
{
    private Light pointLight;
    private bool canToggle = false; // Tracks if the player is nearby

    void Start()
    {
        pointLight = GetComponent<Light>();
        if (pointLight == null)
        {
            Debug.LogError("No Light component found on this GameObject.");
        }
    }

    void Update()
    {
        if (canToggle && Input.GetKeyDown(KeyCode.F))
        {
            ToggleLight();
        }
    }

    private void ToggleLight()
    {
        if (pointLight != null)
        {
            pointLight.enabled = !pointLight.enabled;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canToggle = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canToggle = false;
        }
    }
}