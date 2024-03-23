using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BicycleCheckList.Core;
using BicycleCheckList.Models;

namespace BicycleCheckList.Services
{
    public class PredefinesTourListService
    {
        const string checkItemsFilename = "checklist.json";
        // Define a map of groups (string) with checkitems (List<string>)
        //static readonly string[] predefinedCategories = ["Rain Clothes", "Bicycle Clothes", "Underwear", "Toilette Arctiles", "First Aid", "Medicine", "Bicycle Gears"];

        public static List<CheckItemGroup> StdTour() =>
            [
                //new CheckItemGroup("Rain Clothes",
                //[
                //    new("Trouser", 1, "en-US"),
                //    new("Shoes", 1, "en-US")
                //]),
                //new CheckItemGroup("Bicycle Gears",
                //[
                //    new("Tube"),
                //    new("Tools")
                //]),
                new CheckItemGroup("Kosmetik",
                [
                    new("Badeschuhe"),
                    new("Sonnencreme"),
                    new("Creme"),
                    new("Papiertaschentücher"),
                    new("Nagelschere / -feile"),
                    new("Nagelknipser"),
                    new("Shampoo"),
                    new("Mundwasser"),
                    new("Kamm / Bürste"),
                    new("Deo"),
                    new("Rasierschaum"),
                    new("Zahnsticks"),
                    new("Zahnpasta"),
                    new("Zahnseide"),
                    new("Zahnbürste"),
                    new("Rasierer + Klingen"),
                    new("Duschgel"),
                ]),
                new CheckItemGroup("Medizin",
                [
                    new("Magnesium"),
                    new("Sonnenallergiemittel"),
                    new("1.Hilfe Päckchen"),
                    new("Voltaren"),
                    new("Schmerztabletten"),
                    new("Solventol Hydrocort"),
                ]),
                new CheckItemGroup("Fahrradkleidung (1 Woche)",
                [
                    new("Helm"),
                    new("Fahrradhandschuhe"),
                    new("Fahrradbrille"),
                    new("Fahrradhose, kurz"),
                    new("Fahrradhose, lang"),
                    new("Regenüberziehschuhe"),
                    new("Regenhose"),
                    new("Regenjacke"),
                    new("Regenschutz Helm"),
                    new("Fahrradjacke"),
                    new("Fahrradhosenpolster", 2),
                    new("Charmois Crème"),
                ]),
                new CheckItemGroup("Fahrradkleidung (1 Woche)",
                [
                    new("Socken (1 Paar pro Tag)"),
                    new("Jeans"),
                    new("Pyjama"),
                    new("Polohemden (2 pro Tag)"),
                    new("Funktionsshirt, lang (2 pro Woche)"),
                    new("Funktionsshirt, kurz (1 pro Tag)"),
                    new("Unterhose (1 pro Tag)"),
                    new("Sweatshirt"),
                    new("Trekkingschuhe"),
                ]),
                new CheckItemGroup("Sonstiges",
                [
                    new("Wasser 3 * 0,5l / Tag"),
                    new("Rei in der Tube"),
                    new("Schutzmaske"),
                ]),
                new CheckItemGroup("Elektronik",
                [
                    new("Smartphone, Kabel, Stecker"),
                    new("Powerbank, Kabel"),
                    new("GPS, Kabel, Ladegerät (Akkus)"),
                ]),
                new CheckItemGroup("Fahrrad", 
                [
                    new("Öl, Lappen"),
                    new("Plastikhandschuhe"),
                    new("Spezialwerkzeug"),
                    new("Panzerband"),
                    new("Minitool"),
                    new("Kabelbinder"),
                    new("Flickzeug"),
                    new("Luftpumpe"),
                    new("Schloss"),
                    new("Ersatzschlauch"),
                ]),
                new CheckItemGroup("Papiere", 
                [
                    new("JHB-Ausweis"),
                    new("Bargeld"),
                    new("Kreditkarte, usw."),
                ]),
            ];

        public static List<CheckItemGroup> ReadFromJson()
        {
            try
            {
                string appDir = FileSystem.Current.AppDataDirectory;
                string json = File.ReadAllText(Path.Combine(appDir, checkItemsFilename));
                List<CheckItemGroup>? checkItems = JsonSerializer.Deserialize<List<CheckItemGroup>>(json);
                if (checkItems != null) { return checkItems; }
                return StdTour();

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return StdTour();
            }
        }

        public static void WriteToJson(List<CheckItemGroup> items)
        {
            string appDir = FileSystem.Current.AppDataDirectory;
            string json = JsonSerializer.Serialize(items, ServiceOptions.jsonOptions);
            File.WriteAllText(Path.Combine(appDir, checkItemsFilename), json);
        }

    }
}