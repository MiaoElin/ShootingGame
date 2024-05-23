using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SoundCore {

    public AudioSource prefab;
    public AudioSource role_Walk;
    public AudioSource role_EnterGround;
    public AudioSource role_Pick;
    public AudioSource bag_OpenClose;

    public AudioSource gun_Shoot;
    AsyncOperationHandle prefabHandle;

    public void LoadAll() {
        Transform sfx = new GameObject("SFX").transform;
        var handle = Addressables.LoadAssetAsync<GameObject>("AudioSource");
        prefabHandle = handle;
        prefab = handle.WaitForCompletion().GetComponent<AudioSource>();
        role_Walk = GameObject.Instantiate(prefab, sfx);
        role_EnterGround = GameObject.Instantiate(prefab, sfx);
        gun_Shoot = GameObject.Instantiate(prefab, sfx);
        role_Pick = GameObject.Instantiate(prefab, sfx);
        bag_OpenClose = GameObject.Instantiate(prefab, sfx);
    }

    public void Unload() {
        if (prefabHandle.IsValid()) {
            Addressables.Release(prefabHandle);
        }
    }

    public void Role_walk_Play(AudioClip clip) {
        role_Walk.loop = true;
        role_Walk.pitch = 1.5f;
        if (!role_Walk.isPlaying) {
            role_Walk.clip = clip;
            role_Walk.Play();
        }
    }

    public void Role_walk_Stop() {
        if (role_Walk.isPlaying) {
            role_Walk.Stop();
        }
    }

    internal void Role_EnterGround_Play(AudioClip clip) {
        role_EnterGround.volume = 0.15f;
        if (!role_EnterGround.isPlaying) {
            role_EnterGround.clip = clip;
            role_EnterGround.Play();
        }
    }

    public void Gun_Shoot(AudioClip clip) {
        if (!gun_Shoot.isPlaying) {
            gun_Shoot.volume = 0.1f;
            gun_Shoot.clip = clip;
            gun_Shoot.Play();
        }
    }

    public void Role_Pick(AudioClip clip) {
        if (!role_Pick.isPlaying) {
            role_Pick.volume = 0.3f;
            role_Pick.clip = clip;
            role_Pick.Play();
        }
    }

    public void OpenClose_Bag(AudioClip clip) {
        if (!bag_OpenClose.isPlaying) {
            bag_OpenClose.volume = 0.3f;
            bag_OpenClose.clip = clip;
            bag_OpenClose.Play();
        }
    }

}