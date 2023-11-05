using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackstate : StateMachineBehaviour
{
    Transform player;
    Transform muisca;
    bool playerDetected = false;
    bool muiscaDetected = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        muisca = GameObject.FindGameObjectWithTag("Muisca").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!playerDetected)
        {
            float distance = Vector3.Distance(animator.transform.position, player.position);
            if (distance <= 40)
            {
                animator.transform.LookAt(player);
                animator.SetBool("Atacar", true);
                playerDetected = true;
            }
        }

        if (!muiscaDetected)
        {
            float distance2 = Vector3.Distance(animator.transform.position, muisca.position);
            if (distance2 <= 40)
            {
                animator.transform.LookAt(muisca);
                animator.SetBool("Atacar", true);
                muiscaDetected = true;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Restablece las detecciones al salir del estado.
        playerDetected = false;
        muiscaDetected = false;
    }
}



