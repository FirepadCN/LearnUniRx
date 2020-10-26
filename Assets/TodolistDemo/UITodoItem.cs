using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class UITodoItem : MonoBehaviour
{
    private Text mContent;
    private Button mBtnComplete;

    private TodoItem Model;

    private void Awake()
    {
        mContent = transform.Find("ContentTxt").GetComponent<Text>();
        mBtnComplete = transform.Find("CompleteBtn").GetComponent<Button>();

        mBtnComplete.OnClickAsObservable()
            .Subscribe(_ =>
            {
                Model.Complete.Value = true;
            });
    }

    public void SetModel(TodoItem model)
    {
        Model = model;
        UpdateView();
    }

    void UpdateView()
    {
        mContent.text = Model.Content.Value;
    }
}
