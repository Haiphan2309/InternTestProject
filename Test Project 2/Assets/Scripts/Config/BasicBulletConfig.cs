using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/BasicBulletConfig")]
public class BasicBulletConfig : BulletConfig
{

    public override void Move(BulletInfo info)
    {
        info.bulletObj.Translate(Vector3.up * speed * Time.deltaTime);
    }

}