using Raylib_cs;
using static System.Net.Mime.MediaTypeNames;

namespace tarot_card_battler.Util
{
    public static class TextRendering
    {
        public static void RenderLines(string text, int fontSize, Color textColor, int x, int y, int maxWidth)
        {
            List<string> words = text.Split(" ").ToList();

            List<string> lines = new List<string>();
            string line = "";

            while (words.Count > 0)
            {
                string word = words[0];
                words.RemoveAt(0);

                string newLine = line == "" ? word : line + " " + word;
                int width = Raylib.MeasureText(newLine, fontSize);
                if (width > maxWidth)
                {
                    lines.Add(line);
                    line = word;
                } else
                {
                    line = newLine;
                }
            }
            lines.Add(line);

            int lineSpacing = 1;

            int n = 0;
            foreach (string l in lines)
            {
                Raylib.DrawText(l, x, y + (fontSize + lineSpacing) * n, fontSize, textColor);
                n++;
            }

        }
    }
}
