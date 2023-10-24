using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.IO;
using UnityEditor;

public class GetPrefab : MonoBehaviour
{

    //Import sedia ada
    //public string url = "https://drive.google.com/u/0/uc?id=1MGIKWObYAzw2cbdaVXP3UidkgYrJligS&export=download"; // The Google Drive asset bundle URL
    //public string assetBundleName = "Chicken-Dark-1"; // The name of your asset bundle
    //public GameObject prefab;
    //public AssetBundle assetBundle;

    //IEnumerator Start()
    //{
    //    UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url);
    //    //UnityWebRequest www = UnityWebRequest.Get(url);
    //    yield return www.SendWebRequest();

    //    if (www.isNetworkError || www.isHttpError)
    //    {
    //        Debug.Log(www.error);
    //    }
    //    else
    //    {

    //        assetBundle = DownloadHandlerAssetBundle.GetContent(www);

    //        if (assetBundle != null)
    //        {
    //            // Load your asset from the asset bundle
    //            prefab = assetBundle.LoadAsset<GameObject>(assetBundleName);

    //            if (prefab != null)
    //            {
    //                Instantiate(prefab);
    //            }
    //        }
    //        else
    //        {
    //            Debug.Log("null");
    //        }
    //    }
    //}

    //DOnwload Gambar
    //public string imageUrl;  // Paste the direct URL to your image here.
    //public SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component.

    //void Start()
    //{
    //    StartCoroutine(DownloadImage());
    //}

    //IEnumerator DownloadImage()
    //{
    //    UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageUrl);
    //    yield return www.SendWebRequest();

    //    if (www.isNetworkError || www.isHttpError)
    //    {
    //        Debug.LogError("Image download error: " + www.error);
    //    }
    //    else
    //    {
    //        Texture2D texture = DownloadHandlerTexture.GetContent(www);
    //        DisplayImage(texture);
    //    }
    //}

    //void DisplayImage(Texture2D texture)
    //{
    //    // Create a new Sprite from the downloaded texture.
    //    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);

    //    // Set the sprite to the SpriteRenderer.
    //    spriteRenderer.sprite = sprite;
    //}

    //Downlad folder
    //public string folderUrl = "https://example.com/files/";
    //public string localPath = "Assets/";

    //// A list of filenames you want to download
    //public List<string> fileNames = new List<string>();

    //private void Start()
    //{
    //    StartCoroutine(DownloadFiles());
    //}

    //IEnumerator DownloadFiles()
    //{
    //    foreach (string fileName in fileNames)
    //    {
    //        string remoteFileUrl = folderUrl + fileName;
    //        string localFilePath = localPath + fileName;

    //        using (UnityWebRequest www = UnityWebRequest.Get(remoteFileUrl))
    //        {
    //            yield return www.SendWebRequest();

    //            if (www.isNetworkError || www.isHttpError)
    //            {
    //                Debug.LogError("Error: " + www.error);
    //            }
    //            else
    //            {
    //                System.IO.File.WriteAllBytes(localFilePath, www.downloadHandler.data);
    //                Debug.Log("Downloaded: " + localFilePath);
    //            }
    //        }
    //    }
    //}

    //Dwnload prefab as Assets bundle
    //public string prefabURL = "https://your-cloud-storage.com/path/to/prefab.unity3d";
    //public string prefabName = "PrefabName";

    //IEnumerator Start()
    //{
    //    UnityWebRequest request = UnityWebRequest.Get(prefabURL);
    //    yield return request.SendWebRequest();

    //    if (request.isNetworkError || request.isHttpError)
    //    {
    //        Debug.LogError("Error: " + request.error);
    //    }
    //    else
    //    {
    //        AssetBundle assetBundle = AssetBundle.LoadFromMemory(request.downloadHandler.data);

    //        if (assetBundle == null)
    //        {
    //            Debug.LogError("Failed to load AssetBundle.");
    //        }
    //        else
    //        {
    //            GameObject prefab = assetBundle.LoadAsset<GameObject>(prefabName);

    //            if (prefab == null)
    //            {
    //                Debug.LogError("Failed to load the prefab from the AssetBundle.");
    //            }
    //            else
    //            {
    //                Instantiate(prefab, Vector3.zero, Quaternion.identity);
    //            }

    //            // Unload the AssetBundle to free up memory.
    //            assetBundle.Unload(false);
    //        }
    //    }
    //}


    //Dwnload prefab as addresssable
    [Header("Addressable Settings")]

    public string prefabDownloadURL; // The direct download link from Google Drive
    public string savePath; // The path where the downloaded prefab will be saved
    public string Prefabname;
    public GameObject Prefabs;
    //public string Prefabloc;

    void Start()
    {
        Debug.Log(Application.persistentDataPath);
        StartCoroutine(DownloadPrefabFromGoogleDrive());
    }

    IEnumerator DownloadPrefabFromGoogleDrive()
    {
        UnityWebRequest request = UnityWebRequest.Get(prefabDownloadURL);

        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError("Error downloading prefab: " + request.error);
        }
        else
        {
            savePath = Application.persistentDataPath + Prefabname;
            byte[] prefabData = request.downloadHandler.data;

            if (prefabData != null && prefabData.Length > 0)
            {
                System.IO.File.WriteAllBytes(savePath, prefabData);
                Debug.Log(prefabData);
                Debug.Log("Prefab downloaded and saved to: " + savePath);

                // Now, you can load and instantiate this prefab in your game.
                CopyPrefab();
            }
            else
            {
                Debug.LogError("Downloaded prefab data is empty or null.");
            }
        }
    }
    public void CopyPrefab()
    {
        string destinationPath = "Assets/Resources/" + Prefabname + ".prefab";

        if (File.Exists(savePath))
        {
            if (File.Exists(destinationPath))
            {
                Debug.LogWarning("Prefab already exists in Resources folder. It will be overwritten.");
                FileUtil.DeleteFileOrDirectory(destinationPath);
            }

            FileUtil.CopyFileOrDirectory(savePath, destinationPath);
            AssetDatabase.Refresh();
            Debug.Log("Prefab copied to Resources folder.");
            LoadPrefab();
        }
        else
        {
            Debug.LogError("Prefab not found in the persistent data path.");
        }
    }
    public void LoadPrefab()
    {
        GameObject loadedPrefab = Resources.Load("Chicken-Dark-1.prefab") as GameObject;
        
        if (loadedPrefab != null)
        {
            Prefabs = loadedPrefab;
            // Instantiate the loaded prefab
            Instantiate(Prefabs);
        }
        else
        {
            Debug.LogError("Prefab not found or failed to load.");
        }
    }

}
