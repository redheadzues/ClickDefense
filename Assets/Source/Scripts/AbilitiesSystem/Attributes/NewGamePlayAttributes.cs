using System;
using System.Collections.Generic;

namespace Assets.Source.Scripts.AbilitiesSystem.Attributes
{
    [Serializable]
    public class NewGamePlayAttributes
    {
        List<Attribute> Attributes = new List<Attribute>();

        public void ApplyChanges()
        {

        }

        public void CancelChanges()
        {

        }
    }

    public enum AttributeTypeId
    {
        HP, 
        Damage,
        AttackSpeed,
        MovementSpeed,
        Range,
        Jump
    }

    [Serializable]
    public class Attribute
    {
        public AttributeTypeId Id;
        public int Value;

    }
}
