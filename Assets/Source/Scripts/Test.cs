using Assets.Source.Scripts.AbilitiesSystem.Attributes;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Test : MonoBehaviour
{

    public List<Attribute> attr = new List<Attribute>();

    private void OnValidate()
    {
        //attr = attr.GroupBy(x => x.Id).Select(x => x.First()).ToList();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
