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
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.collider.CompareTag("TownMonster"))
    //    {
    //        string EnemyName = collision.collider.gameObject.name;
    //        EnemyName = EnemyName.Replace("(Clone)","");
    //        SpawnManager.instance.GetNameOfPrefab(EnemyName + "_B");
    //        Debug.Log($"[PlayerCollision] : 마을에서 {EnemyName}과 충돌");
    //        collision.gameObject.SetActive(false);
    //        GameManager.instance.MoveBattleField();
    //    }

    //    if(collision.collider.CompareTag("Portal"))
    //    {
    //        GameManager.instance.MoveTown();
    //    }
    //}

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

        if (collision.collider.CompareTag("PowerZone"))
        {
            UiManager.instance.SetSmithy(true);
        }

        // 아이템 관련
        if (collision.collider.CompareTag("Item"))
        {
            Dice itemName = collision.gameObject.GetComponent<DropDice>().GiveInfo();
            Debug.Log($"[PlayerCollision] : 마을에서 {itemName}과 충돌");
            InventoryManager.instance.GetDice(itemName);
            collision.gameObject.SetActive(false);

        }
    }    


}
