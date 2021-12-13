using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FactRandomizer : MonoBehaviour
{
    string[] facts = new string[20];
    // Start is called before the first frame update
    void Start()
    {
        facts[0] = "Birds secretly are government spies";
        facts[1] = "Birds scare me.";
        facts[2] = "A seagul once stole my fries";
        facts[3] = "'Boids' sounds like an new yorker trying to say birds";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FactRandomize(TextMeshProUGUI factbar)
    {
        int i = Random.Range(0,3);
        factbar.text = facts[i];
    }
}
