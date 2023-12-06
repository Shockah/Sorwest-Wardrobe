namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Common })]
    public class WADuVuDoll : Artifact
    {
        public override string Name() => "DU-VU DOLL";
        public int counter;
        public override int? GetDisplayNumber(State s) => counter;
        public override void OnCombatStart(State state, Combat combat)
        {
            counter = 0;
            foreach (Card card in state.deck)
            {
                var cardDeck = card.GetMeta().deck;
                if (cardDeck == Deck.trash || cardDeck == Deck.corrupted)
                    counter++;
            }
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
            (Tooltip) new TTGlossary("status.overdrive", 1),
        };
    }
}
