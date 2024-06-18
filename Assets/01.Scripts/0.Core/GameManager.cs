using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    private PoolingListSO _poolingListSO;

    private void Start()
    {
        MakePool();
    }

    private void MakePool()
    {
        PoolManager.Instance = new PoolManager(transform);

        _poolingListSO.PoolingList.ForEach(p => PoolManager.Instance.CreatePool(p.prefab, p.poolCount));
    }
}
