using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{

}
//public void DoStomp(Vector3 position)
//{
//    if (coMoveAndAttack != null)
//    {
//        attackTarget = null;
//        StopCoroutine(CoMoveAndAttack());
//        coMoveAndAttack = null;
//    }
//    coMoveAndAttack = StartCoroutine(ComoveAndStomp(position));

//}

//public Aoe stompAttack;

//private IEnumerator ComoveAndStomp(Vector3 position)
//{
//    agent.isStopped = false;
//    agent.destination = position;
//    while (Vector3.Distance(transform.position, position) > stompAttack.range)
//    {
//        yield return null;
//    }
//    agent.isStopped = true;
//    animator.SetTrigger("Stomp");
//}

//private void Stomp()
//{
//    stompAttack.Fire(gameObject, transform.position);
//}