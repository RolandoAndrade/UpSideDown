using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    public GameObject normalBlock,physicBlock;

    public bool physicsEnabled;

    public Transform background;

    public Collider2D scrollSensor;

    public Counter counter;

    private static List<GameObject> blocks = new List<GameObject>();

    public static Preview preview;

    private static bool isCross = false;

    private GameObject block;

    private static Color color;
   
	// Use this for initialization
	void Start ()
    {
        color= Colors.Random();
        preview = new Preview(physicBlock,counter);
        preview.ChangeColor(color);
        /*UnityEngine.Object pPrefab = Resources.Load("Assets/Prefab/Items/Key_yellow"); // note: not .prefab!
 GameObject pNewObject = (GameObject)GameObject.Instantiate(pPrefab, Vector3.zero, Quaternion.identity);*/
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
    private void OnMouseEnter()
    {
        if (!blocks.Contains(block) && !isCross)
        {
            CreateBlock();
        }
        else
        {
            int last = blocks.Count - 1;
            if (blocks.Count > 1 && blocks[last - 1] == block)
            {
                DestroyBlock(last);
                preview.Pop();
                PutColor();
            }
            else if (blocks[last] == block)
            {
                isCross = false;
            }

            else
            {
                isCross = true;
            }
        }
    }

    private void CreateBlock()
    {
        preview.Add(gameObject);
        block = Instantiate(normalBlock, gameObject.transform.position, Quaternion.identity);
        blocks.Add(block);
        PutColor();
    }

    private void PutColor()
    {

        if (counter.Ready())
            ChangeColorOfAll(color);
        else
            ChangeColorOfAll(Colors.GRAY);
    }
    private void ChangeColorOfAll(Color color)
    {
        foreach (GameObject g in blocks)
        {
            SpriteRenderer sr = g.GetComponent<SpriteRenderer>();
            sr.color = color;
        }
    }
    private void DestroyBlock(int index)
    {
        try
        {
            Destroy(blocks[index]);
            blocks.RemoveAt(index);
        }
        catch
        {

        }
        
    }
    private void OnMouseUp()
    {
        while(blocks.Count>0)
            DestroyBlock(0);
        if(counter.Ready())
        {
            preview.Drop(background);
            color = Colors.Random();
            preview.ChangeColor(color);
            Invoke("Scroll", 0.7f);
        }
        else
        {
            preview.Clear();
        }
        
    }
    private void Scroll()
    {
        scrollSensor.enabled = true;
    }
}
