using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehavior : MonoBehaviour
{
   public static void ttt(float t)
    {
        t = 1.0f;
    }
    public static void Move(AIData data)
    {
        //Debug.Log(data.m_fTempTurnForce+"aaaa");
        if(data.m_bMove == false)
        {
            return;
        }
        Transform myobj = data.mGoGo.transform;
        Vector3 myPos = data.mGoGo.transform.position;
        Vector3 vr = myobj.right;
        //Vector3 vec = myobj.forward;
        Vector3 vf = data.mCurrentVec;

        if(data.m_fTempTurnForce > data.m_fMaxRotate)
        {
            data.m_fTempTurnForce = data.m_fMaxRotate;
        }
        else if(data.m_fTempTurnForce < -data.m_fMaxRotate)
        {
            data.m_fTempTurnForce = -data.m_fMaxRotate;
        }
        else
        {
            data.m_fTempTurnForce = -data.m_fTempTurnForce;
        }
        //Debug.Log(data.m_fTempTurnForce + "aaaa1");
        //Debug.Log(vf+"1");
        vf = vf + vr * data.m_fTempTurnForce;
        //Debug.Log(vf+"2");
        vf.Normalize();
        vf.y = 0;
        myobj.forward = vf;

        data.m_Speed = data.m_Speed + data.m_fMoveForce * Time.deltaTime;
        if(data.m_Speed < 0.01f)
        {
            data.m_Speed = 0.01f;
        }
        else if(data.m_Speed > data.m_fMaxSpeed)
        {
            data.m_Speed = data.m_fMaxSpeed;
        }

        //myobj.forward = vec;

        //if (data.m_Speed < 0.02f)
        //{
        //    if (data.m_fTempTurnForce > 0)
        //    {
        //        myobj.forward = vr;
        //    }
        //    else
        //    {
        //        myobj.forward = -vr;
        //    }
        //}
        
        myPos = myPos + myobj.forward * data.m_Speed;
        myobj.position = myPos;
    }
    public static bool Seek(AIData data)
    {
        Vector3 myPos = data.mGoGo.transform.position; //起始&即時物件位置
        Vector3 vec = data.mTarget - myPos; //起始&即時向量
        vec.y = 0.0f;
        

        float fDist = vec.magnitude;  //fDist為vec的length

        //DeadZone

        if (fDist < data.m_Speed + 0.5f) 
        {
            Vector3 vGoal = data.mTarget;  //把目標座標丟給Goal
            vGoal.y = myPos.y;  //排除掉y
            data.mGoGo.transform.position = vGoal;  //把終點與物件座標對齊
            data.m_fMoveForce = 0.0f; //合力歸零
            data.m_fTempTurnForce = 0.0f;//旋轉歸零
            data.m_Speed = 0.0f;
            data.m_bMove = false;  //bool move = false
            return false;
            
        }

        Vector3 vf = data.mGoGo.transform.forward; //物件的平行方向
        Vector3 vr = data.mGoGo.transform.right;  //物件的垂直方向
        data.mCurrentVec = vf; //把正面設成即時方向
        vec.Normalize(); //vec單位化 length = 1的向量
        float fDotF = Vector3.Dot(vf, vec); //vf在vec上投影的角度 

        //Debug.Log(fDotF+"F");
        //Debug.Log(data.m_fTempTurnForce+"TTF");

        if (fDotF > 0.96f) //防呆 //vf & vec length = 1 條件只看cos角  //若cos角幾乎為0
        {
            fDotF = 1.0f;  
            data.mCurrentVec = vec;  //把即時方向改成目標方向
            data.m_fTempTurnForce = 0.0f; //垂直向量歸零
            data.m_Rotate = 0.0f; //無旋轉
        }

        
        else
        {
            //防呆

            if (fDotF < -1.0f) 
            {
                fDotF = -1.0f; 
            }

            //fDotR = 物件的垂直方向 dot 物件到目標的方向  normalize化純cos角

            float fDotR = Vector3.Dot(vr, vec); //vr dot vec的角度

            //若方向正確 fDotF該為0 

            if (fDotF < 0.0f)  //小於0為反向 //if current vec
            {

                if (fDotR > 0.0f)  //給予順或逆的1旋轉向量
                {
                    fDotR = 1.0f;
                }
                else
                {
                    fDotR = -1.0f;
                }
            }
            if(fDist < 3.0f)  //若距離在3以內
            {
                fDotR *= (fDist / 3.0f + 1.0f);  //fDotR則為距離反比
            }
            data.m_fTempTurnForce = fDotR;
            
        }

        if(fDist < 3.0f)
        {
            //Debug.Log(data.m_Speed);

            if(data.m_Speed > 0.1f)
            {
                data.m_fMoveForce = -(1.0f - fDist / 3.0f) * 5.0f;
            }
            else
            {
                data.m_fMoveForce = fDotF * 100.0f;
            }
        }
        else
        {
            data.m_fMoveForce = fDotF * 100.0f;
        }

        data.m_bMove = true;
        return true;
    }
}
