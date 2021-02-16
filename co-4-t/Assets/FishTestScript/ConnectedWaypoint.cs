using System.Text;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{


    public class ConnectedWaypoint : MonoBehaviour
    {
        [SerializeField]
        protected float connectivityRadius = 50f;
        protected float debugDrawRadius = 1f;

        List<ConnectedWaypoint> connections;

        // Start is called before the first frame update
        public void Start()
        {
            // grab all waypoints in scene
            GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");

            // Create list of waypoints to refer to later
            connections = new List<ConnectedWaypoint>();

            // check if connected
            for (int i = 0; i < allWaypoints.Length; i++)
            {
                ConnectedWaypoint nextWaypoint = allWaypoints[i].GetComponent<ConnectedWaypoint>();

                // i.e we found a waypoint
                if (nextWaypoint != null)
                {
                    if(Vector3.Distance(this.transform.position, nextWaypoint.transform.position) <= connectivityRadius && nextWaypoint != this)
                    {
                        connections.Add(nextWaypoint);
                    }
                }
            }

        }

        public virtual void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, debugDrawRadius);

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, connectivityRadius);
        }

        public ConnectedWaypoint NextWaypoint(ConnectedWaypoint previousWaypoint)
        {
            if (connections.Count == 0)
            {
                // no waypoints means return null and complain
                Debug.LogError("Insufficient Waypoint Count");
                return null;
            }

            else if(connections.Count == 1 && connections.Contains(previousWaypoint))
            {
                // if only waypoint is last used, use it again
                return previousWaypoint;
            }
            else // otherwise, find a random close one
            {
                ConnectedWaypoint nextWaypoint;
                int nextIndex = 0;

                do
                {
                    nextIndex = UnityEngine.Random.Range(0, connections.Count);
                    nextWaypoint = connections[nextIndex];
                } while (nextWaypoint == previousWaypoint);

                return nextWaypoint;
            }
        }


       
    }

}