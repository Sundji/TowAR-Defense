using UnityEngine;

public class Pawn : MonoBehaviour
{
    public enum PawnType { FRIENDLY, TOWER, ENEMY_MELEE, ENEMY_RANGE }
    public PawnType _type;
    public Transform _transform;


    private void Update()
    {
        if (this._type ==PawnType.FRIENDLY)
        {
            Debug.Log(GameManager.Instance.FindClosestTarget(_transform.position, _type)._type);
        }
    }


}
