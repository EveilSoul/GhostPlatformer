using UnityEngine;
using System.Collections;

/// Переход по таймеру.
public class TimerTransition : Transition
{
    /// Время в секундах.  Задается в Inspector'е.
    [SerializeField, Tooltip("Time in seconds.")]
    float time;

    /// Событие "включения".
    /// Запускает таймер и обнуляет свойство NeedTransit.
    void OnEnable()
    {
        NeedTransit = false;
        StartCoroutine("Timer");
    }

    /// Таймер, реализованный при помощи корутины.
    /// По истечении времени устанавливает свойство NeedTransit в true.
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        NeedTransit = true;
    }

    /// Событие "выключения".
    /// Останавливает таймер.
    void OnDisable()
    {
        StopCoroutine("Timer");
    }
}