using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomizableUIMeow.Parser.TagParser.Player;

namespace CustomizableUIMeow.Parser.SimpleTag.TagParser.PlayerInfo
{
    //Start with P
    public class Name
    {
        [TagParser("PNickname")]
        public string Nickname(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).Nickname;

        [TagParser("PCustomName")]
        public string CustomName(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).CustomName;

        [TagParser("PRankName")]
        public string RankName(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).RankName;

        [TagParser("PGroupName")]
        public string GroupName(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).GroupName;

        [TagParser("PUnitName")]
        public string PlayerInfoName(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).UnitName;
    }
}
