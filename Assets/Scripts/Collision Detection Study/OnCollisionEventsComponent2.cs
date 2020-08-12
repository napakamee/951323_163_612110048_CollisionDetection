using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OnCollisionEventsComponent2 : MonoBehaviour, IHasOriginalColour
{
    Color _originalColour;


    [Header("Force Setting")]
    [SerializeField]
    [Tooltip("Constance force applying to an object.")]
    private Vector3 _force;
    public Vector3 Force{
        get{
            return _force;
        }
        set{
            _force = value;
        }
    }

    // Start is called before the first frame update
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

    private void OnCollisionEnter(Collision collision){
        this.GetComponent <MeshRenderer >().materials[0].color = Color.black;
        
    }

    private void OnCollisionStay(Collision collision){
        ApplyForce();
    }
    private void OnCollisionExit(Collision collision){
        this.GetComponent <MeshRenderer >().materials[0].color = _originalColour;
        
    }

    private void ApplyForce(){
        Rigidbody rb = this.GetComponent <Rigidbody >();
        rb.AddForce(_force, ForceMode.Impulse);
    }
    
}
