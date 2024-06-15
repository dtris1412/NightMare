using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Purchasing;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool canMove = true;
    public Animator anim;
    Rigidbody2D m_rb;
    private float speed = 4f;
    public float OffsetY { get; private set; } = 0.3f;
    public Transform playerTransform;
    public float playerRadius;

    bool isLightTurnOn = false;
    public GameObject Light;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform Check;
    [SerializeField] private LayerMask questLayer;
    [SerializeField] private LayerMask houseLayer;
    [SerializeField] private LayerMask lightBottonLayer;
    [SerializeField] private LayerMask flashLightLayer;

    UIManager m_ui;
    GameController m_gc;
    public GameObject player;
    public GameObject flashLight;
    bool isTookFL;
    public bool canUseFL = false;
    public float coolDown = 5f;
    LightController m_lc;
    MNGameController mn_gc;
    Laptop lap;
    Paper paper;
    MapManager m_map;
    FlashLight fl;
    
    void Start()
    {
        fl = FindObjectOfType<FlashLight>();
        anim = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody2D>();
        m_ui = FindObjectOfType<UIManager>();
        m_gc = FindObjectOfType<GameController>();
        m_lc = FindObjectOfType<LightController>();
        mn_gc = FindObjectOfType<MNGameController>();
        lap = FindObjectOfType<Laptop>();
        m_map = FindObjectOfType<MapManager>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        paper = FindObjectOfType<Paper>();
    }
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.E) && canUseFL == true )
        {
            UseFlashLight();
            
        }
        if(canMove)
        {
            Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);
            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
            anim.SetFloat("Magnitude", movement.magnitude);
            transform.position = transform.position + movement * speed * Time.deltaTime;
        }
/*
        if (CheckQuest() == true)
        {
            
            m_ui.ShowDots(true);
        }*/
 /*       else
        {
            m_ui.ShowDots(false);
        }*/
    }
    public void Awake()
    {
        SetPositionAndSnapToTile(transform.position);
    }

    public bool CheckQuest()
    {
        Vector2 checkPosition = playerTransform.position;
        float checkRadius = playerRadius;
        return Physics2D.OverlapCircle(checkPosition, checkRadius, questLayer);
        
    }
    public bool IsLightBotton()
    {
        return Physics2D.OverlapCircle(Check.position, 0.5f, lightBottonLayer);
    }
    public bool IsFlashLight()
    {
        return Physics2D.OverlapCircle(Check.position, 0.5f, flashLightLayer);
    }
    
    public void SetPositionAndSnapToTile(Vector2 pos)
    {
        
        pos.x = Mathf.Floor(pos.x) + 0.5f;
        pos.y = Mathf.Floor(pos.y) + 0.5f + OffsetY;
        transform.position = pos;
    }

    public void UseFlashLight()
    {
        if (isLightTurnOn == false)
        {
            Light.SetActive(true);
            isLightTurnOn = true;
            StartCoroutine(TurnOffFlashLight(6f));
            StartCoroutine(CoolDown(10f));
        }
        else
        {
            Debug.Log("Den da tat");
        }
    }
    IEnumerator TurnOffFlashLight(float value)
    {
        yield return new WaitForSeconds(value);
        Light.SetActive(false);
        isLightTurnOn = false;
        coolDown = 5f;
    }
    IEnumerator CoolDown(float value)
    {
        canUseFL = false;
        yield return new WaitForSeconds(value);
        canUseFL = true;
    }
    public void TakeFlashLight()
    {
        flashLight.SetActive(false);
        Destroy(fl);
        isTookFL = true;
        canUseFL = true;
        Debug.Log("Code takeflashlight is running");
    }
}
