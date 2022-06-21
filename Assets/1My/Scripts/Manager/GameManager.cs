/******************************************************************************
* �� �� �� : 2022-06-19
* ��    �� : ������ ��ü ������ scene�̵��� ���
* �� �� �� :
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
     * ���� : ���� ���۰� ���ÿ� �̱����� ����
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
            Debug.LogWarning("���� �ΰ� �̻��� GameManager�� �����մϴ�!");
            Destroy(gameObject);
        }

        //ObjectPoolManager.instance.GetObject("Player");
    }

    /**********************************************************
    * ���� : ���ο� ������ ������
    ***********************************************************/
    public void StartNewGame()
    {
        SceneManager.LoadScene("Town");
        StartCoroutine(Delay());
     
    }

    /**********************************************************
    * ���� : Ÿ�� ���Ϳ� ������ �� ��Ʋ�ʵ�� �̵�
    ***********************************************************/
    public void MoveBattleField()
    {
        SceneManager.LoadScene("BattleField1");
    }

    /**********************************************************
    * ���� : ��Ż�� �浹���� �� Ÿ������ �̵�
    ***********************************************************/
    public void MoveTown()
    {
        SceneManager.LoadScene("Town");
    }


    /**********************************************************
    * ���� : �� ��ȯ�ϴ� ���� ���� ȭ��
    ***********************************************************/
    IEnumerator Delay()
    {
        Debug.Log($"[GameManager] : �������ִ���");

        yield return 0;

        var prefab = ObjectPoolManager.instance.GetObject("Player2");
        var startPoint = GameObject.FindGameObjectWithTag("StartPoint");
        Debug.Log(startPoint);
        prefab.transform.position = startPoint.transform.position;
        //prefab.transform.position = Vector3.zero;

        Debug.Log($"[GameManager] : �÷��̾� ��ġ {prefab.transform.position}");
    }


    /**********************************************************
    * ���� : �� ��ȯ�ϴ� ���� ���� ȭ��
    ***********************************************************/
    IEnumerator GoBattleField()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("BattleField1");

    }

    /**********************************************************
    * ���� : �������Ͱ� ����ִ��� ����
    ***********************************************************/
    public bool IsBossAlive()
    {
        return bossAlive;
    }

    /**********************************************************
    * ���� : �������� ���� ����
    ***********************************************************/
    public void SetBossAlive(bool what)
    {
        bossAlive = what;
    }
}
