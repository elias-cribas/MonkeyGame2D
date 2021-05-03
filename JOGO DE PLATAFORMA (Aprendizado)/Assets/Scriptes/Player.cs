using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;

    public float Jumpforce;

    public bool isJumping;

    public bool doubleJump;

    private Rigidbody2D rig;
    
    private Animator animacao;
    // Start is called before the first frame update
    void Start()
    {
      rig = GetComponent<Rigidbody2D>();  
      animacao = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }
    void Move()
    {
    Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); // Pega um Vector3 com input X e Y Horizontal
    transform.position += movement * Time.deltaTime * Speed; 
    // transform.position vai somar  com o valor de movement do input Horizontal    

    if(Input.GetAxis("Horizontal") > 0f) // Movimento para esquerda 
    {
      animacao.SetBool("Walk", true); // Sprite "Walk" vai ser ativado

      transform.eulerAngles = new Vector3(0f,0f,0f); // Mantém / Volta a posição inicial do Player em 0°
    }
    if(Input.GetAxis("Horizontal") < 0f) // Movimento para direita
    {
      animacao.SetBool("Walk", true); // Sprite "Walk" vai ser ativado

      transform.eulerAngles = new Vector3(0f,180f,0f); // Vira o Player em um Movimento 180° para esquerda
    }
    if(Input.GetAxis("Horizontal") == 0f) // Idle
    {
      animacao.SetBool("Walk", false); // Sprite "Walk" vai ser desativado
    }
    
    }

void Jump()
{
    if (Input.GetButtonDown("Jump"))
     {
        if(!isJumping)
        {
          rig.AddForce(new Vector2(0f, Jumpforce), ForceMode2D.Impulse);
          doubleJump = true;
          animacao.SetBool("Jump", true);
        }
        else
        {
          if(doubleJump)
          {
            rig.AddForce(new Vector2(0f, Jumpforce), ForceMode2D.Impulse);
            doubleJump = false;
          }
        }   
     }
        
}
void OnCollisionEnter2D(Collision2D collision)
		{
			if(collision.gameObject.layer == 8)
			{
				isJumping = false;
        animacao.SetBool("Jump", false);
			}
		}
		void OnCollisionExit2D(Collision2D collision)
		{
			if(collision.gameObject.layer == 8)
			{
				isJumping = true;
			}
		}
}
