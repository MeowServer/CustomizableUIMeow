using CustomizableUIMeow.Parser.TagParser;
using CustomizableUIMeow.Parser.TagParser.ParserUtilities;

namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.Item
{
    public class Weapon
    {
        [TagParser("IWeaponName")]
        public object WeaponName(TagParserParameter parameter) => NameTranslator.GetName(ItemGetter.GetFirearm(parameter.Player.CurrentItem)?.Type??ItemType.None);

        [TagParser("IAmmoName")]
        public object AmmoName(TagParserParameter parameter) => NameTranslator.GetName(ItemGetter.GetFirearm(parameter.Player.CurrentItem)?.AmmoType ?? Exiled.API.Enums.AmmoType.None);

        [TagParser("IWeaponType")]
        public object WeaponType(TagParserParameter parameter) => ItemGetter.GetFirearm(parameter.Player.CurrentItem)?.FirearmType.ToString();

        [TagParser("IAmmoType")]
        public object AmmoType(TagParserParameter parameter) => ItemGetter.GetFirearm(parameter.Player.CurrentItem)?.AmmoType.ToString();

        [TagParser("IWeaponAmmo")]
        public object Ammo(TagParserParameter parameter) => ItemGetter.GetFirearm(parameter.Player.CurrentItem)?.Ammo.ToString();
    }
}
