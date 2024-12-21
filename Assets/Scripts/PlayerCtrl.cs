using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    public float moveSpeed = 3f;
    public float spinSpeed = 90f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        float mx = Input.GetAxis("Mouse X");

        Vector3 moveDir = Vector3.forward * ver + Vector3.right * hor;
        transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * spinSpeed * mx * Time.deltaTime);
    }
}
