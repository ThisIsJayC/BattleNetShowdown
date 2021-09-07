using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTypes : MonoBehaviour
{


    //TODO: implement the tile types for the grid


    /*
    [ ] Normal - Base tile
    [ ] Cracked - Damaged tile that will break once the player steps on and then steps off of. Can also be broken when hit by an attack or after an object that is placed on it breaks
    [ ] Broken - Cannot be stepped on. Will regenerate after a set amount of time.
    [ ] Hole - Cannot be stepped on and will NOT regenerate.
    [ ] Grass - Can be used in conjuction with some wood attacks for bonus effects. Increases fire damage
    [ ] Sand - Once the player steps on this tile, they are unable to move freely for a small amount of time.
    [ ] Metal - Just like the Normal tiles, but cannot be broken
    [ ] Ice - The player will slide the entire row/column if they move. Can be used in conjuction with some water attacks. Increases electric damage.
    [ ] Poison - Constantly drains the player of health while standing on the tile.
    [ ] Lava - Can be used in conjuctionwith some fire attacks. Increases water damage. Once the player steps on this tile, they take a set amount of damage. This will consume the tile and reset it back to a Normal tile.
    [ ] Holy - Player takes half damage while standing on this tile.
    [ ] Spike - Stepping onto the tile will do X damage. Remains on the field until broken with break attacks
    [ ] Slider - When a player steps onto this tile, it will move them 1 square in the direction that the arrow is facing on the slider tile.
    [ ] Magnetic - Pulls the character to the panel if they are idle 1 sec(?) and on an adjacent tile
    [ ] Teleport - Blink from one tile to the matching teleport tile
    */
}
