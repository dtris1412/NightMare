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
    public GameObject FreamDesktopMNGame;
    public GameObject MNGame;
    public bool MNGisTurnOn;
    private int count;
    public bool isTurnOn;
    public bool canUse;
    public bool showFream;
    public bool showDesktop;
    public bool isFream;
    [SerializeField] private UIInventoryPage inventoryUI;
    [SerializeField] private InventorySO inventoryData;
    Player player;
    MNGameController mn_gc;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<Player>();
        mn_gc = FindObjectOfType<MNGameController>();
        isTurnOn = false;
        showFream = false;
        showDesktop = false;
        MNGisTurnOn = false;
        isFream = false;
        count = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canUse == true && count == 1)
        {
            TurnOnFreamDesktopMNGame();
          
            player.canMove = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && canUse == true && count == 2)
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

            if (inventoryUI.gameObject.activeSelf == false)
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
    public void TurnOnMNGAME()
    {
        MNGame.SetActive(true);
    }
    public void TurnOffMNGAME()
    {
        MNGame.SetActive(false);
    }
    public void TurnOnFreamDesktopMNGame()
    {
        FreamDesktopMNGame.SetActive(true);
        isFream = true;
    }
    public void TurnOffFreamDesktopMNGame()
    {
        FreamDesktopMNGame.SetActive(false);
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


}
