using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    // DOHVAT VARIJABLI ILI FUNKCIJA: GameManager.Instance.ime-varijable-ili-funkcije
    // ZA KORISTENJE AWAKE FUNKCIJE TREBA NAPRAVITI NJEN OVERRIDE I KAO PRVI KORAK OSTAVITI base.Awake() (koristi se u SingletonBehaviour)

    public List<Pawn> _friendlyPawns;
    public List<Pawn> _enemyPawns;
    private int _towersLeft = 0;

    private void Start()
    {
        EventManager.Instance.OnPawnCreatedEvent.AddListener(OnPawnCreated);
    }

    private void OnPawnCreated(Pawn pawn)
    {
        if ((pawn._type == Pawn.PawnType.FRIENDLY) || (pawn._type == Pawn.PawnType.TOWER))
        {
            _friendlyPawns.Add(pawn);

            if (pawn._type == Pawn.PawnType.TOWER)
            {
                _towersLeft += 1;
            }

        }
        else
        {
            _enemyPawns.Add(pawn);
        }

    }

    public Pawn FindClosestTarget(Vector3 position, Pawn.PawnType attackerType)
    {
        float minDistance = Mathf.Infinity;
        Pawn closest = null;
        if ((attackerType == Pawn.PawnType.FRIENDLY) || (attackerType == Pawn.PawnType.TOWER))
        {
            foreach (Pawn p in _enemyPawns)
            {
                float trenDistance = Vector3.Distance(position, p._transform.position);
                if (trenDistance < minDistance)
                {
                    minDistance = trenDistance;
                    closest = p;
                }
            }

        } else if (attackerType == Pawn.PawnType.ENEMY_MELEE)
        {
            foreach (Pawn p in _friendlyPawns)
            {
                float trenDistance = Vector3.Distance(position, p._transform.position);
                if ((p._type == Pawn.PawnType.FRIENDLY) && (trenDistance < minDistance))
                {
                    minDistance = trenDistance;
                    closest = p;
                }
            }
        } else
        {
            foreach (Pawn p in _friendlyPawns)
            {
                float trenDistance = Vector3.Distance(position, p._transform.position);
                if ((p._type == Pawn.PawnType.TOWER) && (trenDistance < minDistance))
                {
                    minDistance = trenDistance;
                    closest = p;
                }
            }
        }
        return closest;
    }


    public void pawnDead(Pawn deadPawn)
    {
        if (_friendlyPawns.Contains(deadPawn))
        {
            _friendlyPawns.Remove(deadPawn);
            if (deadPawn._type == Pawn.PawnType.TOWER) _towersLeft -= 1;
            if (_towersLeft == 0) playerLoses();
        } else
        {
            _enemyPawns.Remove(deadPawn);
            if (_enemyPawns.Count == 0) playerWins();
        }
    }

    void playerWins()
    {
        Debug.Log("Victory");
    }


    void playerLoses()
    {
        Debug.Log("Defeat");
    }

    

}
