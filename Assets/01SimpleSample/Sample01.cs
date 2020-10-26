using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class Sample01 : MonoBehaviour
{
    public Action<int> OnAgeChanged;

    public Button TestBtn;

    public Button Btn1;
    public Button Btn2;
    public Button Btn3;

    public Toggle Toggle;
    public Image Image;


    private int _age=1;

    public int Age
    {
        get { return _age; }
        set
        {
            if (_age != value)
            {
                _age = value;
                if(OnAgeChanged!=null)
                    OnAgeChanged(value);
            }

            
        }
    }

    //--------------Reactive Property------------
    public ReactiveProperty<int> PAge=new ReactiveProperty<int>(1);
    
    

    // Use this for initialization
	void Start ()
	{
	    Observable.EveryUpdate().Where(x => Input.GetMouseButtonDown(0)).First()
	        .Subscribe(x =>
	        {
                Debug.Log("mouse clicked");
	        });

        //使用携程回调
	    StartCoroutine(Timer(5f, () =>
	    {
            Debug.Log("Coroutine DoSth");
	    }));

        //使用UniRx定时操作
	    Observable.Timer(TimeSpan.FromSeconds(5f))
	        .Subscribe(x =>
	        {
	            Debug.Log("UniRx DoSth");

	        })
	        .AddTo(this);//使用AddTo与对象 Destory绑定


	    Observable.EveryUpdate()
	        .Subscribe(_ =>
	            {
	                if (Input.GetMouseButtonDown(0))
	                {
                        Debug.Log("Left mouse button clicked");
	                }
	            }
	        )
	        .AddTo(this);

        //---------UniRx UGUI-------------
	    TestBtn.OnClickAsObservable()
	        .Subscribe(_ =>
	        {
                Debug.Log("Btn onclick");
	        });

	    Toggle.OnValueChangedAsObservable()
	        .Subscribe(x =>
	        {
                Debug.Log(x==true?"True":"False");
	        });

	    Image.OnBeginDragAsObservable()
	        .Subscribe(_ =>
	        {
                Debug.Log("On begin Drag");
	        });
	    Image.OnDragAsObservable()
	        .Subscribe(_ =>
	        {
	            Debug.Log("On Draging");
	            Image.transform.position = _.position;
	        });
	    Image.OnEndDragAsObservable()
	        .Subscribe(_ =>
	        {
	            Debug.Log("On End Drag");
	            Image.transform.position = _.position;

	        });

        //监听属性值改变
	    OnAgeChanged += x =>
	    {
            Debug.Log("Age Changed:"+x);
	    };
        
	    Age = 1;
	    Age = 2;

        //------------Reactive Property--------------
        PAge.Subscribe(page =>
	    {
	        Debug.Log("Page Change:" + page);
	    });

	    PAge.Value = 1;
	    PAge.Value = 2;

        //-------------mrege---------------------------
	    var leftClickEvent = Observable.EveryUpdate()
	        .Where(_ => Input.GetMouseButtonDown(0));
	    var rightClickEvent = Observable.EveryUpdate()
	        .Where(_ => Input.GetMouseButtonDown(1));

	    Observable.Merge(leftClickEvent, rightClickEvent)
	        .Subscribe(_ =>
	        {
	            Debug.Log("Merge:合并事件流");
	        });

        //--------------merge 只接受第一次点击事件--------
	    var Btn1Stream = Btn1.OnClickAsObservable().Select(_=>"A");
	    var Btn2Stream = Btn2.OnClickAsObservable().Select(_ => "B");
	    var Btn3Stream = Btn3.OnClickAsObservable().Select(_ => "C");

	    Observable.Merge(Btn3Stream, Btn2Stream, Btn1Stream)
	        .First()
	        .Subscribe(_ =>
	        {
                Debug.LogFormat("Btn {0} Click:",_);
	            Observable.Timer(TimeSpan.FromSeconds(1.0f))
	                .Subscribe(x =>
	                {
                        gameObject.SetActive(false);
	                });
	        });
	}

    IEnumerator Timer(float seconds,Action callback)
    {
        yield return new WaitForSeconds(seconds);
        callback();
    }

}
