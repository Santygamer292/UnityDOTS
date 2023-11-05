using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class walkstate : StateMachineBehaviour
{
    float timer;
    List<Transform> waypoints = new List<Transform>();
    NavMeshAgent agent;

    Transform player;
    Transform muisca;
    float attack = 40;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        Transform wayPointsObject = GameObject.FindGameObjectWithTag("WayPoints").transform;
        GameObject go = GameObject.FindGameObjectWithTag("WayPoints");

        foreach (Transform t in wayPointsObject)
        {
            waypoints.Add(t);
        }

        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[0].position);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        muisca = GameObject.FindGameObjectWithTag("Muisca").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(waypoints[Random.Range(0, waypoints.Count)].position);
        }

        timer += Time.deltaTime;
        if (timer > 8)
        {
            animator.SetBool("Patrullando", false);
        }

        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance < attack)
        {
            animator.SetBool("Perseguir", true);
        }
        float distance2 = Vector3.Distance(animator.transform.position, muisca.position);
        if (distance2 < attack)
        {
            animator.SetBool("Perseguir", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
