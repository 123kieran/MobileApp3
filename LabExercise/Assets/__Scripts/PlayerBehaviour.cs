using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {
    // use the arrow keys for movement.
    private const string H_AXIS = "Horizontal";
    private const string V_AXIS = "Vertical";

    [SerializeField]
    private float speed = 15f;

    [SerializeField]
    private float xMin = -1.95f;

    [SerializeField]
    private float xMax = 1.95f;

    Rigidbody2D rb;
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		// Frames Per Second - 25 PAL 30 NTSC
	}
    private void FixedUpdate()
    {
        float hMovement = Input.GetAxis(H_AXIS);
        float vMovement = Input.GetAxis(V_AXIS);
        rb.velocity = new Vector2(hMovement * speed, 
                                vMovement * speed);
        // keep with the boundaries
        // get the position of the boundary objects
        // work out the x value - do the maths
        // or use Mathf.Clamp
        float newX = Mathf.Clamp(rb.position.x, xMin, xMax);
        // have newX value, need to reposition rb
        rb.position = new Vector2(newX, rb.position.y);
    }
}
