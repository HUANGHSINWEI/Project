using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += gameObject.transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {

            gameObject.transform.Rotate(0, -100*Time.deltaTime,0);
            gameObject.transform.position += gameObject.transform.forward * Time.deltaTime/10;

        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position -= gameObject.transform.forward* Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {

            gameObject.transform.Rotate(0, 100 * Time.deltaTime,0);
            gameObject.transform.position += gameObject.transform.forward * Time.deltaTime / 10;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.transform.position -= gameObject.transform.forward * Time.deltaTime;
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(gameObject.transform.position, gameObject.transform.position + gameObject.transform.forward);
    }
}
