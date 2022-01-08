using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    ObjPool myPool;
    //InstantiateTarget InT;
    public Object Target;
    public Object prefab;
    private GameObject Goal;
    private List<GameObject> LoadedObj;
    public int SetNum;
    private void Awake()
    {
        Goal = InstantiateTarget.InstanTar(Target, 1);
        //InT = new InstantiateTarget();
        //InT.InstanTar(Target, 1);

        myPool = new ObjPool();
        myPool.InitObjData(prefab, SetNum);

        LoadedObj = new List<GameObject>();
        Debug.Log("insMain");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (SetNum > LoadedObj.Count)
            {
                GameObject me = myPool.LoadObjData();
                me.SetActive(true);
                me.transform.position = new Vector3(Random.Range(-500.0f, 500.0f), 0.0f, Random.Range(-500.0f, 500.0f));
                LoadedObj.Add(me);
                Debug.Log("LoadedObj = "+LoadedObj.Count);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            int iCount = LoadedObj.Count;
            if(iCount >0)
            {
                int id = Random.Range(0, iCount);
                GameObject me = LoadedObj[id];
                myPool.UnLoadObjData(me);
                LoadedObj.RemoveAt(id);
                Debug.Log("ID = "+ id);
            }
            
        }
    }
}
