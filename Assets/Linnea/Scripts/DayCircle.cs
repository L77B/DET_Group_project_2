using System.Configuration.Assemblies;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DayCircle : MonoBehaviour
{
    public Material morningMaterial;
    public Material dayMaterial;
    public Material afternoonMaterial;
    public Material eveningMaterial;
    public Material nightMaterial;
    public GameObject nightText;
    private Renderer objectRenderer;
    private bool started = false;

    public GameObject startMenu;

    // once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        objectRenderer = GetComponent<Renderer>();
        StartCoroutine(DayNightCycle());
        objectRenderer.material = morningMaterial;
    }

    IEnumerator DayNightCycle()
    {
        while (started)
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
            yield return new WaitForSeconds(5);
            nightText.SetActive(true);
            yield return new WaitForSeconds(100);
            started = false;
        }
    }

    public void startGame()
    {
        started = true;
        StartCoroutine(DayNightCycle());
        startMenu.SetActive(false);
    }
    public void RestartGame()
 {
     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
 }
}
