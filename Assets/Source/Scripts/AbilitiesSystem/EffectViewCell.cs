using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem
{
    public class EffectViewCell
    {
        public GamePlayEffect Effect;
        public GameObject ViewParticle;

        public EffectViewCell(GamePlayEffect effect, GameObject viewParticle)
        {
            Effect = effect;
            ViewParticle = viewParticle;
        }
    }
}
