using Wardrobe.Cards;
namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Unreleased })]
    public class WAPureWaterV2 : Artifact
    {
        public override string Name() => "HOLY WATER";
        public override void OnReceiveArtifact(State state)
        {
            foreach (Artifact artifact in state.artifacts)
            {
                if (artifact.Name() == "PURE WATER")
                    artifact.OnRemoveArtifact(state);
            }
            state.artifacts.RemoveAll((Predicate<Artifact>)(r => r.Name() == "PURE WATER"));
        }
        public override void OnCombatStart(State state, Combat combat)
        {
            AAddCard aaddCard1 = new AAddCard();
            WCMiracle waMiracle1 = new WCMiracle();
            waMiracle1.temporaryOverride = true;
            aaddCard1.card = (Card)waMiracle1;
            aaddCard1.destination = CardDestination.Hand;
            aaddCard1.amount = 3;
            combat.QueueImmediate((CardAction)aaddCard1);
            this.Pulse();
        }

        public override List<Tooltip>? GetExtraTooltips() => new List<Tooltip>()
        {
            (Tooltip) new TTCard()
            {
                card = (Card) new Cards.WCMiracle()
            }
        };
    }
}
