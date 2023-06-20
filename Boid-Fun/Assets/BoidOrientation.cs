using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Boid_Orientation : MonoBehaviour
{
    private TMP_Text _boidText;
    // Start is called before the first frame update
    void Start()
    {
        _boidText = GetComponent<TMP_Text>();
        _boidText.alignment = TextAlignmentOptions.BottomLeft;
    }
    private void DisplayMessage()
    {
        _boidText.text = $" Boid Fun";
    }
    // Update is called once per frame
    void Update()
    {
        DisplayMessage();
    }
}
