using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text;

public class ItemButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int buttonID;
    public Item thisItem;

    public Tooltips tooltip;
    public Vector2 position;

    private Item GetThisItem(){
        for (int i = 0; i < GameManager.instance.items.Count; i++)
        {
            if (buttonID == i)
            {
                thisItem = GameManager.instance.items[i];
            }

        }
        return thisItem;
    }
    public void CloseButton(){
        GameManager.instance.RemoveItem(GetThisItem());

        thisItem = GetThisItem();
        if(thisItem!=null){
            tooltip.ShowTooltip();
            //tooltip.UpdateTooltip(thisItem.itemDes);
            tooltip.UpdateTooltip(GetDetailText(thisItem));

            RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as RectTransform, Input.mousePosition, null, out position);
            tooltip.SetPosition(position);
        }
        else
        {
            tooltip.HideTooltip();  
            tooltip.UpdateTooltip("");
        }
    }

    public void OnPointerEnter(PointerEventData eventData){
        GetThisItem();
        if (thisItem != null)
        {
            Debug.Log("Enter" + thisItem.itemName + "SLOT"  );

            tooltip.ShowTooltip();
            //tooltip.UpdateTooltip(thisItem.itemDes);
            tooltip.UpdateTooltip(GetDetailText(thisItem));

            RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as RectTransform, Input.mousePosition, null, out position);
            tooltip.SetPosition(position);
        }


    }
    public void OnPointerExit(PointerEventData eventData){
        //if (thisItem != null)
        //{
            //Debug.Log("Exit" + thisItem.itemName + "SLOT" );

            tooltip.HideTooltip();  
            tooltip.UpdateTooltip("");
        //}

        
    }
    private string GetDetailText(Item _item){   
        if (_item == null)
        {
            return "";
        }
        else
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("<color=red><size=17><b>Item:</b></size></color> <color=orange><size=18>{0}</size></color>\n", _item.itemName);
            stringBuilder.AppendFormat("<size=17>Descrição:</size>  <size=18><color=grey>{0}</color></size>\n", _item.itemDes);
            return stringBuilder.ToString();
        }
    }
}
