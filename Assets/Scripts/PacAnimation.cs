using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animatorController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w")) {
            animatorController.SetTrigger("UpTrigger");
        }

        if (Input.GetKeyDown("a")) {
            animatorController.SetTrigger("LeftTrigger");
        }

        if (Input.GetKeyDown("s")) {
            animatorController.SetTrigger("DownTrigger");
        }

        if (Input.GetKeyDown("d")) {
            animatorController.SetTrigger("RightTrigger");
        }
    }
}
