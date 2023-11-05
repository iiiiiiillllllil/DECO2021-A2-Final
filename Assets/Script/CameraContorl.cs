using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContorl : MonoBehaviour
{
    //目标物体
    public Transform target;
   // private CarMoveControl Control;
    public float speed;

    [Header("----------相机基础属性-------------")]
    //鼠标滑轮的速度
    public float ScrollSpeed = 45f;


    public float Ydictance = 0f;
    private float Ymin = 0f;
    private float Ymax = 4f;


    public float Zdictance = 4f;
    private float Zmin = 4f;
    private float Zmax = 15f;

    //相机看向的角度 和最終位置
    public float angle = -25;
    private Vector3 lastPosition;
    private Vector3 lookPosition;

    [Header("----------加速时相机属性-------------")]
   

    

    public float off = 20;

    //为一些属性初始化
    private void Start()
    {
     
    }

    void LateUpdate()
    {
        FllowEffect(); //相机属性显示

        CameraAtrribute(); //相机跟随功能

    }

    //相机属性显示
    public void CameraAtrribute()
    {
        //实时速度
       // Control = target.GetComponent<CarMoveControl>();

       // speed = Mathf.Lerp(speed, Control.Km_H / 4, Time.deltaTime);

        speed = Mathf.Clamp(speed, 0, 55);   //对应最大200公里每小时

    }

    //相机跟随功能
    public void FllowEffect()
    {
        //Z轴和Y轴的距离和鼠标滑轮联系

        Ydictance += Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed * Time.deltaTime;//平滑效果
        Zdictance += Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed * Time.deltaTime * 2;

        //設置Y軸和x轴的滚轮滑动范围 
        Ydictance = Mathf.Clamp(Ydictance, Ymin, Ymax);
        Zdictance = Mathf.Clamp(Zdictance, Zmin, Zmax);

        //确定好角度，四元数 * 三维向量 = 三维向量 和最终位置
        lookPosition = Quaternion.AngleAxis(angle, target.right) * -target.forward;

        lastPosition = target.position + Vector3.up * Ydictance - lookPosition * Zdictance;

      
        transform.position = lastPosition;

        //更新角度
        transform.rotation = Quaternion.LookRotation(lookPosition);
    }

   

}

