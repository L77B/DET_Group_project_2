using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Does so all children of the object attached to the collider are also destroyed when they enter the death zone
        GameObject target = other.attachedRigidbody != null
            ? other.attachedRigidbody.gameObject
            : other.transform.root.gameObject;

        //Checks if the object that entered the death zone is tagged as "Wall" and destroys it if it is
        if (other.CompareTag("Wall") || target.CompareTag("Wall"))
        {
            Destroy(target);
        }
    }
}