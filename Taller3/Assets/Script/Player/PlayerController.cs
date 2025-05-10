using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController conn;

    // Movimiento
    float speed = 5;
    float horizontal;
    float vertical;

    // Rotación
    Vector3 moveDirection;
    float rotationSpeed = 360;
    Quaternion toRotate;
    float magnitud;

    // Animación
    private Animator anim;

    // Salto
    float jumpSpeed = 10;
    float ySpeed;
    Vector3 vel;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        // Componente
        conn = GetComponent<CharacterController>();
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Toma el valor de Horizontal y Vertical de las entradas
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // Definir la dirección de movimiento
        moveDirection = new Vector3(horizontal, 0, vertical);
        moveDirection.Normalize();

        // Magnitud del movimiento
        magnitud = moveDirection.magnitude;
        magnitud = Mathf.Clamp01(magnitud);
        anim.SetFloat("Speed", magnitud);
        Debug.Log("Speed: " + magnitud);

        // Mover al jugador usando el CharacterController
        conn.SimpleMove(moveDirection * magnitud * speed);

        // Aplicar gravedad
        ySpeed += Physics.gravity.y * Time.deltaTime;

        // Movimiento vertical (gravedad + salto)
        vel = moveDirection * magnitud;
        vel.y = ySpeed;

        // Mover el jugador
        conn.Move(vel * Time.deltaTime);

        // Verificación si está en el suelo
        if (conn.isGrounded)
        {
            ySpeed = -0.5f;
            isGrounded = true;
            anim.SetBool("IsJumping", false);

            // Saltar si está en el suelo
            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
                isGrounded = false;
                anim.SetBool("IsJumping", true);
            }
        }

        // Rotar el jugador en la dirección del movimiento
        if (moveDirection != Vector3.zero)
        {
            toRotate = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);
        }
    }
}
