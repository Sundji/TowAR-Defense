public class EventManager : SingletonBehaviour<EventManager>
{
    // DOHVAT VARIJABLI ILI FUNKCIJA: EventManager.Instance.ime-varijable-ili-funkcije...

    public CustomEvent<Pawn> OnPawnCreatedEvent = new CustomEvent<Pawn>();
}
