using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayRun : MonoBehaviour
{
    public static void Execute(Action callback, float timer, GameObject target)
    {
        var component = target.AddComponent<DelayRun>();
        component.StartCoroutine(component.WaitAndExecute(callback, timer));
    }

    private IEnumerator WaitAndExecute(Action callbak, float timer)
    {
        yield return new WaitForSeconds(timer);
        callbak?.Invoke();
        Destroy(this);
    }
}
