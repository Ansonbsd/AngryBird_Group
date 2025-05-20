using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum BirdState
{
    Waiting,
    Beforeshoot,
    AfterShoot,
    WaitToDie
}
public class Bird : MonoBehaviour
{
    public BirdState state = BirdState.Beforeshoot;
    // Start is called before the first frame update
    private bool isMouseDown = false;

    public float maxDistance = 3.0f;

    public float flyspeed = 10;//小鸟飞行速度

    protected Rigidbody2D rgd;

    private bool isFlying = true;
    private bool isHaveUsedSkill = false;


    void Start()
    {
        rgd = GetComponent<Rigidbody2D>();
        rgd.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {   
            
            case BirdState.Waiting:
                break;
            case BirdState.Beforeshoot:
                MoveControl();
                break;
            case BirdState.AfterShoot:
                StopControl();
                SkillControl();//技能控制
                break;
            case BirdState.WaitToDie:
                break;
            default:
                break;
        }
  
    }
    //OnMouseDown和OnMouseUp

    private void OnMouseDown()
    {
        if (state == BirdState.Beforeshoot)
        {
            isMouseDown = true;
            Slingshot.Instance.StartDraw(transform);
            AudioManager.Instance.PlayBirdSelect(transform.position);
        }
    }

    private void OnMouseUp()
    {
        if (state == BirdState.Beforeshoot)
        {
            isMouseDown = false;
            Slingshot.Instance.EndDraw();
            Fly();
        }
    }

    private void MoveControl()
    {
        if (isMouseDown)
        {
            transform.position = GetMousePosition();
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 centerPosition = Slingshot.Instance.getCenterPositon();
        Vector3 mp= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDir = mp - centerPosition;
        mp.z = 0;

        float distance = mouseDir.magnitude;//鼠标点与中心点的距离

        if (distance > maxDistance)
        {
            mp =mouseDir.normalized * maxDistance + centerPosition;//将鼠标位置限定在范围内
        }
        return mp;
    }

    private void Fly()//控制小鸟飞行
    {
        rgd.bodyType = RigidbodyType2D.Dynamic;//设置刚体

        rgd.velocity = (Slingshot.Instance.getCenterPositon() - transform.position).normalized * flyspeed;//获取方向向量，乘速度大小

        state = BirdState.AfterShoot;//飞出后鼠标不可控制

        AudioManager.Instance.PlayBirdFlying(transform.position);
    }

    public void GoStage(Vector3 position)//控制小鸟的上场状态,并提供小鸟位置
    {
        state = BirdState.Beforeshoot;
        transform.position = position;
    }

    private void StopControl()//
    {
        if (rgd.velocity.magnitude < 0.1f)//若小鸟速度小于一定值
        {
            state = BirdState.WaitToDie;//改变现在小鸟状态，准备销毁
            Invoke("LoadNextBird", 1f);
        }
    }

    private void SkillControl()
    {
        if (isHaveUsedSkill) return;
       
        if (isFlying= true && Input.GetMouseButtonDown(0))
        {
            FlyingSkill();
        }

        if (Input.GetMouseButtonDown(0))
        {
            isHaveUsedSkill = true;
            FullTimeSkill();
        }
    }

    protected virtual void FlyingSkill()
    {
       
       
    }
    
    protected void FullTimeSkill()
    {
        
    }
    private void LoadNextBird()//加载下一只小鸟
    {
        Destroy(gameObject);//销毁小鸟
        GameObject.Instantiate(Resources.Load("Boom1"), transform.position, Quaternion.identity);
        GameManager.Instance.LoadNextBird();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isFlying = true;
        if (state == BirdState.AfterShoot && collision.relativeVelocity.magnitude > 5)//播放条件：正在飞行，速度大于5
        
        {
            AudioManager.Instance.PlayBirdCollision(transform.position);
        }
    }
}
