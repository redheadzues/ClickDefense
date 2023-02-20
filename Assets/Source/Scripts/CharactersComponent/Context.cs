using Assets.Source.Scripts.AbilitiesSystem.Components;
using UnityEngine;

namespace Assets.Source.Scripts.CharactersComponent
{
    public class Context : MonoBehaviour
    {
        public Attacker Attacker;
        public Mover Mover;
        public AttributeSetterComponent Attributes;
        
        [HideInInspector] public Transform Target;
        public IDamageable TargetHealth;

        
    }
}