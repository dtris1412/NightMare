using Inventory.Model;
using Inventory.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;

public class Laptop : MonoBehaviour
{
    

    public GameObject DialougePoint3;
    SpriteRenderer sr;
    public Sprite passive, active;
    public GameObject laptop;
    public GameObject freamLaptop;
    public GameObject desktop;
    public GameObject FreamDesktopMNGame;
    public GameObject MNGame;
    public GameObject MNGameMenu;
    public GameObject CountDownToBegin;
    public bool MNGisTurnOn;
    private int count;
    public bool isTurnOn;
    public bool canUse;
    public bool showFream;
    public bool showDesktop;
    
    public bool isFream;
    //Desktop
    public GameObject DLoadingOb;
    /*[SerializeField] private UIInventoryPage inventoryUI;
    [SerializeField] private InventorySO inventoryData;*/
    Player player;
    MNGameController mn_gc;
    UIMiniGController uMC;
    Mirror mr;
    Downloading dl;
    EvenScript eventScript;
    public bool isDone = false;
    public GameObject laptopError;
    public bool isError = false;
    private void Start()
    {

        sr = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<Player>();
        mn_gc = FindObjectOfType<MNGameController>();
        uMC = FindObjectOfType<UIMiniGController>();
        mr = FindObjectOfType<Mirror>();
        dl = FindObjectOfType<Downloading>();
        eventScript = FindObjectOfType<EvenScript>();
        isTurnOn = false;
        showFream = false;
        showDesktop = false;
        MNGisTurnOn = false;
        isFream = false;
        count = 1;
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canUse == true && /*count == 1*/ isDone == false && isError == false)
        {
            TurnOnFreamDesktopMNGame();
            TurnOnMNGameMenu();
            player.canMove = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && canUse == true && count >= 2  && isDone == true)
        {
            if(count >= 3)
            {
                dl.openBotton.SetActive(true);
            }
            TurnOnDesktop();
            player.canMove = false;

        }
        if (Input.GetKeyDown(KeyCode.E) && canUse == true && isError == true)
        {
            ShowlaptopError();
        }

    }

    public bool TurnOnDesktop()
    {
        DLoadingOb.SetActive(true);
        return true;
    }
    
    public void TurnOffDesktop()
    {
        DLoadingOb.SetActive(false);
        player.canMove = true;
        
    }
    public void TurnOnMNGameMenu()
    {
        if(MNGameMenu)
        {
            MNGameMenu.SetActive(true);
        }
    }
    public void TurnOffMNGameMenu()
    {
        if (MNGameMenu)
        {
            MNGameMenu.SetActive(false);
        }
    }
    public void TurnOnCountDown()
    {
        if(CountDownToBegin)
        {
            CountDownToBegin.SetActive(true);
        }
    }
    public void TurnOffCountDown()
    {
        if (CountDownToBegin)
        {
            CountDownToBegin.SetActive(false);
        }
    }

    public void TurnOnMNGAME()
    {
        MNGame.SetActive(true);
    }
    public void PlayAgain()
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
       
    }
    public void TurnOffFreamDesktopMNGame()
    {
        FreamDesktopMNGame.SetActive(false);
    }
    public void StartButton()
    {
        TurnOffMNGameMenu();
        TurnOnCountDown();
        isFream = true;
    }

    public void ShowlaptopError()
    {
        StartCoroutine(LaptopError());
    }
    IEnumerator LaptopError()
    {
        laptopError.SetActive(true);
        yield return new WaitForSeconds(2f);
        laptopError.SetActive(false);
    }
    public void QuitButton()
    {
        TurnOffFreamDesktopMNGame();
        TurnOffMNGameMenu();
        TurnOffMNGAME();
        uMC.ShowGameLose(false);
        uMC.ShowGameWin(false);
        player.canMove = true;
    }
    public void DoneButton()
    {
        TurnOffFreamDesktopMNGame();
        TurnOffMNGameMenu();
        TurnOffMNGAME();
        uMC.ShowGameLose(false);
        uMC.ShowGameWin(false);
        player.canMove = true;
        mn_gc.IsDoneMNGame = true;
        count = 2;
        isDone = true;
        DialougePoint3.SetActive(true);
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
