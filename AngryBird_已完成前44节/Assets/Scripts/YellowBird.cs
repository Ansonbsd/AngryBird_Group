using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBird : Bird
{
    // Start is called before the first frame update
    protected override void FlyingSkill()//��д����
    {
        rgd.velocity = rgd.velocity * 2;
    }
}
