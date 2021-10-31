using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float _maxHP;
    [SerializeField] private GameObject[] _drop;
    [SerializeField] private float _score;
    [SerializeField] private int _minDmg;
    [SerializeField] private int _maxDmg;
    [SerializeField] private float _attackCoolDown;
    [SerializeField] private int _dropSum;
    [SerializeField] private GameObject _enemy;

    [SerializeField] private GameObject _agroZone;
    private Vector2 _agroZonePos;
    [SerializeField] private GameObject _notFollowZone;

    private bool _dmgForPlayer;
    [HideInInspector] public float _HP;

    private GameObject _player;
    private Collider2D _playerColl;
    private Vector2 _playerPos;
    private bool _follow;

    private float _scaleX;
    
    private NavMeshAgent _agent;
    
    private Vector2 _itemPos;
    private Vector2 _startPos;
    private GameObject _greenZone;

    private float _lateAttack;
    private float _lateDmg;
    private void Start()
    {
        _maxHP = _maxHP * (0.5f + 0.7f * Dungeon.DungeonLvl) + PlayerData.WeaponUpLvl * 20;
        _minDmg += _minDmg * Dungeon.DungeonLvl / 4;
        _maxDmg += _maxDmg * Dungeon.DungeonLvl / 4;
        _agroZonePos = _agroZone.transform.position;
        _HP = _maxHP;
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerColl = _player.GetComponent<Collider2D>();
        _scaleX = 4;
        _startPos = gameObject.transform.position;

        _agent = _enemy.GetComponent<NavMeshAgent>();
        _follow = true;
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _greenZone = GameObject.FindGameObjectWithTag("GreenZone");
        _lateDmg = 0;
    }

    private void Update()
    {
        _agroZone.transform.position = _agroZonePos;
        _notFollowZone.transform.position = _agroZonePos;
        _playerPos = new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z);
        _itemPos = new Vector2(transform.position.x + Random.Range(-1, 1), transform.position.y + Random.Range(-1, 1));
        if (_agroZone.GetComponent<Collider2D>().IsTouching(_playerColl))
        {
            StartCoroutine(AgroEnemy());
        }

        else if(_greenZone.GetComponent<Collider2D>().IsTouching(_playerColl) || _notFollowZone.GetComponent<Collider2D>().IsTouching(_playerColl))
        {
            StopCoroutine(AgroEnemy());
            StartCoroutine(GoEnemyStartPos());
        }
        

        if ( _HP <= 0)
        {
            Destroy(_enemy.gameObject);

            for (int i = 0; i < _dropSum; i++)
            {
                _itemPos = new Vector2(transform.position.x + Random.Range(-1, 1), transform.position.y + Random.Range(-1, 1));
                Instantiate(_drop[Random.Range(0, _drop.Length)], _itemPos, Quaternion.identity);
                PlayerData.Score += _score * Dungeon.DungeonLvl;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("PlayerWeapon"))
        {
            _lateAttack = Time.time - _attackCoolDown / 1.1f;
            StartCoroutine(DMGforPlayer());
            _dmgForPlayer = true;
        }

        if (collision.tag.Equals("Player"))
        {
            _follow = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("PlayerWeapon"))
        {
            float _deltaTime = Time.time - _lateDmg;
            if(_deltaTime > (1 / PlayerData.AttakInSecond) && Input.GetKey(KeyCode.Space))
            {
                _HP -= Random.Range((PlayerData.MinDmg + PlayerData.DmgUp * PlayerData.WeaponUpLvl), (PlayerData.MaxDmg + PlayerData.DmgUp * PlayerData.WeaponUpLvl));
                _lateDmg = Time.time;
            }
            else
            {
                _HP -= 0;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("PlayerWeapon"))
        {
            _dmgForPlayer = false;
        }

        if (collision.tag.Equals("Player"))
        {
            StopCoroutine(DMGforPlayer());
            _dmgForPlayer = false;
            _follow = true;
        }
    }

    IEnumerator DMGforPlayer()
    {
        for (int i = 0; i < 255; i++)
        {
            float _deltaTime = Time.time - _lateAttack;
            if (_dmgForPlayer == true && _deltaTime > _attackCoolDown)
            {
                PlayerData.HealthPoint -= Random.Range((_minDmg), (_maxDmg));
                _lateAttack = Time.time;
            }
            else
            {
                PlayerData.HealthPoint -= 0;
            }
            yield return new WaitForSeconds(1);
        }
    }

    public IEnumerator AgroEnemy()
    {
        if (_agroZone.GetComponent<Collider2D>().IsTouching(_playerColl) && _follow == true)
        {
            _agent.SetDestination(_playerPos);
            if (transform.position.x > _playerPos.x)
            {
                transform.localScale = new Vector3(-_scaleX, transform.localScale.y, 0);
            }
            else
            {
                transform.localScale = new Vector3(_scaleX, transform.localScale.y, 0);
            }
        }
        yield return new WaitForSeconds(1);
    }

    public IEnumerator GoEnemyStartPos()
    {
        _agent.SetDestination(_startPos);
        if (transform.position.x > _startPos.x)
        {
            transform.localScale = new Vector3(-_scaleX, transform.localScale.y, 0);
        }
        else
        {
            transform.localScale = new Vector3(_scaleX, transform.localScale.y, 0);
        }
        yield return new WaitForSeconds(1);
    }
}
