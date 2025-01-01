using CobaltCoreModding.Definitions;
using CobaltCoreModding.Definitions.ExternalItems;
using CobaltCoreModding.Definitions.ModContactPoints;
using CobaltCoreModding.Definitions.ModManifests;
using Microsoft.Extensions.Logging;

namespace Wardrobe
{
    public partial class Manifest :
        ISpriteManifest,
        IArtifactManifest,
        ICardManifest,
        IStatusManifest,
        IGlossaryManifest,
        IPrelaunchManifest
    {
        internal static Manifest Instance = null!;
        internal IMoreDifficultiesApi? MoreDifficultiesApi;
        
        public string Name => "Sorwest.Wardrobe";

        public static System.Drawing.Color Wardrobe_Primary_Color = System.Drawing.Color.FromArgb(255, 255, 255);
        public IEnumerable<DependencyEntry> Dependencies => new DependencyEntry[]
            {
            };
        public DirectoryInfo? ModRootFolder { get; set; }
        public ILogger? Logger { get; set; }
        public DirectoryInfo? GameRootFolder { get; set; }

        //artifact sprites
        public static ExternalSprite? WAEnergySprite { get; private set; }
        public static ExternalSprite? WAEnergyLessDrawSprite { get; private set; }
        public static ExternalSprite? WAEnergyMoreDrawSprite { get; private set; }
        public static ExternalSprite? WADeathCounterSprite_0 { get; private set; }
        public static ExternalSprite? WADeathCounterSprite_1 { get; private set; }
        public static ExternalSprite? WADeathCounterSprite_2 { get; private set; }
        public static ExternalSprite? WADeathCounterSprite_3 { get; private set; }
        public static ExternalSprite? WADeathCounterSprite_4 { get; private set; }
        public static ExternalSprite? WADeathCounterSprite_5 { get; private set; }
        public static ExternalSprite? WADeathCounterSprite_6 { get; private set; }
        public static ExternalSprite? WAIncenseBurnerSprite { get; private set; }
        public static ExternalSprite? WAPocketWatchSprite_0 { get; private set; }
        public static ExternalSprite? WAPocketWatchSprite_1 { get; private set; }
        public static ExternalSprite? WADuVuDollSprite { get; private set; }
        public static ExternalSprite? WAPantographSprite { get; private set; }
        public static ExternalSprite? WACloakClaspSprite { get; private set; }
        public static ExternalSprite? WAOrrerySprite { get; private set; }
        public static ExternalSprite? WASneckoEyeSprite { get; private set; }
        public static ExternalSprite? WARunicDomeSprite { get; private set; }
        public static ExternalSprite? WAGiryaSprite { get; private set; }
        public static ExternalSprite? WAOnTheMeatBoneSprite { get; private set; }
        public static ExternalSprite? WABagOfMarblesSprite { get; private set; }
        public static ExternalSprite? WAPerfectMarshmellowSprite { get; private set; }
        public static ExternalSprite? WAPreservedInsectSprite { get; private set; }
        public static ExternalSprite? WAPureWaterSprite { get; private set; }
        public static ExternalSprite? WAPureWaterV2Sprite { get; private set; }
        public static ExternalSprite? WAPenNibSprite { get; private set; }
        public static ExternalSprite? WAShotDummySprite { get; private set; }
        public static ExternalSprite? WAMarkOfTheBloomSprite { get; private set; }
        public static ExternalSprite? WANLothsGiftSprite { get; private set; }
        public static ExternalSprite? WARunicPyramidSprite { get; private set; }
        public static ExternalSprite? WAToriiSprite { get; private set; }
        public static ExternalSprite? WAShovelSprite { get; private set; }
        public static ExternalSprite? WACollectionOfTailsSprite { get; private set; }

        // statuses sprites
        public static ExternalSprite? ConfusedStatusSprite { get; private set; }
        public static ExternalSprite? PenNibStatusSprite { get; private set; }

        // card sprites
        public static ExternalSprite? WCBasicBackgroud {  get; private set; }
        public static ExternalSprite? WCMiracleSprite { get; private set; }

        // glossary
        public static ExternalGlossary? AConfusedStatus_Glossary { get; private set; }
        void ISpriteManifest.LoadManifest(ISpriteRegistry artRegistry)
        {
            if (this.ModRootFolder == null)
                throw new Exception("Root Folder not set");

            //ARTIFACT SPRITES
            {
                // +/- Energy +/- Draw
                {
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WAEnergySprite.png"));
                        WAEnergySprite = new ExternalSprite("Wardrobe.sprites.WAEnergySprite", new FileInfo(path));
                        artRegistry.RegisterArt(WAEnergySprite);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WAEnergyLessDrawSprite.png"));
                        WAEnergyLessDrawSprite = new ExternalSprite("Wardrobe.sprites.WAEnergyLessDrawSprite", new FileInfo(path));
                        artRegistry.RegisterArt(WAEnergyLessDrawSprite);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WAEnergyMoreDrawSprite.png"));
                        WAEnergyMoreDrawSprite = new ExternalSprite("Wardrobe.sprites.WAEnergyMoreDrawSprite", new FileInfo(path));
                        artRegistry.RegisterArt(WAEnergyMoreDrawSprite);
                    }
                }
                // Death Counter
                {
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WADeathCounterSprite_0.png"));
                        WADeathCounterSprite_0 = new ExternalSprite("Wardrobe.sprites.WADeathCounterSprite_0", new FileInfo(path));
                        artRegistry.RegisterArt(WADeathCounterSprite_0);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WADeathCounterSprite_1.png"));
                        WADeathCounterSprite_1 = new ExternalSprite("Wardrobe.sprites.WADeathCounterSprite_1", new FileInfo(path));
                        artRegistry.RegisterArt(WADeathCounterSprite_1);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WADeathCounterSprite_2.png"));
                        WADeathCounterSprite_2 = new ExternalSprite("Wardrobe.sprites.WADeathCounterSprite_2", new FileInfo(path));
                        artRegistry.RegisterArt(WADeathCounterSprite_2);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WADeathCounterSprite_3.png"));
                        WADeathCounterSprite_3 = new ExternalSprite("Wardrobe.sprites.WADeathCounterSprite_3", new FileInfo(path));
                        artRegistry.RegisterArt(WADeathCounterSprite_3);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WADeathCounterSprite_4.png"));
                        WADeathCounterSprite_4 = new ExternalSprite("Wardrobe.sprites.WADeathCounterSprite_4", new FileInfo(path));
                        artRegistry.RegisterArt(WADeathCounterSprite_4);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WADeathCounterSprite_5.png"));
                        WADeathCounterSprite_5 = new ExternalSprite("Wardrobe.sprites.WADeathCounterSprite_5", new FileInfo(path));
                        artRegistry.RegisterArt(WADeathCounterSprite_5);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WADeathCounterSprite_6.png"));
                        WADeathCounterSprite_6 = new ExternalSprite("Wardrobe.sprites.WADeathCounterSprite_6", new FileInfo(path));
                        artRegistry.RegisterArt(WADeathCounterSprite_6);
                    }
                }
                // PocketWatch
                {
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WAPocketWatchSprite_0.png"));
                        WAPocketWatchSprite_0 = new ExternalSprite("Wardrobe.sprites.WAPocketWatchSprite_0", new FileInfo(path));
                        artRegistry.RegisterArt(WAPocketWatchSprite_0);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WAPocketWatchSprite_1.png"));
                        WAPocketWatchSprite_1 = new ExternalSprite("Wardrobe.sprites.WAPocketWatchSprite_1", new FileInfo(path));
                        artRegistry.RegisterArt(WAPocketWatchSprite_1);
                    }
                }
                // INCENSE BURNER - DU-VU DOLL - PANTOGRAPH - CLOAK CLASP - ORRERY - SNECKO EYE - RUNIC DOME - GIRYA
                {
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WAIncenseBurnerSprite.png"));
                        WAIncenseBurnerSprite = new ExternalSprite("Wardrobe.sprites.WAIncenseBurnerSprite", new FileInfo(path));
                        artRegistry.RegisterArt(WAIncenseBurnerSprite);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WADuVuDollSprite.png"));
                        WADuVuDollSprite = new ExternalSprite("Wardrobe.sprites.WADuVuDollSprite", new FileInfo(path));
                        artRegistry.RegisterArt(WADuVuDollSprite);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WAPantographSprite.png"));
                        WAPantographSprite = new ExternalSprite("Wardrobe.sprites.WAPantographSprite", new FileInfo(path));
                        artRegistry.RegisterArt(WAPantographSprite);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WACloakClaspSprite.png"));
                        WACloakClaspSprite = new ExternalSprite("Wardrobe.sprites.WACloakClaspSprite", new FileInfo(path));
                        artRegistry.RegisterArt(WACloakClaspSprite);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WAOrrerySprite.png"));
                        WAOrrerySprite = new ExternalSprite("Wardrobe.sprites.WAOrrerySprite", new FileInfo(path));
                        artRegistry.RegisterArt(WAOrrerySprite);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WASneckoEyeSprite.png"));
                        WASneckoEyeSprite = new ExternalSprite("Wardrobe.sprites.WASneckoEyeSprite", new FileInfo(path));
                        artRegistry.RegisterArt(WASneckoEyeSprite);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WARunicDomeSprite.png"));
                        WARunicDomeSprite = new ExternalSprite("Wardrobe.sprites.WARunicDomeSprite", new FileInfo(path));
                        artRegistry.RegisterArt(WARunicDomeSprite);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WAGiryaSprite.png"));
                        WAGiryaSprite = new ExternalSprite("Wardrobe.sprites.WAGiryaSprite", new FileInfo(path));
                        artRegistry.RegisterArt(WAGiryaSprite);
                    }
                }
                // ON THE MEAT BONE - BAG OF MARBLES - PERFECT MARSHMELLOW - PRESERVED INSECT - PURE WATER - PURE WATER V2
                {
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WAOnTheMeatBoneSprite.png"));
                        WAOnTheMeatBoneSprite = new ExternalSprite("Wardrobe.sprites.WAOnTheMeatBoneSprite", new FileInfo(path));
                        artRegistry.RegisterArt(WAOnTheMeatBoneSprite);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WABagOfMarblesSprite.png"));
                        WABagOfMarblesSprite = new ExternalSprite("Wardrobe.sprites.WABagOfMarblesSprite", new FileInfo(path));
                        artRegistry.RegisterArt(WABagOfMarblesSprite);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WAPerfectMarshmellowSprite.png"));
                        WAPerfectMarshmellowSprite = new ExternalSprite("Wardrobe.sprites.WAPerfectMarshmellowSprite", new FileInfo(path));
                        artRegistry.RegisterArt(WAPerfectMarshmellowSprite);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WAPreservedInsectSprite.png"));
                        WAPreservedInsectSprite = new ExternalSprite("Wardrobe.sprites.WAPreservedInsectSprite", new FileInfo(path));
                        artRegistry.RegisterArt(WAPreservedInsectSprite);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WAPureWaterSprite.png"));
                        WAPureWaterSprite = new ExternalSprite("Wardrobe.sprites.WAPureWaterSprite", new FileInfo(path));
                        artRegistry.RegisterArt(WAPureWaterSprite);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WAPureWaterV2Sprite.png"));
                        WAPureWaterV2Sprite = new ExternalSprite("Wardrobe.sprites.WAPureWaterV2Sprite", new FileInfo(path));
                        artRegistry.RegisterArt(WAPureWaterV2Sprite);
                    }
                }
                // PEN NIB - SHOT DUMMY - MARK OF THE BLOOM - N'LOTH'S GIFT - RUNIC PYRAMID - TORII - SHOVEL
                {
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WAPenNibSprite.png"));
                        WAPenNibSprite = new ExternalSprite("Wardrobe.sprites.WAPenNibSprite", new FileInfo(path));
                        artRegistry.RegisterArt(WAPenNibSprite);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WAShotDummySprite.png"));
                        WAShotDummySprite = new ExternalSprite("Wardrobe.sprites.WAShotDummySprite", new FileInfo(path));
                        artRegistry.RegisterArt(WAShotDummySprite);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WAMarkOfTheBloomSprite.png"));
                        WAMarkOfTheBloomSprite = new ExternalSprite("Wardrobe.sprites.WAMarkOfTheBloomSprite", new FileInfo(path));
                        artRegistry.RegisterArt(WAMarkOfTheBloomSprite);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WANLothsGiftSprite.png"));
                        WANLothsGiftSprite = new ExternalSprite("Wardrobe.sprites.WANLothsGiftSprite", new FileInfo(path));
                        artRegistry.RegisterArt(WANLothsGiftSprite);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WARunicPyramidSprite.png"));
                        WARunicPyramidSprite = new ExternalSprite("Wardrobe.sprites.WARunicPyramidSprite", new FileInfo(path));
                        artRegistry.RegisterArt(WARunicPyramidSprite);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WAToriiSprite.png"));
                        WAToriiSprite = new ExternalSprite("Wardrobe.sprites.WAToriiSprite", new FileInfo(path));
                        artRegistry.RegisterArt(WAToriiSprite);
                    }
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WAShovelSprite.png"));
                        WAShovelSprite = new ExternalSprite("Wardrobe.sprites.WAShovelSprite", new FileInfo(path));
                        artRegistry.RegisterArt(WAShovelSprite);
                    }
                }
                // COLLECTION OF TAILS
                {
                    {
                        var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Artifact_Icons", Path.GetFileName("WACollectionOfTailsSprite.png"));
                        WACollectionOfTailsSprite = new ExternalSprite("Wardrobe.sprites.WACollectionOfTailsSprite", new FileInfo(path));
                        artRegistry.RegisterArt(WACollectionOfTailsSprite);
                    }
                }
            }
            // STATUS SPRITES
            {
                {
                    var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Status_Icons", Path.GetFileName("ConfusedStatusSprite.png"));
                    ConfusedStatusSprite = new ExternalSprite("Wardrobe.sprites.ConfusedStatusSprite", new FileInfo(path));
                    artRegistry.RegisterArt(ConfusedStatusSprite);
                }
                {
                    var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Status_Icons", Path.GetFileName("PenNibStatusSprite.png"));
                    PenNibStatusSprite = new ExternalSprite("Wardrobe.sprites.PenNibStatusSprite", new FileInfo(path));
                    artRegistry.RegisterArt(PenNibStatusSprite);
                }
            }
            // CARD SPRITES
            {
                {
                    var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Card_BG", Path.GetFileName("WCBasicBackgroud.png"));
                    WCBasicBackgroud = new ExternalSprite("Wardrobe.sprites.WCBasicBackgroud", new FileInfo(path));
                    artRegistry.RegisterArt(WCBasicBackgroud);
                }
                {
                    var path = Path.Combine(ModRootFolder.FullName, "Sprites", "Card_BG", Path.GetFileName("WCMiracleSprite.png"));
                    WCMiracleSprite = new ExternalSprite("Wardrobe.sprites.WCMiracleSprite", new FileInfo(path));
                    artRegistry.RegisterArt(WCMiracleSprite);
                }
            }
        }
        void IGlossaryManifest.LoadManifest(IGlossaryRegisty registry)
        {
            AConfusedStatus_Glossary = new ExternalGlossary("Wardrobe.Glossary.AConfusedStatus_Glossary", "ConfusedStatusGlossary", false, ExternalGlossary.GlossayType.action, ConfusedStatusSprite ?? throw new Exception("Missing ConfusedStatusSprite"));
            AConfusedStatus_Glossary.AddLocalisation("en", "Confused", "The costs of your cards are randomized on draw, from 0 to 3.", null);
            registry.RegisterGlossary(AConfusedStatus_Glossary);
        }
        
        void IPrelaunchManifest.FinalizePreperations(IPrelaunchContactPoint prelaunchManifest)
        {
            Instance = this;
            MoreDifficultiesApi = prelaunchManifest.GetApi<IMoreDifficultiesApi>("TheJazMaster.MoreDifficulties");
        }
    }
}