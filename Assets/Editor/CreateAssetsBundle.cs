using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using System.IO;

public class CreateAssetsBundle : MonoBehaviour
{
    [MenuItem("Assets/Create Assets Bundles")]
    private static void BuildAllAssetsBundles()
    {
        // Specify the directory where you want to save the Asset Bundles.
        string assetPath = Application.dataPath + "/../Assets/AssetBundles";
        Debug.Log(!Directory.Exists(assetPath));
        try
        {
            // Create the output directory if it doesn't exist.
            if (!Directory.Exists(assetPath))
            {
                Debug.Log("ok");
                Directory.CreateDirectory(assetPath);
            }

            // Build the Asset Bundles.
            BuildPipeline.BuildAssetBundles(assetPath, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);

            Debug.Log("Asset Bundles created successfully in: " + assetPath);
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
