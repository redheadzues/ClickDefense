using UnityEngine;
using NumbersForIdle;

namespace Saver
{
    public abstract class Saver
    {
        private delegate T LoadObject<T>(string key);

        protected void SetInt(string key, int value)
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

        protected void SetVector3(string key, Vector3 point)
        {
            PlayerPrefs.SetString(key, point.ToString());
        }

        protected void SetIdleNumber(string key, IdleNumber value)
        {
            PlayerPrefs.SetString(key, key);
            PlayerPrefs.SetFloat(key + "Value", value.Value);
            PlayerPrefs.SetInt(key + "Degree", value.Degree);
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
            if (PlayerPrefs.HasKey(key))
                return PlayerPrefs.GetFloat(key);
            else
                return defaultValue;
        }

        protected double GetDouble(string key, double defalutValue = 0)
        {
            if (PlayerPrefs.HasKey(key))
                return double.Parse(PlayerPrefs.GetString(key));
            else
                return defalutValue;
        }

        protected IdleNumber GetIdleNumber(string key, IdleNumber defaultValue)
        {
            if (PlayerPrefs.HasKey(key))
                return new IdleNumber(PlayerPrefs.GetFloat(key + "Value"), PlayerPrefs.GetInt(key + "Degree"));
            else
                return defaultValue;
        }

        protected Vector3 GetVector3(string key, Vector3 defaultPoint)
        {
            if (PlayerPrefs.HasKey(key))
                return StringToVector3Converter.ConvertStringToVector(PlayerPrefs.GetString(key));
            else
                return defaultPoint;
        }

        protected bool TryLoadObject<T>(string fileName, out T obj)
        {
            return TryLoadObject(PlayerPrefs.HasKey(fileName), fileName, LoadFromJsonUtility<T>, out obj);
        }

        private bool TryLoadObject<T>(bool condition, string key, LoadObject<T> objectLoading, out T result)
        {
            result = default;

            if (condition)
                result = objectLoading(key);

            return condition != false;
        }

        private T LoadFromJsonUtility<T>(string fileName)
        {
            return JsonUtility.FromJson<T>(PlayerPrefs.GetString(fileName));
        }
    }
}
