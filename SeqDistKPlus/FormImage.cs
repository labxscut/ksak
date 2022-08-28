using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeqDistKPlus
{
    public partial class FormImage : Form
    {
        public BinaryNode treeRoot { get; set; }

        public FormImage(string title, BinaryNode treeRoot)
        {
            InitializeComponent();
            Text = title;
            this.treeRoot = treeRoot;
            tcImageType.SelectedIndexChanged += new EventHandler(tcImageType_SelectedIndexChanged);
            Show();
            Repaint();
        }

        private void pbMain_Resize(object sender, EventArgs e)
        {
            Repaint();
        }

        private Painter painter;

        public void Repaint()
        {
            var task = new Task(new Action(() =>
            {
                Thread.Sleep(100);
                Invoke(new Action(() =>
                {
                    painter = new Painter(pbMain.CreateGraphics(), pbMain.Width, pbMain.Height, treeRoot, tcImageType.SelectedIndex, Settings.font);
                }));
            }));
            task.Start();
        }

        private void tcImageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Repaint();
        }
    }
}
