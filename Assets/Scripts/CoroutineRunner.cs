using UnityEngine;
using System.Collections;

public class CoroutineRunner : MonoBehaviour
{
    private static CoroutineRunner instance;

    private void Awake()
    {
        instance = this;
    }

    public static void RunCoroutine(IEnumerator coroutine)
    {
        if (instance == null)
        {
            GameObject runnerObject = new GameObject("CoroutineRunner");
            instance = runnerObject.AddComponent<CoroutineRunner>();
        }

        instance.StartCoroutine(coroutine);
    }
}
