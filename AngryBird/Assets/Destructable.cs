using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour//�������������
{
    public int maxHP = 100;//���Ѫ��
    private int currentHP;//ʵʱѪ��
    private void OnCollisionEnter2D(Collision2D collision)
    {   //��Ѫ���������������
        currentHP = maxHP;
        currentHP -= (int)(collision.relativeVelocity.magnitude*10);//�����λ�÷�Ӧ��ײǿ��
        
        if (currentHP <= 0)//Ѫ��С��0ʱ��������
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
