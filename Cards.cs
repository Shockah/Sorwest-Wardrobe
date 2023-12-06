using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CobaltCoreModding.Definitions.ExternalItems;
using CobaltCoreModding.Definitions.ModContactPoints;
using CobaltCoreModding.Definitions.ModManifests;
using Wardrobe.Cards;

namespace Wardrobe
{
    public partial class Manifest
    {
        //cards
        public static ExternalCard? WCMiracle {  get; private set; }
        void ICardManifest.LoadManifest(ICardRegistry registry)
        {
            var card_DefaultArt = WCBasicBackgroud;
            if (card_DefaultArt is null)
                throw new Exception("Missing Wardrobe Basic Background");
            {
                WCMiracle = new ExternalCard("Wardrobe.WCMiracle", typeof(WCMiracle), card_DefaultArt, ExternalDeck.GetRaw((int)Deck.colorless));
                registry.RegisterCard(WCMiracle);
                WCMiracle.AddLocalisation("Miracle");
            }
        }
    }
}
