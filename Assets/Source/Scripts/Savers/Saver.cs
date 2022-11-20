using UnityEngine;

public abstract class Saver : MonoBehaviour
{
    protected void SaveInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    protected void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    protected void SetDouble(string key, double value)
    {
        PlayerPrefs.SetString(key, value.ToString());
    }

    protected int GetInt(string key, int defaultValue = 0)
    {
        if (PlayerPrefs.HasKey(key))
            return PlayerPrefs.GetInt(key);
        else
            return defaultValue;
    }

    protected float GetFloat(string key, float defaultValue = 0)
    {
        if(PlayerPrefs.HasKey(key))
            return PlayerPrefs.GetFloat(key);
        else 
            return defaultValue;
    }

    protected double GetDouble(string key, double defalutValue = 0)
    {
        if(PlayerPrefs.HasKey(key))
            return double.Parse(PlayerPrefs.GetString(key));
        else
            return defalutValue;
    }
}
