using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Thif : MonoBehaviour
{
    [SerializeField] private float _speed;

    public bool alarmMove = false;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (alarmMove == false)
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
        else
        {
            _animator.SetTrigger("miror");
            transform.Translate(_speed * Time.deltaTime * -1 * 2, 0, 0);
        }
    }
}
