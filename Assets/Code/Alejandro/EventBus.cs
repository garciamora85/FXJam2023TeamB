using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static EventBus;

public static class EventBus 
{
    public enum AlienEventType
    {
        PICKED, DROPPED
    }


    public delegate void Listener();

    private static readonly IDictionary<AlienEventType, UnityEvent> Events = new Dictionary<AlienEventType, UnityEvent>();

    public static void Subscribe(AlienEventType eventType, UnityAction listener)
    {
        UnityEvent thisEvent;
        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Events.Add(eventType, thisEvent);
        }
    }


    public static void Unsubscribe(AlienEventType eventType, UnityAction listener)
    {
        UnityEvent thisEvent;
        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }


    public static void Publish(AlienEventType eventType)
    {
        UnityEvent thisEvent;
        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
