/******************************************************************************
* 작 성 일 : 2022-06-18
* 내    용 : 카메라가 플레이어를 따라다니도록 함
* 수 정 일 :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowTarget : MonoBehaviour
{
    private GameObject target;
    Vector3 offset;

    bool check;

    /**********************************************************
    * 설명 : 카메라가 플레이어를 따라다니도록 함
    ***********************************************************/
    private void LateUpdate()
    {
        if(SceneManager.GetActiveScene().name != "Title")
        {
            if (target == null)
            {
                target = GameObject.FindGameObjectWithTag("Player");
                transform.position = new Vector3(target.transform.position.x -26.5f,
                    target.transform.position.y +18f, target.transform.position.z - 15.6f);

                return;
            }
            else
            {
                if (!check)
                {
                
                    offset = transform.position - target.transform.position;
                    check = true;
                }

                transform.position = target.transform.position + offset;

                return;
            }
        }
    }
}

//transform.position = new Vector3(target.transform.position.x -10f,
//                    target.transform.position.y +7f, target.transform.position.z - 6f);