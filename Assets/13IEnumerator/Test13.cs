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

        int i = 0;
        while (IEFuc().MoveNext()&&i<10)
        {
            i++;
            Debug.Log(IEFuc().Current);
        }
    }


    IEnumerator IEFuc()
    {
        Debug.Log("y");
        yield return "z";
        Debug.Log("a");
        yield return "b";
        Debug.Log("c");
        yield break;
        Debug.Log("d");
        yield return "3";
        Debug.Log("f");
    }

}
