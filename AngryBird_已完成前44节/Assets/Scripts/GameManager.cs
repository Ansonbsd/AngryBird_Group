using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour//���С����������������Ƿ������Ϸ
{   public static GameManager Instance { get; private set; }

    private Bird[] birdList;//��¼С�������������ж�

    private int pigTotalCount;
    private int pigDeadCount;//����������

    private int index = -1;

    private FollowTarget cameraFollowTarget;

    public GameOverUI gameOverUI;

    private void Awake()
    {
        Instance = this;
        pigDeadCount = 0;
    }
    void Start()
    {
        birdList = FindObjectsByType<Bird>(FindObjectsSortMode.None);//�ҵ�Ŀǰ���е�С��
        pigTotalCount = (FindObjectsByType<Pig>(FindObjectsSortMode.None)).Length;
        cameraFollowTarget = Camera.main.GetComponent<FollowTarget>();

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
        index++;//������һֻС��
        if (index >= birdList.Length)//û��С���ˣ�������Ϸ
        {
            GameOver();
        }
        else//������С��
        {
            birdList[index].GoStage(Slingshot.Instance.getCenterPositon());//����һֻС����뵯��
            cameraFollowTarget.SetTarget(birdList[index].transform);
        }
        }
    public void OnPigDead()
    {
        pigDeadCount++;
        if (pigDeadCount >= pigTotalCount)
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        int starCount = 0;
        float pigDeadPercent = pigDeadCount *1f / pigTotalCount;
        if (pigDeadPercent > 0.99f)
        {
            starCount = 3;
        }else if (pigDeadPercent > 0.66f)
        {
            starCount = 2;
        }else if (pigDeadPercent > 0.33f)
        {
            starCount = 1;
        }
        gameOverUI.Show(starCount);
    }

    public void RestartLevel()
    {
        //TODO
    }
    public void LevelList()
    {
        //TODO
    }

    //1加载界面     2地图和关卡选择          3游戏场景
}
