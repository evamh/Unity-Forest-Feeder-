using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitAnimation : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        // Start Coroutine
        if(animator.runtimeAnimatorController.name == "RabbitController")
            StartCoroutine(AnimationSwitch());
    }

    // toggle animation between Idle and Running every 5-10 seconds
    private IEnumerator AnimationSwitch()
    {
        Debug.Log("entering AnimationSwitch");

        while(true)
        {
            float waitTime = Random.Range(5, 10);
            yield return new WaitForSeconds((float)waitTime);

            //Debug.Log("changing animation from " + animator.GetBool("StartRunning") + " to " + !animator.GetBool("StartRunning"));
            animator.SetBool("StartRunning", !animator.GetBool("StartRunning"));

        }
    }
}
