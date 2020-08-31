using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateRoom : MonoBehaviour
{
    private Tilemap floorTilemap, wallTilemap;
    private Tile floor, wall;
    private GameObject playerInstance, playerPrefab, portalInstance, portalPrefab,
        ronnyRimsInstance, ronnyRimsPrefab, demonPrefab;
    private LevelData levelData;

    private void Start()
    {
        levelData = GetComponent<LevelData>();
        floorTilemap = levelData.floorTilemap;
        wallTilemap = levelData.wallTilemap;
        floor = levelData.floor;
        wall = levelData.wall;
        ronnyRimsPrefab = levelData.ronnyRimsPrefab;
        portalPrefab = levelData.portalPrefab;
        playerPrefab = levelData.playerPrefab;
        playerInstance = levelData.playerInstance;
        demonPrefab = levelData.demonPrefab;
    }
    private bool IsColliding(Vector3Int origin, int roomWidth, int roomHeight)
    {
        Vector3Int scanPosition;
        for (int height = 0; height < roomHeight; height += 1)
        {
            for (int width = 0; width < roomWidth; width += 1)
            {
                scanPosition = new Vector3Int(origin.x + width, origin.y + height, 0);
                if (floorTilemap.HasTile(scanPosition) || wallTilemap.HasTile(scanPosition))
                {
                    return true;
                }
            }
        }
        return false;
    }
    public Vector3Int generateRoom(bool spawnPlayer, bool spawnRonnyRims, bool spawnPortal)
    {
        int worldWidth = 100;
        int worldHeight = 100;
        int roomWidth = Random.Range(10, 20);
        int roomHeight = Random.Range(10, 30);
        int numEnemies;
        bool CollisionFlag = false;
        Vector3Int roomOrigin = new Vector3Int(Random.Range(0, worldWidth - roomWidth), Random.Range(0, worldHeight - roomHeight), 0);
        Vector3Int rightCorner = new Vector3Int(roomOrigin.x + roomWidth, roomOrigin.y, 0);
        Vector3Int upperRightCorner = new Vector3Int(roomOrigin.x + roomWidth, rightCorner.y + roomHeight, 0);
        Vector3Int upperLeftCorner = new Vector3Int(roomOrigin.x, roomOrigin.y + roomHeight, 0);
        Vector3Int playerPosition, ronnyRimsPosition, roomCenter, demonPosition;

        CollisionFlag = IsColliding(roomOrigin, roomWidth, roomHeight);
        if (CollisionFlag == false)
        {
            numEnemies = Random.Range(1, 6);
            for (int y = roomOrigin.y; y <= roomOrigin.y + roomHeight; y += 1)
            {
                for (int x = roomOrigin.x; x <= roomOrigin.x + roomWidth; x += 1)
                {
                    Vector3Int currentPositon = new Vector3Int(x, y, 0);
                    if (currentPositon.x == roomOrigin.x || currentPositon.x == roomOrigin.x + roomWidth ||
                        currentPositon.y == roomOrigin.y || currentPositon.y == roomOrigin.y + roomHeight)
                    {
                        wallTilemap.SetTile(currentPositon, wall);
                    }
                    else
                    {
                        floorTilemap.SetTile(currentPositon, floor);
                    }
                }
            }
            if (spawnPlayer == true)
            {
                playerPosition = new Vector3Int(Random.Range(roomOrigin.x + 2, roomOrigin.x + roomWidth - 2), Random.Range(roomOrigin.y + 2, roomOrigin.y + roomHeight - 2), 0);
                playerInstance = Instantiate(playerPrefab, playerPosition, Quaternion.identity);
                levelData.playerInstance = playerInstance;
            }
            else if (spawnPlayer == false)
            {
                for(int i = 0; i < numEnemies; i += 1)
                {
                    demonPosition = new Vector3Int(Random.Range(roomOrigin.x + 2, roomOrigin.x + roomWidth - 2), Random.Range(roomOrigin.y + 2, roomOrigin.y + roomHeight - 2), 0);
                    Instantiate(demonPrefab, demonPosition, Quaternion.identity);
                }
                if(spawnRonnyRims)
                {
                    ronnyRimsPosition = new Vector3Int(Random.Range(roomOrigin.x + 2, roomOrigin.x + roomWidth - 2), Random.Range(roomOrigin.y + 2, roomOrigin.y + roomHeight - 2), 0);
                    ronnyRimsInstance = Instantiate(ronnyRimsPrefab, ronnyRimsPosition, Quaternion.identity);
                }
                if (spawnPortal)
                {
                    Vector3Int portalPosition = new Vector3Int(Random.Range(roomOrigin.x + 2, roomOrigin.x + roomWidth - 2), Random.Range(roomOrigin.y + 2, roomOrigin.y + roomHeight - 2), 0);
                    portalInstance = Instantiate(portalPrefab, portalPosition, Quaternion.identity);
                }
            }
            roomCenter = new Vector3Int(roomOrigin.x + (roomWidth / 2), roomOrigin.y + (roomHeight / 2), 0);
        }
        else
        {
            // Flag
            roomCenter = new Vector3Int(0, 0, 0);
        }
        return roomCenter;
    }
}
