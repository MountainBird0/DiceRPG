using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : LivingEntity
{
    public GameObject Hpbar;

    


    private void Awake()
    {
        Hpbar = GameObject.FindGameObjectWithTag("Hpbar");
        maxHealth = 100f;
    }

    private void Update()
    {

        Hpbar.transform.localScale = new Vector3(1 * (currentHealth / maxHealth), 1, 1);
        // Debug.Log($"[MonsterHealth] 체력바 사이즈 {Hpbar.transform.localScale}");
    }
}
