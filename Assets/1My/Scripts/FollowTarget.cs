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

    private void Awake()
    {

    }

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
                transform.position = new Vector3(target.transform.position.x * 1.25f,
                    target.transform.position.y * 3.7f, target.transform.position.z);

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
