using UniRx;
public class TodoItem
{
        /// <summary>
        /// The identifier
        /// </summary>
	    public int Id;

        /// <summary>
        /// 内容
        /// </summary>
	    public StringReactiveProperty Content;

        /// <summary>
        /// 是否完成
        /// </summary>
	    public BoolReactiveProperty Complete;

}
public class TodoList
	    {
	        public ReactiveCollection<TodoItem> TodoItems = new ReactiveCollection<TodoItem>()
	        {
	            new TodoItem
	            {
                    Id=0,
                    Content = new StringReactiveProperty("买火车票"),
                    Complete = new BoolReactiveProperty(false)
	            },

	            new TodoItem
	            {
	                Id=1,
	                Content = new StringReactiveProperty("买飞机票"),
	                Complete = new BoolReactiveProperty(false)
                }
	        };
	    }
