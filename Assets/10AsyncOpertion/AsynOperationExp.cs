using System;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsynOperationExp : MonoBehaviour
{
    
	// Use this for initialization
	void Start ()
	{
	    Resources.LoadAsync<GameObject>("TestCanvas").AsAsyncOperationObservable()
	        .Subscribe(resourceRequest =>
	        {
                Debug.Log("Resources.LoadAsync()");
	            Instantiate(resourceRequest.asset);
	        });

        var loadProgress=new ScheduledNotifier<float>();
	    Observable.Timer(TimeSpan.FromSeconds(5.0f))
	        .Subscribe(_ =>
	        {
	            SceneManager.LoadSceneAsync("Async").AsAsyncOperationObservable(loadProgress)
	                .Subscribe(progress =>
	                {
	                    Debug.Log("load done");
	                });

	            loadProgress.Subscribe(progress =>
	            {
	                Debug.LogFormat("Progress:{0}", progress);
	            });
	        });
	}
}
