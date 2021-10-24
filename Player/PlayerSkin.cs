using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private RuntimeAnimatorController[] _animatorControllers;

    private SpriteRenderer _skinSprite;
    private Animator _skinAnimatorController;

    private void Start()
    {
        _skinSprite = gameObject.GetComponent<SpriteRenderer>();
        _skinAnimatorController = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        _skinSprite.sprite = _sprites[PlayerData.PlayerSkin];
        _skinAnimatorController.runtimeAnimatorController = _animatorControllers[PlayerData.PlayerSkin];
    }
}
