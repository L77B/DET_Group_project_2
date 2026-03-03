using System.Configuration.Assemblies;
using System.Collections;
using UnityEngine;

public class DayCircle : MonoBehaviour
{
    public Material morningMaterial;
    public Material dayMaterial;
    public Material afternoonMaterial;
    public Material eveningMaterial;
    public Material nightMaterial;
    private Renderer objectRenderer;

    // once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        StartCoroutine(DayNightCycle());
    }

    IEnumerator DayNightCycle()
    {
        while (true)
        {
            objectRenderer.material = morningMaterial;
            yield return new WaitForSeconds(36);

            objectRenderer.material = dayMaterial;
            yield return new WaitForSeconds(46);

            objectRenderer.material = afternoonMaterial;
            yield return new WaitForSeconds(46);

            objectRenderer.material = eveningMaterial;
            yield return new WaitForSeconds(36);

            objectRenderer.material = nightMaterial;
            yield return new WaitForSeconds(16);
        }
    }
}
