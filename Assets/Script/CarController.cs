using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CarController : MonoBehaviour
{
    public float speed = 15f;
    public float rotationSpeed = 50f;
    public float steeringAngle = 10f;
    public Transform frontLeftWheel, frontRightWheel, rearLeftWheel, rearRightWheel;
    public Transform steeringWheel;
    public WheelCollider frontLeftCollider, frontRightCollider, rearLeftCollider, rearRightCollider;

    public GameObject cam1, cam2;
    bool flag = false;
    //public CinemachineVirtualCamera camera;
    //public Transform tran;
    //bool flagSet = false;
    //float timeSet;
    //public GameObject go;
    //public Button an;

    private float horizontalInput, verticalInput;

    private void Start()
    {
        //an.onClick.AddListener(() =>
        //{
        //    Time.timeScale = 1;
        //    transform.position = new Vector3(-172, 9.8f, -180);
        //    transform.localEulerAngles = new Vector3(0, 16.7f, 0);
        //    GetComponent<Camera>().gameObject.SetActive(false);
        //    tran.gameObject.SetActive(false);
        //    go.SetActive(false);
        //    flagSet = false;
        //});
    }


    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");



        //摁下鼠标右键加速
        if (verticalInput == Input.GetAxis("Vertical") && Input.GetMouseButton(1))
        {
            speed = 20f;
        }
        //抬起鼠标右键变成初始速度
        if (verticalInput == Input.GetAxis("Vertical") && Input.GetMouseButtonUp(1))
        {
            speed = 15f;
        }
        //第一人称和第三人称切换
        if (Input.GetKeyDown(KeyCode.Q))
        {
            flag = !flag;
            cam1.SetActive(!flag);
            cam2.SetActive(flag);
        }
        //摁下空格刹车
        if (Input.GetKey(KeyCode.Space) && speed != 0)
        {
            speed -= Time.deltaTime * 10;
            if (speed <= 0.01f)
            {
                speed = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            speed = 20f;
        }

    }

    void FixedUpdate()
    {

        if (GameManager.instance.flag)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            transform.Rotate(Vector3.up, rotationSpeed * horizontalInput * Time.deltaTime);
        }
        float steerAngle = steeringAngle * horizontalInput;
        frontLeftCollider.steerAngle = steerAngle;
        frontRightCollider.steerAngle = steerAngle;
        frontLeftWheel.localEulerAngles = new Vector3(0, steerAngle, 0);
        frontRightWheel.localEulerAngles = new Vector3(0, steerAngle, 0);

        float wheelAngle = Mathf.Clamp(horizontalInput * 45f, -45f, 45f);
        steeringWheel.localEulerAngles = new Vector3(0, 0, -wheelAngle);

        frontLeftCollider.motorTorque = speed * verticalInput;
        frontRightCollider.motorTorque = speed * verticalInput;

        rearLeftCollider.motorTorque = speed * verticalInput;
        rearRightCollider.motorTorque = speed * verticalInput;

        float rotate = verticalInput * rotationSpeed * Time.deltaTime;
        frontLeftWheel.Rotate(rotate * Vector3.right);
        frontRightWheel.Rotate(rotate * Vector3.right);
        rearLeftWheel.Rotate(rotate * Vector3.right);
        rearRightWheel.Rotate(rotate * Vector3.right);

        //if (flagSet)
        //{
        //    timeSet += Time.deltaTime;
        //    if (timeSet>=5)
        //    {
        //        go.SetActive(true);
        //        Time.timeScale = 0;
        //        flagSet = false;
        //        timeSet = 0;

        //    }
        //}

    }
}
