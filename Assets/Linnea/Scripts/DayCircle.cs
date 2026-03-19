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

        // Attaches renderer component and sets morningMaterial as default material
        objectRenderer = GetComponent<Renderer>();
        StartCoroutine(DayNightCycle());
        objectRenderer.material = morningMaterial;
    }


    IEnumerator DayNightCycle()
    {
        // Loops through the day and night cycle until the game is restarted
        while (started)
        {
            objectRenderer.material = morningMaterial;
            yield return new WaitForSeconds(46);

            objectRenderer.material = dayMaterial;
            yield return new WaitForSeconds(56);

            objectRenderer.material = afternoonMaterial;
            yield return new WaitForSeconds(56);

            objectRenderer.material = eveningMaterial;
            yield return new WaitForSeconds(56);

            objectRenderer.material = nightMaterial;
            yield return new WaitForSeconds(5);
            nightText.SetActive(true);
            yield return new WaitForSeconds(500);
            started = false;
        }
    }

    // Starts the day and night cycle and hides the start menu
    public void startGame()
    {
        started = true;
        StartCoroutine(DayNightCycle());
        startMenu.SetActive(false);
    }

    // Restarts the game by reloading the current scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
