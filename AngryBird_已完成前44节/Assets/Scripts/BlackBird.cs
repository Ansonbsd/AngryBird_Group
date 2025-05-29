using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBird : Bird
{
    public float boomRadius = 2.5f;//��ը�뾶
   protected override void FullTimeSkill()
    {
       Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,boomRadius);
       foreach(Collider2D collider in colliders)
        {
            Destructable des = collider.GetComponent<Destructable>();//�Ƿ�õ������������
            if (des != null)
            {
                des.TakeDamage(Int32.MaxValue);

            }
        }
        state = BirdState.WaitToDie;//�ı�����С��״̬��׼������
        LoadNextBird();
    }
}
