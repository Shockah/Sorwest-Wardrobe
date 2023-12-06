namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Boss }, unremovable = true)]
    public class WASneckoEye : Artifact
    {
        public override string Name() => "SNECKO EYE";
        public override void OnReceiveArtifact(State state)
        {
            state.ship.baseDraw += 2;
        }
        public override void OnRemoveArtifact(State state)
        {
            state.ship.baseDraw -= 2;
        }
        public override void OnCombatStart(State state, Combat combat)
        {
            AStatus aStatus1 = new AStatus();
            aStatus1.status = (Status)Manifest.ConfusedStatus!.Id!;
            aStatus1.statusAmount = 1;
            aStatus1.targetPlayer = true;
            combat.QueueImmediate(aStatus1);
            this.Pulse();
            return;
        }
        public override List<Tooltip>? GetExtraTooltips() => new List<Tooltip>()
        {
            (Tooltip) new TTGlossary(Manifest.AConfusedStatus_Glossary?.Head ?? throw new Exception("Missing AConfusedStatus_Glossary")),
        };
    }
}
