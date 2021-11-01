public class GameManager : SingletonBehaviour<GameManager>
{
    // DOHVAT VARIJABLI ILI FUNKCIJA: GameManager.Instance.ime-varijable-ili-funkcije
    // ZA KORISTENJE AWAKE FUNKCIJE TREBA NAPRAVITI NJEN OVERRIDE I KAO PRVI KORAK OSTAVITI base.Awake() (koristi se u SingletonBehaviour)

    private void Start()
    {
        EventManager.Instance.OnPawnCreatedEvent.AddListener(OnPawnCreated);
    }

    private void OnPawnCreated(Pawn pawn)
    {

    }
}
