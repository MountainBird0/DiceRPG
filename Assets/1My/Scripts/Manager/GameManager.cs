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
    public static GameManager instance; // �̱����� �Ҵ��� ���� ����

    /**********************************************************
     * ���� : ���� ���۰� ���ÿ� �̱����� ����
     ***********************************************************/
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this; // instance�� ����ִٸ�(null) �װ��� �ڱ� �ڽ��� �Ҵ�
        }
        else
        {
            Debug.LogWarning("���� �ΰ� �̻��� GameManager�� �����մϴ�!");
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
