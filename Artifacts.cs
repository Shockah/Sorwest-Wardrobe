using System.Reflection;
using CobaltCoreModding.Definitions.ExternalItems;
using CobaltCoreModding.Definitions.ModContactPoints;
using HarmonyLib;
using Wardrobe.Artifacts;

namespace Wardrobe
{
    public partial class Manifest
    {
        //artifacts
        public static ExternalArtifact? WAEnergy1 { get; private set; }
        public static ExternalArtifact? WAEnergy2 { get; private set; }
        public static ExternalArtifact? WAEnergyLessDraw1 { get; private set; }
        public static ExternalArtifact? WAEnergyLessDraw2 { get; private set; }
        public static ExternalArtifact? WAEnergyMoreDraw1 { get; private set; }
        public static ExternalArtifact? WAEnergyMoreDraw2 { get; private set; }
        public static ExternalArtifact? WADeathCounter { get; private set; }
        public static ExternalArtifact? WAIncenseBurner { get; private set; }
        public static ExternalArtifact? WAPocketWatch { get; private set; }
        public static ExternalArtifact? WADuVuDoll { get; private set; }
        public static ExternalArtifact? WAPantograph { get; private set; }
        public static ExternalArtifact? WACloakClasp { get; private set; }
        public static ExternalArtifact? WAOrrery { get; private set; }
        public static ExternalArtifact? WASneckoEye { get; private set; }
        public static ExternalArtifact? WARunicDome { get; private set; }
        public static ExternalArtifact? WAGirya { get; private set; }
        public static ExternalArtifact? WAOnTheMeatBone { get; private set; }
        public static ExternalArtifact? WABagOfMarbles { get; private set; }
        public static ExternalArtifact? WAPerfectMarshmellow { get; private set; }
        public static ExternalArtifact? WAPreservedInsect { get; private set; }
        public static ExternalArtifact? WAPureWater { get; private set; }
        public static ExternalArtifact? WAPureWaterV2 { get; private set; }
        public static ExternalArtifact? WAPenNib { get; private set; }
        public static ExternalArtifact? WAShotDummy { get; private set; }
        public static ExternalArtifact? WAMarkOfTheBloom { get; private set; }
        public static ExternalArtifact? WANLothsGift { get; private set; }
        public static ExternalArtifact? WARunicPyramid { get; private set; }
        public static ExternalArtifact? WATorii { get; private set; }
        public static ExternalArtifact? WAShovel { get; private set; }
        public static ExternalArtifact? WACollectionOfTails { get; private set; }
        public void LoadManifest(IArtifactRegistry registry)
        {
            //patch in logic for our artifacts
            var harmony = new Harmony("Sorwest.Wardrobe.harmonyArtifacts");
            DomeRenderLogic(harmony);
            ShopPatchLogic(harmony);
            BloomHealLogic(harmony);
            GiftRarityLogic(harmony);
            PyramidDiscardLogic(harmony);
            // +/- Energy +/- Draw
            {
                {
                    WAEnergy1 = new ExternalArtifact("Wardrobe.Artifacts.WAEnergy1",
                        typeof(WAEnergy1),
                        WAEnergySprite ?? throw new Exception("missing WAEnergy artifact sprite"));

                    WAEnergy1.AddLocalisation("+1 ENERGY",
                        "Gain 1 extra <c=energy>ENERGY</c> every turn.");

                    registry.RegisterArtifact(WAEnergy1);
                }
                {
                    WAEnergy2 = new ExternalArtifact("Wardrobe.Artifacts.WAEnergy2",
                            typeof(WAEnergy2),
                            WAEnergySprite ?? throw new Exception("missing WAEnergy artifact sprite"));

                    WAEnergy2.AddLocalisation("+2 ENERGY",
                        "Gain 2 extra <c=energy>ENERGY</c> every turn.");

                    registry.RegisterArtifact(WAEnergy2);
                }
                {
                    WAEnergyLessDraw1 = new ExternalArtifact("Wardrobe.Artifacts.WAEnergyLessDraw1",
                            typeof(WAEnergyLessDraw1),
                            WAEnergyLessDrawSprite ?? throw new Exception("missing WAEnergyLessDraw artifact sprite"));

                    WAEnergyLessDraw1.AddLocalisation("+1 ENERGY -1 DRAW",
                        "<c=hurt>Draw 1 less card per turn</c>.\nGain 1 extra <c=energy>ENERGY</c> every turn.");

                    registry.RegisterArtifact(WAEnergyLessDraw1);
                }
                {
                    WAEnergyLessDraw2 = new ExternalArtifact("Wardrobe.Artifacts.WAEnergyLessDraw2",
                            typeof(WAEnergyLessDraw2),
                            WAEnergyLessDrawSprite ?? throw new Exception("missing WAEnergyLessDraw artifact sprite"));

                    WAEnergyLessDraw2.AddLocalisation("+2 ENERGY -2 DRAW",
                        "<c=hurt>Draw 2 less cards per turn</c>.\nGain 2 extra <c=energy>ENERGY</c> every turn.");

                    registry.RegisterArtifact(WAEnergyLessDraw2);
                }
                {
                    WAEnergyMoreDraw1 = new ExternalArtifact("Wardrobe.Artifacts.WAEnergyMoreDraw1",
                            typeof(WAEnergyMoreDraw1),
                            WAEnergyMoreDrawSprite ?? throw new Exception("missing WAEnergyMoreDraw artifact sprite"));

                    WAEnergyMoreDraw1.AddLocalisation("+1 ENERGY +1 DRAW",
                        "Draw 1 extra card per turn.\nGain 1 extra <c=energy>ENERGY</c> every turn.");

                    registry.RegisterArtifact(WAEnergyMoreDraw1);
                }
                {
                    WAEnergyMoreDraw2 = new ExternalArtifact("Wardrobe.Artifacts.WAEnergyMoreDraw2",
                            typeof(WAEnergyMoreDraw2),
                            WAEnergyMoreDrawSprite ?? throw new Exception("missing WAEnergyMoreDraw artifact sprite"));

                    WAEnergyMoreDraw2.AddLocalisation("+2 ENERGY +2 DRAW",
                        "Draw 2 extra cards per turn.\nGain 2 extra <c=energy>ENERGY</c> every turn.");

                    registry.RegisterArtifact(WAEnergyMoreDraw2);
                }
            }
            // Counters - DEATH COUNTER - INCENSE BURNER - POCKETWATCH - PEN NIB
            {
                {
                    WADeathCounter = new ExternalArtifact("Wardrobe.Artifacts.WADeathCounter",
                            typeof(WADeathCounter),
                            WADeathCounterSprite_0 ?? throw new Exception("missing WADeathCounter artifact sprite"));

                    WADeathCounter.AddLocalisation("DEATH COUNTER",
                        "<c=hurt>At the end of the 10th turn, DIE</c>.");

                    registry.RegisterArtifact(WADeathCounter);
                }
                {
                    WAIncenseBurner = new ExternalArtifact("Wardrobe.Artifacts.WAIncenseBurner",
                            typeof(WAIncenseBurner),
                            WAIncenseBurnerSprite ?? throw new Exception("missing WAIncenseBurner artifact sprite"));

                    WAIncenseBurner.AddLocalisation("INCENSE BURNER",
                        "Every 6 turns, gain 1 <c=status>PERFECT SHIELD</c>.");

                    registry.RegisterArtifact(WAIncenseBurner);
                }
                {
                    WAPocketWatch = new ExternalArtifact("Wardrobe.Artifacts.WAPocketWatch",
                            typeof(WAPocketWatch),
                            WAPocketWatchSprite_0 ?? throw new Exception("missing WAPocketWatch artifact sprite"));

                    WAPocketWatch.AddLocalisation("POCKETWATCH",
                        "Whenever you play 3 or less cards in a turn, draw 3 extra cards at the start of next turn.");

                    registry.RegisterArtifact(WAPocketWatch);
                }
                {
                    WAPenNib = new ExternalArtifact("Wardrobe.Artifacts.WAPenNib",
                            typeof(WAPenNib),
                            WAPenNibSprite ?? throw new Exception("missing WAPenNib artifact sprite"));

                    WAPenNib.AddLocalisation("PEN NIB",
                        "Every 10th <c=card>ATTACK</c> card is played twice.");

                    registry.RegisterArtifact(WAPenNib);
                }
            }
            // Combat Start Effects - DU-VU DOLL - PANTOGRAPH - GIRYA - BAG OF MARBLES - PRESERVED INSECT
            // PURE WATER - HOLY WATER
            {
                {
                    WADuVuDoll = new ExternalArtifact("Wardrobe.Artifacts.WADuVuDoll",
                            typeof(WADuVuDoll),
                            WADuVuDollSprite ?? throw new Exception("missing WADuVuDoll artifact sprite"));

                    WADuVuDoll.AddLocalisation("DU-VU DOLL",
                        "At the start of combat, gain 1 <c=status>OVERDRIVE</c> for each <c=trash>Trash</c> in your deck.");

                    registry.RegisterArtifact(WADuVuDoll);
                }
                {
                    WAPantograph = new ExternalArtifact("Wardrobe.Artifacts.WAPantograph",
                            typeof(WAPantograph),
                            WAPantographSprite ?? throw new Exception("missing WAPantograph artifact sprite"));

                    WAPantograph.AddLocalisation("PANTOGRAPH",
                        "At the start of <c=ff6bb9>BOSS</c> combats, <c=healing>heal 3</c>.");

                    registry.RegisterArtifact(WAPantograph);
                }
                {
                    WAGirya = new ExternalArtifact("Wardrobe.Artifacts.WAGirya",
                            typeof(WAGirya),
                            WAGiryaSprite ?? throw new Exception("missing WAGirya artifact sprite"));

                    WAGirya.AddLocalisation("GIRYA",
                        "You can now gain start-of-combat <c=status>OVERDRIVE</c> at repair yards (3 times max).");

                    registry.RegisterArtifact(WAGirya);
                }
                {
                    WABagOfMarbles = new ExternalArtifact("Wardrobe.Artifacts.WABagOfMarbles",
                            typeof(WABagOfMarbles),
                            WABagOfMarblesSprite ?? throw new Exception("missing WABagOfMarbles artifact sprite"));

                    WABagOfMarbles.AddLocalisation("BAG OF MARBLES",
                        "At the start of combat, a random enemy part becomes <c=hurt>weak</c>.");

                    registry.RegisterArtifact(WABagOfMarbles);
                }
                {
                    WAPreservedInsect = new ExternalArtifact("Wardrobe.Artifacts.WAPreservedInsect",
                            typeof(WAPreservedInsect),
                            WAPreservedInsectSprite ?? throw new Exception("missing WAPreservedInsect artifact sprite"));

                    WAPreservedInsect.AddLocalisation("PRESERVED INSECT",
                        "<c=c16bff>ELITE</c> combats start with a quarter less hull.");

                    registry.RegisterArtifact(WAPreservedInsect);
                }
                {
                    WAPureWater = new ExternalArtifact("Wardrobe.Artifacts.WAPureWater",
                            typeof(WAPureWater),
                            WAPureWaterSprite ?? throw new Exception("missing WAPureWater artifact sprite"));

                    WAPureWater.AddLocalisation("PURE WATER",
                        "At the start of combat, gain a <c=card>Miracle</c>.");

                    registry.RegisterArtifact(WAPureWater);
                }
                {
                    WAPureWaterV2 = new ExternalArtifact("Wardrobe.Artifacts.WAPureWaterV2",
                            typeof(WAPureWaterV2),
                            WAPureWaterV2Sprite ?? throw new Exception("missing WAPureWaterV2 artifact sprite"));

                    WAPureWaterV2.AddLocalisation("HOLY WATER",
                        "At the start of combat, gain 3 <c=card>Miracles</c>.");

                    registry.RegisterArtifact(WAPureWaterV2);
                }
            }
            // Combat End Effects - ON THE BONE MEAT
            {
                {
                    WAOnTheMeatBone = new ExternalArtifact("Wardrobe.Artifacts.WAOnTheMeatBone",
                            typeof(WAOnTheMeatBone),
                            WAOnTheMeatBoneSprite ?? throw new Exception("missing WAOnTheMeatBone artifact sprite"));

                    WAOnTheMeatBone.AddLocalisation("ON THE MEAT BONE",
                        "If your hull is at or under its half at the end of combat, <c=healing>heal 2</c>.");

                    registry.RegisterArtifact(WAOnTheMeatBone);
                }
            }
            // Turn Start Effects - PERFECT MARSHMELLOW
            {
                {
                    WAPerfectMarshmellow = new ExternalArtifact("Wardrobe.Artifacts.WAPerfectMarshmellow",
                            typeof(WAPerfectMarshmellow),
                            WAPerfectMarshmellowSprite ?? throw new Exception("missing WAPerfectMarshmellow artifact sprite"));

                    WAPerfectMarshmellow.AddLocalisation("PERFECT MARSHMELLOW",
                        "Gain 1 <c=status>AUTOPILOT</c> at the start of each turn.");

                    registry.RegisterArtifact(WAPerfectMarshmellow);
                }
            }
            // Turn End Effects - CLOAK CLASP - RUNIC PYRAMID
            {
                {
                    WACloakClasp = new ExternalArtifact("Wardrobe.Artifacts.WACloakClasp",
                            typeof(WACloakClasp),
                            WACloakClaspSprite ?? throw new Exception("missing WACloakClasp artifact sprite"));

                    WACloakClasp.AddLocalisation("CLOAK CLASP",
                        "At end of turn, gain 1 <c=status>TEMP SHIELD</c> for each card in your hand.");

                    registry.RegisterArtifact(WACloakClasp);
                }
                {
                    WARunicPyramid = new ExternalArtifact("Wardrobe.Artifacts.WARunicPyramid",
                            typeof(WARunicPyramid),
                            WARunicPyramidSprite ?? throw new Exception("missing WARunicPyramid artifact sprite"));

                    WARunicPyramid.AddLocalisation("RUNIC PYRAMID",
                        "At end of turn, no longer discard your hand.");

                    registry.RegisterArtifact(WARunicPyramid);
                }
            }
            // Single Use Effects - ORRERY
            {
                {
                    WAOrrery = new ExternalArtifact("Wardrobe.Artifacts.WAOrrery",
                            typeof(WAOrrery),
                            WAOrrerySprite ?? throw new Exception("missing WAOrrery artifact sprite"));

                    WAOrrery.AddLocalisation("ORRERY",
                        "Choose and add 5 cards to your deck.");

                    registry.RegisterArtifact(WAOrrery);
                }
            }
            // OnGoing Effects - SNECKO EYE - RUNIC DOME - SHOT DUMMY - MARK OF THE BLOOM - N'LOTH'S GIFT
            // TUNGSTEN ROD - SHOVEL - COLLECTION OF TAILS
            {
                {
                    WASneckoEye = new ExternalArtifact("Wardrobe.Artifacts.WASneckoEye",
                            typeof(WASneckoEye),
                            WASneckoEyeSprite ?? throw new Exception("missing WASneckoEye artifact sprite"));

                    WASneckoEye.AddLocalisation("SNECKO EYE",
                        "Draw 2 extra cards per turn. Start each combat <c=status>CONFUSED</c>.");

                    registry.RegisterArtifact(WASneckoEye);
                }
                {
                    WARunicDome = new ExternalArtifact("Wardrobe.Artifacts.WARunicDome",
                            typeof(WARunicDome),
                            WARunicDomeSprite ?? throw new Exception("missing WARunicDome artifact sprite"));

                    WARunicDome.AddLocalisation("RUNIC DOME",
                         "Gain 1 extra <c=energy>ENERGY</c> every turn. <c=hurt>You can no longer see enemy info</c>.");

                    registry.RegisterArtifact(WARunicDome);
                }
                {
                    WAShotDummy = new ExternalArtifact("Wardrobe.Artifacts.WAShotDummy",
                            typeof(WAShotDummy),
                            WAShotDummySprite ?? throw new Exception("missing WAShotDummy artifact sprite"));

                    WAShotDummy.AddLocalisation("SHOT DUMMY",
                         "Cards titled <c=card>SHOT</c> deal 1 extra damage.");

                    registry.RegisterArtifact(WAShotDummy);
                }
                {
                    WAMarkOfTheBloom = new ExternalArtifact("Wardrobe.Artifacts.WAMarkOfTheBloom",
                            typeof(WAMarkOfTheBloom),
                            WAMarkOfTheBloomSprite ?? throw new Exception("missing WAMarkOfTheBloom artifact sprite"));

                    WAMarkOfTheBloom.AddLocalisation("MARK OF THE BLOOM",
                         "You can no longer heal.");

                    registry.RegisterArtifact(WAMarkOfTheBloom);
                }
                {
                    WANLothsGift = new ExternalArtifact("Wardrobe.Artifacts.WANLothsGift",
                            typeof(WANLothsGift),
                            WANLothsGiftSprite ?? throw new Exception("missing WANLothsGift artifact sprite"));

                    WANLothsGift.AddLocalisation("N'LOTH'S GIFT",
                         "Triples the chance of receiving rare cards as card rewards.");

                    registry.RegisterArtifact(WANLothsGift);
                }
                {
                    WATorii = new ExternalArtifact("Wardrobe.Artifacts.WATorii",
                            typeof(WATorii),
                            WAToriiSprite ?? throw new Exception("missing WATorii artifact sprite"));

                    WATorii.AddLocalisation("TORII",
                         "If you would receive 3 or less damage, reduce it to 1.\n<c=hurt>Applies before WEAK and BRITTLE calculations</c>.");

                    registry.RegisterArtifact(WATorii);
                }
                {
                    WAShovel = new ExternalArtifact("Wardrobe.Artifacts.WAShovel",
                            typeof(WAShovel),
                            WAShovelSprite ?? throw new Exception("missing WAShovel artifact sprite"));

                    WAShovel.AddLocalisation("SHOVEL",
                         "You can now <c=card>DIG</c> at repair yards for artifacts.");

                    registry.RegisterArtifact(WAShovel);
                }
                {
                    WACollectionOfTails = new ExternalArtifact("Wardrobe.Artifacts.WACollectionOfTails",
                            typeof(WACollectionOfTails),
                            WACollectionOfTailsSprite ?? throw new Exception("missing WACollectionOfTails artifact sprite"));

                    WACollectionOfTails.AddLocalisation("COLLECTION OF TAILS",
                         "If you have any <c=status>OVERDRIVE</c>, gain 1 at end of turn.");

                    registry.RegisterArtifact(WACollectionOfTails);
                }
            }
        }
        private void DomeRenderLogic(Harmony harmony)
        {
            {
                MethodInfo method1 = typeof(Combat).GetMethod("ShouldDrawEnemyUI", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance) ?? throw new Exception("Couldn't find Combat.ShouldDrawEnemyUI method");
                MethodInfo method2 = typeof(Manifest).GetMethod("DomeHideIntent", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic) ?? throw new Exception("Couldn't find Manifest.DomeHideIntent method");
                harmony.Patch(method1, prefix: new HarmonyMethod(method2));
            }
        }
        private void ShopPatchLogic(Harmony harmony)
        {
            {
                MethodInfo method1 = typeof(Events).GetMethod("NewShop") ?? throw new Exception("Couldn't find Combat.NewShop method");
                MethodInfo method2 = typeof(Manifest).GetMethod("Events_NewShop_Postfix", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic) ?? throw new Exception("Couldn't find Manifest.Events_NewShop_Postfix method");
                harmony.Patch(method1, postfix: new HarmonyMethod(method2));
            }
        }
        private void BloomHealLogic(Harmony harmony)
        {
            {
                MethodInfo method1 = typeof(AHeal).GetMethod("Begin") ?? throw new Exception("Couldn't find AHeal.Begin method");
                MethodInfo method2 = typeof(Manifest).GetMethod("DisableHeal", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic) ?? throw new Exception("Couldn't find Manifest.DisableHeal method");
                harmony.Patch(method1, prefix: new HarmonyMethod(method2));
            }
        }
        private void GiftRarityLogic(Harmony harmony)
        {
            {
                MethodInfo method1 = typeof(CardReward).GetMethod("GetOffering") ?? throw new Exception("Couldn't find CardReward.GetOffering method");
                MethodInfo method2 = typeof(Manifest).GetMethod("GetOffering_Prefix", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic) ?? throw new Exception("Couldn't find Manifest.GetOffering_Prefix method");
                harmony.Patch(method1, prefix: new HarmonyMethod(method2));
            }
        }
        private void PyramidDiscardLogic(Harmony harmony)
        {
            {
                MethodInfo method1 = typeof(AEndTurn).GetMethod("Begin") ?? throw new Exception("Couldn't find AEndTurn.Begin method");
                MethodInfo method2 = typeof(Manifest).GetMethod("AEndTurn_Begin_Prefix", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic) ?? throw new Exception("Couldn't find Manifest.AEndTurn_Begin_Prefix method");
                harmony.Patch(method1, prefix: new HarmonyMethod(method2));
            }
        }

