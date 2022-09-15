using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.RuleTile;

[CreateAssetMenu(menuName = "2D/Tiles/Custom/TopDownTileRule")]
public class TopDownTileRule : RuleTile<TilingRule.Neighbor>
{
    public override bool RuleMatch(int neighbor, TileBase other)
    {
        if (other is RuleOverrideTile)
            other = (other as RuleOverrideTile).m_InstanceTile;

        switch (neighbor)
        {
            case TilingRule.Neighbor.This: return other != null;
            case TilingRule.Neighbor.NotThis: return other != this;
        }
        return true;
    }
}