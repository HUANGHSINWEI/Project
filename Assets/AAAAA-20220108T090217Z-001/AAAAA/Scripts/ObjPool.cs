using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPool : MonoBehaviour
{
    public class ObjData
    {
        public GameObject me;
        public bool useOn;
    }
    private static ObjPool mInstance;

    private List<ObjData> objDataContainer;

    public ObjPool()
    {
        mInstance = this;
    }

    public void InitObjData(Object prefab , int iCount)
    {
        objDataContainer = new List<ObjData>();
        for(int i = 0; i < iCount; i++)
        {
            GameObject me = GameObject.Instantiate(prefab) as GameObject;
            me.SetActive(false);
            ObjData data = new ObjData();
            data.useOn = false;
            data.me = me;
            objDataContainer.Add(data);
        }
    }

    public GameObject LoadObjData()
    {
        int iCount = objDataContainer.Count;
        GameObject LObj = null;
        for(int i = 0; i < iCount ; i++)
        {
            if(objDataContainer[i].useOn ==false )
            {
                LObj = objDataContainer[i].me;
                objDataContainer[i].useOn = true;
                break;
            }    
        }
        return LObj;
    }

    public  void UnLoadObjData(GameObject me)
    {
        int iCount = objDataContainer.Count;
        //GameObject LObj = null;
        for(int i = 0; i < iCount; i++)
        {
            if(objDataContainer[i].me == me)
            {
                objDataContainer[i].me.SetActive(false);
                objDataContainer[i].useOn = false;
                break;
            }
                
        }
    }
}
