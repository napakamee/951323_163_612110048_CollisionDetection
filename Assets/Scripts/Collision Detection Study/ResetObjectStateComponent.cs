using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResetObjectStateComponent : MonoBehaviour
{
    private Vector3 _originalPosition;

    [SerializeField]
    Button _resetButton;
    // Start is called before the first frame update
    void Start()
    {
        _resetButton.onClick.AddListener(
            delegate { OnButtonClickHandler(_resetButton); }
        );

        _originalPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnButtonClickHandler(Button button){
        this.transform.position = _originalPosition;
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        Rigidbody rb = this.GetComponent <Rigidbody >();
        if (rb != null){
            rb.velocity = new Vector3(0f, 0f, 0f);
            rb.angularVelocity = new Vector3(0f, 0f, 0f);
        }
    }
}