        private static bool DomeHideIntent(G g)
        {
            State state = g.state;
            var artifact = state.EnumerateAllArtifacts().OfType<WARunicDome>().FirstOrDefault();
            if (!(artifact is null))
                return true;
            return false;
        }
        private static void Events_NewShop_Postfix(State s, ref List<Choice> __result)
        {
            var artifact1 = s.EnumerateAllArtifacts().OfType<WAGirya>().FirstOrDefault();
            if (!(artifact1 is null))
            {
                if (!(artifact1.counter == 3))
                {
                    int indexToAppend = __result.FindIndex(c => c.key == ".shopAboutToDestroyYou");
                    if (indexToAppend == -1)
                        indexToAppend = __result.FindIndex(c => c.key == ".shopSkip_Confirm");

                    __result.Insert(indexToAppend, new Choice
                    {
                        label = "Lift (Girya)",
                        key = ".shopUpgradeCard",
                        actions =
                    {
                        new ADelegateAction((_, state, _) => {
                            artifact1.counter++;
                            artifact1.Pulse();
                        })
                    }
                    });
                }
            }
            var artifact2 = s.EnumerateAllArtifacts().OfType<WAShovel>().FirstOrDefault();
            if (!(artifact2 is null))
            {
                int indexToAppend = __result.FindIndex(c => c.key == ".shopAboutToDestroyYou");
                if (indexToAppend == -1)
                    indexToAppend = __result.FindIndex(c => c.key == ".shopSkip_Confirm");

                __result.Insert(indexToAppend, new Choice
                {
                    label = "Dig (Shovel)",
                    key = ".shopUpgradeCard",
                    actions =
                    {
                        new AArtifactOffering(),
                    }
                });
            }
            return;
        }
        private static bool DisableHeal(G g, State s, Combat c)
        {
            var artifact = s.EnumerateAllArtifacts().OfType<WAMarkOfTheBloom>().FirstOrDefault();
            if (artifact is null)
                return true;
            artifact.Pulse();
            return false;
        }
        private static bool GetOffering_Prefix(State s, BattleType battleType = BattleType.Normal, Rarity? rarityOverride = null)
        {
            var artifact = s.EnumerateAllArtifacts().OfType<WANLothsGift>().FirstOrDefault();
            if (artifact is null)
                return true;
            Rarity randomRarity;
            switch (battleType)
            {
                case BattleType.Elite:
                    randomRarity = Mutil.Roll<Rarity>(s.rngCardOfferings.Next(), (0.15, Rarity.common), (0.25, Rarity.uncommon), (0.6, Rarity.rare));
                    break;
                case BattleType.Boss:
                    randomRarity = Rarity.rare;
                    break;
                default:
                    randomRarity = Mutil.Roll<Rarity>(s.rngCardOfferings.Next(), (0.65, Rarity.common), (0.2, Rarity.uncommon), (0.15, Rarity.rare));
                    break;
            }
            rarityOverride = randomRarity;
            return true;
        }
        private static bool AEndTurn_Begin_Prefix(AEndTurn __instance, G g, State s, Combat c)
        {
            var artifact = s.EnumerateAllArtifacts().OfType<WARunicPyramid>().FirstOrDefault();
            if (artifact is null)
                return true;
            artifact.Pulse();
            __instance.timer = 0.0;
            c.isPlayerTurn = false;
            c.Queue((CardAction)new AAfterPlayerTurn());
            return false;
        }
    }
}