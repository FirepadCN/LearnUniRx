using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test13 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StrIEnumerator strIEnumerator=new StrIEnumerator(new []{"A","B","C"});

        while (strIEnumerator.MoveNext())
        {
            Debug.Log(strIEnumerator.Current);
        }


        StrIEnumerable strIEnumerable=new StrIEnumerable(new []{"1","2","3"});

        IEnumerator strIEnumerator2 = strIEnumerable.GetEnumerator();
        
        foreach (var strIE in strIEnumerable)
        {
            Debug.Log(strIE);   
        }

        while (strIEnumerator2.MoveNext())
        {
            Debug.Log(strIEnumerator2.Current);
        }

        var IEFuc_0 = IEFuc();
        //不能直接使用IEFunc迭代，while (IEFuc().MoveNext())
        while (IEFuc_0.MoveNext())
        {
            Debug.Log(IEFuc_0.Current);
        }
    }


    IEnumerator IEFuc()
    {
        Debug.Log("y");
        yield return "z";
        Debug.Log("a");
        yield return null;
        Debug.Log("c");
        yield break;
        Debug.Log("d");
        yield return "3";
        Debug.Log("f");
    }

}
