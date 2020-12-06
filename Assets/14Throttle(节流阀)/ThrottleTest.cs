using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class ThrottleTest : MonoBehaviour
{
    public  Button Btn;
    // Start is called before the first frame update
    void Start()
    {
        // 事件会在间隔后执行，间隔期间屏蔽事件，间隔空白期事件又会在间隔后执行
        Btn.OnPointerClickAsObservable().Throttle(TimeSpan.FromSeconds(3.0f)).Subscribe(data =>
        {
            Debug.Log($"btnpos:{data.position}");
        });

    }
}
