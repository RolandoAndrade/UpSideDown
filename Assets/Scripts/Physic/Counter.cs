using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private TextMesh number;

    private SpriteRenderer background;

    private int num,dif,startNum;

    void Start()
    {
        number = gameObject.GetComponent<TextMesh>();
        background = gameObject.GetComponentInChildren<SpriteRenderer>();
        StartValue();
    }

    public void StartValue()
    {
        System.Random a = new System.Random();
        num = a.Next(10) + 1;
        startNum = num;
        ChangeText();
    }

    public void Reset()
    {
        num = startNum;
        dif = 0;
        ChangeText();
    }

    public int GetValue()
    {
        return num;
    }

    public void ChangeColor(Color color)
    {
        if (background == null)
            Start();
        background.color = color;
    }
    public void Inc()
    {
        if (dif == 0)
            num++;
        else
            dif--;
        ChangeText();
    }
    public void Dec()
    {
        if (num > 0)
            num--;
        else
            dif++;
        ChangeText();
    }
    private void ChangeText()
    {
        number.text = "" + num;
    }
    public bool Ready()
    {
        return true;
        //return (dif + num) == 0;
    }
}
