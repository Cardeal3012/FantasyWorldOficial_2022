using UnityEngine;
using System.Collections;

public class CameraMovimentacao : MonoBehaviour
{
    [SerializeField] public bool CursorOn;

    [SerializeField] public Transform Player;
    [SerializeField] public GameObject Head;
    [SerializeField] public GameObject target2;
    [SerializeField] public GameObject target1;


    [Range(0.001f,2)]
    [SerializeField] public float rotationSpeed;

    [SerializeField] public float ajusteCamera;
    [SerializeField] public float distCamera;

    [SerializeField] public bool FPersonPlayer;



    float mouseX, mouseY;

    void Start()
    {
    
    }


    public void Update()
    {
        if(CursorOn == false)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            FPersonPlayer = !FPersonPlayer;
        }

        PPessoaCamera();
    }

    public void PPessoaCamera()
    {
        if(FPersonPlayer == true)
        {
            mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;

            mouseY = Mathf.Clamp(mouseY, -35, 60);
            transform.position = target2.transform.position - transform.forward * distCamera;


            target2.transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);

        }
        else
        {
            TPessoaCamera();
        }
    }

    public void TPessoaCamera()
    {

        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;

        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.position = target1.transform.position - transform.forward * distCamera;


        target1.transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
        Head.transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);

        if (Head.transform.rotation.x >= 33)
        {
            Head.transform.rotation = Quaternion.Euler(mouseY, 33, 0);
        }


        RaycastHit hit;

        if (Physics.Linecast(target1.transform.position, transform.position, out hit))
        {
            transform.position = hit.point + transform.forward * ajusteCamera;
        }
    }

}