using UnityEngine;

public class Thisisnotagame : MonoBehaviour
{
    public GameObject bomgs;
    public GameObject iceIceBaby;
    public float spermRate = 1f;

    public float minimus = -1f;
    public float maxVerstappen = 1f;

    public bool hitTheSlopes = false;

    private void OnEnable()
    {
        if (hitTheSlopes == false)
        {
            InvokeRepeating(nameof(Spawn), spermRate, spermRate);
        }
        else if (hitTheSlopes == true)
        {
            InvokeRepeating(nameof(Spawn2electricboogaloo), spermRate, spermRate);
        }
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject Bongs = Instantiate(bomgs, transform.position, Quaternion.identity);
        Bongs.transform.position += Vector3.up * Random.Range(minimus, maxVerstappen);
    }

    private void Spawn2electricboogaloo()
    {
        GameObject Bongs2electricboogaloo = Instantiate(iceIceBaby, transform.position, Quaternion.identity);
        Bongs2electricboogaloo.transform.position += Vector3.up * Random.Range(minimus, maxVerstappen);
    }

    public void TheWhiteStuff()
    {
        CancelInvoke();

        hitTheSlopes = !hitTheSlopes;

        Object.FindAnyObjectByType<GameManager>().WhatsUpDanger();

        if (!hitTheSlopes)
        {
            InvokeRepeating(nameof(Spawn), spermRate, spermRate);
        }
        else
        {
            InvokeRepeating(nameof(Spawn2electricboogaloo), spermRate, spermRate);
        }

    }
}
