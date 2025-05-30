using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour//控制物体的销毁
{
    public int maxHP = 100;//最大血量
    private int currentHP;//实时血量

    public List<Sprite> injuredSpriteList;//分血量,取图片
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
        TakeDamage((int)(collision.relativeVelocity.magnitude * 8));
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            Dead();
        }
        else
        {
            Sprite beforeSprite = spriteRenderer.sprite;
            int index = (int)((maxHP - currentHP) / (maxHP / (injuredSpriteList.Count + 1.0f))) - 1;
            if (index != -1)
            {
                spriteRenderer.sprite = injuredSpriteList[index];
            }
            if (beforeSprite != spriteRenderer.sprite)
            {
                PlayAudioCollision();
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



    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
