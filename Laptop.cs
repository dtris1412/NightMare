using Inventory.Model;
using Inventory.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Laptop : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite passive, active;
    public GameObject laptop;
    public GameObject freamLaptop;
    public GameObject desktop;

    public bool isTurnOn;
    public bool canUse;
    public bool showFream;
    public bool showDesktop;

    [SerializeField] private UIInventoryPage inventoryUI;
    [SerializeField] private InventorySO inventoryData;
    Player player;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<Player>();
        isTurnOn = false;
        showFream = false;
        showDesktop = false;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canUse == true)
        {
            TurnOnAndOffLapTop();
            TurnOnAndOffDesktop();
        }
    }
    public void TurnOnAndOffLapTop()
    {
        if(isTurnOn == false)
        {
            sr.sprite = active;
            isTurnOn = true;
        }
        else
        {
            sr.sprite = passive;
            isTurnOn = false;
        }
    }
    public void TurnOnAndOffDesktop()
    {

            if (inventoryUI.isActiveAndEnabled == false)
            {
                inventoryUI.Show();
                foreach (var item in inventoryData.GetcurrentInventoryState())
                {
                    inventoryUI.UpdateData(item.Key, item.Value.item.ItemImage, item.Value.quantity);
                }
            }
            else
            {
                inventoryUI.Hide();
            }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            
            if(showFream == false)
            {
                freamLaptop.SetActive(true);
                showFream = true;
            }

            canUse = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            
            if(showFream != false)
            {
                freamLaptop.SetActive(false);
                showFream = false;
            }
            canUse = false;

        }
    }
    public void CanShow(bool canShow)
    {

    }

}
