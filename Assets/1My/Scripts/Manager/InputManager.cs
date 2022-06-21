/******************************************************************************
* �� �� �� : 2022-06-18
* ��    �� : ������� �Է��� �ް� �ٸ� ������Ʈ���� ����� �� �ֵ��� ����
* �� �� �� :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance; // �̱����� �Ҵ��� ���� ����

    private string moveXName = "Vertical";     // �յ� �������� ���� �Է���
    private string moveZName = "Horizontal";   // �¿� �������� ���� �Է���
    //private string fireButtonName = "Fire1";

    // ���ο����� �� �Ҵ��� �����ϵ���
    public float moveX { get; private set; }   // ������ ������ �Է°� 
    public float moveZ { get; private set; } 

    /**********************************************************
    * ���� : ���� ���۰� ���ÿ� �̱����� ����
    ***********************************************************/
    private void Awake()
    {
        if (instance == null)
        { 
            instance = this;
        }
        else
        {
            Debug.LogWarning("���� �ΰ� �̻��� InputManager�� �����մϴ�!");
            Destroy(gameObject);
        }
    }

    /**********************************************************
    * ���� : �� �����Ӹ��� ����� �Է� ����
    ***********************************************************/
    private void Update()
    {       
        moveX = Input.GetAxis(moveXName);     
        moveZ = -1 * Input.GetAxis(moveZName); 
    }

    /**********************************************************
    * ���� : ���� �Է°��� ���밪���� ����
    ***********************************************************/
    public float MoveValue()
    {
        return Mathf.Abs(moveX) + Mathf.Abs(moveZ);
    }

    /**********************************************************
    * ���� : �̵��ϰ� �ִ��� ���θ� ����
    ***********************************************************/
    public bool IsMove()
    {
        if(moveX == 0 && moveZ == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
