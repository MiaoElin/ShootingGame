using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SoundCore {

    public AudioSource prefab;
    public AudioSource role_walk;
    AsyncOperationHandle prefabHandle;

    public void LoadAll() {
        GameObject sfx = new GameObject("SFX");
        var handle = Addressables.LoadAssetAsync<GameObject>("AudioSource");
        prefabHandle = handle;
        prefab = handle.WaitForCompletion().GetComponent<AudioSource>();
        role_walk = GameObject.Instantiate(prefab, sfx.transform);
    }

    public void Unload() {
        if (prefabHandle.IsValid()) {
            Addressables.Release(prefabHandle);
        }
    }

    public void Role_walk_Play(AudioClip clip) {
        role_walk.loop = true;
        role_walk.pitch = 1.5f;
        if (!role_walk.isPlaying) {
            role_walk.clip = clip;
            role_walk.Play();
        }
    }

    public void Role_walk_Stop() {
        if (role_walk.isPlaying) {
            role_walk.Stop();
        }
    }

}