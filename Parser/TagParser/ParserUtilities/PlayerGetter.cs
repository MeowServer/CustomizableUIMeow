﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomizableUIMeow.Parser.SimpleTag.TagParser;
using Exiled.API.Features.Roles;

namespace CustomizableUIMeow.Parser.TagParser.Player
{
    using Exiled.API.Features;

    public static class PlayerGetter
    {
        public static Player GetPlayer(TagParserParameter parameter, int index = 0)
        {
            if (parameter.Arguments.IsEmpty())
                return parameter.Player;

            if(!parameter.Arguments.TryGet(index, out var arg))
                return parameter.Player;

            switch (arg.ToLower())
            {
                case "SpectatedPlayer":
                    if(parameter.Player.Role is SpectatorRole spectator)
                        return spectator.SpectatedPlayer;
                    break;
            }

            return null;
        }
    }
}
