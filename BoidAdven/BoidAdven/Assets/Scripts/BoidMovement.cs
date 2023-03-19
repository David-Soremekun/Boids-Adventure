using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float FOVAngle;
    [SerializeField] private float smoothVal;
    

    private BoidManager boidFlock;
    private Vector3 boidVelocity;
    private float speed;
    public Transform myTransform {get; set;}
    private List<BoidMovement> closestNeighbours=  new List<BoidMovement>();
    
    private void Awake()
    {
        myTransform = transform;

    } 
    public void AssignBoidToFlock(BoidManager boid)
    {
        boidFlock = boid;
    }

    private bool IsInFov(Vector3 position)
    {
        if (Vector3.Angle(myTransform.position,position-myTransform.position) <= FOVAngle)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void MoveBoids(){
        FindNeighbours();
        
        var cohesionVec= CalculateCohesionVector();
        var movementVec = Vector3.SmoothDamp(myTransform.forward, cohesionVec, ref boidVelocity, smoothVal);
        movementVec = movementVec.normalized * speed;
        myTransform.forward=movementVec;
        myTransform.position += movementVec * Time.deltaTime;
    }

    private Vector3 CalculateCohesionVector(){
        var cohesion= Vector3.zero;
        // Returns Zero if there is nothing within List
        if (closestNeighbours.Count == 0)
            return cohesion;

        int neighbourFOV=0;
        for (int i=0; i<closestNeighbours.Count; i++)
        {
            if (IsInFov(closestNeighbours[i].myTransform.position))
            {
                neighbourFOV++;
                cohesion += closestNeighbours[i].myTransform.position;
            }
        }

        if (neighbourFOV == 0)
            return cohesion;

        cohesion /= neighbourFOV;
        cohesion -= myTransform.position;
        cohesion = Vector3.Normalize(cohesion);

        return cohesion;
    }

    private void FindNeighbours(){
        closestNeighbours.Clear();
        var allUnits = boidFlock.boidArray;
        for (int i=0; i<allUnits.Length; i++)
        {
            var currentUnit = allUnits[i];
            while (currentUnit!=this)
            { 
                float NeighbourDist =Vector3.SqrMagnitude(currentUnit.transform.position-transform.position);
                if (NeighbourDist <= boidFlock.cohesionDistance * boidFlock.cohesionDistance)
                {
                    // closestNeighbours.Add(currentUnit);
                }


            }
        }
    }
    
}
