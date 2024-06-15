using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CutScenes : MonoBehaviour
{
    public UnityEngine.UI.Image cutScenesImage;
    public Sprite[] cutScenesSprites;
    public int currentIndex = 0;
    private bool isShowCutScenes = false;
    [SerializeField] Animator anim;
    private CanvasGroup canvasG;
    public AudioSource aus;
    public AudioClip[] effectSound;
    private int currentSoundIndex = 0;

    public Player pl;
        // Start is called before the first frame update
    void Start()
    {
        
        SpriteRenderer spritesR =  GetComponent<SpriteRenderer>();
        canvasG = cutScenesImage.GetComponent<CanvasGroup>();
        pl = FindObjectOfType<Player>();
        if(canvasG == null)
        {
            canvasG = cutScenesImage.gameObject.AddComponent<CanvasGroup>();
        }
        HideImage();
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void PlayCutScenes()
    {
        if (!isShowCutScenes)
        {
            StartCoroutine(ShowCutScenes());
        }
    }
    IEnumerator ShowCutScenes()
    {
        if(aus && effectSound[currentSoundIndex])
        {
            if (cutScenesImage == null)
            {
                yield break;
            }
            isShowCutScenes = true;
            if (currentIndex >= 0 && currentIndex < cutScenesSprites.Length)
            {
                pl.canMove = false;
                
                ShowImage();
                cutScenesImage.sprite = cutScenesSprites[currentIndex];
                aus.PlayOneShot(effectSound[currentSoundIndex]);
                yield return new WaitForSeconds(2f);
                HideImage();
                currentIndex++;
                currentSoundIndex++;
            }
            else
            {
                yield break;
            }
            pl.canMove = true;
            isShowCutScenes = false;
        }
    }
    public void ShowImage()
    {
        cutScenesImage.canvasRenderer.SetAlpha(1);// dat alpha = 1 de hien thi (alpha la do trong suot)
        canvasG.interactable = true; //kich hoat tuong tac
        canvasG.blocksRaycasts = true; //cho phep raycast
    }
    public void HideImage()
    {
        cutScenesImage.canvasRenderer.SetAlpha(0);
        canvasG.interactable = false;
        canvasG.blocksRaycasts = false;
    }

}
