using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Scroll : MonoBehaviour
{
    private int speed = 2;
    private float timer;
    public int damage;

    // ????? ???? ?????? ???? ?©ª??? ??????? ???? ?????
    private TextMeshPro text;

    private void Awake()
    {
        text = GetComponent<TextMeshPro>();
        text.text = damage.ToString();
        text.color = Color.red;
        text.transform.rotation = Camera.main.transform.rotation;
    }

    private void Update()
    {
        movetext();
    }

    public void movetext()
    {
        timer += Time.deltaTime;
        if (timer < 2)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            // transform.position += Vector3.up * speed * Time.deltaTime;
            // transform.LookAt(Camera.main.transform);
        }
        else
        {
            Destroy(text);
        }
    }

    public void Init(string str, Color color)
    {
        text.text = str;
        text.color = color;
    }
}
