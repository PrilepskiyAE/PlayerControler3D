using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float rotationSensitivity;

    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private Rigidbody rb;
   
    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    private float _xRotation;

    private bool _grounded;



    void Update()
    {
        _xRotation -= Input.GetAxis("Mouse Y") * rotationSensitivity;

        _xRotation = Mathf.Clamp(_xRotation, -60f, 60f);

        cameraTransform.localEulerAngles = new Vector3(_xRotation, 0f, 0f);

        transform.Rotate(0, Input.GetAxis("Mouse X") * rotationSensitivity, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_grounded)
            {
                rb.AddForce(0,jumpForce,0,ForceMode.Impulse);
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        Vector3 speedVector = inputVector * speed;

        Vector3 speedVectorRelativeToPlayer=transform.TransformVector(speedVector);

        rb.linearVelocity = new Vector3(speedVectorRelativeToPlayer.x, rb.linearVelocity.y,speedVectorRelativeToPlayer.z);
    }


    private void OnCollisionStay(Collision collision)
    {
         
        Vector3 normal = collision.contacts[0].normal;
        float dot = Vector3.Dot(normal, Vector3.up);
        if(dot > 0.5) _grounded=true;    
    }

    void OnCollisionExit(Collision collision)
    {
        _grounded=false;
    }

}
