using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Smoothed Cohesion")]
public class SmoothedCohesionBehaviour : FilteredFlockBehaviour
{
    Vector3 currentVelocity;
    public float timeDamp=0.5f;
    public override Vector3 CalculateMovement(Boid b, List<Transform> context, Flock flock)
    {
         List<Transform> filteredContext = (filter == null) ? context : filter.contextfilter(b, context);

        if (context.Count == 0) 
            return Vector3.up; 

        

        Vector3 cohesionVec = Vector3.zero;
       
        foreach (Transform item in context)
        {
            cohesionVec += item.position;
        }
        cohesionVec /= context.Count;

        cohesionVec -= b.transform.position;
        //if (float.IsNaN(currentVelocity.x) || float.IsNaN(currentVelocity.y))
        //    currentVelocity = Vector2.up;
        cohesionVec = Vector3.SmoothDamp(b.transform.up,cohesionVec, ref currentVelocity, timeDamp);
        return cohesionVec;
    }


}
