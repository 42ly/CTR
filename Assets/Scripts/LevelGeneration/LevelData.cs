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
    public List<GameObject> demonInstances, detectorInstances;
    public int ronnyRimsRoom;


    public void removeAllInstances()
    {
        while (demonInstances.Count > 0)
        {
            Destroy(demonInstances[0]);
            demonInstances.RemoveAt(0);
        }
        while (demonInstances.Count > 0)
        {
            Destroy(detectorInstances[0]);
            detectorInstances.RemoveAt(0);
        }
        if(playerInstance)
            Destroy(playerInstance);
    }
    private void Start()
    {
        particleSystemInstances = new List<GameObject>();
    }
}
