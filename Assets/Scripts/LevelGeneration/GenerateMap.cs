using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.Video;

public class GenerateMap : MonoBehaviour
{
    private void Start()
    {
        generateMap();
    }
    private void clearMap()
    {
        GetComponent<LevelData>().wallTilemap.ClearAllTiles();
        GetComponent<LevelData>().floorTilemap.ClearAllTiles();
        GetComponent<GenerateRoom>().taskTilemap.ClearAllTiles();
    }
    public void generateMap()
    {
        clearMap();
        List<Vector3Int> roomCenters = new List<Vector3Int>();
        Vector3Int roomCenter;
        bool doSpawnPlayer = false, doSpawnRonnyRims = false, doSpawnPortal = false;
        int playerRoom, ronnyRimsRoom, iterationLimit;

        iterationLimit = 4;
        ronnyRimsRoom = Random.Range(0, 4);
        playerRoom = Random.Range(0, 4);
        for(int numRooms = 0; numRooms < 5; numRooms += 1)
        {
            if(numRooms == playerRoom)
                doSpawnPlayer = true;
            else
                doSpawnPlayer = false;
            if(numRooms == ronnyRimsRoom)
                doSpawnRonnyRims = true;
            else
                doSpawnRonnyRims = false;
            if(numRooms == 4)
                doSpawnPortal = true;
            roomCenter = GetComponent<GenerateRoom>().generateRoom(doSpawnPlayer, doSpawnRonnyRims, doSpawnPortal);
            while(roomCenter.x == 0 && roomCenter.y == 0 && roomCenter.z == 0)
            {
                if(iterationLimit <= 0)
                {
                    numRooms = 8;
                    break;
                }
                roomCenter = GetComponent<GenerateRoom>().generateRoom(doSpawnPlayer, doSpawnRonnyRims, doSpawnPortal);
                iterationLimit -= 1;
            }
            roomCenters.Add(roomCenter);
        }
        GetComponent<GeneratePaths>().generatePaths(roomCenters);
    }
}
