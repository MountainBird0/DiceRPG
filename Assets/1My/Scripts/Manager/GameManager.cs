/******************************************************************************
* 작 성 일 : 2022-06-19
* 내    용 : 게임의 전체 관리와 scene이동을 담당
* 수 정 일 :
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글톤을 할당할 전역 변수

    /**********************************************************
     * 설명 : 게임 시작과 동시에 싱글톤을 구성
     ***********************************************************/
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this; // instance가 비어있다면(null) 그곳에 자기 자신을 할당
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 GameManager가 존재합니다!");
            Destroy(gameObject);
        }

        ObjectPoolManager.instance.GetObject("Player");
    }

    public void MoveBattleField()
    {
        SceneManager.LoadScene("TestBattleField");
    }

    public void MoveTown()
    {
        SceneManager.LoadScene("TestTown");
    }
}
