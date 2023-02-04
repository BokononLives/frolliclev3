using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _textTimer;
    [SerializeField] private float _totalGameTime = 120f;
    [SerializeField] private float _waitTime = 3f;
    [SerializeField] private Animator _anim;
    private float _timer;
    private bool _isTimerOn = false;

    public static event Action OnTimeUp;

    private void Start()
    {
        _timer = _totalGameTime;
        StartCoroutine(StartTimer());
    }

    private void Update()
    {
        if (_isTimerOn)
        {
            _timer -= Time.deltaTime;
            DisplayTime();
            if (_timer <= 1)
            {
                _isTimerOn = false;
                OnTimeUp?.Invoke();
                StopTimer();
                ResetTimer();
                _anim.SetBool("TimeEnd", true);
            }
        }
    }

    private void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(_timer / 60.0f);
        int seconds = Mathf.FloorToInt(_timer - minutes * 60);
        _textTimer.text = string.Format("Time Left: " + "{0:00}:{1:00}", minutes, seconds);
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(_waitTime);
        _anim.enabled = true;
        _isTimerOn = true;
    }

    private void StopTimer()
    {
        _isTimerOn = false;
    }
    private void ResetTimer()
    {
        _timer = _totalGameTime;
    }
}
