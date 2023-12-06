namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Common })]
    public class WAPerfectMarshmellow : Artifact
    {
        public override string Name() => "PERFECT MARSHMELLOW";
        public override void OnTurnStart(State state, Combat combat)
        {
            Ship ship = state.ship;
            if (ship.isPlayerShip)
            {
                var amount = ship.Get(Status.autopilot);
                ship.Set(Status.autopilot, amount + 1);
            }
        }
        public override List<Tooltip>? GetExtraTooltips() => new List<Tooltip>()
        {
            (Tooltip) new TTGlossary("status.autopilot", 1),
        };
    }
}
