using Assets.Source.Scripts.Infrustructure.Services.Factories;
using Assets.Source.Scripts.Infrustructure.StaticData;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAddCharacter : MonoBehaviour
{
    [SerializeField] private Button _buttonAddCharacter;

    private ICharacterFactory _factory;

    private void OnEnable() => 
        _buttonAddCharacter.onClick.AddListener(CreateCharacter);

    private void OnDisable() => 
        _buttonAddCharacter.onClick.AddListener(CreateCharacter);

    private void CreateCharacter()
    {
        print("good");
        GameObject allie = _factory.CreateAllie(AllieTypeId.Quinth);
        allie.transform.position = Vector3.up;
        allie.gameObject.SetActive(true);
    }

    public void Construct(ICharacterFactory factory)
    {
        _factory = factory;
    }
}
