using UnityEngine;

public class Birbthins : MonoBehaviour
{
    private Vector3 kidnapping;
    //* kidnapping as in OneDirection fanfics; kidnapping=direction
    public float melody = -9.8f;
    //* melody as in "What is this melody?" -Sigma Overwatch; melody=gravity
    public float techno = 5f;
    //* strength -> strength pot -> pvp -> 1.8 -> Technoblade
    private SpriteRenderer spirits;
    //* i thinks that's pretty understandable
    public Sprite[] theWittweGuys;
    //* again not that comlicated
    private int wittweGuysNumb;
    public float strokeFreakvency = 0.2f;
    public bool figureTSOut = false;

    private void Awake()
    {
        spirits = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(GhibliStudios), strokeFreakvency, strokeFreakvency);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            kidnapping = Vector3.up * techno;      
        }

        kidnapping.y += melody * Time.deltaTime;
        transform.position += kidnapping * Time.deltaTime;

        

        }
    
    private void GhibliStudios()
    {
        wittweGuysNumb++;
        if (wittweGuysNumb>=theWittweGuys.Length)
        {
            wittweGuysNumb = 0;
        }

        spirits.sprite = theWittweGuys[wittweGuysNumb];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("IAmTheDevilFromTheBible"))
        {
            Object.FindAnyObjectByType<GameManager>().SkillIssue();
        } else if (other.gameObject.CompareTag("Booty"))
        {
            Object.FindAnyObjectByType<GameManager>().MoreBooty();
        }
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        kidnapping = Vector3.zero;
    }

    public void RainOn()
    {
        //CancelInvoke();

        if (techno == 5f)
        {
            techno = 2.5f;
            Object.FindAnyObjectByType<GameManager>().IWasAlwaysThisCool();

        } else if (techno == 2.5f)
        {
            techno = 5f;
            Object.FindAnyObjectByType<GameManager>().IWasAlwaysThisCool();
        }
    }
}
