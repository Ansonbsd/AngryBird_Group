using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructiable : MonoBehaviour//控制物体的销毁
{
    public int maxHP = 100;//最大血量
    private int currentHP;//实时血量

    public List<Sprite> injuredSpriteLIst;//分血量,取图片
    private SpriteRenderer spriteRenderer;
    private GameObject boomPrefab;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHP = maxHP;
        boomPrefab = Resources.Load<GameObject>("Boom1");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {   //用血量控制物体的销毁
        currentHP -= (int)(collision.relativeVelocity.magnitude*10);//用相对位置反应碰撞强度

        if (currentHP <= 0)//血量小于0时销毁物体
        {
            Dead();return;
        }
        else
        {//换图片
            int index = (int)((maxHP - currentHP) / (maxHP / (injuredSpriteLIst.Count + 1.0f))) - 1;//第几张图片
            if(index != -1){
                spriteRenderer.sprite = injuredSpriteLIst[index];
            }
        }
       
    }
    public virtual void Dead()
    {
        GameObject.Instantiate(boomPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }



    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
