using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMouthBird : Bird
{
    protected override void FlyingSkill()
    {
        Vector2 velocity = rgd.velocity;
        velocity.x = -velocity.x;
        rgd.velocity = velocity;

        Vector3 scale = transform.localScale;
        scale.x = -scale.x;
        transform.localScale = scale;
    }
}
