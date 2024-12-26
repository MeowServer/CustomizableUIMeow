using Exiled.API.Features.Items;

namespace CustomizableUIMeow.Parser.TagParser.ParserUtilities
{
    public static class ItemGetter
    {
        public static Firearm GetFirearm(Exiled.API.Features.Items.Item item)
        {
            if (item is Firearm firearm)
                return firearm;

            return null;
        }
    }
}
