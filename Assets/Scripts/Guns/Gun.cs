﻿using System.Collections;
using UnityEngine;

public abstract class Gun : Item {

	public float FireRate;
	public Projectile ProjectilePrefab; // Has events for on collide
	public Transform SpawnPoint;
    public AudioSource FireSound;
	private bool canFire;

	public Gun() {
		canFire = true;
	}

	protected abstract void OnFire();

	public override void Use() {
		if (canFire) {
			StartCoroutine(fireAndWait());
		}
	}

	private IEnumerator fireAndWait() {
		canFire = false;
		OnFire();
		FireSound.Play();
		yield return new WaitForSeconds(FireRate);
		canFire = true;
	}
}
