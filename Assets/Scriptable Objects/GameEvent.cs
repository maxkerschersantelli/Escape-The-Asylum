using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameEvent", menuName = "ScriptableObjects/GameEvent")]
public class GameEvent : ScriptableObject
{

    private List<GameEventListener> listeners = new List<GameEventListener>();
    public void RegisterListerner(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }

    public void Raise()
    {
        Debug.Log("Raise");
        for (int i = listeners.Count - 1; i >= 0; --i)
        {
            Debug.Log("Raise" + i);
            listeners[i].RaiseEvent();
        }
    }
}