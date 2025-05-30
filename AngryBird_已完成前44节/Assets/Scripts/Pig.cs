using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : Destructable
{
    public int score = 3000;
    public override void Dead()
    {
        base.Dead();
        GameManager.Instance.OnPigDead();
        ScoreManager.Instance.ShowScore(transform.position,score);
    }
    protected override void PlayAudioCollision()
    {
        AudioManager.Instance.PlayPigCollision(transform.position);
    }//重写destructable类的播放函数

    protected override void PlayAudioDestroyed()
    {
        //不播放
    }
}
