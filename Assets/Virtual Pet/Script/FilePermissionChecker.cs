using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FilePermissionChecker : MonoBehaviour
{
    public string API;
    public string acceptString;
    public string WalletAddress;
    public string other;
    public Text response;

    void Start()
    {
        StartCoroutine(MakeMoralisRequest());
    }

    IEnumerator MakeMoralisRequest()
    {
        // Construct the URL with the WalletAddress variable
        string url = $"https://deep-index.moralis.io/api/v2.2/{WalletAddress}/{other}";

        // Create a UnityWebRequest object
        UnityWebRequest request = UnityWebRequest.Get(url);

        // Set the required headers
        request.SetRequestHeader("accept", acceptString);
        request.SetRequestHeader("X-API-Key", API);

        // Send the request and wait for the response
        yield return request.SendWebRequest();

        // Check for errors
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Moralis API request error: " + request.error);
        }
        else
        {
            // Access the response text
            string responseText = request.downloadHandler.text;
            Debug.Log("Moralis API response: " + responseText);
            response.text = responseText;
            // Process the response as needed.
        }
    }
}


