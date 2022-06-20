using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    void Start()
    {
        SpawnManager.instance.Spawning();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnManager.instance.Spawning();
        }
    }
}
