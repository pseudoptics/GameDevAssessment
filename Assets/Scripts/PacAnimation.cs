using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animatorController;
    private SpriteRenderer pacSprite;

    // Start is called before the first frame update
    void Start()
    {
        pacSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w")) {
            if (animatorController.GetCurrentAnimatorStateInfo(0).IsName("PacHorizontalWalkAnim")) {
                animatorController.SetTrigger("VerticalTrigger");
            }
            pacSprite.flipX = false;
            pacSprite.flipY = false;
        }

        if (Input.GetKeyDown("a")) {
            if (animatorController.GetCurrentAnimatorStateInfo(0).IsName("PacVerticalWalkAnim")) {
                animatorController.SetTrigger("HorizontalTrigger");
            }
            pacSprite.flipX = true;
            pacSprite.flipY = false;
        }

        if (Input.GetKeyDown("s")) {
            if (animatorController.GetCurrentAnimatorStateInfo(0).IsName("PacHorizontalWalkAnim")) {
                animatorController.SetTrigger("VerticalTrigger");
            }
            pacSprite.flipX = false;
            pacSprite.flipY = true;
        }

        if (Input.GetKeyDown("d")) {
            if (animatorController.GetCurrentAnimatorStateInfo(0).IsName("PacVerticalWalkAnim")) {
                animatorController.SetTrigger("HorizontalTrigger");
            }
            pacSprite.flipX = false;
            pacSprite.flipY = false;
        }
    }
}
