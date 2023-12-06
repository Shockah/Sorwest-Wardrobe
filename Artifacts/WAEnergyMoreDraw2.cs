namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Unreleased }, unremovable = true)]
    public class WAEnergyMoreDraw2 : Artifact
    {
        public override string Name() => "+2 ENERGY +2 DRAW";
        public override int? GetDisplayNumber(State s) => new int?(2);
        public override void OnReceiveArtifact(State state)
        {
            state.ship.baseEnergy += 2;
            state.ship.baseDraw += 2;
        }
        public override void OnRemoveArtifact(State state)
        {
            state.ship.baseEnergy -= 2;
            state.ship.baseDraw -= 2;
        }
    }
}
