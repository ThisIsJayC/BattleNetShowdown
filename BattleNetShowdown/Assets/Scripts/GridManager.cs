using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField]
    public Sprite red, blue;

    public SpriteRenderer[,] BattleGrid;

    public AudioSource battleMusic;


    [SerializeField]
    public int vertical = 3, horizontal = 3;

    //Start is called before the first frame update
    void Start()
    {
        //Starts the Battle Theme
        battleMusic.Play();

        // vertical = (int)Camera.main.orthographicSize;
        horizontal = vertical * (Screen.width / Screen.height);
        int Columns = horizontal * 2;
        int Rows = vertical * 2;
        BattleGrid = new SpriteRenderer[Columns,Rows];

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
        string side = "";
        if(x < 3)
            side = "RED";
        if(x >= 3)
            side = "BLUE";

        GameObject g = new GameObject(side + " X: " + (x + 1) + " Y: " + (y + 1));
        g.transform.position = new Vector3(x - (horizontal - 0.5f), y - (vertical - 0.5f));

        var s = g.AddComponent<SpriteRenderer>();

        if(x < 3)
        {
            s.sprite = red;
            s.tag = "Red"; //TODO: work on how to attatch properties to the tiles
        }
        if(x >= 3)
        {
            s.sprite = blue;
            s.tag = "Blue";
        }
        BattleGrid[x , y] = s;
        // Debug.Log(BattleGrid[x,y]);
    }

    public string GetTag(int x, int y)
    {
        return BattleGrid[x-1, y-1].tag;
        //Debug.Log("Test");
        //Debug.Log("You planned on stepping to " + BattleGrid[x-1, y-1] + ". That tag is: " + BattleGrid[x-1, y-1].tag);
        // Debug.Log("Next step: " + BattleGrid[x-1, y-1]);
        // Debug.Log("Next step: " + BattleGrid[x-1, y-1].tag);
    }
}

//TODO: Look into this some more. I think I already do this but maybe there's something different I can do?
/* From Alwin.

static final int STAGE_HEIGHT = //your preference //would be 3 tall

static final int STAGE_WIDTH = ""   //would be 6 wide or do I make this 3, and do this twice :|

//Alwin says one big array is way easier. I'm inclined to belive him. He seems to know how to code.
your 2D Array: Array int stage = new Array(STAGE_HEIGHT)(STAGE_WIDTH)

//Write the 2D sprite out so you can place numbers in it corresponding to a sprite later on, for example tileOne = 1, tileTwo = 2

List<Sprites> allTiles = new List<>();

Sprite tileOne
Sprite tileTwo // add all Sprite variations you want //I thik tileOne would be red and the other would be blue. Just normal tiles for now

Start() {
 setStageTiles()
 placeAllTiles()
}

public void setStageTiles() {
for(int i = 0; i < STAGE_HEIGHT; i++) {
   for(int n = 0; n < STAGE_WIDTH; n++) {
   if(stage[i][n] == 1) {
      allTiles.add(tileOne)
   }
   if(stage[i][n] == 2) {
      allTiles.add(tileTwo)
  }
}
}

public void placeAllTiles() {

int allTilesCurrentPos = -1 //you see why -1 when calling the values

for(int i = 0; i < STAGE_HEIGHT; i++) {
   for(int n = 0; n < STAGE_WIDTH; n++) {
    allTilesCurrentPos++;

    Sprite tile =       allTiles.get(allTilesCurrentPos);
    scene.add(tile)
    scene.get(Tile).setTranslateY(at which    height you want the grid to start * i)
    scene.get(Tile).setTranslageX(at which X Coordinate you want to start it at the scene * n)
   }
}
*/