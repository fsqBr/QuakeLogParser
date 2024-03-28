using QuakeLogParser.Domain.Entities;
using QuakeLogParser.Domain.Services.Interface;

namespace QuakeLogParser.App
{
    public partial class Form1 : Form
    {

        private readonly IParser _parser;
        private readonly IReportMatch _reportMatch;
        private readonly IResolveJson _resolveJson;

        private string file = Path.Combine($"{Directory.GetCurrentDirectory()}\\qgames.log");
        public Form1(IParser parser, IReportMatch reportMatch, IResolveJson resolveJson)
        {
            this._parser = parser;
            this._reportMatch = reportMatch;
            this._resolveJson = resolveJson;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMatchReport_Click(object sender, EventArgs e)
        {
            var lsGames = ReadLog();
            var lsReport = _reportMatch.GroupedMatch(lsGames, chkWithWeapon.Checked).Result;
            txtResult.Text = _resolveJson.ReturnJson(lsReport).Result;
        }

        private void btnPreviewLog_Click(object sender, EventArgs e)
        {
            var lsGames = ReadLog();
            txtResult.Text = _resolveJson.ReturnJson(lsGames).Result;
        }

        private List<Game> ReadLog()
        {
            try
            {
                return _parser.Read(file).Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ArgumentNullException.ThrowIfNullOrEmpty(txtResult.Text, "Please generate report to save");


                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Json files (*.json)|*.json";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = "ParserLog.json";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, txtResult.Text);
                    MessageBox.Show("File saved successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
