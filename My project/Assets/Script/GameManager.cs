using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Birbthins birbthins;
    public Text bootyText;
    public GameObject lettuce;
    public GameObject skillIssueUI;
    public GameObject one;
    public GameObject two;
    public Text AreYouHigh;
    public GameObject iHaveAnAnouncement;
    public GameObject obama;
    public GameObject hobie;
    public GameObject miles;
    public GameObject getOutaEre;
    public GameObject hate;

    private bool youIdiot = false;
    private bool punk = false;
    private bool hip = false;
    private bool tsundere = false;
    private int booty;
    private int HiHowAreYou;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
        HiHowAreYou = 0;
        iHaveAnAnouncement.SetActive(false);
        hobie.SetActive(false);
        miles.SetActive(false);
        hate.SetActive(false);
    }

    public void Play()
    {
        booty = 0;
        bootyText.text = booty.ToString();


        lettuce.SetActive(false);
        skillIssueUI.SetActive(false);
        one.SetActive(false);
        two.SetActive(false);
        obama.SetActive(false);
        getOutaEre.SetActive(false);

        Time.timeScale = 1f;
        birbthins.enabled = true;

        foreach (Bongs obstacle in Bongs.allObstacles.ToArray())
        {
            Destroy(obstacle.gameObject);
        }


    }

    public void Pause()
    {
        Time.timeScale = 0;
        birbthins.enabled = false;
    }

    public void MoreBooty()
    {
        booty++;
        bootyText.text = booty.ToString();

    }

    public void SkillIssue()
    {
        skillIssueUI.SetActive(true);
        lettuce.SetActive(true);
        one.SetActive(true);
        two.SetActive(true);
        obama.SetActive(true);
        getOutaEre.SetActive(true);
        if (booty > HiHowAreYou)
        {
            HiHowAreYou = booty;
            //HiHowAreYou = hig score
        }
        AreYouHigh.text = "High score: " + HiHowAreYou.ToString();
        Pause();
    }

    public void ShadowTheHeadgehogIsABitchAssMotherFucker()
    {
        youIdiot = !youIdiot;

        if (youIdiot == true)
        {
            lettuce.SetActive(false);
            skillIssueUI.SetActive(false);
            one.SetActive(false);
            two.SetActive(false);

            iHaveAnAnouncement.SetActive(true);
        } else if (youIdiot == false)
        {
            lettuce.SetActive(true);
            skillIssueUI.SetActive(true);
            one.SetActive(true);
            two.SetActive(true);

            iHaveAnAnouncement.SetActive(false);
        }
    }

    public void IWasAlwaysThisCool()
    {
        punk = !punk;

        if (punk == true)
        {
            hobie.SetActive(true);
        } else if (!punk)
        {
            hobie.SetActive(false);
        }
    }

    public void WhatsUpDanger()
    {
        hip = !hip;

        if (hip == true)
        {
            miles.SetActive(true);
        } else if (!hip)
        {
            miles.SetActive(false);
        }
    }

    public void IAmNot()
    {
        tsundere = !tsundere;
        if (tsundere == true)
        {
            hate.SetActive(true);
        } else
        {
            hate.SetActive(false);
        }
    }

    public void QuitIt()
    {
        Application.Quit();
        Debug.Log("Gone");
    }
}
