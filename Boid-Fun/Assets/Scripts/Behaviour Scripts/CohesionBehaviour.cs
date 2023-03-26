using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Flock/Behaviour/Cohesion")]
public class CohesionBehaviour : BoidBehaviour
{
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
        return cohesionVec;
    }


}
