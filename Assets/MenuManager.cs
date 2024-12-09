using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject MenuPrincipal;
    public GameObject SousMenuSett;

    public void ShowSousMenuSett()
    {
        MenuPrincipal.SetActive(false);
        SousMenuSett.SetActive(true);
    }

    public void BackToMenuPrincipal()
    {
        MenuPrincipal.SetActive(true);
        SousMenuSett.SetActive(false);
    }
}
