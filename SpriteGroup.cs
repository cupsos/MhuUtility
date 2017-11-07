using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SpriteGroup : MonoBehaviour
{
    public float Alpha { get { return _Alpha; }
        set
        {
            _Alpha = value;
            foreach (SpriteRenderer renderer in everyChildSpriteRenderer)
            {
                Color col = renderer.color;
                col.a = _Alpha;
                renderer.color = col;
            }
            
        }
    }
    [HideInInspector] private float _Alpha = 1;
    private SpriteRenderer[] everyChildSpriteRenderer;

    private void OnEnable()
    {
        everyChildSpriteRenderer = GetComponentsInChildren<SpriteRenderer>(true);
    }
    private void OnTransformChildrenChanged()
    {
        everyChildSpriteRenderer = GetComponentsInChildren<SpriteRenderer>(true);
        Alpha = Alpha;
    }
}