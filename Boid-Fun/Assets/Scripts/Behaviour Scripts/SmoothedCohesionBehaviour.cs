using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Smoothed Cohesion")]
public class SmoothedCohesionBehaviour : BoidBehaviour
{
    Vector3 currentVelocity;
    public float timeDamp=0.5f;
    public override Vector3 CalculateMovement(Boid b, List<Transform> context, Flock flock)
    {
        if (context.Count == 0)
            return Vector3.zero;

        Vector3 cohesionVec = Vector3.zero;
        foreach (Transform item in context)
        {
            cohesionVec += item.position;
        }
        cohesionVec /= context.Count;

        cohesionVec -= b.transform.position;
        cohesionVec = Vector3.SmoothDamp(b.transform.up,cohesionVec, ref currentVelocity, timeDamp);
        return cohesionVec;
    }


}
