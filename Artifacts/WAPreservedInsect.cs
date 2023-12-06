namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Common })]
    public class WAPreservedInsect : Artifact
    {
        public override string Name() => "PRESERVED INSECT";
        public override void OnCombatStart(State state, Combat combat)
        {
            if (!(state.map.GetCurrent().contents is MapBattle))
                return;
            MapBattle contents = (MapBattle)state.map.GetCurrent().contents;
            if (contents.battleType != BattleType.Elite)
                return;
            Ship ship = !(state.ship.isPlayerShip) ? state.ship : combat.otherShip;
            int quarterHull = ship.hull / 4;
            if (quarterHull * 4 < ship.hull)
                quarterHull += 1;
            if (quarterHull <= 0)
                return;
            AHurt aHurt1 = new AHurt();
            aHurt1.hurtAmount = quarterHull;
            aHurt1.targetPlayer = false;
            combat.Queue(aHurt1);
            this.Pulse();
        }
    }
}
