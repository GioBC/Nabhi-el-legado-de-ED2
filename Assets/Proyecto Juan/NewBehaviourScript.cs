using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
namespace MoreMountains.CorgiEngine
{ 

public class NewBehaviourScript : MonoBehaviour, MMEventListener<CorgiEngineEvent>
{
        protected Transform _target;


        protected virtual void Initialization()
    {
        




    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Tranquilidad")
        {
            //this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            //GetComponentInParent<CircleCollider2D>().enabled = false;
            GetComponentInParent<DamageOnTouch>().enabled = false;
            GetComponentInParent<Stimpack>().enabled = true;
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            GetComponent<Renderer>().material.color = Color.blue;
            }
        
    }

    public virtual void OnMMEvent(CorgiEngineEvent corgiEngineEvent)
    {
        switch (corgiEngineEvent.EventType)
        {
            case CorgiEngineEventTypes.LevelStart:
                Initialization();
                break;
        }
    }

    /// <summary>
    /// On enable, we start listening to events
    /// </summary>
    protected virtual void OnEnable()
    {
        this.MMEventStartListening<CorgiEngineEvent>();
    }

    /// <summary>
    /// On disable, we stop listening to events
    /// </summary>
    protected virtual void OnDisable()
    {
        this.MMEventStopListening<CorgiEngineEvent>();
    }

}
}
