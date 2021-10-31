using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float _speed;
    [SerializeField] private GameObject _weapon;
    private Animator _weaponAnimator;
    [SerializeField] private Animator _animator;
    private float scaleX;
    private float scaleY;
    private Rigidbody2D _rb;

    [SerializeField] private AudioSource _runSound;
    [SerializeField] private AudioSource _spawnSound;
    [SerializeField] private AudioSource _attackSoundLoop;
    [SerializeField] private AudioSource _attackSound;

    [SerializeField] private GameObject _loadingImage;

    [HideInInspector] public float _attackCoolDown;
    [HideInInspector] public float _lateAttack;
    private void Start()
    {
        _speed = PlayerData.AttakSpeed / 1.5f;
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
        _rb = GetComponent<Rigidbody2D>();

        _spawnSound.Play();

        _attackCoolDown = 1 / PlayerData.AttakInSecond;
        _lateAttack = 0;
    }

    private void FixedUpdate()
    {
        MovementLogic();

    }
    private void Update()
    {
        float _deltaTime = Time.time - _lateAttack;

        _weaponAnimator = _weapon.GetComponent<Animator>();

        if(_loadingImage.activeInHierarchy == false)
        {
            _runSound.volume = PlayerData.SoundVolume;
        }
        else
        {
            _runSound.volume = 0;
        }
        _spawnSound.volume = PlayerData.SoundVolume;
        _attackSound.volume = PlayerData.SoundVolume * 0.2f;
        _attackSoundLoop.volume = _attackSound.volume;

        float X = Input.GetAxisRaw("Horizontal");

        if (X > 0)
            transform.localScale = new Vector3(scaleX, scaleY, 1);
        else if (X < 0)
            transform.localScale = new Vector3(-scaleX, scaleY, 1);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            _animator.SetFloat("Speed", 1);
            _weapon.transform.localRotation = Quaternion.Euler(0, 0, 10);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            _animator.SetFloat("Speed", 0);
            _weapon.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.time - _lateAttack > _attackCoolDown)
            {
                _lateAttack = Time.time;
                _weaponAnimator.SetFloat("AnimSpeed", 1);
                _weapon.transform.localRotation = Quaternion.Euler(0, 0, -10);
                if (_attackSoundLoop.isPlaying != true)
                {
                    _attackSoundLoop.Play();
                }
            }
               
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_attackSound.isPlaying != true)
            {
                _attackSound.Play();
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _weaponAnimator.SetFloat("AnimSpeed", 0);
            _weapon.transform.localRotation = Quaternion.Euler(0, 0, 0);
            _attackSoundLoop.Stop();
        }

        if(Input.GetAxis("Horizontal") != 0 || (Input.GetAxis("Vertical") != 0))
        {
            if(_runSound.isPlaying != true)
            {
                _runSound.Play();
            }
        }
        else if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            _runSound.Stop();
        }

      
    }
    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        _rb.velocity = (movement * _speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Fog"))
        {
            Destroy(collision.gameObject);
        }
    }
}
