using System.Diagnostics.Metrics;
using System;
using System.Reflection;
using CobaltCoreModding.Definitions.ExternalItems;
using CobaltCoreModding.Definitions.ModContactPoints;
using FMOD;
using HarmonyLib;
using Wardrobe.Artifacts;

namespace Wardrobe
{
    public partial class Manifest
    {

        // statuses
        public static ExternalStatus? ConfusedStatus { get; private set; }
        public static ExternalStatus? PenNibStatus { get; private set; }
        public void LoadManifest(IStatusRegistry statusRegistry)
        {
            //patch in logic for our statuses
            var harmony = new Harmony("Sorwest.Wardrobe.harmonyStatus");
            ConfusedOnDrawLogic(harmony);
            PenNibOnPlayLogic(harmony);
            {
                ConfusedStatus = new ExternalStatus("Wardrobe.Status.ConfusedStatus", true, Wardrobe_Primary_Color, null, ConfusedStatusSprite ?? throw new Exception("MissingSprite"), true);
                ConfusedStatus.AddLocalisation("Confused", "The costs of your cards are randomized on draw, from 0 to 3.");
                statusRegistry.RegisterStatus(ConfusedStatus);
            }
            {
                PenNibStatus = new ExternalStatus("Wardrobe.Status.PenNibStatus", true, Wardrobe_Primary_Color, null, PenNibStatusSprite ?? throw new Exception("MissingSprite"), true);
                PenNibStatus.AddLocalisation("Pen Nib", "The next <c=card>ATTACK</c> card is played twice.");
                statusRegistry.RegisterStatus(PenNibStatus);
            }
        }
        private void ConfusedOnDrawLogic(Harmony harmony)
        {
            {
                MethodInfo method1 = typeof(Card).GetMethod("OnDraw") ?? throw new Exception("Couldn't find Card.OnDraw method");
                MethodInfo method2 = typeof(Manifest).GetMethod("ConfusedOnDraw", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic) ?? throw new Exception("Couldn't find Manifest.ConfusedOnDraw method");
                harmony.Patch(method1, postfix: new HarmonyMethod(method2));
            }
        }
        private void PenNibOnPlayLogic(Harmony harmony)
        {
            {
                MethodInfo method1 = typeof(Combat).GetMethod("TryPlayCard") ?? throw new Exception("Couldn't find Combat.TryPlayCard method");
                MethodInfo method2 = typeof(Manifest).GetMethod("PenNibOnPlay", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic) ?? throw new Exception("Couldn't find Manifest.PenNibOnPlay method");
                harmony.Patch(method1, postfix: new HarmonyMethod(method2));
            }
        }
        private static void ConfusedOnDraw(Card __instance, State s, Combat c)
        {
            if (Manifest.ConfusedStatus?.Id == null)
                return;
            var status = (Status)Manifest.ConfusedStatus.Id;
            var amount = s.ship.Get(status);
            if (amount <= 0)
                return;
            var index = c.hand.Count;
            if (index > 0)
            {
                var card = c.hand[index - 1];
                var random = new Random();
                var list = new List<int> { 0, 1, 2, 3 };
                var randomEnergy = random.Next(list.Count);
                var differenceEnergy = randomEnergy - card.GetCurrentCost(s);
                if (differenceEnergy != 0)
                    card.discount = differenceEnergy;
            }
        }
        private static void PenNibOnPlay(
            Combat __instance,
            State s,
            Card card,
            ref bool __result,
            bool playNoMatterWhatForFree,
            bool exhaustNoMatterWhat)
        {
            if (!__result)
                return;
            if (Manifest.PenNibStatus?.Id == null)
                return;
            var status = (Status)Manifest.PenNibStatus.Id;
            var amount = s.ship.Get(status);
            if (amount <= 0)
                return;
            var cardHasAttacks = false;
            foreach (CardAction cardAction in card.GetActionsOverridden(s, __instance))
            {
                if (cardAction is AAttack && !cardHasAttacks)
                {
                    cardHasAttacks = true;
                    break;
                }
            }
            if (!cardHasAttacks)
                return;
            foreach (CardAction cardAction in card.GetActionsOverridden(s, __instance))
            {
                if (!(cardAction is AEndTurn))
                    __instance.Queue(Mutil.DeepCopy<CardAction>(cardAction));
            }
            s.ship.Set(status, amount - 1);
        }
    }
}
