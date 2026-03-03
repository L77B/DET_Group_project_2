using UnityEngine;

public class StartScript : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject dayCircle;
    public GameObject outerCircle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startMenu.SetActive(true);
        dayCircle.SetActive(false);
        outerCircle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startGame()
    {
        // Code to start the game goes here
        startMenu.SetActive(false);
        dayCircle.SetActive(true);
        outerCircle.SetActive(true);
    }
}
