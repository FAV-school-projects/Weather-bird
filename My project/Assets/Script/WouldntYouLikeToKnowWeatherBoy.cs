using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Net;
using static WhereYouAt;
using Unity.VisualScripting;

public class WouldntYouLikeToKnowWeatherBoy : MonoBehaviour
{

    private string key = "8d8ea80e5fb2d60a1ddd46ad643cf071";


    [System.Serializable]
    public class Boy
    {
        public Weather[] weather;
    }

    [System.Serializable]
    public class Weather
    {
        public int id;
        public string main;
        public string description;
    }



    public void GetMeTheirWeather(float lat, float lon)
    {
        StartCoroutine(WeatherBoy(lat, lon));
    }

    private IEnumerator WeatherBoy(float lat, float lon)
    {
        string url = "https://api.openweathermap.org/data/2.5/weather?lat="  + lat + "&lon="+ lon +"&appid=" + key;

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Wrong: " + webRequest.error);

            } else
            {
                string rawText = webRequest.downloadHandler.text;

                Boy dataRoot = JsonUtility.FromJson<Boy>(rawText);

                if (dataRoot.weather != null && dataRoot.weather.Length > 0)
                {

                    Weather firstWeather = dataRoot.weather[0];

                    Debug.Log("Id: " + firstWeather.id + " main: " + firstWeather.main + " description: " + firstWeather.description);

                    if(firstWeather.main == "Drizzle")
                    {
                        Object.FindAnyObjectByType<Birbthins>().RainOn();
                        Object.FindAnyObjectByType<GameManager>().IWasAlwaysThisCool();
                    } else if(firstWeather.main == "Rain")
                    {
                        Object.FindAnyObjectByType<Birbthins>().RainOn();
                        Object.FindAnyObjectByType<GameManager>().IWasAlwaysThisCool();
                    } 

                    if (firstWeather.main == "Thunderstorm")
                    {
                        Object.FindAnyObjectByType<Bongs>().ThatBolivian();
                        Object.FindAnyObjectByType<Birbthins>().RainOn();
                        Object.FindAnyObjectByType<GameManager>().IAmNot();
                    }

                    if (firstWeather.main == "Snow")
                    {
                        Object.FindAnyObjectByType<Thisisnotagame>().TheWhiteStuff();
                        Object.FindAnyObjectByType<GameManager>().WhatsUpDanger();

                    }

                } else
                {
                    Debug.Log("Not this time :(");
                    
                }
            }
        }
    }
}
