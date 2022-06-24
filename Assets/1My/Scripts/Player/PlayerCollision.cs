/******************************************************************************
* 작 성 일 : 2022-06-19
* 내    용 : 플레이어가 각종 오브젝트와 충돌했을 때 반응 담당
* 수 정 일 :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("TownMonster"))
        {
            string EnemyName = collision.collider.gameObject.name;
            EnemyName = EnemyName.Replace("(Clone)","");
            SpawnManager.instance.GetNameOfPrefab(EnemyName + "_B");
            Debug.Log($"[PlayerCollision] : 마을에서 {EnemyName}과 충돌");
            collision.gameObject.SetActive(false);
            GameManager.instance.MoveBattleField();
        }

        if(collision.collider.CompareTag("Portal"))
        {
            GameManager.instance.MoveTown();
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        //if(other.CompareTag("BattleMonster"))
        //{
        //    LivingEntity life = other.GetComponent<LivingEntity>();
        //    life.OnDamage(10, transform.position);
        //}

    }

    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if (collision.collider.CompareTag("TownMonster"))
        {
            string EnemyName = collision.collider.gameObject.name;
            EnemyName = EnemyName.Replace("(Clone)", "");
            SpawnManager.instance.GetNameOfPrefab(EnemyName + "_B");
            Debug.Log($"[PlayerCollision] : 마을에서 {EnemyName}과 충돌");
            collision.gameObject.SetActive(false);
            GameManager.instance.MoveBattleField();
        }

        if (collision.collider.CompareTag("Portal"))
        {
            GameManager.instance.MoveTown();
        }
    }    


}
