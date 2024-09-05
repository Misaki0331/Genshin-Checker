namespace Genshin_Checker.App.General.Convert
{
    public static class World
    {
        public enum Country
        {
            Mondstadt,
            Liyue,
            Inazuma,
            Sumeru,
            Fontaine,
            Natlan,
            Snezhnaya,
            Khaenriah,
            Celestia,
            DarkSea,
            Unknown,
        }
        public static Color GetBackgroundColor(Country country)
        {
            return country switch
            {
                Country.Mondstadt => Element.GetBackgroundColor(Element.ElementType.Anemo),
                Country.Liyue => Element.GetBackgroundColor(Element.ElementType.Geo),
                Country.Inazuma => Element.GetBackgroundColor(Element.ElementType.Electro),
                Country.Sumeru => Element.GetBackgroundColor(Element.ElementType.Dendro),
                Country.Fontaine => Element.GetBackgroundColor(Element.ElementType.Hydro),
                Country.Natlan => Element.GetBackgroundColor(Element.ElementType.Pyro),
                Country.Snezhnaya => Element.GetBackgroundColor(Element.ElementType.Cryo),
                _ => Color.White
            };
        }

    }
}
