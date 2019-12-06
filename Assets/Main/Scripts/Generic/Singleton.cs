using UnityEngine;
public class Singleton<T> :  MonoBehaviour where T : MonoBehaviour
{
    private static T _instnace;
    public static T Instance
    {
        get
        {
            if(_instnace == null)
                _instnace = FindObjectOfType<T>() as T;
                if (_instnace == null)
                    Debug.LogError("There's no active " + typeof(T) + " in this scene.");

            return _instnace;
        }
        private set { }
    }
}