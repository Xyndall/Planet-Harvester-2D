using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveMainMenu : MonoBehaviour
{
    public GameObject Mainmenu;
    public GameObject OptionMenu;
    public GameObject ControlsMenu;
    public GameObject Startmenu;

    private void Start()
    {
        Mainmenu.SetActive(true);
        OptionMenu.SetActive(false);
        ControlsMenu.SetActive(false);
        Startmenu.SetActive(false);
    }
}
