using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public static MouseManager instance;

   
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 UiManager 존재합니다!");
            Destroy(gameObject);
        }

        //ObjectPoolManager.instance.GetObject("Player");
    }

    

}
