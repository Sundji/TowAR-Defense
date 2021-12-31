using UnityEngine.Events;

public class EventManager : SingletonBehaviour<EventManager>
{
    public CustomEvent<bool> OnGameEndEvent = new CustomEvent<bool>();
    public UnityEvent OnGameStartEvent = new UnityEvent();

    public CustomEvent<Pawn> OnPawnCreatedEvent = new CustomEvent<Pawn>();
    public CustomEvent<Pawn> OnPawnDeathEvent = new CustomEvent<Pawn>();
}
