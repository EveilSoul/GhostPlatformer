using UnityEngine;
using System.Collections.Generic;

/// Базовый класс для состояний.
/// Наследуемые компоненты должны быть выключены (disabled) в Inspector'е.
public abstract class State : MonoBehaviour
{
    /// Список исходящих переходов.
    /// Задается в Inspector'е.
    [SerializeField, Tooltip("List of transitions from this state.")]
    List<Transition> transitions = new List<Transition>();

    /// Возвращает следующее состояние, если должен быть
    /// совершен переход, иначе возвращает null.
    /// Вызывается из StateMachine.
    public virtual State GetNext()
    {
        foreach (var transition in transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }

    /// Выключает состояние и переходы из него.
    /// Будет вызван OnDisable, если его реализовать в потомке.
    public virtual void Exit()
    {
        if (enabled)
        {
            foreach (var transition in transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }

    /// Включает состояние и переходы из него.
    /// Будет вызван OnEnable, если его реализовать в потомке.
    public virtual void Enter()
    {
        if (!enabled)
        {
            enabled = true;
            foreach (var transition in transitions)
            {
                transition.enabled = true;
            }
        }
    }

    /// Этот метод реализован для того, чтобы в Inspector'е всегда
    /// отображался чекбокс enabled/disabled для состояний.
    /// В потомке его придется переопределять при необходимости.
    protected virtual void FixedUpdate()
    {
    }
}