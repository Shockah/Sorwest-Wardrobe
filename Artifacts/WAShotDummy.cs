namespace Wardrobe.Artifacts
{
    [ArtifactMeta(owner = Deck.colorless, pools = new ArtifactPool[] { ArtifactPool.Boss })]
    public class WAShotDummy : Artifact
    {
        private static readonly Dictionary<Type, bool> BasicAttackCardCache = [];
        
        public override string Name() => "SHOT DUMMY";
        public override int ModifyBaseDamage(int baseDamage, Card? card, State state, Combat? combat, bool fromPlayer)
        {
            if (card == null)
                return 0;
            if (card.Name().Contains("shot", StringComparison.OrdinalIgnoreCase))
                return 1;
            if (card.GetFullDisplayName().Contains("shot", StringComparison.OrdinalIgnoreCase))
                return 1;
            if (combat is not null && IsBasicAttackCard(state, combat, card))
                return 1;
            return 0;
        }
        
        private static bool IsBasicAttackCard(State state, Combat combat, Card card)
        {
            var type = card.GetType();
            if (BasicAttackCardCache.TryGetValue(type, out var result))
                return result;

            if (card is CannonColorless)
            {
                BasicAttackCardCache[type] = true;
                return true;
            }
            if (Manifest.Instance.MoreDifficultiesApi is { } moreDifficultiesApi && type == moreDifficultiesApi.BasicOffencesCardType)
            {
                BasicAttackCardCache[type] = true;
                return true;
            }

            foreach (var ship in StarterShip.ships.Values)
            {
                foreach (var shipCard in ship.cards)
                {
                    if (shipCard.GetType() != type)
                        continue;

                    foreach (var action in shipCard.GetActions(state, combat))
                    {
                        if (action is not AAttack)
                            continue;

                        BasicAttackCardCache[type] = true;
                        return true;
                    }
                }
            }

            BasicAttackCardCache[type] = false;
            return false;
        }
    }
}