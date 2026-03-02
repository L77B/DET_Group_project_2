using UnityEngine;

public class HideSpheresOnTable : MonoBehaviour
{
    public GameObject[] scaleSpheres;   //This creates the Inspector slots
    public string tableTag = "Table";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(tableTag))
        {
            foreach (var sphere in scaleSpheres)
                sphere.SetActive(false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag(tableTag))
        {
            foreach (var sphere in scaleSpheres)
                sphere.SetActive(true);
        }
    }
}
