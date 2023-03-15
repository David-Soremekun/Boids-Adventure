using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    // Start is called before the first frame update
    Boid[] boidArr= new Boid[100];
    private Vector3 bPosition;
    public float radius=100;
    Vector3 Seperation(Boid b)
    {
        Vector3 c=Vector3.zero;

        foreach(Boid boid in boidArr)
        {
            if (b != boid)
            {
                
                
                if ((b.bPosition.x - boid.bPosition.x)< radius || (b.bPosition.y - boid.bPosition.y) < radius
                    ||(b.bPosition.z - boid.bPosition.z) < radius)
                {
                    c = new Vector3(b.bPosition - boid.bPosition);
                }
            }
        }
        return result;
    }
    Vector3 Cohesion(Boid b)
    {
        Vector3 result = Vector3.zero;


        return result;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
