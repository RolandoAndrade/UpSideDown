using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public GameObject background;
    public float scrollValue;
    public static bool colision=false;
    private void OnTriggerExit2D(Collider2D collision)
    {
        colision = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        colision = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        colision = true;
        background.transform.Translate(new Vector2(0, scrollValue));
    }

    private void Update()
    {
        if(gameObject.GetComponent<Collider2D>().enabled==true&&!colision)
        {
            Invoke("Remove", 0.02f);
        }
    }
    private void Remove()
    {
        if(!colision)
            gameObject.GetComponent<Collider2D>().enabled = false;
    }
}
