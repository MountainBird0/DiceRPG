/******************************************************************************
* �� �� �� : 2022-06-19
* ��    �� : �������� �÷��̾ �� �浹���� �� ����
* �� �� �� :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("TownMonster"))
        {
            Debug.Log("[PlayerCollision] : �������� ���� �浹");
            GameManager.instance.MoveBattleField();
        }
    }
}
