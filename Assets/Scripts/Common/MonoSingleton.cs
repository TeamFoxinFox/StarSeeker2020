using UnityEngine;

namespace Common
{
  public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
  {
    private static T _instance = null;
    public static T Instance
    {
      get
      {
        _instance = FindObjectOfType (typeof(T)) as T;
        if (_instance != null) return _instance;
        _instance = new GameObject("@" + typeof(T), typeof(T)).AddComponent<T>();
        DontDestroyOnLoad(_instance);
        return _instance;
      }
    }
  } 
}