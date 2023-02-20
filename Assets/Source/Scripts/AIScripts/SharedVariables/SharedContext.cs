using Assets.Source.Scripts.CharactersComponent;
using BehaviorDesigner.Runtime;

public class SharedContext : SharedVariable<Context>
{
    public static implicit operator SharedContext(Context value) { return new SharedContext { Value = value }; }
}
