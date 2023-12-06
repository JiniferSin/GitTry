using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpStrength = 8f;
    [SerializeField] private float _jumpStrengthOnSlime = 12f;
    [SerializeField] private float upGravity = 1f, downGravity = 5f;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private LayerMask slimeLayer;

    
    [SerializeField] private Transform feet;
    [SerializeField] private Checkpoint checkpoint;
    
    public static Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private SoundPlayer _audioPlayer;
    PlayerLife _playerLife;
    private LayerMask voidLayer;
    private Collider2D _holeCollider;
    private bool isOnSlime = false;
    private Slimy slimyHorse = null;
    private float slimyHorseOffset = 0;

    private float horizontalMovement = 0;
    private bool jump = false, isGrounded = false;
    
    void Awake()
    {
        _playerLife = GetComponent<PlayerLife>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioPlayer = GetComponent<SoundPlayer>();
        voidLayer = LayerMask.NameToLayer("Void");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            horizontalMovement = -_speed;
            _spriteRenderer.flipX = true;
        }else if (Input.GetKey(KeyCode.D))
        {
            horizontalMovement = _speed;
            _spriteRenderer.flipX = false;
        }
        else
        {
            horizontalMovement = 0;
        }
        
        _animator.SetBool("Walk", (horizontalMovement != 0 && isGrounded));
        transform.position += new Vector3(horizontalMovement * Time.deltaTime, 0, 0);

        CheckGround();
        
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            isGrounded = false;
            _animator.SetBool("Jump", true);
            _audioPlayer.PlayAudio(SoundFX.Jump);
        }

        if (isOnSlime)
        {
            transform.position = new Vector3(slimyHorse.transform.position.x + slimyHorseOffset, transform.position.y, transform.position.z);
        }

    }

    private void FixedUpdate()
    {
        if (jump)
        {
            if (isOnSlime)
            {
                // If on slime, add a force with a modified strength or any special behavior.
                _rigidbody.AddForce(new Vector2(0, _jumpStrengthOnSlime), ForceMode2D.Impulse);
            }
            else
            {
                _rigidbody.AddForce(new Vector2(0, _jumpStrength), ForceMode2D.Impulse);

            }
            _rigidbody.gravityScale = upGravity;
            jump = false;
        }

        if (!isGrounded && _rigidbody.velocity.y < 0)
        {
            _rigidbody.gravityScale = downGravity;
        }

        if (PlayerLife._life <= 0)
        {
            Respawn();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.layer == groundLayers)
        {
            isGrounded = true;
            _animator.SetBool("Jump", false);
            _rigidbody.gravityScale = upGravity;
            if (collision.gameObject.CompareTag("Slime"))
            {

            }
        } 
        else if(collision.gameObject.layer == voidLayer)
        {
            
            collision.collider.isTrigger = true;
            GetComponent<PlayerLife>().Hurt(1);
            Invoke(nameof(Respawn), 1f);
            _holeCollider = collision.collider;
        }
        
    }

    

    public void Respawn()
    {
        
        transform.position = checkpoint.transform.position;
        Debug.Log("NO");
        PlayerLife._life = 5;
        _playerLife.UpdateUI();
        if(_holeCollider != null)
        {

            _holeCollider.isTrigger = false;
            _holeCollider = null;
        }
    }

    public void PlayWalkingSound()
    {
        _audioPlayer.PlayAudio(SoundFX.Walk);
    }
    
    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.2f, groundLayers);
        RaycastHit2D hitSlime = Physics2D.Raycast(feet.transform.position, Vector2.down, 0.1f, slimeLayer); // Adjust slimeLayer according to your slime layer.
        if (hit)
        {
            isGrounded = true;
            _animator.SetBool("Jump", false);
            _rigidbody.gravityScale = upGravity;

            if (!isOnSlime && hitSlime.collider != null)
            {
                isOnSlime = true;
                slimyHorse = hit.collider.GetComponent<Slimy>();
                slimyHorseOffset = transform.position.x - hit.transform.position.x;
                Debug.Log("Offset is " + slimyHorseOffset);
            }
        }
        else
        {
            isGrounded = false;
            _animator.SetBool("Jump", true);
            _rigidbody.gravityScale = downGravity;

            isOnSlime = false;
        }
    }

    public void ChangeCheckpoint(Checkpoint newCheckpoint)
    {
        if (checkpoint != newCheckpoint)
        {
            Destroy(checkpoint.gameObject);
        }
        checkpoint = newCheckpoint;
    }


}
