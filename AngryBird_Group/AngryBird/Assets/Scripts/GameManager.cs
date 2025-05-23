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
    private void Awake()
    {
        Instance = this;
        pigDeadCount = 0;
    }
    void Start()
    {
        // 修改查找方法，包含非激活的Bird
        birdList = FindObjectsByType<Bird>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        pigTotalCount = FindObjectsByType<Pig>(FindObjectsInactive.Include, FindObjectsSortMode.None).Length;
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
            GameEnd();
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
            GameEnd();
        }
    }
    private void GameEnd()
    {
        print("GameEnd");
    }
}
