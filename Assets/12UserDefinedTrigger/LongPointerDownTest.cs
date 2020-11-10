using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class LongPointerDownTest : MonoBehaviour
{
    public Button Btn;

    // Start is called before the first frame update
    void Start()
    {
        var trigger = Btn.gameObject.AddComponent<ObservableLongPointerDownTrigger>();
        trigger.Interval = 3f;
        trigger.OnLongPointerDownObservable().
            Subscribe(_ =>
            {
                Debug.Log("长按");
            });
    }

}
