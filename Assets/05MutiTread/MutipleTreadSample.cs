using System;
using System.Threading;
using UniRx;
using UnityEngine;

public class MutipleTreadSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var threadAStream = Observable.Start(() =>
        {
             Thread.Sleep(TimeSpan.FromSeconds(1.0f));
            return 0;
        });

        var threadBStream = Observable.Start(() =>
        {
            Thread.Sleep(TimeSpan.FromSeconds(2f));
            return 20;
        });

        Observable.WhenAll(threadAStream, threadBStream)
            .ObserveOnMainThread()
            .Subscribe(results =>
            {
                Debug.LogFormat("{0},{1}", results[0], results[1]);
            });
    }
}
