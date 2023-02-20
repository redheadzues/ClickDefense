using UnityEngine;

public static class StringToVector3Converter
{
    public static Vector3 ConvertStringToVector(string stringVector)
    {
        string[] coordintes = stringVector.Split(",");

        for (int i = 0; i < coordintes.Length; i++)
        {
            coordintes[i].Replace("(", "");
            coordintes[i].Replace(")", "");
        }

        float coordinateX = float.Parse(coordintes[0]);
        float coordinateY = float.Parse(coordintes[1]);
        float coordinateZ = float.Parse(coordintes[2]);


        return new Vector3(coordinateX, coordinateY, coordinateZ);
    }
}
