using System;
using System.Collections;

public class StrIEnumerator : IEnumerator
{
    private string[] _strArray;
    private int _index;

    public StrIEnumerator(string[] strArray)
    {
        _strArray = strArray;
        _index = -1;
    }

    public bool MoveNext()
    {
        if (_index != _strArray.Length)
            _index++;
        return _index<_strArray.Length;
    }


    public void Reset()
    {
        _index = -1;
    }

    public object Current
    {
        get
        {
            return _strArray[_index];
        }
    }
}

public class StrIEnumerable : IEnumerable
{
    private string[] _strArray;
    private IDisposable _disposable;
    public StrIEnumerable(string[] strArray)
    {
         _strArray=strArray;
    }
    public IEnumerator GetEnumerator()
    {
        return new StrIEnumerator(_strArray);
    }

}
