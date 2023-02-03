using Assets.Source.Scripts.AbilitiesSystem.Abilities;
using Assets.Source.Scripts.Infrustructure.Services;

namespace Assets.Source.Scripts.AbilitiesSystem.Factories
{
    public interface IAbilityFactory : IService
    {
        Ability CreateAbility(string name);
    }
}