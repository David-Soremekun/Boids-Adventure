using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    // Setup Suff
    Collider2D boidCollider;
    public Collider2D BoidCollider{get { return boidCollider; } }
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        boidCollider=GetComponent<Collider2D>();
        
    }
    
    public void Move(Vector2 velocity){
        transform.up = velocity;
        transform.position += (Vector3) velocity * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
