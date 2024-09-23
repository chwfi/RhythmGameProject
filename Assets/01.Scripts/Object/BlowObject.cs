using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowObject : PoolableMono
{
    public void OnAnimationEnd()
    {
        PoolManager.Instance.Push(this);
    }
}
