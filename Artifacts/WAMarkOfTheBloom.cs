namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Unreleased })]
    public class WAMarkOfTheBloom : Artifact
    {
        //Heal patching happens in LoadManifest(IArtifactRegistry registry)
        public override string Name() => "MARK OF THE BLOOM";
    }
}