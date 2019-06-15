using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    public Vector2Int GridSize;
    public Vector2Int TileSize;
    public List<Building> GridBuildings;
    public static GameGrid Instance { get; private set; }
    private Bounds gameBounds;
    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        GridBuildings.AddRange(FindObjectsOfType<Building>());
        Vector3 gridSize = new Vector3(GridSize.x*TileSize.x, 10,GridSize.y*TileSize.y);
        gameBounds = new Bounds(transform.position,gridSize);
    }

    public bool CanPlaceBuilding(Building buildingToPlace, Vector3 placingPosition)
    {
        Vector3 buildingRealSize = new Vector3(buildingToPlace.Size.x*TileSize.x, 10,buildingToPlace.Size.y*TileSize.y);
        Vector3 realPlacingPosition =new Vector3(placingPosition.x+buildingRealSize.x/2,0,placingPosition.z-buildingRealSize.z/2);
        Bounds buildingBounds = new Bounds(realPlacingPosition,buildingRealSize);
        bool buildingInsideGrid = gameBounds.Intersects(buildingBounds);
        if (buildingInsideGrid)
        {
            Debug.Log("building inside grid");
        }
        else
        {
            Debug.Log("building outside grid");
            return false;
        }
        
        foreach (Collider collidedObject in Physics.OverlapBox(realPlacingPosition, buildingRealSize/2-Vector3.one*2))
        {
            if (collidedObject.transform.parent != null && collidedObject.transform.parent.GetComponent<Building>() != null)
            {
                Building collidedBuilding = collidedObject.transform.parent.GetComponent<Building>();
                if (collidedBuilding != buildingToPlace)
                {
                    Debug.Log("There was another in this part of the grid");
                    return false;
                }
            }
        }
        return true;
    }

}
