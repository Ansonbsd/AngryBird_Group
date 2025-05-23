using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum BirdState
{
    Waiting,
    BeforeShoot,
    AfterShoot,
    WaitToDie
}
public class Bird : MonoBehaviour
{
    public BirdState state = BirdState.BeforeShoot;
    //等待  发射前  发射后

    private bool isMouseDown = false;
    public float maxDistance = 2.45f;

    public float flySpeed = 13;

    protected Rigidbody2D rgd;

    public bool isFlying = true;
    public bool isHaveUsedSkill = false;


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
                WaitControl();
                break;
            case BirdState.BeforeShoot:
                MoveControl();
                break;
            case BirdState.AfterShoot:
                StopControl();
                SkillControl();
                break;
            case BirdState.WaitToDie:
                break;
            default:
                break;
        }

    }
    private void WaitControl()
    {

    }

    private void OnMouseDown()
    {
        if (state == BirdState.BeforeShoot && EventSystem.current.IsPointerOverGameObject() == false)
        {
            isMouseDown = true;
            Slingshot.Instance.StartDraw(transform);
            AudioManager.Instance.PlayBirdSelect(transform.position);
        }
    }

    private void OnMouseUp()
    {
        if (state == BirdState.BeforeShoot && EventSystem.current.IsPointerOverGameObject() == false)
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
        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mp.z = 0;
        Vector3 mouseDir = mp - centerPosition;

        float distance = mouseDir.magnitude;

        if (distance > maxDistance)
        {
            mp = mouseDir.normalized * maxDistance + centerPosition;
        }

        return mp;
    }

    private void Fly()
    {
        rgd.bodyType = RigidbodyType2D.Dynamic;

        rgd.velocity = (Slingshot.Instance.getCenterPositon() - transform.position).normalized * flySpeed;
        state = BirdState.AfterShoot;

        AudioManager.Instance.PlayBirdFlying(transform.position);
    }

    public void GoStage(Vector3 position)
    {
        state = BirdState.BeforeShoot;
        transform.position = position;
    }

    private void StopControl()
    {
        if (rgd.velocity.magnitude < 0.1f)
        {
            state = BirdState.WaitToDie;
            Invoke("LoadNextBird", 1f);
        }
    }

    private void SkillControl()
    {
        if (isHaveUsedSkill) return;


        if (isFlying == true && Input.GetMouseButtonDown(0))
        {
            isHaveUsedSkill = true;
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
    protected virtual void FullTimeSkill()
    {
    }

    protected void LoadNextBird()
    {
        Destroy(gameObject);
        GameObject.Instantiate(Resources.Load("Boom1"), transform.position, Quaternion.identity);
        GameManager.Instance.LoadNextBird();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (state == BirdState.AfterShoot)
        {
            isFlying = false;
        }

        if (state == BirdState.AfterShoot && collision.relativeVelocity.magnitude > 5)
        {
            AudioManager.Instance.PlayBirdCollision(transform.position);
        }
    }
}

