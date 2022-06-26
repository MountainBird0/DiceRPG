/******************************************************************************
* �� �� �� : 2022-06-19
* ��    �� : �÷��̾ ���� ������Ʈ�� �浹���� �� ���� ���
* �� �� �� :
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
    //        Debug.Log($"[PlayerCollision] : �������� {EnemyName}�� �浹");
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
            Debug.Log($"[PlayerCollision] : �������� {EnemyName}�� �浹");
            collision.gameObject.SetActive(false);
            GameManager.instance.MoveBattleField();
        }

        if (collision.collider.CompareTag("Portal"))
        {
            GameManager.instance.MoveTown();
        }

        // ������ ����
        if (collision.collider.CompareTag("Item"))
        {
            Dice itemName = collision.gameObject.GetComponent<DropDice>().GiveInfo();
            Debug.Log($"[PlayerCollision] : �������� {itemName}�� �浹");
            InventoryManager.instance.GetDice(itemName);
            collision.gameObject.SetActive(false);

        }
    }    


}
