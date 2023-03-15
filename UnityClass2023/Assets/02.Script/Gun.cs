using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Ready,
    Empty,
    Reloading
}
public class Gun : MonoBehaviour
{
    public State state { get; private set; }

    public Transform firePosition; //�Ѿ˳����� ��ġ�� ����
    //public ParticleSystem muzzleFlashEffect;
    public float bulletLineEffectTime = 0.03f;

    private LineRenderer bulletLineRenderer;
    public float damage = 25;

    public float fireDistance = 100f; //�߻簡�� �Ÿ�

    public int magCapacity = 30; //źâ �뷮
    public int magAmmo; //���� źâ�� �ִ� ź���
    public float timeBetFire = 0.12f; //ź�� �߻� ����
    public float reloadTime = 1.8f; //������ �ҿ�ð�
    private float lastFireTime; //���� ���������� �߻��� �ð�

    private void Awake()
    {
        bulletLineRenderer = GetComponent<LineRenderer>();
        bulletLineRenderer.positionCount = 2; //(�ѱ���ġ, ������)
        bulletLineRenderer.enabled = false;
    }

    private IEnumerator ShotEffect(Vector3 hitPos)
    {
        //muzzleFlashEffect.Play();
        bulletLineRenderer.SetPosition(0, firePosition.position);
        bulletLineRenderer.SetPosition(1, hitPos);
        bulletLineRenderer.enabled = true;

        yield return new WaitForSeconds(bulletLineEffectTime);

        bulletLineRenderer.enabled = false;
    }

    public IEnumerator ReloadRoutine()
    {
        state = State.Reloading;
        yield return new WaitForSeconds(reloadTime);
        magAmmo = magCapacity;
        state = State.Ready;
    }

    public bool Fire()
    {
        if (state == State.Ready && Time.time >= lastFireTime + timeBetFire)
        {
            lastFireTime = Time.time;
            Shoot();
        }
        return false;
    }

    private void Shoot()
    {
        RaycastHit hit;

        Vector3 hitPos = Vector3.zero;

        if (Physics.Raycast(firePosition.position, transform.forward, out hit, fireDistance))
        {
            var target = hit.collider.GetComponent<IDamageable>();

            if (target != null)
            {
                target.OnDamage(damage, hit.point, hit.normal);
            }
            hitPos = hit.point;
        }
        else
        {
            hitPos = firePosition.position + firePosition.forward * fireDistance;
        }
        StartCoroutine(ShotEffect(hitPos));
        magAmmo--;
        if (magAmmo <= 0) state = State.Empty;
    }

    public bool Reload()
    {
        //������ ���̰ų� �Ѿ��� �� á���� ����
        if (state == State.Reloading || magAmmo == magCapacity) return false;
        StartCoroutine(ReloadRoutine());
        return true;
    }
}
