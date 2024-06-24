using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    public static PoolManager Instance;

    private Dictionary<string, Pool<PoolableMono>> _pools
        = new Dictionary<string, Pool<PoolableMono>>();

    private Transform _trmParent;

    public PoolManager(Transform trmParent)
    {
        _trmParent = trmParent;
    }

    public void CreatePool(PoolableMono prefab, int count)
    {
        Pool<PoolableMono> pool = new Pool<PoolableMono>(prefab, _trmParent, count);
        _pools.Add(prefab.gameObject.name, pool);
    }

    /// <summary>
    /// 지정한 PoolableMono를 새로 생성하고 PoolManager에 Pop시킵니다.
    /// </summary>
    /// <param name="prefabName"></param>
    /// <returns></returns>
    public PoolableMono Pop(string prefabName)
    {
        if (_pools.ContainsKey(prefabName) == false)
        {
            Debug.LogError($"Prefab doesn't exist on pool list! Prefab name : {prefabName}");
            return null;
        }
        PoolableMono item = _pools[prefabName].Pop();
        item.Init();
        return item;
    }

    /// <summary>
    /// 지정한 PoolableMono를 PoolManager에서 Push시킵니다.
    /// </summary>
    /// <param name="obj"></param>
    public void Push(PoolableMono obj)
    {
        _pools[obj.name].Push(obj);
    }
}