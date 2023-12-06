namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Common })]
    public class WACloakClasp : Artifact
    {
        public override string Name() => "CLOAK CLASP";
        public override void OnTurnEnd(State state, Combat combat)
        {
            var cardsInHand = 0;
            foreach (Card card in combat.hand)
                cardsInHand++;
            if (state.ship.isPlayerShip && cardsInHand > 0)
            {
                AStatus aStatus1 = new AStatus();
                aStatus1.status = Status.tempShield;
                aStatus1.statusAmount = cardsInHand;
                aStatus1.targetPlayer = true;
                combat.QueueImmediate(aStatus1);
                this.Pulse();
            }
        }
        public override List<Tooltip>? GetExtraTooltips() => new List<Tooltip>()
        {
            (Tooltip) new TTGlossary("status.tempShield", 1),
        };
    }
}
