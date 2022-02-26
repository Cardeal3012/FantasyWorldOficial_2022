using UnityEngine;

public class PlayerMovimentacao : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float jumpForce;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }


    public void FixedUpdate()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");
        float yMov = Input.GetAxisRaw("Jump");

        Vector3 playerMoviment = new Vector3(xMov, 0f, zMov).normalized * velocity * Time.deltaTime;

        transform.Translate(playerMoviment, Space.Self);

        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }

}