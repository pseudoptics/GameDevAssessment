using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject pacStudent;
    private Tweener tweener;

    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Equals(pacStudent.transform.position, new Vector3(-12.47f, 12.97f, 0f))) {
            tweener.CreateTween(pacStudent.transform, pacStudent.transform.position, new Vector3(-7.46f, 12.97f, 0f), 3f);
        }
        else if (Vector3.Equals(pacStudent.transform.position, new Vector3(-7.46f, 12.97f, 0f))) {
            tweener.CreateTween(pacStudent.transform, pacStudent.transform.position, new Vector3(-7.46f, 9.02f, 0f), 3f);
        }
        else if (Vector3.Equals(pacStudent.transform.position, new Vector3(-7.46f, 9.02f, 0f)))
        {
            tweener.CreateTween(pacStudent.transform, pacStudent.transform.position, new Vector3(-12.47f, 9.02f, 0f), 3f);
        }
        else if (Vector3.Equals(pacStudent.transform.position, new Vector3(-12.47f, 9.02f, 0f)))
        {
            tweener.CreateTween(pacStudent.transform, pacStudent.transform.position, new Vector3(-12.47f, 12.97f, 0f), 3f);
        }
    }
}
