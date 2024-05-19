using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SoundCore {

    public AudioSource prefab;
    public AudioSource role_Walk;
    public AudioSource role_EnterGround;
    AsyncOperationHandle prefabHandle;

    public void LoadAll() {
        GameObject sfx = new GameObject("SFX");
        var handle = Addressables.LoadAssetAsync<GameObject>("AudioSource");
        prefabHandle = handle;
        prefab = handle.WaitForCompletion().GetComponent<AudioSource>();
        role_Walk = GameObject.Instantiate(prefab, sfx.transform);
        role_EnterGround = GameObject.Instantiate(prefab, sfx.transform);
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

}