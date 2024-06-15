using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] int sceneToLoad = -1;
    [SerializeField] Transform spawnPoint;
    [SerializeField] DestinationIndentifier destinationPortal;

    Player m_pl;
    ScenesManager sm;

    private void Start()
    {
        m_pl = FindObjectOfType<Player>();
        sm = FindObjectOfType<ScenesManager>();
    }
    public void OnPlayerTriggered(Player player)
    {

        this.m_pl = player;

        //StartCoroutine(SwitchScense());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            StartCoroutine(SwitchScense());
        }

    }
    IEnumerator SwitchScense()
    {
        sm.PlayEndScene();
        yield return new WaitForSeconds(1f);
        DontDestroyOnLoad(gameObject);
        yield return SceneManager.LoadSceneAsync(sceneToLoad);
        var destPortal = FindObjectsOfType<Portal>().First(x => x != this && x.destinationPortal == this.destinationPortal);
        m_pl.SetPositionAndSnapToTile(destPortal.spawnPoint.position);
        Destroy(gameObject);
    }

    public enum DestinationIndentifier { A, B, C, D, E }
    public Transform SpawnPoint => spawnPoint;




}
