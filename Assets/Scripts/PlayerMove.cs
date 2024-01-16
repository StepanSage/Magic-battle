using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10f;//скорость передвиженя 
    public float HeatherHero = 3;//здоровье 



    [Header("JumpSystem")]
    public Transform groundCheck; //позиция ног
    public LayerMask groundMask;//платформа.
    public int JumpForce = 10;//сила прыжка 
    public float chekRadius;//радиус у ног 
    private bool IsGround;//проверка столкновение с землей
    private Rigidbody2D rb;//туда переинести Rigidbody2D
    public float jumptime;// время прыжка
    private float _jumpTimeCounter;//Счетчик времени прыжка
    private bool _isjumping;//прыгает



    private Camera _camera;
    [SerializeField]Vector3 pos;

    


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _camera = FindObjectOfType<Camera>();
        
    }

    private void FixedUpdate()
    {
       
    }
    void Update()
    {
         MoveHero(speed);
        FlipHero();
        pos = _camera.WorldToScreenPoint(transform.position);
        _jumpHero();


    }
    private void LateUpdate()
    {
       
        
    }
    

    private void _jumpHero()
    {
        IsGround = Physics2D.OverlapCircle(groundCheck.position, chekRadius, groundMask);
        if (IsGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            _isjumping = true;//можно прыгнуть при удержании
            _jumpTimeCounter = jumptime;//присваивается время, чтобы во время прыжка его нельзя было изменить.
            rb.velocity = Vector2.up * JumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && _isjumping == true)
        {
            if (_jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * JumpForce;
                _jumpTimeCounter -= Time.deltaTime;//отнимаем время прыжка
            }
            else
            {
                _isjumping = false;//когда время ставновиться меньше 0, персонаж падает
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isjumping = false;//при отпускании клавишы персонаж падает
        }
    }
    public void MoveHero(float Speed)
    {
        transform.position += new Vector3(Speed, 0, 0) * Time.deltaTime * Input.GetAxisRaw("Horizontal");
    }
    private void FlipHero()
    {
        //if (Input.GetAxisRaw("Horizontal") < 0)
        //{
        //    GetComponent<SpriteRenderer>().flipX = true;
        //}
        //else if (Input.GetAxisRaw("Horizontal") > 0)
        //{
        //    GetComponent<SpriteRenderer>().flipX = false;
        //}

        if(Input.mousePosition.x < pos.x )
        {
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.mousePosition.x > pos.x)
        {
            //    transform.localRotation = Quaternion.Euler(0, 0, 0);
            GetComponent<SpriteRenderer>().flipX = false;
        }



    }
    public void TakeDamagHero(float damag)
    {
        HeatherHero -= damag;
        if (HeatherHero <= 0)
        {
            SceneManager.LoadScene(0);
        }
        
        
    }

}
