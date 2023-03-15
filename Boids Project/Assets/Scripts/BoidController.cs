using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidController : MonoBehaviour
{

    public int SwarmIndex{get; set;}
    public float NoClumpingRadius = 5.0f;
    public float LocalAreaRadius=10.0f;
    public float Speed = 10.0f;
    public float SteeringSpeed = 10.0f;
    
    private float xMax = 15000.0f;
    private float yMax = 15000.0f;
    private float zMax = 15000.0f;
    private float xMin = 15.0f;
    private float yMin = 15.0f;
    private float zMin = 15.0f;
    Vector3 BoundingVector;
    private void BindPosition(List<BoidController> other)
    {
        if(transform.position.x < xMin)
        {
            //transform.position.x=10;
        }  

        else if(transform.position.x > xMax)
        {
            //transform.position.x = -10;
        }

        if (transform.position.y < yMin)
        {
            //transform.position.y=10;
        }
        else if (transform.position.y > yMax)
        {
            //transform.position.y = -10;
        }

        if (transform.position.z < zMin)
        {
            //transform.position.z=10;
        }
        else if (transform.position.z > zMax)
        {
            //transform.position.z = -10;
        }
    }
    // Start is called before the first frame update
    public void BoidMovement(List<BoidController>other, float deltaTime){
        var steering=Vector3.zero;
        if (steering != Vector3.zero)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(steering), SteeringSpeed * deltaTime);

        
        


    }
}
