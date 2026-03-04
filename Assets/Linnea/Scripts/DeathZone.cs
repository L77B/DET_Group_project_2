using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject target = other.attachedRigidbody != null
            ? other.attachedRigidbody.gameObject
            : other.transform.root.gameObject;

        if (other.CompareTag("Wall") || target.CompareTag("Wall"))
        {
            Destroy(target);
        }
    }
}