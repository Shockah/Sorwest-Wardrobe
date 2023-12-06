namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Unreleased }, unremovable = true)]
    public class WAEnergy1 : Artifact
    {
        public override string Name() => "+1 ENERGY";
        public override int? GetDisplayNumber(State s) => new int?(1);
        public override void OnReceiveArtifact(State state)
        {
            state.ship.baseEnergy += 1;
        }
        public override void OnRemoveArtifact(State state)
        {
            state.ship.baseEnergy -= 1;
        }
    }
}
