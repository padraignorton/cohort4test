using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

namespace Assets.Code
{
    public class NPCConnectedPatrol : MonoBehaviour
    {
        //dictates if npc waits at node
        [SerializeField]
        bool patrolWaiting;

        //Total wait time per node
        [SerializeField]
        float totalWaitTime = 4f;

        //Probability of switching direction
        [SerializeField]
        float switchProbability = 0.2f;


        //private variables
        NavMeshAgent navMeshAgent;
        ConnectedWaypoint currentWaypoint;
        ConnectedWaypoint previousWaypoint;

        int waypointsVisited;
        bool travelling;
        bool waiting;
        bool patrolForward;
        float waitTimer;

        //called at start
        public void Start()
        {
            navMeshAgent = this.GetComponent<NavMeshAgent>();

            if (navMeshAgent == null)
            {
                Debug.LogError("NavMesh shit ain't connected, bro");
            }

            else
            {
                if (currentWaypoint == null)
                {
                    //set it at random
                    // grab all waypoint objects in scene
                    GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");

                    if (allWaypoints.Length > 0)
                    {
                        while (currentWaypoint == null)
                        {
                            int random = UnityEngine.Random.Range(0, allWaypoints.Length);
                            ConnectedWaypoint startingWaypoint = allWaypoints[random].GetComponent<ConnectedWaypoint>();

                            //i.e. we found a waypoint
                            if (startingWaypoint != null)
                            {
                                currentWaypoint = startingWaypoint;
                            }
                        }
                    }
                }

                else
                {
                    Debug.Log("Insufficient patrol points for basic behaviour");
                }
            }

            SetDestination();
        }


        // Update is called once per frame
        public void Update()
        {
            //check if close to destination
            if (travelling && navMeshAgent.remainingDistance <= 1f)
            {
                travelling = false;
                waypointsVisited++;

                //If we're waiting, then wait
                if (patrolWaiting)
                {
                    waiting = true;
                    waitTimer = 0f;
                }

                else
                {
                    SetDestination();
                }

            }

            // Instead, if we're waiting
            if (waiting)
            {
                waitTimer += Time.deltaTime;
                if (waitTimer >= totalWaitTime)
                {
                    waiting = false;

                    SetDestination();
                }
            }

        }

        private void SetDestination()
        {
            if (waypointsVisited > 0)
            {
                ConnectedWaypoint nextWaypoint = currentWaypoint.NextWaypoint(previousWaypoint);
                previousWaypoint = currentWaypoint;
                currentWaypoint = nextWaypoint;
            }

            Vector3 targetVector = currentWaypoint.transform.position;
            navMeshAgent.SetDestination(targetVector);
            travelling = true;
        }


    }
}
