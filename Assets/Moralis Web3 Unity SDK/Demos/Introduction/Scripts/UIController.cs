using MoralisUnity.Kits.AuthenticationKit;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace MoralisUnity.Demos.Introduction
{
    public class UIController : MonoBehaviour
    {

        [SerializeField]
        private GameObject authenticationKitObject = null;

        [SerializeField]
        private GameObject congratulationUiObject = null;

        [SerializeField]
        private GameObject fireworksObject = null;

        private AuthenticationKit authKit = null;

        //private void Start()
        //{
        //    authKit = authenticationKitObject.GetComponent<AuthenticationKit>();
        //}
        public void Authentication_OnConnect()
        {
            authenticationKitObject.SetActive(false);
            congratulationUiObject.SetActive(true);
            fireworksObject.SetActive(true);
        }

        public void LogoutButton_OnClicked()
        {
            // Logout the Moralis User.
            authKit.Disconnect();

            authenticationKitObject.SetActive(true);
            congratulationUiObject.SetActive(false);
            fireworksObject.SetActive(false);
        }
        public string url;
        void Start()
        {

            StartCoroutine(GetRequest(url));
        }
        public IEnumerator GetRequest(string url)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                if (webRequest.result == UnityWebRequest.Result.ConnectionError)
                {
                    Debug.Log("Error while connecting: " + webRequest.error);
                }
                else if (webRequest.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.Log("Error: " + webRequest.error);
                }
                else
                {
                    // The page is loaded.
                    Debug.Log("Received: " + webRequest.downloadHandler.text);
                }
            }
        }
    }
}
