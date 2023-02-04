using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem
{
    public class EffectViewCell
    {
        public ILastingEffect Effect;
        public GameObject ViewParticle;

        public EffectViewCell(ILastingEffect effect, GameObject viewParticle)
        {
            Effect = effect;
            ViewParticle = viewParticle;
        }
    }
}
