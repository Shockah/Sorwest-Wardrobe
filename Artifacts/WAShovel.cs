namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Common })]
    public class WAShovel : Artifact
    {
        // Shop patching happens in LoadManifest(IArtifactRegistry registry)
        public override string Name() => "SHOVEL";
    }
}