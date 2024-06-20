using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void OnInteract();
}

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;

    private void OnMouseEnter()
    {
        OnInteract();
        Debug.Log("마우스가 오브젝트 위에있음");
    }

    public void OnInteract()
    {
        CharacterManager_KYJ.Instance.Player.itemData = data;
        CharacterManager_KYJ.Instance.Player.addItem?.Invoke();
        Destroy(gameObject);
    }
}
