using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeqDistKPlus
{
    public partial class FormSequence : Form
    {
        private string filePath;

        public FormSequence(string filePath)
        {
            this.filePath = filePath;
            InitializeComponent();
        }

        private void FormSequence_Load(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                var seqText = File.ReadAllText(filePath);
                Text = Path.GetFileNameWithoutExtension(filePath);
                rtbMain.Text = seqText;
            }
        }

        private void rtbMain_TextChanged(object sender, EventArgs e)
        {
            return;
            var patterns = new Dictionary<string, Regex>()
            {
                ["ntA"] = new Regex("[Aa]"),
                ["ntC"] = new Regex("[Cc]"),
                ["ntG"] = new Regex("[Gg]"),
                ["ntT"] = new Regex("[Tt]"),
                ["ntU"] = new Regex("[Uu]"),
                ["ntN"] = new Regex("[NnXx]"),
                ["ntGap"] = new Regex("[-]"),
                ["string"] = new Regex("^>.*"),
            };
            var colors = new Dictionary<string, Color>()
            {
                ["string"] = Color.Yellow,
                ["ntA"] = Color.Green,
                ["ntC"] = Color.Red,
                ["ntG"] = Color.Orange,
                ["ntT"] = Color.Blue,
                ["ntU"] = Color.Violet,
                ["ntN"] = Color.Black,
                ["ntGap"] = Color.White,
            };
            foreach (var pattern in patterns)
            {
                var color = colors[pattern.Key];
                foreach (Match match in pattern.Value.Matches(rtbMain.Text.Substring(0, 1000)))
                {

                    rtbMain.ForeColor = color;
                    if (rtbMain.SelectionColor == Color.White)
                    {
                        rtbMain.SelectionBackColor = Color.Black;
                    }
                }
            }
        }
    }
}
