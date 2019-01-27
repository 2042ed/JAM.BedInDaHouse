using UnityEngine;
using System.Collections;
using DG.Tweening;

public class RadialForce : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;

    bool pushingSomeone;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {            
            if (pushingSomeone)
                return;

            Collider2D[] colliders = Physics2D.OverlapAreaAll(new Vector2(transform.position.x,transform.position.y), 
                new Vector2(1,1));


            foreach (Collider2D hit in colliders)
            {
                if (hit.gameObject.tag == "Player")
                    continue;

                Debug.Log("hit "+hit.name);
                Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    pushingSomeone = true;
                    {
                        var pushedX = rb.transform.position.x;
                        var range = Random.Range(1.2f, 1.7f);

                        if (transform.position.x < pushedX)
                        {
                            rb.transform.DOMoveX(pushedX + range, 0.5f).OnComplete(()=> pushingSomeone=false);
                        }
                        else
                        {
                            rb.transform.DOMoveX(pushedX - range, 0.5f).OnComplete(() => pushingSomeone = false);
                        }
                    }
                    {
                        var pushedY = rb.transform.position.y;
                        var range = Random.Range(1.2f, 1.7f);

                        if (transform.position.y < pushedY)
                        {
                            rb.transform.DOMoveY(pushedY + range, 0.5f).OnComplete(() => pushingSomeone = false);
                        }
                        else
                        {
                            rb.transform.DOMoveY(pushedY - range, 0.5f).OnComplete(() => pushingSomeone = false);
                        }
                    }

                }

                //if (rb != null)
                //    rb.AddForce(new Vector2(Random.Range(0.2f,0.8f), Random.Range(0.2f, 0.8f)), ForceMode2D.Force);
            }
        }
    }
}