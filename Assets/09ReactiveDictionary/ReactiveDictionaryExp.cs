using UniRx;
using UnityEngine;

public class ReactiveDictionaryExp : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{

	    var reactiveDictionary = new ReactiveDictionary<int, string>()
	    {
	        {0, "酒酣胸胆尚开张"},
	        {1, "鬓微霜"},
	        {2, "又何妨"}

	    };
	    reactiveDictionary.ObserveAdd()
	        .Subscribe(addStr =>
	        {
	            Debug.LogFormat("add str{0}", addStr);
	        });

	    reactiveDictionary.ObserveRemove()
	        .Subscribe(RemoveStr =>
	        {
	            Debug.LogFormat("Remove str{0}", RemoveStr);
	        });

	    reactiveDictionary.ObserveReplace()
	        .Subscribe(MoveStr =>
	        {
	            Debug.LogFormat("Move str{0}", MoveStr);
	        });

	    reactiveDictionary.ObserveCountChanged()
	        .Subscribe(addStr =>
	        {
	            Debug.LogFormat("Change str{0}", addStr);
	        });

        reactiveDictionary.Add(3,"射天狼");
        reactiveDictionary.Remove(0);


	    foreach (var item in reactiveDictionary)
	    {
	        Debug.LogFormat("item:{0}",item);
	    }

    }
	

}
