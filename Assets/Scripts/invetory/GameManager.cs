using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;//MAKER SINGLETON
    public bool isPaused;

    public List<Item> items = new List<Item>();
    public List<int> itemNumbers = new List<int>();
    public GameObject[] slots;

    //public Dictionary<Item, int> itemDict = new Dictionary<Item, int>();

    public ItemButton thisButton;
    public ItemButton[] itemButtons;
    
    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        DisplayItem();
    }
/*     private void Update() {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddItem(addItem_01);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            RemoveItem(removeItem_01);
        }
    } */

    private void DisplayItem(){
        #region 
 /*       for(int i=0; i < items.Count;i++){
            //Slots Item Image
            slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

            //Slots Count
            slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
            slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();

            //UPDATE CLOSE
            slots[i].transform.GetChild(2).gameObject.SetActive(true);
        } */
        #endregion
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
            {
                //Slots Item Image
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

                //Slots Count
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();

                //UPDATE CLOSE
                //slots[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                //Slots Item Image
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;

                //Slots Count
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = null;

                //UPDATE CLOSE
                //slots[i].transform.GetChild(2).gameObject.SetActive(false); 
            }
        }
    }

    public void AddItem(Item _item){
        if(!items.Contains(_item)){
            items.Add(_item);
            itemNumbers.Add(1);
        }
        else
        {
            Debug.Log("Você ja possui esse Item!");
            for (int i = 0; i < items.Count; i++)
            {
                if (_item == items[i])
                {
                    itemNumbers[i]++;
                }
            }
        }
        DisplayItem();

    }
    
    public void RemoveItem(Item _item){
        if(items.Contains(_item)){
            for (int i = 0; i < items.Count; i++){
                if (_item==items[i])
                {
                    itemNumbers[i]--;
                    if (itemNumbers[i]==0)
                    {
                        items.Remove(_item);
                        itemNumbers.Remove(itemNumbers[i]);
                    }
                }
            }
        }
        else
        {
            Debug.Log("Esse Item" + _item + "não esta na mochila");
        }
        ResetButtonItems();
        DisplayItem();

    }

    public void ResetButtonItems(){
        for (int i = 0; i < itemButtons.Length; i++)
        {
            if (i < items.Count)
            {
                itemButtons[i].thisItem = items[i];
            }
            else
            {
                itemButtons[i].thisItem = null;
            }
        }
    }
}
