namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Common }, extraGlossary = new string[] { "parttrait.weak" })]
    public class WABagOfMarbles : Artifact
    {
        public override string Name() => "BAG OF MARBLES";
        public override void OnCombatStart(State state, Combat combat)
        {
            var num = 0;
            var flag = false;
            var random = new Random();
            var parts = combat.otherShip.parts;
            var index = random.Next(parts.Count);

            foreach (Part part in combat.otherShip.parts)
            {
                if (num != index)
                    num++;
                if (part.damageModifier != PDamMod.brittle && part.damageModifier != PDamMod.weak && !flag && num == index)
                {
                    Combat combat1 = combat;
                    AWeaken a = new AWeaken();
                    a.targetPlayer = false;
                    a.worldX = combat.otherShip.x + num;
                    a.artifactPulse = this.Key();
                    flag = true;
                    combat1.QueueImmediate((CardAction)a);
                }
            }
        }
    }
}
