using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseColDetection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
  
    public GameObject hintTab;
    [SerializeField] Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        hintTab.SetActive(true);
        

    }

    // Xử lý khi chuột rời khỏi đối tượng
    public void OnPointerExit(PointerEventData eventData)
    {
        hintTab.SetActive(false);
    }

}