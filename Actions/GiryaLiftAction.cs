using Wardrobe.Artifacts;

namespace Wardrobe.Actions
{
    public class GiryaLiftAction : CardAction
    {
        public override void Begin(G g, State s, Combat c)
        {
            base.Begin(g, s, c);

            if (s.EnumerateAllArtifacts().OfType<WAGirya>().FirstOrDefault() is not { } artifact)
            {
                timer = 0;
                return;
            }
            
            artifact.counter++;
            artifact.Pulse();
        }
    }
}