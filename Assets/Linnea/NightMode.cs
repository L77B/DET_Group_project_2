using System.Configuration.Assemblies;
using UnityEngine;

public class NightMode : MonoBehaviour
{
    public Material nightMaterial;
    public Material dayMaterial;
    private bool isNightMode = false;
    private Renderer objectRenderer;

    // once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleNightMode(bool isNight)
    {
        isNightMode = isNight;
        if (isNight)
        {
            objectRenderer.material = nightMaterial;
        }
        else
        {
            objectRenderer.material = dayMaterial;
        }
    }
}
