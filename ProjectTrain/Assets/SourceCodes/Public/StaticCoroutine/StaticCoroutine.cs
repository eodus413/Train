using UnityEngine;
using System.Collections;
using Singleton;

public delegate Coroutine TempCoroutine(IEnumerator routine);

public class StaticCoroutine : MonoSingleton<StaticCoroutine>
{
}