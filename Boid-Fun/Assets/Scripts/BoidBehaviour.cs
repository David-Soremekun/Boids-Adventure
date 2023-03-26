using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoidBehaviour : ScriptableObject
{
    public abstract Vector3 CalculateMovement(Boid b, List<Transform> context, Flock flock);
    

}
