using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class FloatEvent : UnityEvent<float, float>
{

}

public class EventManager : MonoBehaviour
{

    private Dictionary<string, FloatEvent> eventDictionary;

    private static EventManager eventManager;

    public static EventManager Instance {
        get {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, FloatEvent>();
        }
    }

    public static FloatEvent CreateEvent(string eventName, UnityAction<float, float> listener)
    {
        FloatEvent thisEvent = new FloatEvent();
        Instance.eventDictionary.Add(eventName, thisEvent);
        return thisEvent;
    }

    public static void StartListening(string eventName, UnityAction<float, float> listener)
    {
        FloatEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = CreateEvent(eventName, listener);
            thisEvent.AddListener(listener);
        }
    }

    public static void StopListening(string eventName, UnityAction<float, float> listener)
    {
        if (eventManager == null) return;
        FloatEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName, float posY, float posZ)
    {
        FloatEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(posY, posZ);
        }
    }
}
