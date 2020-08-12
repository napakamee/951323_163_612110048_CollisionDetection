using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectLauncherUP2 : MonoBehaviour, IHasOriginalColour
{
    [SerializeField]
    protected GameObject _gameObjectToBeLaunched;
    
    [SerializeField]
    protected Transform _launchPosition;

    [SerializeField]
    protected float _forceMagnitude;
    [SerializeField]
    [Tooltip("Object life time in seconds")]
    protected float _objectLifeTime;

    [SerializeField]
    [Tooltip("Interval in seconds")]
    protected float _launchInterval = 1.0f;

    [SerializeField]
    private bool _activate = false;
    public bool Activate{
        get{
            return _activate;
        }
        set{
            _activate = value;
        }
    }

    Color _originalColour;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LaunchTheObject", _launchInterval);
        _originalColour = this.GetComponent <MeshRenderer >().materials[0].color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void LaunchTheObject(){
        Invoke("LaunchTheObject", _launchInterval);
        if (!_activate) return;

        GameObject go = Instantiate(_gameObjectToBeLaunched);
        go.SetActive(true);
        go.transform.position = _launchPosition.position;
        Rigidbody rb = go.AddComponent <Rigidbody >();
        rb.useGravity = false;

        rb.AddForce(_launchPosition.up.normalized*_forceMagnitude ,ForceMode.Impulse);
        Destroy(go, _objectLifeTime);
    }
    public Color GetOriginalColour(){
        return this._originalColour;
    }
    private void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            _activate = true;
            this.GetComponent <MeshRenderer>().materials[0].color = Color.black;
        }
        
    }
    private void OnTriggerExit(Collider other){
        if (other.tag == "Player"){
            _activate = false;
            this.GetComponent <MeshRenderer>().materials[0].color = _originalColour;
        }
        
    }

    private void OnTriggerStay(Collider other){
        if (other.tag == "Player"){
            this.GetComponent <MeshRenderer>().materials[0].color = Color.blue;
        }
        
    }
}
