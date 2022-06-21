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
    public static GameManager instance;
    private bool bossAlive = false;

    /**********************************************************
     * 설명 : 게임 시작과 동시에 싱글톤을 구성
     ***********************************************************/
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 GameManager가 존재합니다!");
            Destroy(gameObject);
        }

        //ObjectPoolManager.instance.GetObject("Player");
    }

    /**********************************************************
    * 설명 : 새로운 게임을 시작함
    ***********************************************************/
    public void StartNewGame()
    {
        SceneManager.LoadScene("Town");
        StartCoroutine(Delay());
     
    }

    /**********************************************************
    * 설명 : 타운 몬스터와 만났을 때 배틀필드로 이동
    ***********************************************************/
    public void MoveBattleField()
    {
        SceneManager.LoadScene("BattleField1");
    }

    /**********************************************************
    * 설명 : 포탈과 충돌했을 때 타운으로 이동
    ***********************************************************/
    public void MoveTown()
    {
        SceneManager.LoadScene("Town");
    }


    /**********************************************************
    * 설명 : 씬 전환하는 동안 나올 화면
    ***********************************************************/
    IEnumerator Delay()
    {
        Debug.Log($"[GameManager] : 딜레이주는중");

        yield return 0;

        var prefab = ObjectPoolManager.instance.GetObject("Player2");
        var startPoint = GameObject.FindGameObjectWithTag("StartPoint");
        Debug.Log(startPoint);
        prefab.transform.position = startPoint.transform.position;
        //prefab.transform.position = Vector3.zero;

        Debug.Log($"[GameManager] : 플레이어 위치 {prefab.transform.position}");
    }


    /**********************************************************
    * 설명 : 씬 전환하는 동안 나올 화면
    ***********************************************************/
    IEnumerator GoBattleField()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("BattleField1");

    }

    /**********************************************************
    * 설명 : 보스몬스터가 살아있는지 여부
    ***********************************************************/
    public bool IsBossAlive()
    {
        return bossAlive;
    }

    /**********************************************************
    * 설명 : 보스몬스터 상태 변경
    ***********************************************************/
    public void SetBossAlive(bool what)
    {
        bossAlive = what;
    }
}
