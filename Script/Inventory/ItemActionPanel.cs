using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    namespace Inventory.UI
    {
        public class ItemActionPanel : MonoBehaviour
        {
            [SerializeField] private GameObject bottonPrefab;

            public void AddBotton(string name, Action onClickAction)
            {
                GameObject button = Instantiate(bottonPrefab, transform);
                button.GetComponent<Button>().onClick.AddListener(() => onClickAction());
                button.GetComponentInChildren<TMPro.TMP_Text>().text = name;
            }
        
            public void Toggle(bool val)
            {
                if (val == true)
                    RemoveOldBottons();
                gameObject.SetActive(val);
            }
            public void RemoveOldBottons()
            {
                foreach(Transform transformChildObjects in transform)
                {
                    Destroy(transformChildObjects.gameObject);
                }
            }
        }
    }