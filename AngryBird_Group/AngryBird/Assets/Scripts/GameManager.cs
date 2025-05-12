using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour//检查小鸟和猪个数，决定是否结束游戏
{   public static GameManager Instance { get; private set; }

    private Bird[] birdList;//记录小鸟数量，方便判定

    private int pigTotalCount;
    private int pigDeadCount;//死亡猪数量

    private int index = -1;
    private void Awake()
    {
        Instance = this;
        pigDeadCount = 0;
    }
    void Start()
    {
        birdList = FindObjectsByType<Bird>(FindObjectsSortMode.None);//找到目前所有的小鸟
        pigTotalCount = (FindObjectsByType<Pig>(FindObjectsSortMode.None)).Length;
        LoadNextBird();
    }

    private object FindAnyObjectByType<T>(FindObjectsSortMode none)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextBird()
    {
        index++;//加载下一只小鸟
        if (index >= birdList.Length)//没有小鸟了，结束游戏
        {
            GameEnd();
        }
        else//若还有小鸟
        {
            birdList[index].GoStage(Slingshot.Instance.getCenterPositon());//让下一只小鸟进入弹弓
        }
        }
    public void OnPigDead()
    {
        pigDeadCount++;
        if (pigDeadCount >= pigTotalCount)
        {
            GameEnd();
        }
    }
    private void GameEnd()
    {
        print("GameEnd");
    }
}
