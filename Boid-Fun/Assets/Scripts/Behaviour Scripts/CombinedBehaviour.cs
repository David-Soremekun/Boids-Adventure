using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behaviour/Combined")]
public class CombinedBehaviour : BoidBehaviour
{
    public BoidBehaviour[] behaviour;
    public float[] weights;
    public override Vector3 CalculateMovement(Boid b, List<Transform> context, Flock flock)
    {
        if (weights.Length != behaviour.Length)
        {
            Debug.Log("ERROR- Data Mismatch in: " + name, this);
            return Vector3.zero;
        }

        Vector3 moveVec = Vector3.zero;

        for (int i = 0; i < behaviour.Length; i++)
        {
            Vector3 halfMove = behaviour[i].CalculateMovement(b, context, flock) * weights[i];

            if (halfMove.sqrMagnitude < weights[i] * weights[i])
            {
                halfMove.Normalize();
                halfMove *= weights[i];
            }
            moveVec += halfMove;
        }

        return moveVec;
    }
}
