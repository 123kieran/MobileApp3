using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dock : MonoBehaviour {
    // use the onDrawGizmos to draw the rectangle
    [SerializeField]
    private float Height = 0.5f;
    [SerializeField]
    private float Width = 0.5f;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(Width, Height));
    }
}
