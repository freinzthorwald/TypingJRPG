using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TravelManager : MonoBehaviour
{
    [SerializeField]
    public TravelScriptableObject TestTravel;
    [SerializeField]
    public Text OutputBox;
    public static TravelManager instance { get; private set; }
    public Transform canvas;
    public GameObject TextPrefab;
    public GameObject QuestPrefab;
    public TravelScriptableObject Destination;
    public GameObject HealthBar;
    private TravelQuest Quest;
    private GameObject QuestObject;
    private bool isFinished = false;
    private float health; //This should go to the party eventually, but they currently don't exist.

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        PartyCaravan.CreateInstance(); //This doesn't belong here, likely belongs in a game manager. I also don't have one of those.
        StartQuest(TestTravel);
    }

    public void StartQuest(TravelScriptableObject travel)
    {
        QuestObject = Instantiate(QuestPrefab);
        if(!QuestObject.TryGetComponent(out Quest))
        {
            Debug.LogError("Could not find quest.");
            return;
        }
        Quest.Setup(travel, canvas);
    }

    public void FinishQuest()
    {
        isFinished = true;
        if(QuestObject.TryGetComponent(out Quest))
        {
            Quest.CleanUp();
        }
        Destroy(QuestObject);
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("EventSelection");
    }

    public void ModifyHealthBar(int value)
    {
        if(HealthBar.TryGetComponent(out Slider slider))
        {
            slider.value = value;
        }
    }

    public void Parse(string input)
    {
        /* Basically lazy null checking here. If we're done don't bother doing anything. */
        if(isFinished)
        {
            return;
        }
        string phrase = OutputBox.text;
        foreach (char c in input)
        {
            Quest.Parse(c);
            if (Quest.IsQuestComplete())
            {
                OutputBox.enabled = true;
                OutputBox.text = "Journey finished!";
                FinishQuest();
            }
            else if (PartyCaravan.Instance.IsDead())
            {
                OutputBox.enabled = true;
                OutputBox.text = "Journey failed :(";
                FinishQuest();
            }
        }
    }

    public void KeyPress(KeyCode keyCode)
    {
        Quest.KeyPress(keyCode);
    }
}