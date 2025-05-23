using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructiable : MonoBehaviour//控制物体的销毁
{
    public int maxHP = 100;//最大血量
    private int currentHP;//实时血量

    public List<Sprite> injuredSpriteList;//1

    private SpriteRenderer spriteRenderer;

    private GameObject boomPrefab;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHP = maxHP;
        boomPrefab = Resources.Load<GameObject>("Boom1");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //用血量控制物体的销毁
        TakeDamage((int)(collision.relativeVelocity.magnitude * 8));
    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;//用相对位置反应碰撞强度

        if (currentHP <= 0)//血量小于0时销毁物体
        {
            Dead();
        }
        else
        {
            //换图片,播放音乐
            Sprite beforeSprite = spriteRenderer.sprite;
            int index = (int)((maxHP - currentHP) / (maxHP / (injuredSpriteList.Count + 1.0f))) - 1;//第几张图片
            if (index != -1)
            {
                spriteRenderer.sprite = injuredSpriteList[index];
            }
            if (beforeSprite != spriteRenderer.sprite)
            {
                PlayAudioCollision();//若prefabs发生改变，则播放音效
            }
        }
    }

    protected virtual void PlayAudioCollision()
    {
        AudioManager.Instance.PlayWoodCollision(transform.position);
    }

    protected virtual void PlayAudioDestroyed()
    {
        AudioManager.Instance.PlayWoodDestroyed(transform.position);
    }

    public virtual void Dead()
    {
        PlayAudioDestroyed();
        GameObject.Instantiate(boomPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

