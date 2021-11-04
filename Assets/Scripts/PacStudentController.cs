using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    private string lastInput;
    private string currentInput;
    private Vector3 direction;
    public Tweener tweener;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            lastInput = "w";
        }

        if (Input.GetKeyDown("a"))
        {
            lastInput = "a";
        }

        if (Input.GetKeyDown("s"))
        {
            lastInput = "s";
        }

        if (Input.GetKeyDown("d"))
        {
            lastInput = "d";
        }

        if (!tweener.TweenExists() && lastInput != null)
        {
            direction = GetDirection(lastInput);

            if (!Physics2D.Raycast(transform.position, direction, 1f)) {
                tweener.CreateTween(transform, transform.position, (transform.position + direction), 0.3f);
                currentInput = lastInput;
            }
            else {
                direction = GetDirection(currentInput);
                if (!Physics2D.Raycast(transform.position, direction, 1f)) {
                    tweener.CreateTween(transform, transform.position, (transform.position + direction), 0.3f);
                }
            }
        }
    }

    private Vector3 GetDirection(string input)
    {
        if (input.Equals("w"))
        {
            return new Vector3(0, 1, 0);
        }
        else if (input.Equals("a"))
        {
            return new Vector3(-1, 0, 0);
        }
        else if (input.Equals("s"))
        {
            return new Vector3(0, -1, 0);
        }
        else if (input.Equals("d"))
        {
            return new Vector3(1, 0, 0);
        }

        return new Vector3(0, 0, 0);
    }
}
