namespace GameCore.Domain
{
    /// <summary>
    /// Author      : Emmanuel Nuyttens
    /// Date        : 02-2020
    /// Purpose     : Magical Item class
    /// Info        : Represents an item of magical power in the 
    ///               Goldorak game such as:
    ///               -fulguro point, asterohache, retrolaser, pulvonium, cornofulgure
    ///               -planitron, clavicogyre, megavolts, missilesgamma
    /// 
    /// </summary>
    public class MagicalItem
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Power { get; set; }

    }
}
