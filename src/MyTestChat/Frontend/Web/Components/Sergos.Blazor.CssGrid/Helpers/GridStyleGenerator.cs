using System.Text;

namespace Sergos.Blazor.CssGrid.Helpers
{
    internal class GridStyleGenerator
    {
        public static void GenerateStyle(ref string style, 
                                         string columnDefinitions, 
                                         string rowDefinitions,
                                         string width,
                                         string height)
        {
            style += "grid-template-columns:" + ReplaceStarToFr(columnDefinitions) + ";";
            style += "grid-template-rows:" + ReplaceStarToFr(rowDefinitions) + ";";
            style += "width:" + width + ";";
            style += "height:" + height + ";";
        }

        #region Private Methods
        private static string ReplaceStarToFr(string input)
        {
            var splits = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var sb = new StringBuilder();

            foreach (var split in splits)
            {
                if (split.Contains("*"))
                {
                    var value = GetStarValue(split);
                    sb.Append(value);
                    sb.Append("fr");
                }
                else
                {
                    sb.Append(split);
                }
                sb.Append(' ');
            }

            return sb.ToString();
        }

        private static double GetStarValue(string input)
        {
            var value = 1.0;

            var splits = input.Split('*');

            if (splits.Length > 0)
            {
                var res = double.TryParse(splits[0], out var value2);
                if (res)
                    value = value2;
            }

            return value;
        }

        #endregion

    }


}
