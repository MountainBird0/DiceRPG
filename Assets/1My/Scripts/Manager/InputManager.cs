/******************************************************************************
* 작 성 일 : 2022-06-18
* 내    용 : 사용자의 입력을 받고 다른 컴포넌트들이 사용할 수 있도록 제공
* 수 정 일 :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance; // 싱글톤을 할당할 전역 변수

    private string moveXName = "Vertical";     // 앞뒤 움직임을 위한 입력축
    private string moveZName = "Horizontal";   // 좌우 움직임을 위한 입력축
    //private string fireButtonName = "Fire1";

    // 내부에서만 값 할당이 가능하도록
    public float moveX { get; private set; }   // 감지된 움직임 입력값 
    public float moveZ { get; private set; } 

    /**********************************************************
    * 설명 : 게임 시작과 동시에 싱글톤을 구성
    ***********************************************************/
    private void Awake()
    {
        if (instance == null)
        { 
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 InputManager가 존재합니다!");
            Destroy(gameObject);
        }
    }

    /**********************************************************
    * 설명 : 매 프레임마다 사용자 입력 감지
    ***********************************************************/
    private void Update()
    {       
        moveX = Input.GetAxis(moveXName);     
        moveZ = -1 * Input.GetAxis(moveZName); 
    }

    /**********************************************************
    * 설명 : 방향 입력값을 절대값으로 리턴
    ***********************************************************/
    public float MoveValue()
    {
        return Mathf.Abs(moveX) + Mathf.Abs(moveZ);
    }

    /**********************************************************
    * 설명 : 이동하고 있는지 여부를 리턴
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
