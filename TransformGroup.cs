using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TransformGroup : MonoBehaviour
{
    public Vector3 AveragePosition
    {
        get
        {
            Vector3 ret = Vector3.zero;
            foreach (Transform child in this.transform)
                ret += child.transform.localPosition;
            ret /= this.transform.childCount;
            return ret;
        }
        set
        {
            Vector3 curAvg = AveragePosition;
            Vector3 diff = value - curAvg;
            foreach (Transform child in this.transform)
                child.transform.localPosition += diff;
        }
    }

    public void MultiplyPos(float value)
    {
        foreach (Transform child in this.transform)
            child.transform.localPosition *= value;
    }
}