using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField]
    public Sprite red, blue, sprite;

    public float[,] Grid;


    //[SerializeField]
    int vertical, horizontal, Columns, Rows;
    // Start is called before the first frame update
    void Start()
    {
        vertical = (int)Camera.main.orthographicSize;
        horizontal = vertical * (Screen.width / Screen.height);
        Columns = horizontal * 2;
        Rows = vertical * 2;
        Grid = new float[Columns,Rows];

        //Places tiles from top left to bottom right
        //This is helpful for the bottom tiles to have skirts

        for (int i = 0; i < Columns; i++)
        {
            for (int j = Rows; j >= 0; j--)
            {
                if(j < 3)
                {
                    SpawnTile(i, j);
                }
            }
        }
    }

    private void SpawnTile(int x, int y)
    {
        GameObject g = new GameObject("X: "+x+"Y: "+y);
        g.transform.position = new Vector3(x - (horizontal - 0.5f), y - (vertical - 0.5f));
            
        var s = g.AddComponent<SpriteRenderer>();
        
        if(x < 3)
        {
            s.sprite = red;
        }
        if(x >= 3)
        {
            s.sprite = blue;
        }
    }
}
