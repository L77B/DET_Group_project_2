using UnityEngine;

public class TableTrigger : MonoBehaviour
{
    public GameObject grabbableObject;   // The parent object containing the spheres
    public GameObject[] scaleSpheres;    // The two spheres you want to hide

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == grabbableObject)
        {
            foreach (var sphere in scaleSpheres)
                sphere.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == grabbableObject)
        {
            foreach (var sphere in scaleSpheres)
                sphere.SetActive(true);
        }
    }
}
