using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightController : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite passive, active;
    public GameObject theLight;
    
    public bool isTurnOn;
    Player m_pl;
    public bool canUse;

    // Start is called before the first frame update
    void Start()
    {
        m_pl = FindObjectOfType<Player>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.E) && canUse == true && isTurnOn == true)
        {
            TurnOffTheLight();
            isTurnOn = false;
            Debug.Log("true");
        }
        else if(Input.GetKeyDown(KeyCode.E) && canUse == true && isTurnOn == false)
        {
            TurnOnTheLight();
            isTurnOn = true;
        }
        else
        {
            Debug.Log("False");
        }
    }
    public void SetGlobalLight( float value)
    {
        Light2D light = theLight.GetComponent<Light2D>();
        if(light != null)
        {
            light.intensity = value;
        }
        else
        {
            Debug.LogError("Không tìm thấy thành phần Light 2d trong đối tượng globalLight");
        }
    }
    public void TurnOffTheLight()
    {
        SetGlobalLight(0f);
    }
    public void TurnOnTheLight()
    {
        SetGlobalLight(0.5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            canUse= true;
            sr.sprite = active;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            canUse= false;
            sr.sprite = passive;
        }
    }
}
