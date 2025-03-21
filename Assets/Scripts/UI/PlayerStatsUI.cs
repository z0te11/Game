using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private Text _textHp;
    [SerializeField] private Text _textDamage;
    [SerializeField] private Text _textSpeed;
    [SerializeField] private Text _textLevel;
    private PlayerHealth _playerHealth;
    private ShootAbility _playerShoot;
    private Movement _playerMove;
    private ExperiancePlayer _playerExp;

    private void OnEnable()
    {
        SpawnSystem.onPlayerSpawn += SubEventPlayer;
    }

    private void OnDisable()
    {
        if (_playerHealth != null) _playerHealth.onPlayerHealthChanged -= ShowHpPlayer;
        if (_playerShoot != null) _playerShoot.onPlayerDamageChanged -= ShowDamagePlayer;
        if (_playerMove != null) _playerMove.onPlayerSpeedChanged -= ShowSpeedPlayer;
        if (_playerExp != null) _playerExp.onPlayerLevelChanged -= ShowLevelPlayer;
        SpawnSystem.onPlayerSpawn -= SubEventPlayer;
    }

    private void SubEventPlayer()
    {
        var playerObj = GameManager.instance.currentPlayer;
        if (playerObj.TryGetComponent<PlayerHealth>(out PlayerHealth health))
        {
            _playerHealth = health;
            _playerHealth.onPlayerHealthChanged += ShowHpPlayer;
            ShowHpPlayer(_playerHealth.Healths);
        }
        if (playerObj.TryGetComponent<ShootAbility>(out ShootAbility shoot))
        {
            _playerShoot = shoot;
            _playerShoot.onPlayerDamageChanged += ShowDamagePlayer;
            ShowDamagePlayer(_playerShoot.Damage);
        } 
        if (playerObj.TryGetComponent<Movement>(out Movement move))
        {
            _playerMove = move;
            _playerMove.onPlayerSpeedChanged += ShowSpeedPlayer;
            ShowSpeedPlayer(_playerMove.Speed);
        }
        if (playerObj.TryGetComponent<ExperiancePlayer>(out ExperiancePlayer exp))
        {
            _playerExp = exp;
            _playerExp.onPlayerLevelChanged += ShowLevelPlayer;
            ShowLevelPlayer(_playerExp.Level);
        }  
    }

    private void ShowHpPlayer(float value)
    {
        _textHp.text = "Hp " + value.ToString();
    }

    private void ShowSpeedPlayer(float value)
    {
        _textSpeed.text = "Speed " + value.ToString();
    }
    private void ShowDamagePlayer(float value)
    {
        _textDamage.text = "Damage " + value.ToString();
    }

    private void ShowLevelPlayer(int value)
    {
        _textLevel.text = "Level " + value.ToString();
    }
}
