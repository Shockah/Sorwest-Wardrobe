namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Boss })]
    public class WAOrrery : Artifact
    {
        public override string Name() => "ORRERY";
        public override void OnReceiveArtifact(State state)
        {
            var count = 5;
            do
            {
                ACardOffering aCardOffering1 = new ACardOffering();
                aCardOffering1.amount = 3;
                state.GetCurrentQueue().Add(aCardOffering1);
                count -= 1;
            }
            while (count > 0);
            this.Pulse();
        }
    }
}