using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour//控制物体的销毁
{
    public int maxHP = 100;//最大血量
    private int currentHP;//实时血量
    private void OnCollisionEnter2D(Collision2D collision)
    {   //用血量控制物体的销毁
        currentHP = maxHP;
        currentHP -= (int)(collision.relativeVelocity.magnitude*10);//用相对位置反应碰撞强度
        
        if (currentHP <= 0)//血量小于0时销毁物体
        {
            Destroy(gameObject);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
