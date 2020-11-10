using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObservableLongPointerDownTrigger : ObservableTriggerBase,IPointerDownHandler,IPointerUpHandler
{
    public float Interval = 1f;
    private Subject<Unit> _onLongPointerDown;
    private float? _raiseTime;

    void Update()
    {
        if (_raiseTime != null && _raiseTime <= Time.realtimeSinceStartup)
        {
            _onLongPointerDown?.OnNext(Unit.Default);
            _raiseTime = null;
        }
    }

    #region 接口实现
    /// <summary>
    /// ObservableTriggerBase接口
    /// </summary>
    protected override void RaiseOnCompletedOnDestroy()
    {
        _onLongPointerDown?.OnCompleted();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //加上长按间隔后完成长按的时刻
        _raiseTime = Time.realtimeSinceStartup + Interval;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //抬起后长按时刻清空
        _raiseTime = null;
    }
    #endregion

    public IObservable<Unit> OnLongPointerDownObservable()
    {
        return _onLongPointerDown ??(_onLongPointerDown = new Subject<Unit>());
    }

}
