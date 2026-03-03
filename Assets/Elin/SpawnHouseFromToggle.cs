using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnAndFreezeHouse : MonoBehaviour
{
    public GameObject housePrefab;
    public float spawnDistance = 0.5f;

    private Toggle toggle;

    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleChanged);
    }

    void OnToggleChanged(bool isOn)
    {
        if (!isOn) return;

        Camera cam = Camera.main;
        Vector3 spawnPos = cam.transform.position + cam.transform.forward * spawnDistance;

        // Spawn the house
        GameObject obj = Instantiate(housePrefab, spawnPos, Quaternion.LookRotation(cam.transform.forward));

        // Freeze the house so it floats
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }

        // Add the unfreeze script directly to the spawned object
        //obj.AddComponent<FreezeUntilGrabbed>();

        toggle.isOn = false;
        
    }
}

