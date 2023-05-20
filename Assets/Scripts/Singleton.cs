using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            // referencing blocker in the event where the instance is called while OnDestroy
            if (applicationIsQuitting)
            {
                return null;
            }

            if (!_instance)
            {
                _instance = (T)FindObjectOfType(typeof(T));
            }

            if (!_instance)
            {
                Debug.Log((typeof(T)).Name);
                T instance = Resources.Load<T>("System/" + (typeof(T)).Name);
                T go = (T)Instantiate(instance);
                _instance = go;
            }

            return _instance;
        }
    }

    private static bool applicationIsQuitting = false;

    [SerializeField] protected bool isPersist = false;

    protected virtual void Awake()
    {
        if (_instance == null) _instance = this as T;


        if (_instance != null)
        {
            if (_instance != this as T)
                Destroy(this.gameObject);
        }

        if (isPersist) DontDestroyOnLoad(this.gameObject);

    }

    protected virtual void OnDestroy()
    {
        applicationIsQuitting = true;
    }

}