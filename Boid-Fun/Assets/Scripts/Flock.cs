using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    
    [Header("Boid Spawn Setup: ")]
    public Boid boidPrefab;
    public BoidBehaviour behaviour;
    List<Boid> boidList= new List<Boid>();

    [Header("Flock Initialisations: ")]
    
    [SerializeField]public int AmountOfBoids=50;
    private const float boidDensity=0.08f;
    
    //[Range(20.0f,100.0f)]
    //public float minSpeed=0.0f;
    [Range(2.5f,100.0f)]
    public float maxSpeed=2.5f;
    [Range(0.0f, 100.0f)]
    public float steeringFactor = 10.0f;
    [Range(0.0f,10.0f)]
    public float neighbourRadius=1.2f;
    [Range(0.0f, 1.0f)]
    public float RadiusMultiplier = 0.5f;

    private float squareMaxSpeed;
    private float squareNeighbourRadius;
    private float avoidanceRadius;

    public float getAvoidanceRadius { get{ return avoidanceRadius; } }

    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighbourRadius = neighbourRadius * neighbourRadius;
        avoidanceRadius = squareNeighbourRadius * RadiusMultiplier * RadiusMultiplier;

        for (int i = 0; i < AmountOfBoids; i++)
        {
            Boid b = Instantiate(
                boidPrefab,
                Random.insideUnitCircle * AmountOfBoids * boidDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0.0f, 360.0f)),
                transform
                );
            Debug.Log("Boid " + i + " Created!");
            b.name = "Element " + i;
            boidList.Add(b);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Boid boid in boidList)
        {
            List<Transform> collection = GetNearbyObjects(boid);
            //boid.GetComponentInChildren<SpriteRenderer>().color=Color.Lerp(Color.white,Color.red,collection.Count/6.0f);
            Vector2 movementVector = behaviour.CalculateMovement(boid, collection, this);
            movementVector *= steeringFactor;

            if (movementVector.sqrMagnitude > squareMaxSpeed)
            {
                movementVector = movementVector.normalized * maxSpeed;
            }
            boid.Move(movementVector);
        }
    }

    List<Transform> GetNearbyObjects(Boid boid)
    {
        List<Transform> collection = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(boid.transform.position, neighbourRadius);

        foreach (Collider2D c in contextColliders)
        {
            if (c != boid.BoidCollider)
            {
                collection.Add(c.transform);
            }
        }
        return collection;

    }
}
