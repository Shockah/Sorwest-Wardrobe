namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Unreleased }, unremovable = true)]
    public class WADeathCounter : Artifact
    {
        public override string Name() => "DEATH COUNTER";
        public int counter;
        public int TRIGGER = 10;
        public override void OnReceiveArtifact(State state)
        {
            counter = 0;
            return;
        }

        public override int? GetDisplayNumber(State s) => counter;
        public override Spr GetSprite()
        {
            Spr sprite = new Spr();
            if (counter <= 4)
                sprite = (Spr)Manifest.WADeathCounterSprite_0!.Id!;
            if (counter == 5)
                sprite = (Spr)Manifest.WADeathCounterSprite_1!.Id!;
            if (counter == 6)
                sprite = (Spr)Manifest.WADeathCounterSprite_2!.Id!;
            if (counter == 7)
                sprite = (Spr)Manifest.WADeathCounterSprite_3!.Id!;
            if (counter == 8)
                sprite = (Spr)Manifest.WADeathCounterSprite_4!.Id!;
            if (counter == 9)
                sprite = (Spr)Manifest.WADeathCounterSprite_5!.Id!;
            if (counter == TRIGGER)
                sprite = (Spr)Manifest.WADeathCounterSprite_6!.Id!;
            return sprite;
        }
        public override void OnCombatStart(State state, Combat combat)
        {
            counter = 0;
            return;
        }
        public override void OnCombatEnd(State state)
        {
            counter = 0;
            return;
        }
        public override void OnTurnStart(State state, Combat combat)
        {
            if (state.ship.isPlayerShip)
            {
                counter = combat.turn;
                if (counter >= 5)
                    state.ship.pendingEffects.Add(Ship.MiscEffects.Overheat);
                return;
            }
        }
        public override void OnTurnEnd(State state, Combat combat)
        {
            if (counter == TRIGGER && state.ship.isPlayerShip)
            {
                var damage = state.ship.hull;
                AHurt aHurt = new AHurt();
                aHurt.hurtAmount = damage;
                aHurt.targetPlayer = true;
                combat.Queue(aHurt);
                counter = 0;
                return;
            }
        }
    }
}
