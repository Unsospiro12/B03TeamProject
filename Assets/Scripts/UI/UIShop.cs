using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIShop : MonoBehaviour
{
    public ShopItemSlot[] slots;

    public Transform slotPanel;

    [Header("List Item")]
    public TextMeshProUGUI listItemName;
    public TextMeshProUGUI listItemGold;
    public TextMeshProUGUI listStatName;
    public TextMeshProUGUI listStatValue;
    public GameObject buyButton;
    public GameObject sellButton;
    public GameObject goldImage;

    ItemData listItem;
    int listItemIndex = 0;

    private void Start()
    {
        slots = new ShopItemSlot[slotPanel.childCount];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = slotPanel.GetChild(i).GetComponent<ShopItemSlot>();
            slots[i].index = i;
        }

        ClearShopListItemWindow();
    }

    private void FixedUpdate()
    {
        UpdateUI();
    }

    void ClearShopListItemWindow()
    {
        listItemName.text = string.Empty;
        listItemGold.text = string.Empty;
        listStatName.text = string.Empty;
        listStatValue.text = string.Empty;

        buyButton.SetActive(false);
        sellButton.SetActive(false);
        goldImage.SetActive(false);
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
            {
                slots[i].Set();
            }
        }
    }

    public void ShopListItem(int index)
    {
        if (slots[index].item == null) return;

        listItem = slots[index].item;
        listItemIndex = index;

        listItemName.text = listItem.displayName;
        listItemGold.text = listItem.buyPrice.ToString();

        listStatName.text = string.Empty;
        listStatValue.text = string.Empty;

        for (int i = 0; i < listItem.consumables.Length; i++)
        {
            listStatName.text += listItem.consumables[i].Type.ToString() + "\n";
            listStatValue.text += listItem.consumables[i].value.ToString() + "\n";
        }

        for (int i = 0; i < listItem.equipables.Length; i++)
        {
            listStatName.text += listItem.equipables[i].Type.ToString() + "\n";
            listStatValue.text += listItem.equipables[i].value.ToString() + "\n";
        }

        goldImage.SetActive(true);
        buyButton.SetActive(true);
        sellButton.SetActive(true);
    }
}
