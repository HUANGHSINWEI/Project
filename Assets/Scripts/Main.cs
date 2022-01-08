using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private List<GameObject> terrainPrefabIns;
    private GameObject player;
    delegate void keydown();
    Dictionary<string, keydown> creator = new Dictionary<string, keydown>();

    private void Awake()
    {
        terrainPrefabIns = LoadTerrain.LoadData();
        player = LoadCharacter.LoadData();
        FlowPlayer.playerPos = player.transform;
        Controller();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.anyKey)
        //{
        //    Debug.Log(Input.inputString);
        //    creator[Input.inputString]();
        //}
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.position += player.transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {

            player.transform.Rotate(0, -100 * Time.deltaTime, 0);
            player.transform.position += player.transform.forward * Time.deltaTime / 10;

        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position -= player.transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {

            player.transform.Rotate(0, 100 * Time.deltaTime, 0);
            player.transform.position += player.transform.forward * Time.deltaTime / 10;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //me.transform.position -= me.transform.forward * Time.deltaTime * KeySpace_weight;
            player.transform.position += new Vector3(0, 1 , 0);
            player.transform.position += player.transform.forward * Time.deltaTime ;
        }

    }

    void Controller()
    {
        creator[""] = () => { };
        creator["w"] = () => player.transform.position += player.transform.forward * Time.deltaTime; ;
        creator["s"] = () => player.transform.position -= player.transform.forward * Time.deltaTime;
        creator["a"] = () => {
                                player.transform.Rotate(0, -100 * Time.deltaTime, 0);
                                player.transform.position += player.transform.forward * Time.deltaTime / 10;
                             };
        creator["d"] = () => {
                                player.transform.Rotate(0, 100 * Time.deltaTime, 0);
                                player.transform.position += player.transform.forward * Time.deltaTime / 10;
                             };
        creator["Space"] = () => player.transform.position -= player.transform.forward * Time.deltaTime;
    }

}
