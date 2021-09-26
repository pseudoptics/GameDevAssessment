using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween
{
    public Transform PacStudent { get; private set; }
    public Vector3 StartPos { get; private set; }
    public Vector3 EndPos { get; private set; }
    public float StartTime { get; private set; }
    public float Duration { get; private set; }

    public Tween(Transform pacStudent, Vector3 startPos, Vector3 endPos, float startTime, float duration) {
        PacStudent = pacStudent;
        StartPos = startPos;
        EndPos = endPos;
        StartTime = startTime;
        Duration = duration;
    }
}
