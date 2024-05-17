using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Web : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        using (UnityWebRequest www = UnityWebRequest.Post("https://gameapi-2e9bb6e38339.herokuapp.com/api/v1/resources", "{ \"field1\": 1, \"field2\": 2 }"))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}