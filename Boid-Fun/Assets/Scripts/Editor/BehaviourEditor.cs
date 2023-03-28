using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(CombinedBehaviour))]
public class BehaviourEdior : Editor
{
    public override void OnInspectorGUI()
    {
        //setup
        CombinedBehaviour cb = (CombinedBehaviour)target;

        //check for behaviour
        if (cb.behaviour == null || cb.behaviour.Length == 0)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.HelpBox("No behaviour in array.", MessageType.Warning);
            EditorGUILayout.EndHorizontal();
        }
        else
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Number", GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
            EditorGUILayout.LabelField("Behaviors", GUILayout.MinWidth(60f));
            EditorGUILayout.LabelField("Weights", GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
            EditorGUILayout.EndHorizontal();

            for (int i = 0; i < cb.behaviour.Length; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(i.ToString(), GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
                cb.behaviour[i] = (BoidBehaviour)EditorGUILayout.ObjectField(cb.behaviour[i], typeof(BoidBehaviour),false, GUILayout.MinWidth(60f));
                cb.weights[i] = EditorGUILayout.FloatField(cb.weights[i], GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
                EditorGUILayout.EndHorizontal();
            }
        }

        if (GUILayout.Button("Add Behavior"))
        {
            AddBehaviour(cb);
            EditorUtility.SetDirty(cb);
        }

        if (cb.behaviour != null && cb.behaviour.Length > 0)
        {
            if (GUILayout.Button("Remove Behavior"))
            {
                RemoveBehaviour(cb);
                EditorUtility.SetDirty(cb);
            }
        }
    

        void AddBehaviour(CombinedBehaviour cb)
        {
        int oldCount = (cb.behaviour != null) ? cb.behaviour.Length : 0;
        BoidBehaviour[] newBehav = new BoidBehaviour[oldCount + 1];
        float[] newWeights = new float[oldCount + 1];
        
        for (int i = 0; i < oldCount; i++)
        {
            newBehav[i] = cb.behaviour[i];
            newWeights[i] = cb.weights[i];
        }

        newWeights[oldCount] = 1f;
        cb.behaviour = newBehav;
        cb.weights = newWeights;
        }

        void RemoveBehaviour(CombinedBehaviour cb)
        {
            int oldCount = cb.behaviour.Length;

            if (oldCount == 1)
            {
                cb.behaviour = null;
                cb.weights = null;
                return;
            }

            BoidBehaviour[] newBehav = new BoidBehaviour[oldCount - 1];
            float[] newWeights = new float[oldCount - 1];

            for (int i = 0; i < oldCount - 1; i++)
            {
                newBehav[i] = cb.behaviour[i];
                newWeights[i] = cb.weights[i];
            }

            cb.behaviour = newBehav;
            cb.weights = newWeights;
          }
    }
}


        
    

    
