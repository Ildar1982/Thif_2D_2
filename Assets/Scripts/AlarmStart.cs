using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class AlarmStart : MonoBehaviour
{
    [SerializeField] private GameObject _cameraDinamic;
    [SerializeField] private AudioSource _audioSourse;
    [SerializeField] private float _speedAudio;

    private Collider2D _collider2D;
    private bool _activAlarm = false;

    private void Start()
    {
        _audioSourse.volume = 0;
        _collider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thif>(out Thif thif))
        {
            _activAlarm = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thif>(out Thif thif))
        {
            thif.alarmMove = true;
            _activAlarm = false;
            _collider2D.enabled = false;
        }
    }

    private void Update()
    {
        if (_activAlarm == true)
        {
            _audioSourse.volume += _speedAudio * Time.deltaTime;
            _cameraDinamic.SetActive(true);
        }
        else
        {
            _cameraDinamic.SetActive(false);
            _audioSourse.volume -= _speedAudio * Time.deltaTime;
        }
    }
}
