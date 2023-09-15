using UnityEngine;
using System.Collections;

public static class FunctionTimer
{
    public static IEnumerator Start(float time, System.Action action)
    {
        yield return new WaitForSeconds(time);
        action.Invoke();
    }
}
