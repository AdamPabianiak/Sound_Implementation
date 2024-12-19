using UnityEngine;

public class AmbienceManager : MonoBehaviour
{
    private AudioSystem audioSystem;

    private void Start()
    {
        // Locate the AudioSystem in the scene
        audioSystem = FindObjectOfType<AudioSystem>();

        if (audioSystem == null)
        {
            Debug.LogError("AudioSystem not found in the scene!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (audioSystem == null) return;

        if (other.CompareTag("TavernZone"))
        {
            Debug.Log("Entering Tavern Zone");
            SetTavernAmbience(1.0f);   // Full tavern ambience
            SetOutsideAmbience(0.0f); // Mute outside ambience
        }
        else if (other.CompareTag("ForestZone"))
        {
            Debug.Log("Entering Forest Zone");
            SetTavernAmbience(0.1f);  // Faint tavern ambience
            SetOutsideAmbience(1.0f); // Full outside ambience
        }
    }

    private void SetTavernAmbience(float volume)
    {
        audioSystem.TavernAmb.SetParameter("Volume", volume); // Adjust TavernAmb volume
    }

    private void SetOutsideAmbience(float volume)
    {
        audioSystem.OutsideAmb.SetParameter("Volume", volume); // Adjust OutsideAmb volume
    }
}
