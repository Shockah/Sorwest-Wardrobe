namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Common })]
    public class WANLothsGift : Artifact
    {
        // Rare chance patching happens in LoadManifest(IArtifactRegistry registry)
        public override string Name() => "N'LOTH'S GIFT";
    }
}