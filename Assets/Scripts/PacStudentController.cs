using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    private string lastInput;
    private string currentInput;
    private Vector3 direction;
    public Tweener tweener;
    public Animator pacAnimation;
    public AudioSource movementSource;
    public AudioClip[] movementClips;
    public ParticleSystem pacParticle;
    bool particleToggle = true;

    // Start is called before the first frame update
    void Start()
    {
        pacAnimation.speed = 0;
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
                PlayAnimation(lastInput);
                ParticleRotation(lastInput);
                tweener.CreateTween(transform, transform.position, (transform.position + direction), 0.3f);
                currentInput = lastInput;
                if (!movementSource.isPlaying) {
                    movementSource.Play();
                }

                if (particleToggle)
                {
                    pacParticle.Play();
                    particleToggle = false;
                }
            }
            else if (currentInput != null) {
                direction = GetDirection(currentInput);
                if (!Physics2D.Raycast(transform.position, direction, 1f)) {
                    tweener.CreateTween(transform, transform.position, (transform.position + direction), 0.3f);
                }
                else
                {
                    pacAnimation.speed = 0;
                    movementSource.Stop();
                    pacParticle.Stop();
                    particleToggle = true;
                }
            }
        }
    }

    private Vector3 GetDirection(string input)
    {
        if (input.Equals("w")) {
            return new Vector3(0, 1, 0);
        }

        else if (input.Equals("a")) {
            return new Vector3(-1, 0, 0);
        }

        else if (input.Equals("s")) {
            return new Vector3(0, -1, 0);
        }

        else if (input.Equals("d")) {
            return new Vector3(1, 0, 0);
        }

        return new Vector3(0, 0, 0);
    }

    private void PlayAnimation(string input)
    {
        pacAnimation.speed = 1;
        if (input.Equals("w")) {
            pacAnimation.SetTrigger("UpTrigger");
            pacAnimation.ResetTrigger("LeftTrigger");
            pacAnimation.ResetTrigger("RightTrigger");
            pacAnimation.ResetTrigger("DownTrigger");
        }

        else if (input.Equals("a")) {
            pacAnimation.SetTrigger("LeftTrigger");
            pacAnimation.ResetTrigger("UpTrigger");
            pacAnimation.ResetTrigger("RightTrigger");
            pacAnimation.ResetTrigger("DownTrigger");
        }

        else if (input.Equals("s")) {
            pacAnimation.SetTrigger("DownTrigger");
            pacAnimation.ResetTrigger("LeftTrigger");
            pacAnimation.ResetTrigger("RightTrigger");
            pacAnimation.ResetTrigger("UpTrigger");
        }

        else if (input.Equals("d")) {
            pacAnimation.SetTrigger("RightTrigger");
            pacAnimation.ResetTrigger("LeftTrigger");
            pacAnimation.ResetTrigger("UpTrigger");
            pacAnimation.ResetTrigger("DownTrigger");
        }
    }

    private void ParticleRotation(string input)
    {
        var shape = pacParticle.shape;

        if (input.Equals("w")) {
            shape.position = new Vector3(0, -1, 0);
            shape.rotation = new Vector3(180, 0, 0);
        }

        else if (input.Equals("a")) {
            shape.position = new Vector3(1, 0, 0);
            shape.rotation = new Vector3(90, 90, 0);
        }

        else if (input.Equals("s")) {
            shape.position = new Vector3(0, 1, 0);
            shape.rotation = new Vector3(0, 0, 0);
        }

        else if (input.Equals("d")) {
            shape.position = new Vector3(-1, 0, 0);
            shape.rotation = new Vector3(-90, 90, 0);
        }
    }
}
