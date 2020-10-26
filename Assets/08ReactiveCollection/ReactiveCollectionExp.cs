using UniRx;
using UnityEngine;

public class ReactiveCollectionExp : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{

	    var ReactiveCollection = new ReactiveCollection<string>()
	    {
            "君莫笑",
            "酒一杯"
	    };

	    ReactiveCollection.ObserveAdd()
	        .Subscribe(addStr =>
	        {
	            Debug.LogFormat("add str{0}", addStr);
	        });

	    ReactiveCollection.ObserveRemove()
	        .Subscribe(RemoveStr =>
	        {
	            Debug.LogFormat("Remove str{0}", RemoveStr);
	        });

	    ReactiveCollection.ObserveMove()
	        .Subscribe(MoveStr =>
	        {
	            Debug.LogFormat("Move str{0}", MoveStr);
	        });

	    ReactiveCollection.ObserveCountChanged()
	        .Subscribe(addStr =>
	        {
	            Debug.LogFormat("Change str{0}", addStr);
	        });

        ReactiveCollection.Add("莫等闲");
        ReactiveCollection.Remove("莫等闲");
        ReactiveCollection.Move(1,0);


	    foreach (var item in ReactiveCollection)
	    {
	        Debug.LogFormat("item:{0}",item);
	    }

    }
	

}
