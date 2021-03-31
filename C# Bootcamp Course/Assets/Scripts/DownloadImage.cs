using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DownloadImage : MonoBehaviour
{
    [SerializeField] private string _url;
    private Text _text;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(DownloadFactRoutine());
        }
    }

    IEnumerator DownloadFactRoutine()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(_url))
        {
            yield return request.SendWebRequest();

            if (request.isHttpError || request.isNetworkError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                Debug.Log("Successfully got fact.");
                var text = request.downloadHandler.text;
                _text = GetComponent<Text>();
                _text.text = text;
            }
        }
    }
}
