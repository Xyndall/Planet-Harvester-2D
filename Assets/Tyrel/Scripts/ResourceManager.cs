using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ResourceManager : MonoBehaviour
{

    public int _resources;
    public int _maxResourcesGained;

    bool _drilling;
    public int _drillsOwned;
    public int _planetSize;

    public float timerLimit = 1.0f;
    private float timer = 0.0f;

    public int _upgraded;
    public int _droppedAmount;

    public DroppedResourceAmount _resourceDrop;
    bool _isDamaged;

    void Start()
    {
        _upgraded = 0;
        _resources = 0;
        _drillsOwned = 0;
        _planetSize = 0;
    }



    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1.0f && _drilling)
        {

            GainResource(_drillsOwned);
            timer = 0.0f;
        }


        
    }

    void DropResources()
    {
        _droppedAmount = _resources / 10;
        DroppedResourceAmount droppedResource = Instantiate(_resourceDrop, transform.position, transform.rotation);
        droppedResource.GetComponent<DroppedResourceAmount>().amount = _droppedAmount;
        _resources -= droppedResource.amount;
    }

    void GainExtraResources()
    {
        _resources += _resourceDrop.amount;
    }

    void GainResource(int drillsOwned)
    {
        _resources += drillsOwned + _planetSize + _upgraded;
    }

    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(3);
        _isDamaged = false;
    }

    public void PlaceDrill(bool IsDrilling, int PlanetSize)
    {
        _drilling = IsDrilling;
        _planetSize += PlanetSize;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Resource" )
        {
            if(_isDamaged == false)
            {
                _resourceDrop = collision.gameObject.GetComponent<DroppedResourceAmount>();
                GainExtraResources();
                Destroy(collision.gameObject);
            }
            
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            DropResources();
            _isDamaged = true;
            ResetDamage();
        }
    }

}
