using UnityEngine;
using System.Collections;

public class ConditionTransition : Transition
{

    public bool IsCondition;
    /// Событие "включения".
    /// Запускает таймер и обнуляет свойство NeedTransit.
    void OnEnable()
    {
        NeedTransit = false;
        StartCoroutine(nameof(Condition));
    }

    /// Таймер, реализованный при помощи корутины.
    /// По истечении времени устанавливает свойство NeedTransit в true.
    IEnumerator Condition()
    {
        yield return new WaitUntil(IsInConditional);
        NeedTransit = true;
    }

    private bool IsInConditional()
    {
        return IsCondition;
    }

    /// Событие "выключения".
    /// Останавливает таймер.
    void OnDisable()
    {
        StopCoroutine(nameof(Condition));
        IsCondition = false;
    }
}