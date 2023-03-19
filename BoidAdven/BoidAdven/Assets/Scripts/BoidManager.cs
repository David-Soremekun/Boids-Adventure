using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    BoidMovement m;
    [Header("Boid Spawn Setup: ")]
    [SerializeField] private BoidManager boidUnitPrefab;
    [SerializeField] private int NumberOfBoids;
    [SerializeField] private Vector3 bounds;

    [Header("Speed Shenanigans: ")]
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    //[Range(0,10)]
    [Header("Detection Distances: ")]
    [SerializeField] private float _cohesionDistance;

    public float cohesionDistance { get { return _cohesionDistance; } }
    public BoidManager[] boidArray { get; set;}
    // Start is called before the first frame update
    void Start()
    {
        GenerateBoids();
    }
    private void GenerateBoids(){
        
        boidArray= new BoidManager[NumberOfBoids];

        for (int i = 0; i < NumberOfBoids; i++)
        {
            // Determines a random point within a sphere
            var randVec = UnityEngine.Random.insideUnitSphere;
            randVec= new Vector3(randVec.x*bounds.x, randVec.y*bounds.y, randVec.z* bounds.z);
            
            var spawnPosition= transform.position + randVec;
            var rotation= Quaternion.Euler(0, Random.Range(0,360), 0);

            // Sets the initial position of the boids
            boidArray[i]= Instantiate(boidUnitPrefab, spawnPosition, rotation);
            //boidArray[i].AssignBoidToFlock(this);
        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < boidArray.Length; i++)
        {
            //boidArray[i].MoveBoids();
        }
    }
}
