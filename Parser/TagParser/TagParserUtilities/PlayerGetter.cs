using Exiled.API.Features.Roles;

namespace CustomizableUIMeow.Parser.TagParser.ParserUtilities
{
    using Exiled.API.Features;

    public static class PlayerGetter
    {
        public static Player GetPlayer(TagParserParameter parameter, int index = 0)
        {
            if (parameter.Arguments.IsEmpty())
                return parameter.Player;

            if (!parameter.Arguments.TryDequeue(out var arg))
                return parameter.Player;

            switch (arg.ToLower())
            {
                case "spectatedplayer":
                    if (parameter.Player.Role is SpectatorRole spectator)
                        return spectator.SpectatedPlayer;
                    break;
            }

            return null;
        }
    }
}
