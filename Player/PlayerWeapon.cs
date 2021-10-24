using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private RuntimeAnimatorController[] _animatorControllers;

    private SpriteRenderer _weaponSprite;
    private Animator _weaponAnimatorController;

    private void Start()
    {
        _weaponSprite = gameObject.GetComponent<SpriteRenderer>();
        _weaponAnimatorController = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        _weaponSprite.sprite = _sprites[PlayerData.WeaponType];
        _weaponAnimatorController.runtimeAnimatorController = _animatorControllers[PlayerData.WeaponType];
    }
}
