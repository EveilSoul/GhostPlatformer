using UnityEngine;

/// Класс стейт машины.
public class StateMachine : MonoBehaviour
{
    /// Начальное состояние.
    /// Задается в Inspector'е.
    [SerializeField]
    State startingState;

    /// Текущее состояние.
    State current;

    /// Доступ к текущему состоянию.
    public State Current
    {
        get { return current; }
    }

    /// Инициализация (переход в начальное состояние).
    void Start()
    {
        Reset();
    }

    /// Переводит стейт машину в начальное состояние.
    public void Reset()
    {
        Transit(startingState);
    }

    /// На каждом кадре проверяет, не нужно ли совершить
    /// переход. Если нужно - совершает.
    void Update()
    {
        if (current == null)
            return;

        var next = current.GetNext();
        if (next != null)
            Transit(next);
    }

    /// Собственно, переход.
    /// Выходит из текущего состояния,
    /// делает следующее текущим и
    /// входит в него.
    void Transit(State next)
    {
        if (current != null)
            current.Exit();

        current = next;
        if (current != null)
            current.Enter();
    }
}