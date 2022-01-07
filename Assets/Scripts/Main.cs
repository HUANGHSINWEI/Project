using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private List<GameObject> terrainPrefabIns;
    // Start is called before the first frame update
    void Start()
    {
        terrainPrefabIns =LoadTerrain.LoadData();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
