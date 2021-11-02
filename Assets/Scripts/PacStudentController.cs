using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    private string lastInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w")) {
            lastInput = "w";
        }

        if (Input.GetKeyDown("a")) {
            lastInput = "a";
        }

        if (Input.GetKeyDown("s")) {
            lastInput = "s";
        }

        if (Input.GetKeyDown("d")) {
            lastInput = "d";
        }
    }
}
