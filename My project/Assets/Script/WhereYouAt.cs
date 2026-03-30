using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Net;

public class WhereYouAt : MonoBehaviour
{
    [System.Serializable]
    public class PLocation
    {
        public string status;
        public float lat;
        public float lon;
    }

    public WouldntYouLikeToKnowWeatherBoy Script;

    

    private void Start()
    {
        StartCoroutine(WhereArtsThough());
    }

    private IEnumerator WhereArtsThough()
    {
        string url = "http://ip-api.com/json/";

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Wrong: " + webRequest.error);

            }
            else
            {
                string rawr = webRequest.downloadHandler.text;
                PLocation myLocation = JsonUtility.FromJson<PLocation>(rawr);

                Script.GetMeTheirWeather(myLocation.lat, myLocation.lon);

                if (myLocation.status == "success")
                {
                    Debug.Log("That's my fucking location: latitude: " + myLocation.lat + " longitude: " + myLocation.lon);
                }
            }
        }
    }
}
