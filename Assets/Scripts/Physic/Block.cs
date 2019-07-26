using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block: MonoBehaviour
{

    private GameObject block;

    private Color color;
	
    public void ChangeColor(Color color)
    {
        this.color = color;
    }

    public GameObject Get()
    {
        return block;
    }

    public void DestroyBlock()
    {
        Destroy(this);
    }
}
