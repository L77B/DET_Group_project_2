using UnityEngine;

public class HideSpheresOnTable : MonoBehaviour
{
    public GameObject[] scaleSpheres;   //This creates the Inspector slots
    public string tableTag = "Table";
    private Rigidbody rb;
    private void Start() 
    { 
        rb = GetComponent<Rigidbody>(); 
    }

    private void OnCollisionEnter(Collision collision)
{
    if (collision.collider.CompareTag(tableTag))
    {
        // Hide spheres 
        foreach (var sphere in scaleSpheres) 
        sphere.SetActive(false);
        // Snap upright
        Vector3 euler = transform.eulerAngles;
        euler.x = 0f;
        euler.z = 0f;
        transform.eulerAngles = euler;

        // Optional: re-enable physics stability
        rb.angularVelocity = Vector3.zero;
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
