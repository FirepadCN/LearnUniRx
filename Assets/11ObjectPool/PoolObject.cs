using System;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class PoolObject : MonoBehaviour
{
    public IObservable<Unit> AsyncAction()
    {
        var colorstream = Observable.Timer(TimeSpan.FromSeconds(0.2f));
        colorstream.Subscribe(_ =>
        {
            GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.blue, Random.Range(0.0f,1.0f));
        });
        var positiontream = Observable.Timer(TimeSpan.FromSeconds(0.2f));
        positiontream.Subscribe(_ =>
        {
            transform.localPosition=Vector3.one*Random.Range(-5f,5f);
        });

        var unit = Observable.ReturnUnit();
        var allStream = Observable.WhenAll(unit);
        allStream.Subscribe(_ =>
        {
            Debug.Log("QAQ");
        });

        return Observable.ReturnUnit();
    }
}