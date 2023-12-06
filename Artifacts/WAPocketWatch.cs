namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Common })]
    public class WAPocketWatch : Artifact
    {
        public override string Name() => "POCKETWATCH";
        public int counter;
        public int TRIGGER = 3;
        public override void OnReceiveArtifact(State state)
        {
            counter = 0;
            return;
        }
        public override int? GetDisplayNumber(State s) => (counter > TRIGGER) ? null : counter;
        public override Spr GetSprite()
        {
            Spr sprite = new Spr();
            if (counter <= TRIGGER)
                sprite = (Spr)Manifest.WAPocketWatchSprite_0!.Id!;
            if (counter > TRIGGER)
                sprite = (Spr)Manifest.WAPocketWatchSprite_1!.Id!;
            return sprite;
        }
        public override void OnPlayerPlayCard(int energyCost, Deck deck, Card card, State state, Combat combat, int handPosition, int handCount)
        {
            if (counter <= TRIGGER)
                counter++;
            return;
        }
        public override void OnTurnStart(State state, Combat combat)
        {
            if (state.ship.isPlayerShip)
            {
                if (counter <= TRIGGER && combat.turn != 1)
                {
                    ADrawCard aDrawCard1 = new ADrawCard();
                    aDrawCard1.count = 3;
                    combat.QueueImmediate(aDrawCard1);
                    this.Pulse();
                }
                counter = 0;
            }
            return;
        }
        public override void OnCombatEnd(State state)
        {
            counter = 0;
            return;
        }
    }
}
