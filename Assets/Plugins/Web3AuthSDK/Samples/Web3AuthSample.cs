using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using static Web3Auth;
using UnityEngine.SceneManagement;
using Nethereum.Web3.Accounts;
using Nethereum.RPC.Accounts;
using Nethereum.Web3.Accounts.Managed;
using System.Collections;
using TMPro;
using Nethereum.Web3;
using Nethereum.Util;
using Nethereum.Signer;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.ABI.Encoders;
using Nethereum.Hex.HexTypes;

public class Web3AuthSample : MonoBehaviour
{
    List<LoginVerifier> verifierList = new List<LoginVerifier> {
        new LoginVerifier("Google", Provider.GOOGLE),
        new LoginVerifier("Facebook", Provider.FACEBOOK),
        new LoginVerifier("CUSTOM_VERIFIER", Provider.CUSTOM_VERIFIER),
        new LoginVerifier("Twitch", Provider.TWITCH),
        new LoginVerifier("Discord", Provider.DISCORD),
        new LoginVerifier("Reddit", Provider.REDDIT),
        new LoginVerifier("Apple", Provider.APPLE),
        new LoginVerifier("Github", Provider.GITHUB),
        new LoginVerifier("LinkedIn", Provider.LINKEDIN),
        new LoginVerifier("Twitter", Provider.TWITTER),
        new LoginVerifier("Line", Provider.LINE),
        new LoginVerifier("Hosted Email Passwordless", Provider.EMAIL_PASSWORDLESS),
    };

    Web3Auth web3Auth;

    [SerializeField]
    InputField emailAddressField;

    [SerializeField]
    Dropdown verifierDropdown;

    [SerializeField]
    Button loginButton;

    [SerializeField]
    Text loginResponseText;

    [SerializeField]
    Button logoutButton;

    public GameObject MenuPanel;
    public GameObject SettingPanel;
    public GameObject Web3Panel;

    void Start()
    {
        var loginConfigItem = new LoginConfigItem()
        {
            verifier = "your_verifierid_from_web3auth_dashboard",
            typeOfLogin = TypeOfLogin.GOOGLE,
            clientId = "your_clientId_from_web3auth_dashboard"
        };

        web3Auth = GetComponent<Web3Auth>();
        web3Auth.setOptions(new Web3AuthOptions()
        {
            whiteLabel = new WhiteLabelData()
            {
                appName = "Web3Auth Sample App",
                logoLight = null,
                logoDark = null,
                defaultLanguage = Language.en,
                mode = ThemeModes.dark,
                theme = new Dictionary<string, string>
                {
                    { "primary", "#123456" }
                }
            },
            // If using your own custom verifier, uncomment this code. 
            /*
            ,
            loginConfig = new Dictionary<string, LoginConfigItem>
            {
                {"CUSTOM_VERIFIER", loginConfigItem}
            }
            */
            clientId = "BGP9AMmocGjbMlmwWLFqghfJIx9ODjI3RTm5bEQwnMUtdPSGs7zFDKAfHq0X0F1lxJeBRx-P8sUFGp03PdeNGGQ",
            buildEnv = BuildEnv.PRODUCTION,
            redirectUrl = new Uri("torusapp://com.torus.Web3AuthUnity/auth"),
            network = Web3Auth.Network.SAPPHIRE_DEVNET
        });
        web3Auth.onLogin += onLogin;
        web3Auth.onLogout += onLogout;

        emailAddressField.gameObject.SetActive(false);
        logoutButton.gameObject.SetActive(false);

        loginButton.onClick.AddListener(login);
        logoutButton.onClick.AddListener(logout);

        verifierDropdown.AddOptions(verifierList.Select(x => x.name).ToList());
        verifierDropdown.onValueChanged.AddListener(onVerifierDropDownChange);
    }
    private Account account;
    private void onLogin(Web3AuthResponse response)
    {
        loginResponseText.text = JsonConvert.SerializeObject(response, Formatting.Indented);
        var userInfo = JsonConvert.SerializeObject(response.userInfo, Formatting.Indented);
        Debug.Log(userInfo);
        string privateKey = response.privKey;
        var newAccount = new Account(privateKey);
        account = newAccount;
        Debug.Log(account.Address);
        loginButton.gameObject.SetActive(false);
        verifierDropdown.gameObject.SetActive(false);
        emailAddressField.gameObject.SetActive(false);
        logoutButton.gameObject.SetActive(true);
        //Open panel
        MenuPanel.SetActive(true);
        Web3Panel.SetActive(false);
    }

    private void onLogout()
    {
        loginButton.gameObject.SetActive(true);
        verifierDropdown.gameObject.SetActive(true);
        logoutButton.gameObject.SetActive(false);

        loginResponseText.text = "";
    }


    private void onVerifierDropDownChange(int selectedIndex)
    {
        if (verifierList[selectedIndex].loginProvider == Provider.EMAIL_PASSWORDLESS)
            emailAddressField.gameObject.SetActive(true);
        else
            emailAddressField.gameObject.SetActive(false);
    }

    private void login()
    {
        var selectedProvider = verifierList[verifierDropdown.value].loginProvider;

        var options = new LoginParams()
        {
            loginProvider = selectedProvider
        };

        if (selectedProvider == Provider.EMAIL_PASSWORDLESS)
        {
            options.extraLoginOptions = new ExtraLoginOptions()
            {
                login_hint = emailAddressField.text
            };
        }

        web3Auth.login(options);
    }

    private void logout()
    {
        web3Auth.logout();
        //Open panel
        MenuPanel.SetActive(false);
        SettingPanel.SetActive(false);
        Web3Panel.SetActive(true);
    }
}
