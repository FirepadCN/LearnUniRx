using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class CoroutineExample : MonoBehaviour
{
    private Button Btn1;
    private Button Btn2;

    public GameObject go;
	// Use this for initialization
	void Start ()
	{
	    Btn1 = GameObject.Find("Btn1").GetComponent<Button>();
	    Btn2 = GameObject.Find("Btn2").GetComponent<Button>();

	    var btn1Stream = Btn1.OnClickAsObservable().First();
	    var btn2Stream = Btn1.OnClickAsObservable().First();

	    Observable.WhenAll(btn1Stream, btn2Stream)
	        .Subscribe(_ => { Debug.Log("All btn clicked"); });


	    var aStream = Observable.FromCoroutine(CorcoutineA);
	    aStream.Subscribe(_ => { Debug.Log("From Coroutine A"); });
	    
	    var cStream = Observable.FromCoroutine(CorcoutineC);
	    cStream.Subscribe(_ => { Debug.Log("From Coroutine C"); });

        var bStream=StartCoroutine(CoroutineB());

	    Observable.WhenAll(aStream, cStream).Subscribe(_ => { Debug.Log("when all"); });


	}

    IEnumerator CorcoutineA()
    {
        yield return new WaitForSeconds(5.0f);
        Debug.Log("Wait 5s A()");
    }

    IEnumerator CoroutineB()
    {
        yield return Observable.Timer(TimeSpan.FromSeconds(1.0f)).ToYieldInstruction();
        Debug.Log("Coroutine B");
    }

    IEnumerator CorcoutineC()
    {
        yield return new WaitForSeconds(3.0f);
        Debug.Log("Wait 3s B()");
    }

    void Update()
    {
        if (!go.GetComponent<Renderer>().material.GetTexture("_MainTex"))
        {
            if(go.GetComponent<Renderer>().material.GetFloat("M")>0.0f)
             go.GetComponent<Renderer>().material.SetFloat("M",0.0f);
        }
        else
        {
            if(go.GetComponent<Renderer>().material.GetFloat("M")<1f)
             go.GetComponent<Renderer>().material.SetFloat("M",1f);
        }
    }
}
