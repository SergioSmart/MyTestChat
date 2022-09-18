using Sergos.Blazor.CssGrid.Enums;
using System.Text;

namespace Sergos.Blazor.CssGrid.Helpers
{
    internal class GridChildGenerator
    {
        public static void GenerateStyle(ref string style, 
            string width, string height, 
            int column, int row, 
            int columnSpan, int rowSpan,
            VerticalAlignment verticalAlignment,
            HorizontalAlignment horizontalAlignment)
        {
            style += "width:" + width + ";";
            style += "height:" + height + ";";
            style += "grid-column: " + GetColumnOrRow(column, columnSpan) + ";";
            style += "grid-row: " + GetColumnOrRow(row, rowSpan) + ";";

            var horizontal = horizontalAlignment switch
            {
                HorizontalAlignment.Stretch => "stretch",
                HorizontalAlignment.Center => "center",
                HorizontalAlignment.Left => "start",
                HorizontalAlignment.Right => "end"
            };
            var vertical = verticalAlignment switch
            {
                VerticalAlignment.Stretch => "stretch",
                VerticalAlignment.Center => "center",
                VerticalAlignment.Top => "start",
                VerticalAlignment.Bottom => "end"
            };


            style += "justify-self: " + horizontal + ";";
            style += "align-self: " + vertical + ";";
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
