using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

    public float velocidadLateral = 9;
    public float velocidadVertical = 15;

    Rigidbody rb;

    public Transform Cannon1;
    public Transform Cannon2;
    public KeyCode espacio;
    public GameObject Bala;
    public int velocidad;
    public Vector3 direccion;
    GameObject Disparo;
    GameObject Disparo1;


    public float rotationY;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        Movimiento();
        Payum();
    }

    void Movimiento()
    {
      
       rb.velocity = Vector3.right * Input.GetAxisRaw("Horizontal") * velocidadLateral + Vector3.up * Input.GetAxisRaw("Vertical") * velocidadVertical;
      
        rotationY = transform.rotation.y;
        if (Input.GetButton("Horizontal"))
        {
            transform.Rotate(transform.rotation.x, -2 * Input.GetAxisRaw("Horizontal"), transform.rotation.z);

            transform.rotation = new Quaternion(transform.rotation.x, Mathf.Clamp(transform.rotation.y, -0.25f, 0.25f), transform.rotation.z, transform.rotation.w);
            
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, 0.2f);
        }
    }

    void Payum() //Disparo
    {
        if (Input.GetKeyDown(espacio)) //Disparo
        {
            Disparo = GameObject.Instantiate(Bala);
            Disparo1 = GameObject.Instantiate(Bala);


            Disparo.transform.position = Cannon1.transform.position;
            Disparo1.transform.position = Cannon2.transform.position;

            Rigidbody Disparo_rg = Disparo.GetComponent<Rigidbody>();
            Rigidbody Disparo1_rg = Disparo1.GetComponent<Rigidbody>();

            Disparo_rg.velocity = direccion.normalized * velocidad;
            Disparo1_rg.velocity = direccion.normalized * velocidad;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }

}
