using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCompleteEventArgs
{
    public GameObject targetObject;
    public Vector3 position;
    public Quaternion quaternion;
}

public class Camera_movement : MonoBehaviour
{

    public static event System.EventHandler<MoveCompleteEventArgs> EventHandler_CameraMoveTargtet;


    public float xmove = 0;  // X축 누적 이동량
    public float ymove = 0;  // Y축 누적 이동량
    public float first_distance;
    public float distance;
    public Transform first_transform;

    ///public float rotationSpeed = 0.01f;
    public float SmoothTime = 0.2f;

    private Vector3 velocity = Vector3.zero;

    private int toggleView = 3; // 1=1인칭, 3=3인칭

    private float wheelspeed = 0.8f;
    private bool Check_wheel_clicked = false;
    Vector2 clickPoint;

    private float init_rot_x;
    private float init_rot_y;

    private bool init_check = false;

    private float camera_rot_x;
    private float camera_rot_y;
    private float camera_rot_z;


    /// <summary>
    /// 카메라
    /// </summary>
    public GameObject camera;

    /// <summary>
    /// 줌인 대상 오브젝트
    /// </summary>
    private Transform targetObject;

    /// <summary>
    /// 경유 지점 위치
    /// </summary>
    public Transform subTarget;
    public Transform subTarget1;
    public Transform subTarget2;
    public Transform subTarget3;
    public Transform subTarget4;
    public Transform subTarget5;
    public Transform subTarget6;

    /// <summary>
    /// 부드럽게 이동될 감도
    /// </summary>
    public float smoothTime = 0.1f;


    /// <summary>
    /// 카메라 타겟 줌인 상태 플래그
    /// </summary>
    public static bool IsActive = false;

    /// <summary>
    /// 줌인 정도 -가 클수록 줌아웃
    /// </summary>
    public float Zoomin = -5;

    /// <summary>
    /// 오브젝트 크기에 맞춰 줌기능 사용시 사용될 데이터
    /// </summary>
    private Bounds boundsData;
    private bool isBounds = true;

    /// <summary>
    /// 경유지점 도착 후 진행 카운트
    /// </summary>
    private int PassCount = 0;
    // Update is called once per frame

    private GameObject View_target;
    public GameObject View_target_1;
    public GameObject View_target_2;
    public GameObject View_target_3;
    public GameObject View_target_4;
    public GameObject View_target_5;

    private bool Seq_start = false;
    private bool mouse_active = false;

    private bool check_menu = false;
    void Start()
    {
        Target_changed_1();
        act0();
        //mouse_active = true;
        //check_menu = true;
    }

    void Update()
    {
        if (mouse_active == true&&check_menu==false)
        {
            //Debug.Log("on"++this.gameObject.name);
            if (Input.GetMouseButton(0))
            {

                xmove += Input.GetAxis("Mouse X"); // 마우스의 좌우 이동량을 xmove 에 누적합니다.
                ymove -= Input.GetAxis("Mouse Y"); // 마우스의 상하 이동량을 ymove 에 누적합니다.
                clickPoint = Input.mousePosition;

            }
            transform.rotation = Quaternion.Euler(camera_rot_x + ymove, camera_rot_y + xmove, camera_rot_z); // 이동량에 따라 카메라의 바라보는 방향을 조정합니다.

            //if (Input.GetMouseButtonDown(2)==true)
            //{
            //    toggleView = 4 - toggleView;
            //    Debug.Log("mouse wheel rotated");
            //}
            if (Input.GetMouseButton(2))
            {
                Vector3 position
                 = Camera.main.ScreenToViewportPoint((Vector2)Input.mousePosition - clickPoint);

                Vector3 move = position * (Time.deltaTime * 10.0f);

                transform.Translate(move);

            }

            if (toggleView == 3)
            {
                distance -= Input.GetAxis("Mouse ScrollWheel") * wheelspeed;
                if (distance < 1f) distance = 1f;
                if (distance > 100f) distance = 100f;

                Vector3 reverseDistance = new Vector3(0.0f, 0.0f, distance); // 카메라가 바라보는 앞방향은 Z 축입니다. 이동량에 따른 Z 축방향의 벡터를 구합니다.

                transform.position = Vector3.SmoothDamp(
                    transform.position,
                    View_target.transform.position - transform.rotation * reverseDistance,
                    ref velocity,
                    SmoothTime);
            }

        }


        if (IsActive == true && check_menu == false)
        {
            Vector3 targetPosition;

            //경유지점이 있다면 목표지점을 경유우선으로 지정한다
            if (subTarget != null && PassCount == 0)
            {
                targetPosition = subTarget.transform.position;
                smoothTime = 1.0f;
            }
            else
            {
                //경유지점이 없다면 bounds 체크 후 목표지점을 종착지로 설정한다
                if (!isBounds)
                    targetPosition = targetObject.TransformPoint(new Vector3(0, 10, Zoomin));
                else
                    targetPosition = new Vector3(boundsData.center.x, boundsData.center.y + boundsData.size.y, boundsData.center.z - boundsData.size.z + Zoomin);
            }

            if (Seq_start == true)
            {
                //위에서 설정된 위치로 부드럽게 이동
                camera.transform.position = Vector3.SmoothDamp(camera.transform.position, targetPosition, ref velocity, smoothTime);
                //camera.transform.position = Vector3.Lerp(camera.transform.position, targetPosition, 0.01f);
                camera.transform.LookAt(targetObject);
                if (Vector3.Magnitude(camera.transform.position - targetPosition) < 0.01)
                {
                    Seq_start = false;
                    Debug.Log("camera move complete");
                    Set_distance();
                    Set_camera_value(this.transform);
                    mouse_active = true;
                }
            }


        }


    }

