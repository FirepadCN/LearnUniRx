using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UniRx.Triggers;

public class OnCompleteExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { 
        Observable.Timer(TimeSpan.FromSeconds(1.0f))
            .Subscribe(_ =>
            {
                Debug.Log("OnNext:after 1s");
            }, () =>
            {
                Debug.Log("TimeSpan OnComplete");
            });

        Observable.EveryUpdate()
            .Subscribe(_ =>
            {
                Debug.Log("OnNext:First");
            }, () =>
            {
                Debug.Log("EveryUpdate OnComplete");
            });

        Observable.FromCoroutine(Cortoutine)
            .Subscribe(_ =>
            {
                Debug.Log("OnNext:Cortoutine");
            }, () =>
            {
                Debug.Log("Coroutine OnComplete");
            });

    }


    IEnumerator Cortoutine()
    {
        yield return null;
    }
    
}
