namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Boss }, unremovable = true)]

    public class WARunicDome : Artifact
    {
        // Hide Intent patching happens in LoadManifest(IArtifactRegistry registry)
        public override string Name() => "RUNIC DOME";
        public override void OnReceiveArtifact(State state)
        {
            state.ship.baseEnergy += 1;
        }
        public override void OnRemoveArtifact(State state)
        {
            state.ship.baseEnergy -= 1;
        }
        public override void OnTurnStart(State state, Combat combat)
        {
            this.Pulse();
        }
    }
}
