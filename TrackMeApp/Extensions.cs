using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace TrackMeApp
{
    public static class Extensions
    {
        public static Dictionary<ChartColorPalette, List<Color>> PalleteColors = new Dictionary<ChartColorPalette, List<Color>>()
        {
            { ChartColorPalette.Berry , new List<Color>() { StringToColor("8A2BE2") , StringToColor("BA55D3") , StringToColor("4169E1") , StringToColor("C71585") , StringToColor("0000FF") , StringToColor("8019E0") , StringToColor("DA70D6") , StringToColor("7B68EE") , StringToColor("C000C0") , StringToColor("0000CD") , StringToColor("800080") } },
            { ChartColorPalette.Bright , new List<Color>() { StringToColor("008000") , StringToColor("0000FF") , StringToColor("800080") , StringToColor("800080") , StringToColor("FF00FF") , StringToColor("008080") , StringToColor("FFFF00") , StringToColor("808080") , StringToColor("00FFFF") , StringToColor("000080") , StringToColor("800000") , StringToColor("FF3939") , StringToColor("7F7F00") , StringToColor("C0C0C0") , StringToColor("FF6347") , StringToColor("FFE4B5") } },
            { ChartColorPalette.BrightPastel , new List<Color>() { StringToColor("418CF0") , StringToColor("FCB441") , StringToColor("DF3A02") , StringToColor("056492") , StringToColor("BFBFBF") , StringToColor("1A3B69") , StringToColor("FFE382") , StringToColor("129CDD") , StringToColor("CA6B4B") , StringToColor("005CDB") , StringToColor("F3D288") , StringToColor("506381") , StringToColor("F1B9A8") , StringToColor("E0830A") , StringToColor("7893BE") } },
            { ChartColorPalette.Chocolate , new List<Color>() { StringToColor("A0522D") , StringToColor("D2691E") , StringToColor("8B0000") , StringToColor("CD853F") , StringToColor("A52A2A") , StringToColor("F4A460") , StringToColor("8B4513") , StringToColor("C04000") , StringToColor("B22222") , StringToColor("B65C3A") } },
            { ChartColorPalette.EarthTones , new List<Color>() { StringToColor("33023") , StringToColor("B8860B") , StringToColor("C04000") , StringToColor("6B8E23") , StringToColor("CD853F") , StringToColor("C0C000") , StringToColor("228B22") , StringToColor("D2691E") , StringToColor("808000") , StringToColor("20B2AA") , StringToColor("F4A460") , StringToColor("00C000") , StringToColor("8FBC8B") , StringToColor("B22222") , StringToColor("843A05") , StringToColor("C00000") } },
            { ChartColorPalette.Excel , new List<Color>() { StringToColor("9999FF") , StringToColor("993366") , StringToColor("FFFFCC") , StringToColor("CCFFFF") , StringToColor("660066") , StringToColor("FF8080") , StringToColor("0063CB") , StringToColor("CCCCFF") , StringToColor("000080") , StringToColor("FF00FF") , StringToColor("FFFF00") , StringToColor("00FFFF") , StringToColor("800080") , StringToColor("800000") , StringToColor("007F7F") , StringToColor("0000FF") } },
            { ChartColorPalette.Fire , new List<Color>() { StringToColor("FFD700") , StringToColor("FF0000") , StringToColor("FF1493") , StringToColor("DC143C") , StringToColor("FF8C00") , StringToColor("FF00FF") , StringToColor("FFFF00") , StringToColor("FF4500") , StringToColor("C71585") , StringToColor("DDE221") } },
            { ChartColorPalette.Grayscale , new List<Color>() { StringToColor("C8C8C8") , StringToColor("BDBDBD") , StringToColor("B2B2B2") , StringToColor("A7A7A7") , StringToColor("9C9C9C") , StringToColor("919191") , StringToColor("868686") , StringToColor("7A7A7A") , StringToColor("707070") , StringToColor("656565") , StringToColor("565656") , StringToColor("4F4F4F") , StringToColor("424242") , StringToColor("393939") , StringToColor("2E2E2E") , StringToColor("232323") } },
            { ChartColorPalette.Light , new List<Color>() { StringToColor("E6E6FA") , StringToColor("FFF0F5") , StringToColor("FFDAB9") , StringToColor("") , StringToColor("FFFACD") , StringToColor("") , StringToColor("FFE4E1") , StringToColor("F0FFF0") , StringToColor("F0F8FF") , StringToColor("F5F5F5") , StringToColor("FAEBD7") , StringToColor("E0FFFF") } },
            { ChartColorPalette.Pastel , new List<Color>() { StringToColor("87CEEB") , StringToColor("32CD32") , StringToColor("BA55D3") , StringToColor("F08080") , StringToColor("4682B4") , StringToColor("9ACD32") , StringToColor("40E0D0") , StringToColor("FF69B4") , StringToColor("F0E68C") , StringToColor("D2B48C") , StringToColor("8FBC8B") , StringToColor("6495ED") , StringToColor("DDA0DD") , StringToColor("5F9EA0") , StringToColor("FFDAB9") , StringToColor("FFA07A") } },
            { ChartColorPalette.SeaGreen , new List<Color>() { StringToColor("2E8B57") , StringToColor("66CDAA") , StringToColor("4682B4") , StringToColor("008B8B") , StringToColor("5F9EA0") , StringToColor("38B16E") , StringToColor("48D1CC") , StringToColor("B0C4DE") , StringToColor("8FBC8B") , StringToColor("87CEEB") } },
            { ChartColorPalette.SemiTransparent , new List<Color>() { StringToColor("FF6969") , StringToColor("69FF69") , StringToColor("6969FF") , StringToColor("FFFF5D") , StringToColor("69FFFF") , StringToColor("FF69FF") , StringToColor("CDB075") , StringToColor("FFAFAF") , StringToColor("AFFFAF") , StringToColor("AFAFFF") , StringToColor("FFFFAF") , StringToColor("AFFFFF") , StringToColor("FFAFFF") , StringToColor("E4D5B5") , StringToColor("A4B086") , StringToColor("819EC1") } },
            { ChartColorPalette.None, new List<Color>() }
        };

        public static Color StringToColor(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return Color.Black;
            if (value[0] != '#')
                value = value.Insert(0, "#");
            return ColorTranslator.FromHtml(value);
        }
    }
}
