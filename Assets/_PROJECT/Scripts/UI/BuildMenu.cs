using System;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    [SerializeField] private GameObject buildMenu;
    private bool playerInTrigger = false;
    public void OnTriggerEnter( Collider other)
    {
        if( other.CompareTag("Player"))
        {
            buildMenu.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if( other.CompareTag("Player"))
        {
            buildMenu.SetActive(false);
        }
    }

    private void Update()
    {
        if (buildMenu.activeInHierarchy && !playerInTrigger)
        {
            buildMenu.SetActive(false);
        }
    }
}
