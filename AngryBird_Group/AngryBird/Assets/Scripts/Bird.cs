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

    public float flyspeed = 10;//С������ٶ�

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
                SkillControl();//���ܿ���
                break;
            case BirdState.WaitToDie:
                break;
            default:
                break;
        }
  
    }
    //OnMouseDown��OnMouseUp

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

        float distance = mouseDir.magnitude;//���������ĵ�ľ���

        if (distance > maxDistance)
        {
            mp =mouseDir.normalized * maxDistance + centerPosition;//�����λ���޶��ڷ�Χ��
        }
        return mp;
    }

    private void Fly()//����С�����
    {
        rgd.bodyType = RigidbodyType2D.Dynamic;//���ø���

        rgd.velocity = (Slingshot.Instance.getCenterPositon() - transform.position).normalized * flyspeed;//��ȡ�������������ٶȴ�С

        state = BirdState.AfterShoot;//�ɳ�����겻�ɿ���

        AudioManager.Instance.PlayBirdFlying(transform.position);
    }

    public void GoStage(Vector3 position)//����С����ϳ�״̬,���ṩС��λ��
    {
        state = BirdState.Beforeshoot;
        transform.position = position;
    }

    private void StopControl()//
    {
        if (rgd.velocity.magnitude < 0.1f)//��С���ٶ�С��һ��ֵ
        {
            state = BirdState.WaitToDie;//�ı�����С��״̬��׼������
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
    private void LoadNextBird()//������һֻС��
    {
        Destroy(gameObject);//����С��
        GameObject.Instantiate(Resources.Load("Boom1"), transform.position, Quaternion.identity);
        GameManager.Instance.LoadNextBird();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isFlying = true;
        if (state == BirdState.AfterShoot && collision.relativeVelocity.magnitude > 5)//�������������ڷ��У��ٶȴ���5
        
        {
            AudioManager.Instance.PlayBirdCollision(transform.position);
        }
    }
}
