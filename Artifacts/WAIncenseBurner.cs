namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Common })]
    public class WAIncenseBurner : Artifact
    {
        public override string Name() => "INCENSE BURNER";
        public int counter;
        public int TRIGGER = 6;
        public override void OnReceiveArtifact(State state)
        {
            counter = 0;
            return;
        }
        public override int? GetDisplayNumber(State s) => counter;
        public override void OnTurnStart(State state, Combat combat)
        {
            if (state.ship.isPlayerShip)
            {
                counter++;
                if (counter == 6)
                {
                    counter = 0;
                    AStatus aStatus1 = new AStatus();
                    aStatus1.status = Status.perfectShield;
                    aStatus1.statusAmount = 1;
                    aStatus1.targetPlayer = true;
                    combat.QueueImmediate(aStatus1);
                }
                this.Pulse();
            }
        }
        public override List<Tooltip>? GetExtraTooltips() => new List<Tooltip>()
        {
            (Tooltip) new TTGlossary("status.perfectShield", 1),
        };
    }
}
