using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// attached to the triangle to follow a path of points
// given by an array of transforms.  Array is filled
// by the spawner (need a public method for this)

[RequireComponent(typeof(Rigidbody2D))]
public class WaypointFollower : MonoBehaviour {

    // == fields ==
    // array, rigibody, current point to move to
    // speed to move at
    [SerializeField]
    private float speed;    // set by spawner
    // waypoints - filled by the spawner
    private IList<Vector3> waypoints = new List<Vector3>();
    private Vector3 currentPoint;
    private Rigidbody2D rb;

    // == properties ==
    public float Speed { get { return speed; }
                         set { speed = value; } }
    // == public methods ==
    public void AddPointToPath(Vector3 point)
    {
        waypoints.Add(point);
    }

    // == private methods ==

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetNextPoint();
    }

    private void GetNextPoint()
    {
        if(HasMorePoints())
        {
            currentPoint = waypoints.First();   // system.linq
        }
    }

    private bool HasMorePoints()
    {
        return waypoints.Count != 0;
    }

    private void FixedUpdate()
    {
        // if there are points, call move
        if(HasMorePoints())
        {
            Move();
        }
        else
        {
            // at destination - now what?
            var falling = rb.GetComponent<FallingBehaviour>();
            falling.enabled = true;
        }
    }

    private void Move()
    {
        // using Vector3.Movetowards to update position
        rb.position = Vector3.MoveTowards(rb.position,
                                          currentPoint,
                                          speed * Time.deltaTime);
        // when close enough, update rb.position
        if( Vector3.Distance(rb.position, currentPoint) 
                                                < 0.01 )
        {
            rb.position = new Vector2(currentPoint.x, 
                                      currentPoint.y);
            // remove current from the list
            waypoints.Remove(currentPoint);
            if(HasMorePoints())
            {
                GetNextPoint(); // move to next point on path
            }
        }
    }
}
