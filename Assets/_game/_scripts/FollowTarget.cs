using UnityEngine;
using UnityPlayground;
using System.Collections;

namespace JAM
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class FollowTarget : Physics2DObject
    {
        // This is the target the object is going to move towards
        public GameObject PlayerGO;
        public Transform target;
        public float distance = 2f;
        public float followSharpness = 0.1f;

        [Header("Movement")]
        // Speed used to move towards the target
        public float speed = 1f;

        // Used to decide if the object will look at the target while pursuing it
        public bool lookAtTarget = false;

        // The direction that will face the target
        public Enums.Directions useSide = Enums.Directions.Up;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (target != null)
                return;

            if (collision.gameObject.CompareTag("Player")) {
                gameObject.GetComponent<Collider2D>().isTrigger = false;
                PlayerGO.GetComponent<FollowManager>().AddToQueue(gameObject.transform);
            }
        }


        // FixedUpdate is called once per frame
        void FixedUpdate()
        {
            //do nothing if the target hasn't been assigned or it was detroyed for some reason
            if (target == null)
                return;

            //look towards the target
            if (lookAtTarget) {
                Utils.SetAxisTowards(useSide, transform, target.position - transform.position);
            }

            if (Vector2.Distance(target.position, transform.position) > distance) {
                if (rigidbody2D.IsSleeping()) {
                    rigidbody2D.WakeUp();
                }

                //Vector3 newTarget = (target.position - transform.position) + transform.position;
                //Move towards the target
                rigidbody2D.MovePosition(Vector2.Lerp(transform.position, target.position, Time.fixedDeltaTime * speed));


                //}


                // Vector3 targetPosition = target.position - new Vector3(distance, distance, 0);

                // Keep our y position unchanged.
                //targetPosition.y = transform.position.y;

                // Smooth follow.    
                // transform.position += (targetPosition - transform.position) * followSharpness;
            } else {
                rigidbody2D.Sleep();
            }
        }
    }
}