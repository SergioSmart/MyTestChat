using System.Text;

namespace Sergos.Blazor.CssGrid.Helpers
{
    internal class GridChildGenerator
    {
        public static void GenerateStyle(ref string style, 
                                         string width, 
                                         string height,
                                         int column,
                                         int row,
                                         int columnSpan,
                                         int rowSpan)
        {
            style += "width:" + width + ";";
            style += "height:" + height + ";";
            style += "grid-column: " + GetColumnOrRow(column, columnSpan) + ";";
            style += "grid-row: " + GetColumnOrRow(row, rowSpan) + ";";
        }

        #region Private Methods

        private static string GetColumnOrRow(int columnOrRow, int columnOrRowSpan)
        {
            var sb = new StringBuilder();

            sb.Append(columnOrRow > 1 ? columnOrRow : 1);
            sb.Append("/span ");
            sb.Append(columnOrRowSpan > 1 ? columnOrRowSpan : 1);

            return sb.ToString();
        }

        #endregion


    }
}
