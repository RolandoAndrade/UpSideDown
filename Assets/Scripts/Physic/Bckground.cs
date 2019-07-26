using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bckground : MonoBehaviour
{
    private AudioSource music;
	// Use this for initialization
	void Start ()
    {
        music = GetComponent<AudioSource>();
        InvokeRepeating("Paint", 2, 0.5f);
    }
    private void Update()
    {
        if(music.time>124)
        {
            Reset();
        }
    }
    private void Paint()
    {
        System.Random random = new System.Random();
        Select(random.Next(192)*2+1);
    }
    private void Select(int x)
    {
        try
        {
            SpriteRenderer s= gameObject.GetComponentsInChildren<SpriteRenderer>()[x];
            Animator anim = gameObject.GetComponentsInChildren<Animator>()[(x - 1) / 2];
            if (anim.GetBool("execute"))
            {
                anim.Play("Reset");
                anim.SetBool("execute", false);
            }
            else
            {
                anim.Play("Change");
                anim.SetBool("execute", true);
            }
            
        }
        catch
        {
            
        }
        
    }
    private void Reset()
    {
        foreach (Animator anim in gameObject.GetComponentsInChildren<Animator>())
        {
            if (anim.GetBool("execute"))
            {
                anim.Play("Reset");
                anim.SetBool("execute", false);
            }
        }
    }
}
