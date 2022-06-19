/******************************************************************************
* 작 성 일 : 2022-06-19
* 내    용 : 마을에서 플레이어가 와 충돌했을 때 반응
* 수 정 일 :
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
            Debug.Log("[PlayerCollision] : 마을에서 적과 충돌");
            GameManager.instance.MoveBattleField();
        }
    }
}
