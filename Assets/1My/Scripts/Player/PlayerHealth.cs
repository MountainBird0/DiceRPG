using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : LivingEntity
{
    private void Awake()
    {
        //Hpbar = GameObject.FindGameObjectWithTag("Hpbar");
        //maxHealth = 100f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log($"{maxHealth}, {currentHealth}");
        }
    }
}
