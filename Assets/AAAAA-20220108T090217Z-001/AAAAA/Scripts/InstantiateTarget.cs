using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTarget : MonoBehaviour
{
    public static GameObject me;
    public int KeyW_weight = 1;
    public int KeyA_weight = 1;
    public int KeyS_weight = 1;
    public int KeyD_weight = 1;
    public float KeySpace_weight = 1;
    public float G = 1;

    public static GameObject InstanTar(Object Target, int num)
    {
        me = GameObject.Instantiate(Target) as GameObject;
        return me;
        
    }

    public static GameObject Target()
    {
        return me;
    }

    void Update()
    {
    }
    private void FixedUpdate()
    {
        Get_Key();
        Gravity();
    }
    public void Get_Key()
    {
        if (Input.GetKey(KeyCode.W))
        {
            me.transform.position += me.transform.forward * Time.deltaTime * KeyW_weight;
        }
        if (Input.GetKey(KeyCode.A))
        {

            me.transform.Rotate(0, -100 * Time.deltaTime, 0);
            me.transform.position += me.transform.forward * Time.deltaTime * KeyA_weight;

        }
        if (Input.GetKey(KeyCode.S))
        {
            me.transform.position -= me.transform.forward * Time.deltaTime * KeyS_weight;
        }
        if (Input.GetKey(KeyCode.D))
        {

            me.transform.Rotate(0, 100 * Time.deltaTime, 0);
            me.transform.position += me.transform.forward * Time.deltaTime * KeyD_weight;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //me.transform.position -= me.transform.forward * Time.deltaTime * KeySpace_weight;
            me.transform.position += new Vector3(0, 1 * KeySpace_weight, 0);
            me.transform.position += me.transform.forward * Time.deltaTime * KeySpace_weight;
            
        }
    }

    public void Gravity()
    {
        float me_y = me.transform.position.y;
        if (me_y > 0.5)
        {
            me.transform.position -= new Vector3(0, 1 * G, 0);
        }
        else if(me_y > 0.1 && me_y <0.5)
        {
            me.transform.position -= new Vector3(0, 0.001f * G, 0);
        }
        else if(me_y == 0.1)
        {
            me.transform.position = new Vector3( me.transform.position.x , 0.1f , me.transform.position.z );
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(me.transform.position, me.transform.position + me.transform.forward*5);
    }

    //static bool ccc = Physics.Raycast(me.transform.position,me.transform.forward);

    //void OnTriggerEnter(Collider other)
    //{

    //    if (other.tag == "evir")
    //    {
    //        me.transform.position -= me.transform.forward * Time.deltaTime * KeyW_weight;
    //    }

    //}
    
}