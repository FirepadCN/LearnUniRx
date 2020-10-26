﻿using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class No11_ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject mPoolPrefab;

    [SerializeField]
    private Button mBtnSpawn;

    [SerializeField]
    private Button mBtnShrink;

    void Start()
    {
        UniRxObjectPool pool = new UniRxObjectPool(mPoolPrefab);

        mBtnSpawn.OnClickAsObservable().Subscribe(_ =>
        {
            for (int i = 0; i < 5; i++)
            {
                //从池中获取实例,出栈
                var poolObj = pool.Rent(); 
                //根据对象创建的频率来扩张池子大小
                Observable.TimerFrame(30).Subscribe(f 
                    //回收实例，入栈
                    => pool.Return(poolObj));    
            }

        });

        mBtnShrink.OnClickAsObservable().Subscribe(_ =>
        {
            // 手动回收对象池子, 第一个参数是回收比例，第二个参数是保存最小数量
            //pool.Shrink(0.6f, 1);

            // 自动回收对象池子，3秒检查一次进行回收，销毁实例,缩小池子大小
            pool.StartShrinkTimer(TimeSpan.FromSeconds(3f), 0.6f, 1);
        });

        
        
    }
}