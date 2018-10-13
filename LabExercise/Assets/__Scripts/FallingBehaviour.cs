using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FallingBehaviour : MonoBehaviour {

    [SerializeField]
    private float speed = 2f;

    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    private void FixedUpdate()
    {
        // vector2.down = vector2(0, -1)
        rb.velocity = Vector2.down * speed;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
