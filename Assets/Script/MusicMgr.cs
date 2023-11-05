using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMgr : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audios;
    public bool flag = false;
    public AudioClip[] audioClips;
    int index = 0;
    int count;
    Vector3 pos1;
    Vector3 pos2;

    //当前视野
    private float startView;
    //目标视野 （让其显示可见）
    [SerializeField]
    private float addFov;
    //加速时的跟随力度
    [Range(1, 5)]
    public float shiftOff;

    void Start()
    {

        startView = Camera.main.fieldOfView; //将相机的开始属性赋入
        audios.Stop();
        count = audioClips.Length;
        pos1 = new Vector3(-0.311f, 1.189f, -0.214f);
        pos2 = new Vector3(-0.311f, 2.64f, -5.01f);

        addFov = 30;

    }

    private void LateUpdate()
    {
        FOXChange();
    }
    //加速时相机视野的变化
    public void FOXChange()
    {
        if (Input.GetKey(KeyCode.LeftShift)) //按下坐标shift键生效
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, startView + addFov, Time.deltaTime * shiftOff);
        }
        else
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, startView, Time.deltaTime * shiftOff);
        }

    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    if (transform.position== transform.parent.position + pos1)
        //    {
        //        transform.position = transform.parent.position+ pos2;
        //    }
        //    else if(transform.position == transform.parent.position + pos2)
        //    {
        //        transform.position = transform.parent.position + pos1;
        //    }
        //    else
        //    {
        //        transform.position = transform.parent.position + pos1;
        //    }
        //}
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (flag)
            {
                audios.Stop();
                flag = !flag;
            }
            else
            {
                audios.Play();
                flag = !flag;
            }
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            index++;
            if (index>=count)
            {
                index = 0;
            }
            audios.clip = audioClips[index];
            audios.Play();

        }

    }
}
