namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Common })]
    public class WAPantograph : Artifact
    {
        public override string Name() => "PANTOGRAPH";
        public override void OnCombatStart(State state, Combat combat)
        {
            if (!(state.map.GetCurrent().contents is MapBattle))
                return;
            MapBattle contents = (MapBattle)state.map.GetCurrent().contents;
            if (contents.battleType != BattleType.Boss)
                return;
            AHeal aHeal1 = new AHeal();
            aHeal1.healAmount = 3;
            aHeal1.targetPlayer = true;
            combat.Queue(aHeal1);
            this.Pulse();
        }
    }
}