using UniRx.Toolkit;
using UnityEngine;

public class UniRxObjectPool : ObjectPool<Transform>
{

    private GameObject _prefab;

    public UniRxObjectPool(GameObject prefab)
    {
        this._prefab = prefab;
    }

    protected override Transform CreateInstance()
    {
        var gameObj = Object.Instantiate(_prefab);
        return gameObj.transform;
    }
}
