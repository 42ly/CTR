using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class LevelData : MonoBehaviour
{
    public Tilemap floorTilemap, wallTilemap;
    public Tile wall, floor, door;
    public List<GameObject> particleSystemInstances;
    public GameObject playerPrefab, portalPrefab, ronnyRimsPrefab, demonPrefab;
    public GameObject playerInstance;
    public int ronnyRimsRoom;

    private void Start()
    {
        particleSystemInstances = new List<GameObject>();
    }
}