    public bool Get_menu_check()
    {
        return check_menu;
    }
    public void check_meunu_enabled()
    {
        check_menu = true;
        Debug.Log("check_menu : " + check_menu);
    }
    public void check_meunu_disabled()
    {
        check_menu = false;
        Debug.Log("check_menu : " + check_menu);
    }
    /// <summary>
    /// target 오브젝트로 시점을 이동하는 함수
    /// </summary>
    /// <param name="target">목표 오브젝트</param>
    /// <param name="bounds">오브젝트 크기에 따라 줌인 여부</param>
    public void SetTarget(GameObject target, bool bounds = true)
    {

        if (target == null)
            return;
        IsActive = true;
        targetObject = target.transform;

        //bounds가 true일경우 target의 bounds 데이터를 저장
        if (bounds)
        {
            Bounds combinedBounds = new Bounds();
            var renderers = target.GetComponentsInChildren<Renderer>();
            foreach (var render in renderers)
            {
                combinedBounds.Encapsulate(render.bounds);
            }

            boundsData = combinedBounds;
            isBounds = true;
        }
        else
        {
            boundsData = new Bounds();
            isBounds = false;
        }

    }
    //처음에 스크립트 업데이트 부분 활성화 하기 위해 추가
    public void act0()
    {
        Debug.Log("Camera way 0");
        mouse_active = false;
        subTarget = subTarget1;
        SetTarget(View_target);
        Seq_start = true;
    }

    public void act1()
    {
        Target_changed_2();
        Debug.Log("Camera way 1");
        mouse_active = false;
        subTarget = subTarget1;
        SetTarget(View_target);
        Seq_start = true;
    }

    public void act2()
    {
        Target_changed_1();
        Debug.Log("Camera way 2");
        mouse_active = false;
        subTarget = subTarget2;
        SetTarget(View_target);
        Seq_start = true;
    }
    public void act3() //s3.3
    {
        Debug.Log("Camera way 3");
        View_target = View_target_3;
        mouse_active = false;
        subTarget = subTarget3;
        SetTarget(View_target);
        Seq_start = true;
    }
    public void act4() //s3.3
    {
        Debug.Log("Camera way 4");
        View_target = View_target_4;
        mouse_active = false;
        subTarget = subTarget4;
        SetTarget(View_target);
        Seq_start = true;
    }
    public void act5() //s3.3
    {
        Debug.Log("Camera way 5");
        View_target = View_target_5;
        mouse_active = false;
        subTarget = subTarget5;
        SetTarget(View_target);
        Seq_start = true;
    }

    public void act6()
    {
        Debug.Log("Camera way 6");
        mouse_active = false;
        subTarget = subTarget6;
        SetTarget(View_target);
        Seq_start = true;
    }

    public void Clear()
    {
        smoothTime = 0.3f;
        IsActive = false;
        targetObject = null;
        PassCount = 0;
    }

    public void Set_camera_value(Transform camera_transform)
    {

        camera_rot_x = camera_transform.rotation.eulerAngles.x;
        camera_rot_y = camera_transform.rotation.eulerAngles.y;
        camera_rot_z = camera_transform.rotation.eulerAngles.z;
    }

    public void Reset()
    {
        xmove = 0;
        ymove = 0;
        SetTarget(View_target);
        distance = Vector3.Magnitude(subTarget.transform.position - View_target.transform.position);
        this.transform.position = subTarget.transform.position;
        Debug.Log("RESET Camera position");
    }
    public void Target_changed_1()
    {
        View_target = View_target_1;
    }

    public void Target_changed_2()
    {
        View_target = View_target_2;
    }

    public void Set_distance()
    {
        distance = Vector3.Magnitude(this.transform.position - View_target.transform.position);
        xmove = 0;
        ymove = 0;
    }

}