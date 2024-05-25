using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventSelectionController : MonoBehaviour
{
    [SerializeField]
    private GameObject BackgroundPanel;
    // Start is called before the first frame update
    void Start()
    {
        PartyCaravan.Instance.IsDead();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FieldsSelected()
    {
        Image background = BackgroundPanel.GetComponent<Image>();
        background.color = new Color(0, 255, 0);
    }

    public void TownsSelected()
    {
        Image background = BackgroundPanel.GetComponent<Image>();
        background.color = new Color(0, 0, 255);
    }

    public void BattlesSelected()
    {
        Image background = BackgroundPanel.GetComponent<Image>();
        background.color = new Color(255, 0, 0);
    }
}
