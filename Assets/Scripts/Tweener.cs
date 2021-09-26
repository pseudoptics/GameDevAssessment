using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private Tween currentTween;
    private float timeFraction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTween != null) {
            if (Vector3.Distance(currentTween.PacStudent.position, currentTween.EndPos) > 0.1f) {
                timeFraction = (Time.time - currentTween.StartTime) / currentTween.Duration;
                currentTween.PacStudent.position = Vector3.Lerp(currentTween.StartPos, currentTween.EndPos, timeFraction);
            }
            else {
                currentTween.PacStudent.position = currentTween.EndPos;
                currentTween = null;
            }
        }
    }

    public void CreateTween(Transform pacStudent, Vector3 startPos, Vector3 endPos, float duration) {
        if (currentTween == null)
            currentTween = new Tween(pacStudent, startPos, endPos, Time.time, duration);
    }
}
