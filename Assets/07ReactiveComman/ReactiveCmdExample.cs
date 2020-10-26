using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ReactiveCmdExample : MonoBehaviour {

	void Start ()
	{
	    var reactiveCommand = new ReactiveCommand();

	    reactiveCommand.Subscribe(_ => { Debug.Log("Excute"); });

	    reactiveCommand.Execute();
	    reactiveCommand.Execute();
	    reactiveCommand.Execute();

	    var mouseDownStream = Observable.EveryUpdate()
	        .Where(_ => Input.GetMouseButtonDown(0))
	        .Select(_ => true);
	    var mouseUpStream = Observable.EveryUpdate()
	        .Where(_ => Input.GetMouseButtonUp(0))
	        .Select(_ => false);

	    var isMouseUp = Observable.Merge(mouseUpStream, mouseDownStream);
	    var reactiveCommand2 = new ReactiveCommand(isMouseUp,false);

	    reactiveCommand2.Subscribe(_ =>
	    {
	        Debug.Log("ReactiveCommand2 Excute");
	    });

	    Observable.EveryUpdate().Subscribe(_ =>
	    {
	        reactiveCommand2.Execute();
	    });

        var reactiveCommand3 =new ReactiveCommand<int>();

	    reactiveCommand3.Where(x => (x % 2 == 0))
	        .Subscribe(x => Debug.LogFormat("{0} is Even number", x));
	    reactiveCommand3.Where(x => (x % 2 != 0))
	        .Timestamp()
	        .Subscribe(x => Debug.LogFormat("{0} is Odd number,{1}", x.Value,x.Timestamp));

	    reactiveCommand3.Execute(2);
	    reactiveCommand3.Execute(3);

    }
	
}
