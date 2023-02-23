using Assets.Source.Scripts.Infrustructure.StaticData;
using Assets.Source.Scripts.MergingGrid;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Dictionary<Type, ICellContent> _content = new Dictionary<Type, ICellContent>();

    public TContent GetContent<TType, TContent>() where TType : class, ICellContent where TContent : ICellContent =>
    _content.ContainsKey(typeof(TType)) ? (TContent)_content[typeof(TType)] : default(TContent);

    public void SetContent<TType>(ICellContent content) where TType : class, ICellContent =>
        _content.Add(typeof(TType), content);

    public void SetContentOnPosition(Vector3 position)
    {
        foreach (ICellContent value in _content.Values)
            value.SetPosition(position);
    }

    private void Awake()
    {
        var aaa = Enum.GetValues(typeof(AllieTypeId));

        var x = aaa.GetValue(1);

        AllieTypeId b = (AllieTypeId)x;

        print(b);
    }
}

public class SomeClass : IMergeable
{
    public void SomeAction()
    {

    }

    public void Destroy()
    {

    }

    public void Merge()
    {

    }

    public void SetPosition(Vector3 position)
    {
        
    }
}

public class OtherClass : ICellContent
{
    public void SetPosition(Vector3 position)
    {

    }
}
