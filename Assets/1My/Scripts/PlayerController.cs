/******************************************************************************
* �� �� �� : 2022-06-18
* ��    �� : �÷��̾��� ��Ʈ���� ���
* �� �� �� :
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
    * ���� : ����� ������Ʈ���� ������ �ҷ���
    ***********************************************************/
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    /**********************************************************
    * ���� : �����ֱ⿡ ���� �÷��̾ ������
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
    * ���� : �Է°��� ���� ĳ���͸� ������
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
