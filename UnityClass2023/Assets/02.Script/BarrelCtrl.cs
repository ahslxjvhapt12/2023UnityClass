using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    public Texture[] textures;
    private MeshRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponentInChildren<MeshRenderer>();
        int idx = Random.Range(0, textures.Length);
        _renderer.material.mainTexture = textures[idx];

    }
}
