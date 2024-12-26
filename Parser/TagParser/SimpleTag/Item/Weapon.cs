using CustomizableUIMeow.Parser.TagParser;
using CustomizableUIMeow.Parser.TagParser.ParserUtilities;

namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.Item
{
    public class Weapon
    {
        [TagParser("IWeaponName")]
        public string WeaponName(TagParserParameter parameter) => NameTranslator.GetName(ItemGetter.GetFirearm(parameter.Player.CurrentItem)?.Type ?? ItemType.None);

        [TagParser("IAmmoName")]
        public string AmmoName(TagParserParameter parameter) => NameTranslator.GetName(ItemGetter.GetFirearm(parameter.Player.CurrentItem)?.AmmoType ?? Exiled.API.Enums.AmmoType.None);

        [TagParser("IWeaponType")]
        public string WeaponType(TagParserParameter parameter) => ItemGetter.GetFirearm(parameter.Player.CurrentItem)?.FirearmType.ToString();

        [TagParser("IAmmoType")]
        public string AmmoType(TagParserParameter parameter) => ItemGetter.GetFirearm(parameter.Player.CurrentItem)?.AmmoType.ToString();

        [TagParser("IWeaponAmmo")]
        public string Ammo(TagParserParameter parameter) => ItemGetter.GetFirearm(parameter.Player.CurrentItem)?.TotalAmmo.ToString();
    }
}
