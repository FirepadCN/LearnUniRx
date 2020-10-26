using System.Security.Cryptography.X509Certificates;
using UniRx;
using UnityEngine;

public class UITodoList : MonoBehaviour
{
    private UITodoItem mTodoItemPrototype;

    private TodoList Model = new TodoList();
    [SerializeField] private Transform Content;

    void Awake()
    {
        mTodoItemPrototype = transform.Find("TodoItemPrototype").GetComponent<UITodoItem>();
    }
	// Use this for initialization
	void Start ()
	{
	    OnDateChanged();
	}


    void OnDateChanged()
    {
        int childcount = Content.transform.childCount;
        for (int i = 0; i <childcount ; i++)
        {
            Destroy(Content.GetChild(i).gameObject);
        }
        var todoItems = Model.TodoItems;
        foreach (var todoItem in todoItems)
        {
            if(!todoItem.Complete.Value)
            {
                todoItem.Complete.Subscribe(complete =>
                {
                    if(complete)
                        OnDateChanged();
                });
                var uiTodoItem = Instantiate(mTodoItemPrototype);

                uiTodoItem.transform.SetParent(Content);
                uiTodoItem.gameObject.SetActive(true);

                uiTodoItem.SetModel(todoItem);
            }
        }

    }
	
}
