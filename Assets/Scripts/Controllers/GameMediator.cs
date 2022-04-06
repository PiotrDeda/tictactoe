using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMediator : MonoBehaviour
{
    public static GameMediator Instance { get; private set; }

    private Dictionary<string, Action<object>> _dict;

    private void Awake()
    {
        if (Instance == null) { Instance = this; } else { Debug.Log("Warning: multiple " + this + " in scene!"); Destroy(gameObject); }

        _dict = new Dictionary<string, Action<object>>();
    }
    public void AddHandler(string eventName, Action<object> action)
    {
        if (_dict.ContainsKey(eventName))
        {
            _dict[eventName] += action;
        }
        else
        {
            _dict.Add(eventName, action);
        }
    }

    public void RemoveHandler(string eventName, Action<object> action)
    {
        if (_dict.ContainsKey(eventName))
        {
            _dict[eventName] -= action;
        }
    }
    public void Broadcast(string eventName, object obj = null)
    {
        if (_dict.ContainsKey(eventName) && _dict[eventName] != null)
        {
            _dict[eventName](obj);
        }
    }
}
