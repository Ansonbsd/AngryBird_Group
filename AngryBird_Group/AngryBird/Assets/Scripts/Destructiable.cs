using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructiable : MonoBehaviour//�������������
{
    public int maxHP = 100;//���Ѫ��
    private int currentHP;//ʵʱѪ��

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
        //��Ѫ���������������
        TakeDamage((int)(collision.relativeVelocity.magnitude * 8));
    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;//�����λ�÷�Ӧ��ײǿ��

        if (currentHP <= 0)//Ѫ��С��0ʱ��������
        {
            Dead();
        }
        else
        {
            //��ͼƬ,��������
            Sprite beforeSprite = spriteRenderer.sprite;
            int index = (int)((maxHP - currentHP) / (maxHP / (injuredSpriteList.Count + 1.0f))) - 1;//�ڼ���ͼƬ
            if (index != -1)
            {
                spriteRenderer.sprite = injuredSpriteList[index];
            }
            if (beforeSprite != spriteRenderer.sprite)
            {
                PlayAudioCollision();//��prefabs�����ı䣬�򲥷���Ч
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

