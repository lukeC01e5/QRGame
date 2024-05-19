using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class Button4Login : MonoBehaviour
{
    [SerializeField] private string loginEndpoint = "http://gameapi-2e9bb6e38339.herokuapp.com/api/v1/login";
    [SerializeField] private string createEndpoint = "http://gameapi-2e9bb6e38339.herokuapp.com/api/v1/create_account";

    [SerializeField] private TextMeshProUGUI alertText;
    [SerializeField] private Button loginButton;
    [SerializeField] private Button createButton;
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;

    public CameraFollow cameraFollowScript;



    private void Awake() // Add this method
    {
        // Find the CameraFollow script in the scene and assign it to cameraFollowScript
        cameraFollowScript = FindObjectOfType<CameraFollow>();
    }


    public void CompleteLogin()
    {
        // Enable the CameraFollow script after login
        cameraFollowScript.EnableCameraFollow();
    }


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
                alertText.text = "Welcome " + username + "!";

                // Parse the JSON response into a GameAccount object


                GameAccount gameAccountResponse = JsonUtility.FromJson<GameAccount>(jsonResponse);

                // Now you can access the properties of gameAccountResponse to get the user's information
                Debug.Log("User ID: " + gameAccountResponse._id);
                Debug.Log("Username: " + gameAccountResponse.username);
                // ... and so on for the other properties of GameAccount

                // Store the user's information in the GameAccount object in your Unity game
                //GameAccount.userId = gameAccountResponse.userId;
                //GameAccount.username = gameAccountResponse.username;
                // ... and so on for the other properties of GameAccount

                // Get a reference to the HideLogin script
                HideLogin hideLogin = FindObjectOfType<HideLogin>();

                // Hide the login page
                hideLogin.HideLoginPage();

                CompleteLogin();
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