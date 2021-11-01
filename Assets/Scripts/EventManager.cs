public class EventManager : SingletonBehaviour<EventManager>
{
    // DOHVAT VARIJABLI ILI FUNKCIJA: EventManager.Instance.ime-varijable-ili-funkcije...
    // ZA KORISTENJE AWAKE FUNKCIJE TREBA NAPRAVITI NJEN OVERRIDE I KAO PRVI KORAK OSTAVITI base.Awake() (koristi se u SingletonBehaviour)

    public CustomEvent<Pawn> OnPawnCreatedEvent = new CustomEvent<Pawn>();
}
