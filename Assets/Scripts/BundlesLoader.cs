using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BundlesLoader : MonoBehaviour
{
    [SerializeField] private CircleScroleBar _scroleBar;
    [SerializeField] private string _sceneName;
    private List<WWW> store = new List<WWW>();
    private float _percent;
    private float _proportion;
    private bool _ready;

    private void Awake()
    {
        _proportion = 80 / StaticInfo.paths.Count;
        try
        {
            StartCoroutine(DownloadAll());
        }
        catch
        {
            Application.Quit();
        }
    }

    private IEnumerator DownloadAll()
    {
        StartCoroutine(WaiteCorutine());
        foreach (var item in StaticInfo.paths)
        {
            yield return StartCoroutine(Download(item));
        }
        yield return null;
    }

    private IEnumerator Download(string bundelName)
    {
        AssetBundleManifest manifest;
        using (var www = new WWW(StaticInfo.path + StaticInfo.manifestName))
        {
            yield return www;
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.LogError(www.error);
                yield break;
            }
            manifest = www.assetBundle.LoadAsset("AssetBundleManifest") as AssetBundleManifest;
            yield return null;
            www.assetBundle.Unload(false);
            store.Add(www);
        }

        using (var www = WWW.LoadFromCacheOrDownload(StaticInfo.path + bundelName, manifest.GetAssetBundleHash(bundelName)))
        {
            yield return www;
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.LogError(www.error);
                yield break;
            }
            Store.LoadBandle(www.assetBundle);
            _percent += _proportion;
            _scroleBar.UpdateImage(_percent);
            _ready = true;
            yield return null;
            www.assetBundle.Unload(false);
            store.Add(www);
        }
    }

    private IEnumerator WaiteCorutine()
    {
        yield return new WaitForSeconds(3);
        yield return null;
        if(_ready)
        {
            _scroleBar.UpdateImage(100f);
            SceneManager.LoadScene(_sceneName);
        }
    }

    private void OnApplicationQuit()
    {
        foreach(var www in store)
            www.assetBundle.Unload(true);
    }
} 