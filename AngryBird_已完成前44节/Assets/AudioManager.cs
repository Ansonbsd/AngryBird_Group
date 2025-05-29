using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour//音效通过函数调用播放
{
    public static AudioManager Instance { get; private set; }

    //加载各种音效
    public AudioClip birdCollision;
    public AudioClip birdFlying;
    public AudioClip birdSelect;
    public AudioClip[] pigCollisions;//猪碰撞声音，随机播放
    public AudioClip woodCollision;
    public AudioClip woodDestroyed;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayBirdCollision(Vector3 position)//获取位置
    {
        AudioSource.PlayClipAtPoint(birdCollision, position, 1f);//播放音效
    }

    public void PlayBirdFlying(Vector3 position)//获取位置
    {
        AudioSource.PlayClipAtPoint(birdFlying, position, 1f);//播放音效
    }
    // Update is called once per frame

    public void PlayBirdSelect(Vector3 position)//获取位置
    {
        AudioSource.PlayClipAtPoint(birdSelect, position, 1f);//播放音效
    }

    public void PlayPigCollision(Vector3 position)
    {
        int randomIndex = Random.Range(0, pigCollisions.Length);//随机播放一个音效
        AudioClip ac = pigCollisions[randomIndex];
        AudioSource.PlayClipAtPoint(ac, position, 1f);
    }

    public void PlayWoodCollision(Vector3 position)//获取位置
    {
        AudioSource.PlayClipAtPoint(woodCollision, position, 0.6f);//播放音效
    }

    public void PlayWoodDestroyed(Vector3 position)//获取位置
    {
        AudioSource.PlayClipAtPoint(woodDestroyed, position, 0.6f);//播放音效
    }
}
