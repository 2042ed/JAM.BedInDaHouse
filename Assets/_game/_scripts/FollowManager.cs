using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JAM
{
    public class FollowManager : MonoBehaviour
    {

        private List<Transform> queue;

        private bool inMaze = false;

        void Awake()
        {
            queue = new List<Transform>();
            //queue.Add(gameObject.transform);
        }

        void Start()
        {

        }

        public void AddToQueue(Transform GO)
        {

            if (queue.Count > 0) {
                GO.GetComponent<FollowTarget>().target = queue[queue.Count - 1];
            } else {
                GO.GetComponent<FollowTarget>().target = gameObject.transform;
            }

            queue.Add(GO);
        }

        public void EnterMaze()
        {
            foreach (var follower in queue) {
                follower.GetComponent<Collider2D>().enabled = false;
                // TODO SIZE
            }
        }

        public void ExitMaze()
        {
            foreach (var follower in queue) {
                follower.GetComponent<Collider2D>().enabled = true;
            }
        }
    }
}