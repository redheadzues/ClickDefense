using UnityEngine;

public class Vector3ToString : MonoBehaviour
{
    private Vector3 test = new Vector3(8, 5.144f , 457.5f);
    private string _stringVector;

    private void Start()
    {
        ConvertToString();
        print(ConvertStringToVector());
    }

    private void ConvertToString()
    {
        _stringVector = test.ToString();
    }

    private Vector3 ConvertStringToVector()
    {
        string[] coordintes = _stringVector.Split(",");

        for(int i = 0; i < coordintes.Length; i++)  
        {
            coordintes[i] =  coordintes[i].Replace("(", "");
            coordintes[i] = coordintes[i].Replace(")", "");
        }

        float coordinateX = float.Parse(coordintes[0]);
        float coordinateY = float.Parse(coordintes[1]);
        float coordinateZ = float.Parse(coordintes[2]);


        return new Vector3(coordinateX, coordinateY, coordinateZ);
    }
}
