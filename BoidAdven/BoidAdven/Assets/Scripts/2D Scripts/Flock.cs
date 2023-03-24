using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Boid Spawn Setup: ")]
    public Boid boidPrefab;
    public BoidBehaviour behaviour;
    List<Boid> boidList= new List<Boid>();

    [Header("Boid Spawn Setup: ")]
    [Range(20,100)]
    public int AmountOfBoids=50;
    private const float BoidDensity=0.08f;
    
    [Range(20.0f,100.0f)]
    public float minSpeed=0.0f;
    [Range(20.0f,100.0f)]
    public float maxSpeed=1.0f;
    [Range(0.0f,10.0f)]
    public float neighbourRadius=1.5f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
