namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Common })]
    public class WAPenNib : Artifact
    {
        public override string Name() => "PEN NIB";
        public int counter;
        public override int? GetDisplayNumber(State s) => counter;
        public bool cardHasAttacks;
        public override void OnPlayerPlayCard(int energyCost, Deck deck, Card card, State state, Combat combat, int handPosition, int handCount)
        {
            cardHasAttacks = false;
            foreach (CardAction cardAction in card.GetActionsOverridden(state, combat))
            {
                if (cardAction is AAttack && !cardHasAttacks)
                {
                    cardHasAttacks = true;
                }
                if (cardHasAttacks && counter < 9)
                {
                    counter++;
                    this.Pulse();
                    return;
                }
                if (cardHasAttacks && counter == 9)
                {
                    AStatus aStatus1 = new AStatus();
                    aStatus1.status = (Status)Manifest.PenNibStatus!.Id!;
                    aStatus1.statusAmount = 1;
                    aStatus1.targetPlayer = true;
                    combat.QueueImmediate(aStatus1);
                    counter = 0;
                    this.Pulse();
                    return;
                }
            }
        }
    }
}
