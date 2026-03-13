using UnityEngine;

public class HideSpheresOnTable : MonoBehaviour
{
    public GameObject[] scaleSpheres;   //This creates the Inspector slots
    public string tableTag = "Table";
    public int originalLayer;
    private Rigidbody rb;
    //private Rigidbody touchedWallRb;
    //private bool touchedWallWasKinematic;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // originalLayer = rb.gameObject.layer;
    }


    /*
        void SetLayerRecursively(GameObject obj, int newLayer)
        {
            obj.layer = newLayer;

            foreach (Transform child in obj.transform)
            {
                SetLayerRecursively(child.gameObject, newLayer);
            }
        }

        public void ChangeObjectLayer(int newLayer)
        {
            gameObject.layer = newLayer;

            foreach (Transform child in gameObject.transform)
            {
                SetLayerRecursively(child.gameObject, newLayer);
            }

        }
        */

    private void freezePosition()
    {
        rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
    }

    public void unFreeze()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        foreach (var sphere in scaleSpheres)
            sphere.SetActive(true);

    }

    public void hideObjects()
    {
        // Hide spheres
        foreach (var sphere in scaleSpheres)
            sphere.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag(tableTag))
        {

            //gameObject.layer = originalLayer;

            // Snap upright
            Vector3 euler = transform.eulerAngles;
            euler.x = 0f;
            euler.z = 0f;
            transform.eulerAngles = euler;

            freezePosition();
        }

    }
}
