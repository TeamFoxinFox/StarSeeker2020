using UnityEngine;

namespace Common
{
  public abstract class Singleton<T> where T : class
  {
    private static T _instance = null;
    public static T Instance => _instance ?? (_instance = System.Activator.CreateInstance(typeof(T)) as T);
  }
}
