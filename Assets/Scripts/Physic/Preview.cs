using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preview : MonoBehaviour
{
    private GameObject block;

    private List<GameObject> preview;

    public GameObject shape;

    private Color color;

    private Counter counter;

    private bool physicsEnabled;

    public Preview(GameObject block,Counter counter)
    {
        this.block = block;
        preview = new List<GameObject>();
        this.counter = counter;
    }

    private void CreateShape()
    {
        shape = new GameObject("Shape");
    }

    public void PhysicsEnabled(bool b)
    {
        physicsEnabled = b;
    }
    public void Add(GameObject creatorSelected)
    {
        if (preview.Count==0)
            CreateShape();
        Vector2 location = creatorSelected.transform.position;
        Translate(ref location);
        GameObject a= Instantiate(block, location, Quaternion.identity);
        a.transform.parent = shape.transform;
        ChangeColor(a);
        preview.Add(a);
        counter.Dec();
    }
    private void ChangeColor(GameObject preview)
    {
        SpriteRenderer destiny = preview.GetComponent<SpriteRenderer>();
        destiny.color = color;
    }

    public void ChangeColor(Color color)
    {
        this.color = color;
        counter.ChangeColor(color);
    }
    public void Pop()
    {
        counter.Inc();
        DestroyBlock(preview.Count-1);
    }

    private void Translate(ref Vector2 t)
    {
        //t = new Vector2(t.x*0.7f, 3.5f+t.y*0.73f);
        t = new Vector2(t.x * 0.71f, 3f + t.y * 0.65f);
    }
    
    private void DestroyBlock(int index)
    {
        try
        {
            Destroy(preview[index]);
            preview.RemoveAt(index);
        }
        catch
        {

        }
        
    }

    public void Drop(Transform parent)
    {
        Debug.Log("entro");
        foreach (Collider2D collider in shape.GetComponentsInChildren<Collider2D>())
            collider.isTrigger = false;
        shape.AddComponent<CompositeCollider2D>();
        if (parent != null)
            shape.transform.parent = parent;
        if(!physicsEnabled)
        {
            Rigidbody2D r = shape.GetComponent<Rigidbody2D>();
            r.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        Reset();
    }

    public void Reset()
    {
        preview = new List<GameObject>();
        counter.StartValue();
    }
    public void Clear()
    {
        counter.Reset();
        while (preview.Count > 0)
            DestroyBlock(0);
    }
}
