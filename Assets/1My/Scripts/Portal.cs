using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject portal;

    void Update()
    {
        StartCoroutine(check());
    }

    IEnumerator check()
    {
        yield return new WaitForSeconds(1f);
        var monster = GameObject.FindGameObjectsWithTag("BattleMonster");
        if (monster.Length == 0)
        {
            portal.SetActive(true);
        }
    }
}
