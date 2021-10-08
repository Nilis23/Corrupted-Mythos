using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(EdgeCollider2D), typeof(Tilemap))]
public class TilemapCollider : MonoBehaviour
{
    [SerializeField]
    EdgeCollider2D myCol; //The collider to look at
    [SerializeField]
    Tilemap myMap; //The tilemap to look at
    [Space]
    [Tooltip("This is the max the Y value can deviate between two positions")]
    [SerializeField]
    float MaxYDiff;
    [Tooltip("This is the max the X value can deviate between two positions")]
    [SerializeField]
    float MaxXDiff;
    [Tooltip("The dip in Y value when an X gap is reached")]
    [SerializeField]
    float dip;
    
    public void BuildCollider()
    {
        //Create the list of points
        List<Vector2> validPositions = new List<Vector2>();
        
        //Initialize the emergency counter and grab a starting position. Add it to the array
        int points = 0;
        Vector2 startPos =  FindStartPos();
        validPositions.Add(new Vector2(startPos.x, startPos.y + 1));

        //Set complete to false. The loop will run while complete is false and the brakes have not been pumped
        bool complete = false;
        while (!complete && points < 10000)
        {
            Vector2 lastPos = validPositions[validPositions.Count - 1];

            //Look for next position
            Vector2 newPos = CheckNextPos(new Vector2(lastPos.x, lastPos.y - 1));

            //If the new position is -inf, end the loop. Otherwise, bound check to see if there is a gap or change in altitude and add necessary points in
            if(newPos.Equals(Vector2.negativeInfinity))
            {
                complete = true;
            }
            else
            {
                if (Mathf.Abs(newPos.x - lastPos.x) > 1)
                {
                    validPositions.Add(new Vector2(lastPos.x + 1, lastPos.y));
                    validPositions.Add(new Vector2(lastPos.x + 1, lastPos.y - dip));
                    validPositions.Add(new Vector2(newPos.x, lastPos.y - dip));
                }
                else if(Mathf.Abs(newPos.y - lastPos.y) > 0)
                {
                    validPositions.Add(CapPos(lastPos));
                }
                validPositions.Add(newPos);
            }

            //Increment emergency check
            points++;
        }

        //Once the loop is done, add one last cap to cover the last corner and then assign the list of points to the collider
        validPositions.Add(CapPos(validPositions[validPositions.Count - 1]));
        myCol.SetPoints(validPositions);
    }

    private Vector2 FindStartPos()
    {
        Vector2 sp = Vector2.negativeInfinity;

        //Run through each tile in the map. Find the tile with the lowest x value. Return -inf if no valid tile is found
        foreach(Vector3Int position in myMap.cellBounds.allPositionsWithin)
        {
            if (myMap.HasTile(position))
            {
                if (sp.Equals(Vector2.negativeInfinity))
                {
                    sp = new Vector2(position.x, position.y);
                }
                else if(position.x < sp.x)
                {
                    sp = new Vector2(position.x, position.y);
                }
                //return pos;
            }
        }
        return sp;
    }

    private Vector2 CheckNextPos(Vector2 lastPos)
    {
        //Create starting x position and then run through two loops to test every tile in range until a new tile is found. Range is based on max y and x diff
        float x = lastPos.x + 1f;
        while (Mathf.Abs(x - (lastPos.x + 1)) <= MaxXDiff)
        {
            float y = lastPos.y + MaxYDiff;
            while (y >= lastPos.y - MaxYDiff)
            {
                //Create a Vec3Int position based on the current search grid and test it for tile placement
                Vector3Int testPos = new Vector3Int((int)x, (int)y, 0);
                if (myMap.HasTile(testPos))
                {
                    return new Vector2(x, y + 1);
                }
                y--;
            }
            x++;
        }
        //Return a negative inf vector if no new tile is found. This indicates that the collider has reached the end according to it's parameters
        return Vector2.negativeInfinity;
    }

    private Vector2 CapPos(Vector2 input)
    {
        //calculate the position necessary to add another corner to the currnent tile
        return new Vector2(input.x + 1, input.y);
    }
}
