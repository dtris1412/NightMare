using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{ 
    // Start is called before the first frame update
    public Animator anim;
    private float speed = 4f;

    public float OffsetY { get; private set; } = 0.3f;
    

    public Vector2 targetPosition1;
    public Vector2 targetPosition2;
    public Vector2 targetPosition3;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform Check;
    [SerializeField] private LayerMask npcLayer;
    [SerializeField] private LayerMask houseLayer;
    [SerializeField] private LayerMask lightBottonLayer;

    [SerializeField] public Health healthBar;
    public float currentHealth;
    public float maxHealth;
    public bool canMove = true;
    //public bool isInHouse;

    UIManager m_ui;
    GameController m_gc;
    GameObject player;
    
    LightController m_lc;
    MNGameController mn_gc;
    Laptop lap;
    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
        anim = GetComponent<Animator>();
        m_ui = FindObjectOfType<UIManager>();
        m_gc = FindObjectOfType<GameController>();
        m_lc = FindObjectOfType<LightController>();
        mn_gc = FindObjectOfType<MNGameController>();
        lap = FindObjectOfType<Laptop>();
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            player.transform.position = targetPosition1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);
            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
            anim.SetFloat("Magnitude", movement.magnitude);
            transform.position = transform.position + movement * speed * Time.deltaTime;
        }

        if(CheckDots() == true)
        {
            m_ui.ShowDots(true);
        }
        else
        {
            m_ui.ShowDots(false);
        }
       
    }
    public void Awake()
    {
        SetPositionAndSnapToTile(transform.position);
    }

    public bool CheckDots()
    {
        return Physics2D.OverlapCircle(Check.position, 1f, npcLayer);
    }
    public bool IsLightBotton()
    {
        return Physics2D.OverlapCircle(Check.position, 0.5f, lightBottonLayer);
    }
    public void SetPositionAndSnapToTile(Vector2 pos)
    {
        
        pos.x = Mathf.Floor(pos.x) + 0.5f;
        pos.y = Mathf.Floor(pos.y) + 0.5f + OffsetY;
        transform.position = pos;
    }
    public void AddHealth(float value)
    {
        
        currentHealth = Mathf.Clamp(currentHealth + value, 0f, maxHealth);
        if (currentHealth >= maxHealth)
            return;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }
    public void OnMouseDown()
    {
        currentHealth -= 2;
        if (currentHealth <= -1)
            return;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }



}
