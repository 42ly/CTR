using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GeneratePaths : MonoBehaviour
{
    private Tilemap wallTilemap, floorTilemap;
    private Tile wall, floor;
    private LevelData levelData;

    private void Start()
    {
        levelData = GameObject.Find("GameManager").GetComponent<LevelData>();
        wallTilemap = levelData.wallTilemap;
        floorTilemap = levelData.floorTilemap;
        wall = levelData.wall;
        floor = levelData.floor;
    }
    private void wallOff(Vector3Int origin)
    {
        Vector3Int scanPosition = new Vector3Int(0, 0, 0);
        for (int x = -1; x < 2; x += 1)
        {
            for (int y = -1; y < 2; y += 1)
            {
                scanPosition.x = origin.x + x;
                scanPosition.y = origin.y + y;
                if (wallTilemap.HasTile(scanPosition) == false && floorTilemap.HasTile(scanPosition) == false)
                {
                    wallTilemap.SetTile(scanPosition, wall);
                }
            }
        }
    }
    private void drawPath(Vector3Int point1, Vector3Int point2)
    {
        if (point1.x > point2.x)
        {
            while (point1.x > point2.x)
            {
                point1.x -= 1;
                floorTilemap.SetTile(point1, floor);
                if (wallTilemap.HasTile(point1))
                {
                    wallTilemap.SetTile(point1, null);
                }
                wallOff(point1);
            }
        }
        else if (point1.x < point2.x)
        {
            while (point1.x < point2.x)
            {
                point1.x += 1;
                floorTilemap.SetTile(point1, floor);
                if (wallTilemap.HasTile(point1))
                {
                    wallTilemap.SetTile(point1, null);
                }
                wallOff(point1);
            }
        }
        if (point1.y < point2.y)
        {
            while (point1.y < point2.y)
            {
                point1.y += 1;
                floorTilemap.SetTile(point1, floor);
                if (wallTilemap.HasTile(point1))
                {
                    wallTilemap.SetTile(point1, null);
                }
                wallOff(point1);
            }
        }
        else if (point1.y > point2.y)
        {
            while (point1.y > point2.y)
            {
                point1.y -= 1;
                floorTilemap.SetTile(point1, floor);
                if (wallTilemap.HasTile(point1))
                {
                    wallTilemap.SetTile(point1, null);
                }
                wallOff(point1);
            }
        }
    }
    public void generatePaths(List<Vector3Int> roomCenters)
    {
        // Select a center, find the nearest center relative to it, draw a path to it
        int distance = 0;
        int leastDistance;
        int usedRoomCenter;
        List<System.Tuple<int, int>> usedRoomCenters = new List<System.Tuple<int, int>>();
        System.Tuple<int, int> usedPath;
        Vector3Int point1, point2;

        point2 = new Vector3Int(0, 0, 0);
        for (int roomCenterIndex = 0; roomCenterIndex < roomCenters.Count; roomCenterIndex += 1)
        {
            point1 = roomCenters[roomCenterIndex];
            leastDistance = 1000000;
            usedRoomCenter = 0;
            for (int otherRoomCenterIndex = 0; otherRoomCenterIndex < roomCenters.Count; otherRoomCenterIndex += 1)
            {
                bool isPath = false;
                for (int i = 0; i < usedRoomCenters.Count; i += 1)
                {
                    if ((usedRoomCenters[i].Item1 == roomCenterIndex && usedRoomCenters[i].Item2 == otherRoomCenterIndex) ||
                        (usedRoomCenters[i].Item1 == otherRoomCenterIndex && usedRoomCenters[i].Item2 == roomCenterIndex))
                    {
                        isPath = true;
                    }
                }
                if (otherRoomCenterIndex != roomCenterIndex && isPath == false)
                {
                    distance = (int)(Mathf.Sqrt(Mathf.Pow(roomCenters[otherRoomCenterIndex].x - roomCenters[roomCenterIndex].x, 2) +
                        Mathf.Pow(roomCenters[otherRoomCenterIndex].y - roomCenters[roomCenterIndex].y, 2)));
                    if (distance < leastDistance)
                    {
                        leastDistance = distance;
                        point2 = roomCenters[otherRoomCenterIndex];
                        usedRoomCenter = otherRoomCenterIndex;
                    }
                }
            }
            usedPath = System.Tuple.Create(roomCenterIndex, usedRoomCenter);
            usedRoomCenters.Add(usedPath);
            drawPath(point1, point2);
        }
    }
}
