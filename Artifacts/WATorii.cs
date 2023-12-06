namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Common }, extraGlossary = new string[] { "parttrait.weak", "parttrait.brittle" })]
    public class WATorii : Artifact
    {
        public override string Name() => "TORII";
        public int MINTRIGGER = 2;
        public int MAXTRIGGER = 3;
        public override int ModifyBaseDamage(int baseDamage, Card? card, State state, Combat? combat, bool fromPlayer)
        {
            if (fromPlayer)
                return 0;
            if (baseDamage >= MINTRIGGER && baseDamage <= MAXTRIGGER)
            {
                var oneDamage = (baseDamage - 1) * -1;
                return oneDamage;
            }
            return 0;
        }
    }
}
