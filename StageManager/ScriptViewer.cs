using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace StageManager
{
    public partial class ScriptViewer : UserControl
    {
        DataTable table = new DataTable();

        public ScriptViewer()
        {
            InitializeComponent();
            dataGridView1.ColumnHeadersVisible = false;
        }
        private void ScriptViewer_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
        }

        internal List<string> ReadShows()
        {
            List<string> shows = new List<string>();
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string showsPath = Path.Combine(documentsPath + @"\QLTG_Shows\");
            if (!Directory.Exists(showsPath))
            {
                Directory.CreateDirectory(showsPath);
            }
            var showDirectories = Directory.GetDirectories(showsPath);
            foreach (var showDir in showDirectories)
            {
                string showName = Path.GetFileName(showDir);
                shows.Add(showName);
            }
            return shows;
        }

        internal void ReadExcelFile(string ScriptPath, string Script)
        {

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string FullFileName = Path.Combine(documentsPath + @"\QLTG_Shows\" + ScriptPath + @"\" + Script);


            dataGridView1.SuspendLayout();
            {
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                {
                    LoadExcelWithFormatting(FullFileName, dataGridView1);
                }

                dataGridView1.DefaultCellStyle.WrapMode =  DataGridViewTriState.True;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowsDefaultCellStyle.Padding = new Padding(2, 4, 2, 4);
            }

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridView1.ResumeLayout();

        }
        public void LoadExcelWithFormatting(string path, DataGridView grid)
        {
            var wb = new XLWorkbook(path);
            var ws = wb.Worksheet(1);

            grid.SuspendLayout();
            {
                grid.Rows.Clear();
                grid.Columns.Clear();

                var firstRow = ws.FirstRowUsed();
                int colCount = ws.LastColumnUsed().ColumnNumber();
                // Create columns
                for (int c = 1; c <= colCount; c++)
                {
                    grid.Columns.Add("col" + c, firstRow.Cell(c).GetString());
                }

                // Add rows with formatting
                foreach (var row in ws.RowsUsed().Skip(1))
                {
                    int rowIndex = grid.Rows.Add();

                    for (int c = 1; c <= colCount; c++)
                    {
                        var cell = row.Cell(c);
                        var gridCell = grid.Rows[rowIndex].Cells[c - 1];

                        // ✅ Value
                        gridCell.Value = cell.GetValue<string>();

                        // ✅ Background color
                        var fill = cell.Style.Fill.BackgroundColor;
                        if (fill != null && fill.ColorType == XLColorType.Color)
                        {
                            gridCell.Style.BackColor = Color.FromArgb(
                                fill.Color.R, fill.Color.G, fill.Color.B);
                        }

                        // ✅ Font
                        var font = cell.Style.Font;
                        gridCell.Style.Font = new Font(
                            grid.Font.FontFamily,
                            (float)font.FontSize,
                            (font.Bold ? FontStyle.Bold : FontStyle.Regular) |
                            (font.Italic ? FontStyle.Italic : 0));

                        // ✅ Font color
                        var fontColor = font.FontColor;
                        if (fontColor.ColorType == XLColorType.Color)
                        {
                            gridCell.Style.ForeColor = Color.FromArgb(
                                fontColor.Color.R,
                                fontColor.Color.G,
                                fontColor.Color.B);
                        }
                    }
                }
            }
            grid.ResumeLayout();

        }

        private void ScriptViewer_Resize(object sender, EventArgs e)
        {
            dataGridView1.PerformLayout();
        }
    }
}
