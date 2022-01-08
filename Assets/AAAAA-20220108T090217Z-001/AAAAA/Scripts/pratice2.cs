using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pratice2 : MonoBehaviour
{
    //public Object Target;

    private GameObject m_Goal;
    public AIData m_data;
    //public GameObject m_goal;
    private void Awake()
    {
        //GameObject aaa = GameObject.Instantiate(Target) as GameObject;
        //m_Goal = aaa;
        //Debug.Log("ins1111");
    }
    private void Start()
    {

    }
    void Update()
    {
        m_Goal = InstantiateTarget.Target();
        Debug.Log(m_Goal.transform.position+"m_gaol");
        m_data.mTarget = m_Goal.transform.position;

        SteeringBehavior.Seek(m_data);
        SteeringBehavior.Move(m_data);
    }
    //private void FixedUpdate()
    //{
    //    GetGoal();
    //    Debug.Log(m_goal.transform.position + "GoalPos");
    //}
    private void OnDrawGizmos()
    {
        if(m_data != null)
        {
            if(m_data.m_fMoveForce > 0.0f)
            {
                Gizmos.color = Color.blue;
            }
            else
            {
                Gizmos.color = Color.red;
            }

            Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward * m_data.m_fMoveForce * 4.0f);

            Gizmos.color = Color.green;

            Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward * 2.0f);

            Gizmos.color = Color.yellow;

            Gizmos.DrawLine(this.transform.position, m_data.mTarget);
        }
    }
    //public void GetGoal()
    //{
    //    m_goal.transform.position = m_Goal.transform.position;
    //    m_data.mTarget = m_goal.transform.position;
    //    Debug.Log(m_goal.transform.position + "GoalPos");
    //}
}
