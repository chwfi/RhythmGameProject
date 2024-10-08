using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    private PoolingListSO _poolingListSO;

    private void Awake()
    {
        MakePool();

        Application.targetFrameRate = 60;

        SetPlayer();
    }

    private void MakePool()
    {
        PoolManager.Instance = new PoolManager(transform);

        _poolingListSO.PoolingList.ForEach(p => PoolManager.Instance.CreatePool(p.prefab, p.poolCount));
    }

    public void SetPlayer()
    {
        PoolableMono player = PoolManager.Instance.Pop("Player");
        player.transform.position = Vector3.zero;
        player.transform.rotation = Quaternion.Euler(0f, 0f, 45f);
        CameraManager.Instance.SetTarget(player.transform);
    }
}
