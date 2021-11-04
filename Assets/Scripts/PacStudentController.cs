using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    private string lastInput;
    public Grid levelMap;
    public Tweener tweener;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w")) {
            if (!Physics2D.Raycast(transform.position, new Vector2(0, 1), 1f)) {
                tweener.CreateTween(transform, transform.position, (transform.position + new Vector3(0, 1, 0)), 0.3f);
            }
            else
            {
                Debug.Log(Physics2D.Raycast(transform.position, new Vector2(0, 1), 1f));
            }
            lastInput = "w";
        }

        if (Input.GetKeyDown("a")) {
            if (!Physics2D.Raycast(transform.position, new Vector2(-1, 0), 1f)) {
                tweener.CreateTween(transform, transform.position, (transform.position - new Vector3(1, 0, 0)), 0.3f);
            }
            lastInput = "a";
        }

        if (Input.GetKeyDown("s")) {
            if (!Physics2D.Raycast(transform.position, new Vector2(0, -1), 1f)) {
                tweener.CreateTween(transform, transform.position, (transform.position - new Vector3(0, 1, 0)), 0.3f);
            }
            lastInput = "s";
        }

        if (Input.GetKeyDown("d")) {
            if (!Physics2D.Raycast(transform.position, new Vector2(1, 0), 1f)) {
                tweener.CreateTween(transform, transform.position, (transform.position + new Vector3(1, 0, 0)), 0.3f);
            }
            lastInput = "d";
        }
    }
}
