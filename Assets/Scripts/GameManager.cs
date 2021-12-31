using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    private List<Pawn> _pawnsEnemy = new List<Pawn>();
    private List<Pawn> _pawnsFriendly = new List<Pawn>();
    private List<Pawn> _towersFriendly = new List<Pawn>();

    protected override void Awake()
    {
        base.Awake();
        EventManager.Instance.OnPawnCreatedEvent.AddListener(OnPawnCreated);
        EventManager.Instance.OnPawnDeathEvent.AddListener(OnPawnDeath);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) EventManager.Instance.OnGameStartEvent.Invoke(); // temporary
    }

    private void OnPawnCreated(Pawn pawn)
    {
        PawnType pawnType = pawn.Type;
        
        if (pawnType == PawnType.PAWN_ENEMY_MELEE || pawnType == PawnType.PAWN_ENEMY_RANGED) _pawnsEnemy.Add(pawn);
        else if (pawnType == PawnType.PAWN_FRIENDLY) _pawnsFriendly.Add(pawn);
        else if (pawnType == PawnType.TOWER_FRIENDLY) _towersFriendly.Add(pawn);
    }

    private void OnPawnDeath(Pawn pawn)
    {
        PawnType pawnType = pawn.Type;

        if (pawnType == PawnType.PAWN_ENEMY_MELEE || pawnType == PawnType.PAWN_ENEMY_RANGED)
        {
            _pawnsEnemy.Remove(pawn);
            if (_pawnsEnemy.Count == 0) GameEnd(isVictory: true);
        }
        else if (pawnType == PawnType.PAWN_FRIENDLY)
        {
            _pawnsFriendly.Remove(pawn);
        }
        else if (pawnType == PawnType.TOWER_FRIENDLY)
        {
            _towersFriendly.Remove(pawn);
            if (_towersFriendly.Count == 0) GameEnd(isVictory: false);
        }
    }

    private int FindClosestPawnIndex(Vector3 position, List<Pawn> pawnList)
    {
        float distanceMinimum = Mathf.Infinity;
        int indexOfClosestPawn = -1;

        for (int index = 0; index < pawnList.Count; index++)
        {
            float distance = Vector3.Distance(position, pawnList[index].transform.position);
            if (distanceMinimum > distance)
            {
                distanceMinimum = distance;
                indexOfClosestPawn = index;
            }
        }

        return indexOfClosestPawn;
    }

    private void GameEnd(bool isVictory)
    {
        EventManager.Instance.OnGameEndEvent.Invoke(isVictory);
    }

    public Pawn FindClosestTarget(Vector3 position, PawnType attackerType)
    {
        if (attackerType == PawnType.PAWN_ENEMY_MELEE)
        {
            int index = FindClosestPawnIndex(position, _pawnsFriendly);
            return index == -1 ? null : _pawnsFriendly[index];
        }
        else if (attackerType == PawnType.PAWN_ENEMY_RANGED)
        {
            int index = FindClosestPawnIndex(position, _towersFriendly);
            return index == -1 ? null : _towersFriendly[index];
        }
        else if (attackerType == PawnType.PAWN_FRIENDLY || attackerType == PawnType.TOWER_FRIENDLY)
        {
            int index = FindClosestPawnIndex(position, _pawnsEnemy);
            return index == -1 ? null : _pawnsEnemy[index];
        }
        return null;
    }
}
