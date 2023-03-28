using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour, IDamageable
{
    public Texture[] textures;
    private MeshRenderer _renderer;



    public GameObject expEffect = null;
    private Rigidbody rb = null;
    private int hitCount = 0;

    public void OnDamage(float damage, Vector3 hitPosition, Vector3 hitNormal)
    {
        if (++hitCount == 3)
        {
            //터트리기
            ExpBarrel();
        }
        else
        {
            AttackBarrel(damage, -hitNormal);
        }
    }

    private void AttackBarrel(float power, Vector3 dir)
    {
        //rb.AddForce(dir,,,,);
    }

    private void ExpBarrel()
    {
        GameObject exp = Instantiate(expEffect, transform.position, Quaternion.identity);
        Destroy(exp, 2);

        rb.mass = 1.0f;
        rb.AddForce(Vector3.up * 1500);

        Destroy(gameObject, 3);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        _renderer = GetComponentInChildren<MeshRenderer>();
        int idx = Random.Range(0, textures.Length);
        _renderer.material.mainTexture = textures[idx];
    }
}
