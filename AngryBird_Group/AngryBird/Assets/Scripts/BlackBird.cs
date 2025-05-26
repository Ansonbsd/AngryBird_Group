using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBird : Bird
{
    public float boomRadius = 2.5f;//爆炸半径
   protected override void FullTimeSkill()
    {
       Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,boomRadius);
       foreach(Collider2D collider in colliders)
        {
            Destructable des = collider.GetComponent<Destructable>();//是否得到可销毁组件？
            if (des != null)
            {
                des.TakeDamage(Int32.MaxValue);

            }
        }
        state = BirdState.WaitToDie;//改变现在小鸟状态，准备销毁
        LoadNextBird();
    }
}
