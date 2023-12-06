namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Common })]
    public class WAGirya : Artifact
    {
        // Shop patching happens in LoadManifest(IArtifactRegistry registry)
        public override string Name() => "GIRYA";
        public int counter;
        public override int? GetDisplayNumber(State s) => counter;
        public override void OnCombatStart(State state, Combat combat)
        {
            if (counter > 0)
            {
                AStatus aStatus1 = new AStatus();
                aStatus1.status = Status.overdrive;
                aStatus1.statusAmount = counter;
                aStatus1.targetPlayer = true;
                combat.QueueImmediate(aStatus1);
                this.Pulse();
            }
            return;
        }
        public override List<Tooltip>? GetExtraTooltips() => new List<Tooltip>()
        {
            (Tooltip) new TTGlossary("status.overdrive", counter > 0 ? counter : 1),
        };
    }
}
