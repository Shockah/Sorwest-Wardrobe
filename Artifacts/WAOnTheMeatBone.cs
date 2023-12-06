namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Common })]
    public class WAOnTheMeatBone : Artifact
    {
        public override string Name() => "On The Meat Bone";
        public bool triggered;
        public override void OnCombatStart(State state, Combat combat)
        {
            triggered = false;
        }
        public override void OnCombatEnd(State state)
        {
            if (state.ship.hull * 2 <= state.ship.hullMax && !triggered)
            {
                triggered = true;
                this.Pulse();
                state.ship.hull += 2;
            }
        }
    }
}
