using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour//��Чͨ���������ò���
{
    public static AudioManager Instance { get; private set; }

    //���ظ�����Ч
    public AudioClip birdCollision;
    public AudioClip birdFlying;
    public AudioClip birdSelect;
    public AudioClip[] pigCollisions;//����ײ�������������
    public AudioClip woodCollision;
    public AudioClip woodDestroyed;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayBirdCollision(Vector3 position)//��ȡλ��
    {
        AudioSource.PlayClipAtPoint(birdCollision, position, 1f);//������Ч
    }

    public void PlayBirdFlying(Vector3 position)//��ȡλ��
    {
        AudioSource.PlayClipAtPoint(birdFlying, position, 1f);//������Ч
    }
    // Update is called once per frame

    public void PlayBirdSelect(Vector3 position)//��ȡλ��
    {
        AudioSource.PlayClipAtPoint(birdSelect, position, 1f);//������Ч
    }

    public void PlayPigCollision(Vector3 position)
    {
        int randomIndex = Random.Range(0, pigCollisions.Length);//�������һ����Ч
        AudioClip ac = pigCollisions[randomIndex];
        AudioSource.PlayClipAtPoint(ac, position, 1f);
    }

    public void PlayWoodCollision(Vector3 position)//��ȡλ��
    {
        AudioSource.PlayClipAtPoint(woodCollision, position, 0.6f);//������Ч
    }

    public void PlayWoodDestroyed(Vector3 position)//��ȡλ��
    {
        AudioSource.PlayClipAtPoint(woodDestroyed, position, 0.6f);//������Ч
    }
}
