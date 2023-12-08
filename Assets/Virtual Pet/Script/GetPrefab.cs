using UnityEngine;
using System.Collections;

public class GetPrefab : MonoBehaviour
{
    public string bundleUrl = "https://bafybeihlg7xcw6az5lge7pb7wvn6txdt5uvtulsw5juc6jord4mqrqaagq.ipfs.w3s.link/chicken-dark-1";
    public string assetName = "chicken-dark-1";
    public GameObject parentGameObject; // Reference to the parent GameObject

    // Start is called before the first frame update
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

            // Instantiate the object and set its parent
            GameObject instantiatedObject = Instantiate(remoteAssetBundle.LoadAsset(assetName)) as GameObject;
            if (instantiatedObject != null)
            {
                // Check if a parent GameObject is specified
                if (parentGameObject != null)
                {
                    instantiatedObject.transform.parent = parentGameObject.transform;
                }

                // Modify the transform properties
                instantiatedObject.transform.localScale = new Vector3(100, 100, 100); // Example scale
            }

            remoteAssetBundle.Unload(false);
        }
    }
}
