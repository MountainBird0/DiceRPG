using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LivingEntity life = other.GetComponent<LivingEntity>();
            life.OnDamage(10, transform.position);
        }

    }
}
