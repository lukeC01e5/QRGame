using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using System.Text;


public class Button4Login : MonoBehaviour
{

    //private const string PASSWORD_REGEX = "(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.{8,24})";

    [SerializeField] private string loginEndpoint = "http://gameapi-2e9bb6e38339.herokuapp.com/api/v1/login";
    [SerializeField] private string createEndpoint = "http://gameapi-2e9bb6e38339.herokuapp.com/api/v1/create_account";

    [SerializeField] private TextMeshProUGUI alertText;
    [SerializeField] private Button loginButton;
    [SerializeField] private Button createButton;
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;



    private void Start()
    {
        if (loginButton != null)
            loginButton.onClick.AddListener(OnLoginClick);

        if (createButton != null)
            createButton.onClick.AddListener(CreateAccount);
    }


    public class User
    {
        public string username;
        public string password;
    }

    public void OnLoginClick()
    {
        alertText.text = "Signing in...";
        ActivateButtons(false);

        StartCoroutine(TryLoginCoroutine());
    }

    public void CreateAccount()
    {
        alertText.text = "Creating account...";
        ActivateButtons(false);

        StartCoroutine(TryCreateAccountCoroutine());
    }


    private IEnumerator TryLoginCoroutine()
    {
        string username = usernameInputField.text;
        string password = passwordInputField.text;

        Debug.Log("Attempting to login with username: " + username);

        // Construct the request body
        User user = new User
        {
            username = username,
            password = password
        };

        string jsonBody = JsonUtility.ToJson(user);

        Debug.Log("JSON body of the request: " + jsonBody);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(loginEndpoint, new List<IMultipartFormSection>()))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);
            webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Login request failed with error: " + webRequest.error);
                Debug.LogError("Response code: " + webRequest.responseCode);
            }
            else
            {
                string jsonResponse = webRequest.downloadHandler.text;
                Debug.Log("Login request succeeded. Server response: " + jsonResponse);
            }
        }
    }

    private IEnumerator TryCreateAccountCoroutine()

    {
        string username = usernameInputField.text;
        string password = passwordInputField.text;

        Debug.Log("Attempting to login with username: " + username);

        // Construct the request body
        User user = new User
        {
            username = username,
            password = password
        };

        string jsonBody = JsonUtility.ToJson(user);

        Debug.Log("JSON body of the request: " + jsonBody);

        using (UnityWebRequest webRequest = new UnityWebRequest(createEndpoint, "POST"))
        {
            Debug.Log("Sending request to: " + createEndpoint);

            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);
            webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Login request failed with error: " + webRequest.error);
                Debug.LogError("Response code: " + webRequest.responseCode);
            }
            else
            {
                string jsonResponse = webRequest.downloadHandler.text;
                Debug.Log("Login request succeeded. Server response: " + jsonResponse);
            }
        }
    }

    private void ActivateButtons(bool toggle)
    {
        loginButton.interactable = toggle;
        createButton.interactable = toggle;
    }
}