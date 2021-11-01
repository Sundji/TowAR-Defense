public class GameManager : SingletonBehaviour<GameManager>
{
    // DOHVAT VARIJABLI ILI FUNKCIJA: GameManager.Instance.ime-varijable-ili-funkcije

    private void Start()
    {
        EventManager.Instance.OnPawnCreatedEvent.AddListener(OnPawnCreated);
    }

    private void OnPawnCreated(Pawn pawn)
    {

    }
}
