using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEventsComponent : MonoBehaviour, IHasOriginalColour
{
    // Start is called before the first frame update
    Color _originalColour;
    void Start()
    {
        _originalColour = this.GetComponent <MeshRenderer >().materials[0].color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Color GetOriginalColour(){
        return this._originalColour;
    }

    private void OnTriggerEnter(Collider collider){
        this.GetComponent <MeshRenderer >().materials[0].color = Color.yellow;
    }

    private void OnTriggerStay(Collider collider){

    }

    private void OnTriggerExit(Collider collider){
        this.GetComponent <MeshRenderer >().materials[0].color = _originalColour;
    }
}
