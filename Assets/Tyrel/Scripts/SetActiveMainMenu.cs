using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveMainMenu : MonoBehaviour
{
    public GameObject Mainmenu;
    public GameObject OptionMenu;
    public GameObject Startmenu;

    private void Start()
    {
        Mainmenu.SetActive(true);
        OptionMenu.SetActive(false);
        Startmenu.SetActive(false);
    }
}
