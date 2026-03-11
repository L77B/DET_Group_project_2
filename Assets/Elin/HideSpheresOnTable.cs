using UnityEngine;

public class HideSpheresOnTable : MonoBehaviour
{
    public GameObject[] scaleSpheres;   //This creates the Inspector slots
    public string tableTag = "Table";
    public int originalLayer;
    private Rigidbody rb;
    private Rigidbody touchedWallRb;
    private bool touchedWallWasKinematic;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalLayer = rb.gameObject.layer;
    }



    public void ChangeObjectLayer(int newLayer)
    {
        gameObject.layer = newLayer;

        int childCount = transform.childCount;
        for (int child = 0; child < childCount; child++)
        {
            transform.GetChild(child).gameObject.layer = newLayer;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag(tableTag))
        {

            //gameObject.layer = originalLayer;

            // Hide spheres
            foreach (var sphere in scaleSpheres)
                sphere.SetActive(false);

            // Snap upright
            Vector3 euler = transform.eulerAngles;
            euler.x = 0f;
            euler.z = 0f;
            transform.eulerAngles = euler;
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
