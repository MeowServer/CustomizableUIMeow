using CustomizableUIMeow.Parser.TagParser.ParserUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizableUIMeow.Parser.TagParser.SimpleTag.PlayerInfo
{
    public class IdInfo
    {
        [TagParser("PId")]
        public object Id(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).Id;

        [TagParser("PNetId")]
        public object NetId(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).NetId;

        [TagParser("PRawUserId")]
        public object RawUserId(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).RawUserId;

        [TagParser("PUnitId")]
        public object UnitId(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).UnitId;

        [TagParser("PUserId")]
        public object UserId(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).UserId;
    }
}
