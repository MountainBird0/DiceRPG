using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    private float turnSpeed = 50;

    void Update()
    {
        transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
    }
}
