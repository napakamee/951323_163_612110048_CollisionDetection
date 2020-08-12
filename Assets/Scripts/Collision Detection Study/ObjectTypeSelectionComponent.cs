using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectTypeSelectionComponent : MonoBehaviour
{
    private enum CollisionObjectType{
        StaticCollider=1,
        RigidbodyCollider=2,
        KinematicRigidbodyCollider=4,
        StaticTriggerCollider=8,
        RigidbodyTriggerCollider=16,
        KinematicRigidbodyTriggerCollider=32
    };

    [SerializeField]
    private CollisionObjectType _collisionObjectType = CollisionObjectType.StaticCollider;

    [SerializeField]
    Dropdown _dropDownMenu;
    // Start is called before the first frame update
    void Start()
    {
        _dropDownMenu.onValueChanged.AddListener(delegate { DropdownValueChangedHandler(_dropDownMenu); });

        if (_collisionObjectType == CollisionObjectType.StaticCollider)
            _dropDownMenu.value = 0;
        else if (_collisionObjectType == CollisionObjectType.RigidbodyCollider)
            _dropDownMenu.value = 1;
        else if (_collisionObjectType == CollisionObjectType.KinematicRigidbodyCollider)
            _dropDownMenu.value = 2;
        else if (_collisionObjectType == CollisionObjectType.StaticTriggerCollider)
            _dropDownMenu.value = 3;
        else if (_collisionObjectType == CollisionObjectType.RigidbodyTriggerCollider)
            _dropDownMenu.value = 4;
        else if (_collisionObjectType == CollisionObjectType.KinematicRigidbodyTriggerCollider)
            _dropDownMenu.value = 5;
        
        SelectCollisionObjectType();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SelectCollisionObjectType(){
        switch (_collisionObjectType){
            case CollisionObjectType.StaticCollider:{
                TurnOffTrigger();
                RemoveRigidbodies();
                this.name = "SC";
            }break;
            case CollisionObjectType.RigidbodyCollider:{
                TurnOffTrigger();
                Rigidbody rb = SetupRigidbody();
                rb.isKinematic = false;
                this.name = "RC";
            }break;
            case CollisionObjectType.KinematicRigidbodyCollider:{
                TurnOffTrigger();
                Rigidbody rb = SetupRigidbody();
                rb.isKinematic = true;
                this.name = "KRC";
            }break;
            case CollisionObjectType.StaticTriggerCollider:{
                RemoveRigidbodies();
                Collider collider = this.gameObject.GetComponent <Collider >();
                collider.isTrigger = true;
                this.name = "STC";
            }break;
            case CollisionObjectType.RigidbodyTriggerCollider:{
                Rigidbody rb = SetupRigidbody();
                rb.isKinematic = false;
                Collider collider = this.gameObject.GetComponent <Collider >();
                collider.isTrigger = true;
                this.name = "RTC";
            }break;
            case CollisionObjectType.KinematicRigidbodyTriggerCollider:{
                SetupRigidbody();
                Rigidbody rb = this.gameObject.GetComponent <Rigidbody >();
                rb.isKinematic = true;
                Collider collider = this.gameObject.GetComponent <Collider >();
                collider.isTrigger = true;
                this.name = "KRTC";
            }break;
        }

    }

    private void TurnOffTrigger(){
        Collider[] colliders = this.gameObject.GetComponents <Collider >();
        foreach (Collider c in colliders){
            c.isTrigger = false;
        }
    }

    private void RemoveRigidbodies(){
        Rigidbody[] rigidbodies = this.gameObject.GetComponents <Rigidbody >();
        if (rigidbodies.Length > 0){
            foreach (Rigidbody r in rigidbodies){
                Destroy(r);
            }
        }
    }

    Rigidbody SetupRigidbody(){
        Rigidbody rb = null;
        rb = this.gameObject.GetComponent <Rigidbody >();
        if (rb == null){
            rb = this.gameObject.AddComponent <Rigidbody >();
            if (rb != null){
                rb.useGravity = false;
            }
        }
        return rb;
    }

    void DropdownValueChangedHandler(Dropdown dropdown){
        if (dropdown.value == 0)
            _collisionObjectType = CollisionObjectType.StaticCollider;
        else if (dropdown.value == 1)
            _collisionObjectType = CollisionObjectType.RigidbodyCollider;
        else if (dropdown.value == 2)
            _collisionObjectType = CollisionObjectType.KinematicRigidbodyCollider;
        else if (dropdown.value == 3)
            _collisionObjectType = CollisionObjectType.StaticTriggerCollider;
        else if (dropdown.value == 4)
            _collisionObjectType = CollisionObjectType.RigidbodyTriggerCollider;
        else if (dropdown.value == 5)
            _collisionObjectType = CollisionObjectType.KinematicRigidbodyTriggerCollider;

        SelectCollisionObjectType();
    }
}
