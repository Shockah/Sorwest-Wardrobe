namespace Wardrobe.Cards
{
    [CardMeta(dontOffer = true, rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A }, unreleased = true)]
    public class WCMiracle : Card
    {
        public override string Name() => "Miracle";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            result.retain = true;
            result.art = new Spr?((Spr)Manifest.WCMiracleSprite!.Id!);
            result.cost = 0;
            result.exhaust = true;
            result.singleUse = true;
            return result;
        }
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            switch (upgrade)
            {
                case Upgrade.None:
                    List<CardAction> cardActionList1 = new List<CardAction>();
                    AEnergy aEnergy1 = new AEnergy();
                    aEnergy1.changeAmount = 1;
                    cardActionList1.Add(aEnergy1);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    AEnergy aEnergy2 = new AEnergy();
                    aEnergy2.changeAmount = 2;
                    cardActionList2.Add(aEnergy2);
                    result = cardActionList2;
                    break;
            }
            return result;
        }
    }
}
