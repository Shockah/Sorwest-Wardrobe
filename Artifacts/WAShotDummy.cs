namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Boss })]
    public class WAShotDummy : Artifact
    {
        public override string Name() => "SHOT DUMMY";
        public override int ModifyBaseDamage(int baseDamage, Card? card, State state, Combat? combat, bool fromPlayer)
        {
            if (card == null)
                return 0;
            if (card.Name().Contains("shot", StringComparison.OrdinalIgnoreCase))
                return 1;
            if (card.GetFullDisplayName().Contains("shot", StringComparison.OrdinalIgnoreCase))
                return 1;
            return 0;
        }
    }
}