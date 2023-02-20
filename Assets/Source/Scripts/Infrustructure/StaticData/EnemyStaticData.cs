using Assets.Source.Scripts.AbilitiesSystem.Attributes;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.StaticData
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "StaticData/Enemy")]
    public class EnemyStaticData : ScriptableObject
    {        
        [field: SerializeField] public EnemyTypeId EnemyTypeId { get; private set; }
        [field: SerializeField, Range(1, 100)] public int HP { get; private set; }
        [field: SerializeField, Range(1, 20)] public int Reward { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: SerializeField] public GamePlayAttributes Attributes { get; private set; }
        
        
    }
}
