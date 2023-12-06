namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Common })]
    public class WACollectionOfTails : Artifact
    {
        public override string Name() => "COLLECTION OF TAILS";
        public override void OnTurnEnd(State state, Combat combat)
        {
            if (state.ship.isPlayerShip && state.ship.Get(Status.overdrive) != 0)
            {
                AStatus aStatus1 = new AStatus();
                aStatus1.status = Status.overdrive;
                aStatus1.statusAmount = 1;
                aStatus1.targetPlayer = true;
                combat.QueueImmediate(aStatus1);
                this.Pulse();
            }
        }
        public override List<Tooltip>? GetExtraTooltips() => new List<Tooltip>()
        {
            (Tooltip) new TTGlossary("status.overdrive", 1),
        };
    }
}
