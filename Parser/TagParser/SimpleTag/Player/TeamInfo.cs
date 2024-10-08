﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomizableUIMeow.Parser.TagParser.ParserUtilities;
using CustomizableUIMeow.Parser.TagParser.Player;

namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.PlayerInfo
{
    public class TeamInfo
    {
        [TagParser("PLeadingTeam")]
        public string LeadingTeam(TagParserParameter parameter) => NameTranslator.GetName(PlayerGetter.GetPlayer(parameter).LeadingTeam);

        [TagParser("PTeam")]
        public string Team(TagParserParameter parameter) => NameTranslator.GetName(PlayerGetter.GetPlayer(parameter).Role.Team);
    }
}
