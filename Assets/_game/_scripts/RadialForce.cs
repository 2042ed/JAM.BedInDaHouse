using UnityEngine;
using System.Collections;

public class RadialForce : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("SPACE");
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders) {
                Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();

                if (rb != null) {
                    rb.AddForce(transform.up);
                }
            }
        }
    }
}