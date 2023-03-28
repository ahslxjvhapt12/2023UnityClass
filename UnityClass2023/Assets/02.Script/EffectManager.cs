using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    private static EffectManager instance;

    public static EffectManager Instance
    {
        get
        {
            if (instance == null) instance = FindAnyObjectByType<EffectManager>();
            return instance;
        }
    }

    public enum EffectType
    {
        Common,
        Flesh
    }

    public ParticleSystem commonHitEffect;
    public ParticleSystem fleshHitEffect;

    public void PlayHitEffect(Vector3 pos, Vector3 normal, Transform parent = null, EffectType effectType = EffectType.Common)
    {
        var targetEffect = commonHitEffect;
        if (effectType == EffectType.Flesh) targetEffect = fleshHitEffect;

        var effect = Instantiate(targetEffect, pos, Quaternion.LookRotation(normal));

        if (parent != null) effect.transform.SetParent(parent);

        effect.Play();
    }


}
