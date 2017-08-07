using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public static class Extention
{
    public static T Random<T>(this IList<T> list) => 
        list[UnityEngine.Random.Range(0, list.Count)];
    public static void AddEvent(this EventTrigger trigger, EventTriggerType eventID, UnityAction<BaseEventData> call)
    {
        var callback = new EventTrigger.TriggerEvent();
        callback.AddListener(call);
        trigger.triggers.Add(new EventTrigger.Entry() { eventID = eventID, callback = callback });
    }
    public static int FindIndex<T>(this IEnumerable<T> group, T element)
    {
        int i = 0;
        foreach (var curElement in group)
            if (curElement.Equals(element))
                return i;
            else i++;
        return -1;
    }
    public static T[] ResizeTo<T>(this T[] source, int length) where T : new()
    {
        T[] ret = new T[length];
        int minSize = Mathf.Min(source.Length, ret.Length);
        for (int i = 0; i < minSize; i++)
            ret[i] = source[i];
        for (int i = minSize; i < length; i++)
            ret[i] = new T();
        return ret;
    }
}