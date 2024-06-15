using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject player;
    public float posX;
    public float posY;

    public GameObject objectToPersist;

    [SerializeField] Animator transitionAnim;
    void Start()
    {
        if (objectToPersist != null)
        {
            DontDestroyOnLoad(objectToPersist);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    /*IEnumerator LoadScenes()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("Start");
    }
    public void loadScenes()
    {
        LoadScenes();
    }*/


}
