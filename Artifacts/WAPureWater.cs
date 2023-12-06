using Wardrobe.Cards;
namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Unreleased })]
    public class WAPureWater : Artifact
    {
        public override string Name() => "PURE WATER";
        public override void OnCombatStart(State state, Combat combat)
        {
            AAddCard aaddCard1 = new AAddCard();
            WCMiracle waMiracle1 = new WCMiracle();
            waMiracle1.temporaryOverride = true;
            aaddCard1.card = (Card)waMiracle1;
            aaddCard1.destination = CardDestination.Hand;
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
