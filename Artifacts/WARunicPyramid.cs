namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Boss })]
    public class WARunicPyramid : Artifact
    {
        // End of turn Discard patching happens in LoadManifest(IArtifactRegistry registry)
        public override string Name() => "RUNIC PYRAMID";
    }
}