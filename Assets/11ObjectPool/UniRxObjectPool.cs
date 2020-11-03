using System;
using UniRx;
using UniRx.Toolkit;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class UniRxObjectPool : ObjectPool<PoolObject>
{

    private GameObject _prefab;

    public UniRxObjectPool(GameObject prefab)
    {
        this._prefab = prefab;
    }

    protected override PoolObject CreateInstance()
    {
        var gameObj = Object.Instantiate(_prefab);
        return gameObj.GetComponent<PoolObject>();
    }

    protected override void OnBeforeRent(PoolObject instance)
    {
        base.OnBeforeRent(instance);
        Debug.Log($"从池子中取出：{instance.name}");
    }

    // 在对象返回到池子里面之前回调
    protected override void OnBeforeReturn(PoolObject instance)
    {
        base.OnBeforeReturn(instance);
        Debug.Log($" 返回 {instance} 到池子里面");
    }

    // 在对象从池子里面移除回调
    protected override void OnClear(PoolObject instance)
    {
        base.OnClear(instance);
        Debug.Log($"从池子里面移除 {instance}");
    }
}



