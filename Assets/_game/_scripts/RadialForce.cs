using UnityEngine;
using System.Collections;
using DG.Tweening;

public class RadialForce : MonoBehaviour
{
    public BoxCollider2D PlayerColl;

    public float radius = 5.0F;
    public float power = 10.0F;

    private bool pushing = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !pushing) {
            Debug.Log("SPACE");
            var origSize = PlayerColl.size;

            pushing = true;

            /*PlayerColl.size = new Vector2(3,3);
            DOVirtual.DelayedCall(.5f, () =>
            {
                PlayerColl.size = origSize;
                pushing = false;
            });*/

            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders) {
                Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();

                if (rb != null) {
                    rb.AddForce(transform.up);
                }
            }*/
        }
    }
}