using System.IO;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

public class WWWSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


        ObservableWWW.Get("http://www.sikiedu.com")
            .Subscribe(responseTxt =>
            {
                Debug.Log(responseTxt);
            }, e =>
            {
                Debug.Log(e);
            });


        ObservableWWW.Get("http://www.iqiyi.com")
            .Subscribe(responseText =>
            {
                Debug.Log(responseText);
            }, e =>
            {
                Debug.Log(e);
            });

        var wwwA = ObservableWWW.Get("http://www.baidu.com");
        var wwwB = ObservableWWW.Get("http://www.iqiyi.com");

        Observable.WhenAll(wwwA, wwwB)
            .Subscribe(responseText =>
            {
                Debug.LogFormat("{0}{1}", responseText[0].Substring(0, 10), responseText[1].Substring(0, 10));
            })
            .AddTo(this);


        var progressObervable = new ScheduledNotifier<float>();
        ObservableWWW.GetAndGetBytes("https://github.com/liangxiegame/QFramework/releases/tag/v0.0.9",null,progressObervable)
            .Subscribe(bytes =>
            {
                File.WriteAllBytes(Application.dataPath+"/ss.unitypackage",bytes);
            });

        progressObervable.Subscribe(progress =>
        {
            Debug.LogFormat("进度为：{0}", progress);
        });
    }
}
