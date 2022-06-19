/******************************************************************************
* 작 성 일 : 2022-06-18
* 내    용 : 플레이어의 컨트롤을 담당
* 수 정 일 :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float playerMoveSpeed = 2.0f;

    private Rigidbody playerRigidbody;
    private Animator playerAnimator;

    /**********************************************************
    * 설명 : 사용할 컴포넌트들의 참조를 불러옴
    ***********************************************************/
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    /**********************************************************
    * 설명 : 물리주기에 따라 플레이어를 움직임
    ***********************************************************/
    private void FixedUpdate()
    {
        Move();

        if (Input.GetMouseButtonDown(0))
        {
            playerAnimator.SetTrigger("Attack");
        }
    }

    /**********************************************************
    * 설명 : 입력값에 따라 캐릭터를 움직임
    ***********************************************************/
    private void Move()
    {
        Vector3 moveDir = new Vector3(InputManager.instance.moveX, 0, InputManager.instance.moveZ);
        Vector3 moveDistance = moveDir * playerMoveSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);

        if(InputManager.instance.IsMove())
        {
            playerRigidbody.rotation = Quaternion.LookRotation(moveDir);
        }
        
        playerAnimator.SetFloat("Move", InputManager.instance.MoveValue());        
    }


}
