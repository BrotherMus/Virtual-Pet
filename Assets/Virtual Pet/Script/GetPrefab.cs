using System.Collections;
using System.IO;
using UnityEngine;

public class GetPrefab : MonoBehaviour
{
    public string bundleUrl = "https://bafybeihlg7xcw6az5lge7pb7wvn6txdt5uvtulsw5juc6jord4mqrqaagq.ipfs.w3s.link/chicken-dark-1";
    public string assetName = "chicken-dark-1";

    //Start is called before the first frame update
    IEnumerator Start()
    {
        using (WWW web = new WWW(bundleUrl))
        {
            yield return web;
            AssetBundle remoteAssetBundle = web.assetBundle;
            if (remoteAssetBundle == null)
            {
                Debug.LogError("Failed to download AssetBundle!");
                yield break;
            }
            Instantiate(remoteAssetBundle.LoadAsset(assetName));
            remoteAssetBundle.Unload(false);
        }
    }

}

