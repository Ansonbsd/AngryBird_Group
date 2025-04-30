using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public static Slingshot Instance { get; private set; }

    private LineRenderer LeftLineRenderer;
    private LineRenderer RightLineRenderer;

    private Transform LeftPoint;
    private Transform RightPoint;
    private Transform Centerpoint;
    private Transform birdTransform;

    private void Awake()
    {
        Instance = this;
    }

    private bool isDrawing;//皮筋是否需要绘制？
    private float normalized;

    // Start is called before the first frame update


    void Start()
    {   //用函数返回皮筋的位置，得到皮筋组件
        LeftLineRenderer = transform.Find("LeftLineRenderer").GetComponent<LineRenderer>();
        RightLineRenderer = transform.Find("RightLineRenderer").GetComponent<LineRenderer>();

        LeftPoint = transform.Find("LeftPoint");
        RightPoint = transform.Find("RightPoint");
        Centerpoint = transform.Find("CenterPoint");

        HideLine();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDrawing)
        {
            Draw();
        }
    }

    //用函数判断是否需要绘制皮筋

    public void StartDraw(Transform birdTransform)
    {
        isDrawing = true;
        this.birdTransform = birdTransform;//每次获取小鸟位置
        ShowLine();
    }

    public void EndDraw()
    {
        isDrawing = false;
        HideLine();
    }

    public void Draw()
    {
        Vector3 birdPosition = birdTransform.position;//获取新位置：使弹弓在小鸟后面生成

        birdPosition = (birdPosition - Centerpoint.position).normalized * 1.0f + birdPosition;


        LeftLineRenderer.SetPosition(0, birdPosition);
        LeftLineRenderer.SetPosition(1, LeftPoint.position);

        RightLineRenderer.SetPosition(0, birdPosition);
        RightLineRenderer.SetPosition(1, RightPoint.position);

    }

    public  Vector3 getCenterPositon()//获取center位置，用于控制弹弓范围
    {
        return Centerpoint.transform.position;
    }
    public void HideLine()//在没有点击小鸟时隐藏线段
    {
        RightLineRenderer.enabled = false;
        LeftLineRenderer.enabled = false;
    }

    public void ShowLine()
    {
        RightLineRenderer.enabled = true;
        LeftLineRenderer.enabled = true;
    }
}
