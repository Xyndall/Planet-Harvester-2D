using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillerScript : MonoBehaviour
{
    public ResourceManager _resourceManager;
    public AudioSource _audioSource;


    void PlayAudio()
    {
        _audioSource.PlayOneShot(_audioSource.clip);
    }


    public void PlaceDrill(bool IsDrilling, int PlanetSize)
    {

        _resourceManager._drillsOwned++;
        _resourceManager.PlaceDrill(IsDrilling, PlanetSize);

        PlayAudio();


        Debug.Log("PlacedDrill");
    }


    public void DestroyDrill(int PlanetSize)
    {
        _resourceManager._drillsOwned--;
        _resourceManager._planetSize -= PlanetSize;
    }



}
