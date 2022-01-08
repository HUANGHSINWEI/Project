using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public static Transform playerPos;
    public Vector3 offect;

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.position = playerPos.position+ offect;
    }
}
