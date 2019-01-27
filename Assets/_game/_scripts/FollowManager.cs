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
            //if (queue.Count > 0) {
            //    GO.GetComponent<FollowTarget>().target = queue[queue.Count - 1];
            //} else {
            //    GO.GetComponent<FollowTarget>().target = gameObject.transform;
            //}
            queue.Add(GO);
            relinkQueue();
        }

        public void RemoveFollower(Transform followerGO)
        {
            followerGO.GetComponent<FollowTarget>().target = null;
            if (queue.Contains(followerGO)) {
                queue.Remove(followerGO);
            }
            relinkQueue();
        }

        private void relinkQueue()
        {
            for (int i = 0; i < queue.Count; i++) {
                Debug.Log("relinkQueue " + i);
                if (i < 1) {
                    queue[i].GetComponent<FollowTarget>().target = gameObject.transform;
                } else {
                    queue[i].GetComponent<FollowTarget>().target = queue[i - 1];
                }
            }
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