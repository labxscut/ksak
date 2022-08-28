using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeqDistKPlus
{
    public partial class frmMain : Form
    {
        public static Dictionary<string, SequenceData> sequenceDatas { get; private set; } = new Dictionary<string, SequenceData>();
        public static Dictionary<string, SequenceData> outgroupSequenceDatas { get; private set; } = new Dictionary<string, SequenceData>();
        private List<Form> openedForms = new List<Form>();
        private List<(DateTime time, string output)> outputs = new List<(DateTime, string)>();

        public frmMain()
        {
            InitializeComponent();
            this.cbDrawMethod.Text = "UPGMA";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (fbdMain.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(fbdMain.SelectedPath))
                {
                    foreach (var fileName in Directory.GetFiles(fbdMain.SelectedPath))
                    {
                        var color = Color.Black;
                        var configs = Utility.GetFastFileConfigs(fileName);
                        if (configs != null && configs.TryGetValue("color", out var colorStr))
                        {
                            color = ColorTranslator.FromHtml(colorStr);
                        }
                        sequenceDatas[Path.GetFileNameWithoutExtension(fileName)] = new SequenceData(fileName, color);
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ofdMain.ShowDialog() == DialogResult.OK)
            {
                if (ofdMain.FileNames.Length == 0)
                    return;
                // cdMain.ShowDialog();
                foreach (var fileName in ofdMain.FileNames)
                {
                    var color = Color.Black;
                    var configs = Utility.GetFastFileConfigs(fileName);
                    if (configs != null && configs.TryGetValue("color", out var colorStr))
                    {
                        color = ColorTranslator.FromHtml(colorStr);
                    }
                    sequenceDatas[Path.GetFileNameWithoutExtension(fileName)] = new SequenceData(fileName, color);
                }
                RefreshInputListBox();
            }
        }

        private void addOutgroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdMain.ShowDialog() == DialogResult.OK)
            {
                if (ofdMain.FileNames.Length == 0)
                    return;
                foreach (var fileName in ofdMain.FileNames)
                {
                    var color = Color.Black;
                    var configs = Utility.GetFastFileConfigs(fileName);
                    if (configs != null && configs.TryGetValue("color", out var colorStr))
                    {
                        color = ColorTranslator.FromHtml(colorStr);
                    }
                    outgroupSequenceDatas[Path.GetFileNameWithoutExtension(fileName)] = new SequenceData(fileName, color);
                }
                RefreshInputListBox();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            sequenceDatas.Clear();
            RefreshInputListBox();
        }

        private void lvInput_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lvInput_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                //cdMain.ShowDialog();
                foreach (var fileName in fileNames)
                {
                    if (Directory.Exists(fileName))
                    {
                        foreach (var subFileName in LoadDirectory(fileName))
                        {
                            var color = Color.Black;
                            //var configs = Utility.GetFastFileConfigs(subFileName);
                            //if (configs != null && configs.TryGetValue("color", out var colorStr))
                            //{
                            //    color = ColorTranslator.FromHtml(colorStr);
                            //}
                            sequenceDatas[Path.GetFileNameWithoutExtension(subFileName)] = new SequenceData(subFileName, color);
                        }
                    }
                    else if (File.Exists(fileName) && Path.GetExtension(fileName).ToLower() == ".fasta")
                    {
                        var color = Color.Black;
                        var configs = Utility.GetFastFileConfigs(fileName);
                        if (configs != null && configs.TryGetValue("color", out var colorStr))
                        {
                            color = ColorTranslator.FromHtml(colorStr);
                        }
                        sequenceDatas[Path.GetFileNameWithoutExtension(fileName)] = new SequenceData(fileName, color);
                    }
                }
                RefreshInputListBox();
            }
        }

        private List<string> LoadDirectory(string directory)
        {
            var fileNames = new List<string>();
            if (Directory.Exists(directory))
            {
                foreach (var subDirectory in Directory.GetDirectories(directory))
                {
                    fileNames.AddRange(LoadDirectory(subDirectory));
                }
                foreach (var subFile in Directory.GetFiles(directory))
                {
                    if (Path.GetExtension(subFile).ToLower() == ".fasta")
                    {
                        fileNames.Add(subFile);
                    }
                }
            }
            return fileNames;
        }

        private void lvInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                foreach (ListViewItem selectedItem in lvInput.SelectedItems)
                {
                    sequenceDatas.Remove(selectedItem.SubItems[0].Text);
                }
                RefreshInputListBox();
            }
        }

        private void RefreshInputListBox()
        {
            lvInput.Items.Clear();
            lvInput.Items.AddRange((from kv in sequenceDatas
                                    orderby kv.Value.color.GetHashCode()
                                    select new ListViewItem(new string[]
                                    {
                                        Path.GetFileName(kv.Key),
                                        Utility.GetFastaFileSequenceLength(kv.Value.filePath).ToString(),
                                    }, "", Color.FromArgb(kv.Value.color.A, 255 - kv.Value.color.R, 255 - kv.Value.color.G, 255 - kv.Value.color.B), kv.Value.color, lvInput.Font)).ToArray());
            lvInput.Items.AddRange((from kv in outgroupSequenceDatas
                                    orderby kv.Value.color.GetHashCode()
                                    select new ListViewItem(new String[]
                                    {
                                        $"(Outgroup) {Path.GetFileName(kv.Key)}",
                                        Utility.GetFastaFileSequenceLength(kv.Value.filePath).ToString(),
                                    }, "", Color.FromArgb(kv.Value.color.A, 255, 255 - kv.Value.color.G, 255 - kv.Value.color.B), kv.Value.color, lvInput.Font)).ToArray());
        }

        private void nudKMin_ValueChanged(object sender, EventArgs e)
        {
            mmbK.MinValue = (int)nudKMin.Value;
        }

        private void nudKMax_ValueChanged(object sender, EventArgs e)
        {
            mmbK.MaxValue = (int)nudKMax.Value;
        }

        private void mmbK_Scroll(object sender, ScrollEventArgs e)
        {
            nudKMin.Value = mmbK.MinValue;
            nudKMax.Value = mmbK.MaxValue;
        }

        private void mmbM_Scroll(object sender, ScrollEventArgs e)
        {
            nudMMin.Value = mmbM.MinValue;
            nudMMax.Value = mmbM.MaxValue;
        }

        private void nudMMin_ValueChanged(object sender, EventArgs e)
        {
            mmbM.MinValue = (int)nudMMin.Value;
        }

        private void nudMMax_ValueChanged(object sender, EventArgs e)
        {
            mmbM.MaxValue = (int)nudMMax.Value;
        }

        private void pbMain_DoubleClick(object sender, EventArgs e)
        {
            if (painter == null)
                return;
            var title = $"{tcAlgebra.SelectedTab.Text}_{tcRangeK.SelectedTab.Text}";
            if (tcRangeM.Visible)
            {
                title += $"_{tcRangeM.SelectedTab.Text}";
            }
            var formImage = new FormImage(title, painter?.TreeRoot);
            openedForms.Add(formImage);
        }

        private void lvInput_DoubleClick(object sender, EventArgs e)
        {
            // 打开序列查看弹窗
            var selectedItem = lvInput.SelectedItems;
            if (selectedItem.Count > 0)
            {
                var filePath = sequenceDatas[selectedItem[0].SubItems[0].Text].filePath;
                var formSequence = new FormSequence(filePath);
                formSequence.Show();
                openedForms.Add(formSequence);
            }
        }

        private void clbAlgebra_DoubleClick(object sender, EventArgs e)
        {
            for (int i = 0; i < clbAlgebra.Items.Count; i++)
            {
                if (!clbAlgebra.GetItemChecked(i))
                {
                    for (int j = i; j < clbAlgebra.Items.Count; j++)
                    {
                        clbAlgebra.SetItemChecked(j, true);
                    }
                    return;
                }
            }
            for (int i = 0; i < clbAlgebra.Items.Count; i++)
            {
                clbAlgebra.SetItemChecked(i, false);
            }
        }

        Task task;
        Dictionary<string, string> trees = new Dictionary<string, string>();
        Dictionary<string, BinaryNode> treeRoots = new Dictionary<string, BinaryNode>();
        Dictionary<string, double[][]> matrixes = new Dictionary<string, double[][]>();
        Dictionary<string, List<string>> names = new Dictionary<string, List<string>>();
        int drawMethod;

        private void btnPaint_Click(object sender, EventArgs e)
        {
            if (task != null && task.Status == TaskStatus.Running)
            {
                var result = MessageBox.Show("The working procees will be killed.", "Confirm", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    task = null;
                    btnGenerate.Text = "Generate";
                }
                return;
            }
            btnGenerate.Text = "Stop";
            var op = new Operation();
            Operation._cpu = Environment.ProcessorCount;
            var listK = new List<int>();
            var listM = new List<int>();
            var listFun = new List<string>();
            for (int k = mmbK.MinValue; k <= mmbK.MaxValue; k++)
                listK.Add(k);
            for (int m = mmbM.MinValue; m <= mmbM.MaxValue; m++)
                listM.Add(m);
            foreach (string algebra in clbAlgebra.CheckedItems)
                listFun.Add(algebra);
            task = new Task(() =>
            {
                Invoke(new Action(() =>
                {
                    tspMain.Value = 0;
                    tsslOutput.Text = "Start!";
                }));
                // SeqDistK


                    var result = op.Star((from sequenceData in sequenceDatas.Values.Union(outgroupSequenceDatas.Values)
                                          select sequenceData.filePath).ToList(), (progress) =>
                                          {
                                              Invoke(new Action(() => {
                                                  if (progress > 0)
                                                  {
                                                      tspMain.Style = ProgressBarStyle.Blocks;
                                                      tspMain.Value = progress;
                                                  }
                                                  else
                                                  {
                                                      tspMain.Style = ProgressBarStyle.Marquee;
                                                      tspMain.Value = 0;
                                                  }
                                              }));
                                          }, (output) =>
                                          {
                                              outputs.Add((DateTime.Now, output));
                                              Invoke(new Action(() => tsslOutput.Text = output));
                                          }, false, SequenceType.Genome, listK, listM, listFun);
                    // drawTree
                    trees.Clear();
                    treeRoots.Clear();
                    matrixes.Clear();
                    names.Clear();
                    foreach (var dsts in result.result.DicResult)
                    {
                        // 二维转交错
                        var arr = new double[dsts.Value.GetLength(0)][];
                        for (int i = 0; i < arr.Length; i++)
                        {
                            var arrLine = arr[i] = new double[dsts.Value.GetLength(1)];
                            for (int j = 0; j < arr[i].Length; j++)
                            {
                                arrLine[j] = dsts.Value[i, j];
                            }
                        }
                        var tree = "";
                        switch (drawMethod)
                        {
                            case 0:
                                tree = Tree.Upgma(
                                    result.seqNames.ToArray(),
                                    (from _ in result.seqNames
                                     select 1).ToArray(),
                                    arr);
                                break;
                            case 1:
                                tree = Tree.Nj(
                                    result.seqNames.ToArray(),
                                    (from _ in result.seqNames
                                     select 1).ToArray(),
                                    arr);
                                break;
                        }
                        trees.Add(dsts.Key, tree);
                        var t = Painter.BuildTree(tree);
                        if (outgroupSequenceDatas.Count > 0) { 
                            t = RemakeTreeByOutgroup(t);
                        }
                        treeRoots.Add(dsts.Key, t);
                        matrixes.Add(dsts.Key, arr);
                        names.Add(dsts.Key, result.seqNames);
                    }
                    Invoke(new Action(RefreshTabControls));
                    Invoke(new Action(RepaintTree));
                    Invoke(new Action(() =>
                    {
                        btnGenerate.Text = "Run";
                    }));
            });
            task.Start();
        }

        private void RefreshTabControls()
        {
            tcAlgebra.TabPages.Clear();
            tcRangeK.TabPages.Clear();
            tcRangeM.TabPages.Clear();
            for (int i = 0; i < clbAlgebra.Items.Count; i++)
            {
                if (clbAlgebra.GetItemChecked(i))
                {
                    tcAlgebra.TabPages.Add((string)clbAlgebra.Items[i]);
                }
            }
            for (int i = mmbK.MinValue; i <= mmbK.MaxValue; i++)
                tcRangeK.TabPages.Add($"k{i}");
            for (int i = mmbM.MinValue; i <= mmbM.MaxValue; i++)
                tcRangeM.TabPages.Add($"M{i}");
        }

        private int progress;
        private string output;

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            tspMain.Value = progress;
            tsslOutput.Text = output;
        }

        private Painter painter;

        private void RepaintTree()
        {
            if (tcAlgebra.SelectedTab != null && tcRangeK.SelectedTab != null && tcRangeM.SelectedTab != null)
            {
                var algebra = tcAlgebra.SelectedTab.Text;
                var k = tcRangeK.SelectedTab.Text;
                var m = tcRangeM.SelectedTab.Text;
                var hasM = (algebra == "d2S" || algebra == "d2star");
                if (treeRoots.TryGetValue(hasM ? $"{algebra}_{k}_{m}" : $"{algebra}_{k}", out var treeRoot))
                {
                    var task = new Task(new Action(() =>
                    {
                        var graphics = pbMain.CreateGraphics();
                        Thread.Sleep(100);
                        Invoke(new Action(() =>
                        {
                            painter = new Painter(graphics, pbMain.Width, pbMain.Height, treeRoot, tcImageType.SelectedIndex, Settings.font);
                        }));
                    }));
                    task.Start();
                    //painter.Mode = tcImageType.SelectedIndex;
                    //painter.Width = pbMain.Width;
                    //painter.Height = pbMain.Height;
                    //painter.TreeDesc = treeDesc;
                    //painter.Repaint();
                }
                else
                {

                }
            }
        }

        private BinaryNode RemakeTreeByOutgroup(BinaryNode treeRoot)
        {
            var parentDict = new Dictionary<BinaryNode, BinaryNode>();
            var outgroupNodes = new HashSet<BinaryNode>();
            var newTreeRoot = (BinaryNode)null;
            var walkFunc = (Action<BinaryNode>)null;
            var isRight = false;
            walkFunc = new Action<BinaryNode>((node) =>
            {
                if (node.value != null)
                {
                    if (outgroupSequenceDatas.ContainsKey(node.value))
                    {
                        outgroupNodes.Add(node);
                        newTreeRoot = node;
                    }
                    return;
                }
                var leftChild = node.leftChild;
                var rightChild = node.rightChild;
                parentDict[leftChild] = node;
                parentDict[rightChild] = node;
                walkFunc.Invoke(leftChild);
                walkFunc.Invoke(rightChild);
                if (outgroupNodes.Contains(leftChild) && outgroupNodes.Contains(rightChild))
                {
                    outgroupNodes.Add(node);
                    newTreeRoot = node;
                }
            });
            walkFunc.Invoke(treeRoot);
            var parentNode = parentDict[newTreeRoot];
            isRight = parentNode.rightChild == newTreeRoot;
            newTreeRoot = parentNode;
            if (newTreeRoot == treeRoot)
            {
                return treeRoot;
            }

            // 反转
            var handlingNode = newTreeRoot;
            var lastHandlingNode = (BinaryNode)null;
            var lastIsRight = false;
            var outgroupNode = isRight ? handlingNode.rightChild : handlingNode.leftChild;
            while (parentDict.ContainsKey(handlingNode))
            {
                parentNode = parentDict[handlingNode];
                if (isRight)
                {
                    handlingNode.rightChild = parentNode;
                }
                else
                {
                    handlingNode.leftChild = parentNode;
                }
                lastIsRight = isRight;
                isRight = parentNode.rightChild == handlingNode;
                lastHandlingNode = handlingNode;
                handlingNode = parentNode;
            }

            if (lastHandlingNode is null)
            {
                if (isRight)
                {
                    return handlingNode.leftChild;
                }
                else
                {
                    return handlingNode.rightChild;
                }
            }

            if (lastIsRight)
            {
                lastHandlingNode.rightChild = isRight ? handlingNode.leftChild : handlingNode.rightChild;
                //lastHandlingNode.leftChild = outgroupNode;
            }
            else
            {
                lastHandlingNode.leftChild = isRight ? handlingNode.leftChild : handlingNode.rightChild;
                //lastHandlingNode.rightChild = outgroupNode;
            }

            var finalNode = new BinaryNode();
            finalNode.leftChild = newTreeRoot;
            finalNode.rightChild = outgroupNode;

            return finalNode;
        }

        private void tcAlgebra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcAlgebra.SelectedTab != null)
            {
                if (tcAlgebra.SelectedTab.Text == "d2star" || tcAlgebra.SelectedTab.Text == "d2S")
                {
                    tcRangeM.Visible = true;
                }
                else
                {
                    tcRangeM.Visible = false;
                }
                RepaintTree();
            }
        }

        private void tcRangeK_SelectedIndexChanged(object sender, EventArgs e)
        {
            RepaintTree();
        }

        private void tcRangeM_SelectedIndexChanged(object sender, EventArgs e)
        {
            RepaintTree();
        }

        private void tcImageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RepaintTree();
        }

        private void pbMain_Resize(object sender, EventArgs e)
        {
            if (painter != null)
            {
                painter.Graphics = pbMain.CreateGraphics();
                painter.Width = pbMain.Width;
                painter.Height = pbMain.Height;
                painter.Repaint();
            }
        }

        private void cbDrawMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawMethod = cbDrawMethod.SelectedIndex;
        }

        private void lvInput_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu = new ContextMenu(new MenuItem[]
                {
                    new MenuItem("Delete", new EventHandler((object sender2, EventArgs e2) =>
                    {
                        foreach (ListViewItem selectedItem in lvInput.SelectedItems)
                        {
                            sequenceDatas.Remove(selectedItem.Text);
                        }
                        RefreshInputListBox();
                    })),
                    new MenuItem("Set Color", new EventHandler((object sender2, EventArgs e2) =>
                    {
                        if (cdMain.ShowDialog() == DialogResult.OK){
                            foreach (ListViewItem selectedItem in lvInput.SelectedItems)
                            {
                                sequenceDatas[selectedItem.Text].color = cdMain.Color;
                            }
                            RefreshInputListBox();
                        }
                    })),
                });
                ContextMenu.Show(lvInput, e.Location);
            }
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu = new ContextMenu(new MenuItem[]
                {
                    new MenuItem("Save", new EventHandler((object sender2, EventArgs e2) =>
                    {
                        if (tcRangeM.Visible)
                        {
                            sfdMain.FileName = $"{tcAlgebra.SelectedTab.Text}_{tcRangeK.SelectedTab.Text}_{tcRangeM.SelectedTab.Text}";
                        }
                        else
                        {
                            sfdMain.FileName = $"{tcAlgebra.SelectedTab.Text}_{tcRangeK.SelectedTab.Text}";
                        }
                        sfdMain.Filter = "Image(*.bmp)|*.bmp|Text(*.txt)|*.txt|Matrix(*.csv)|*.csv";
                        sfdMain.ShowDialog();
                        var path = sfdMain.FileName;
                        if (!string.IsNullOrWhiteSpace(path)){
                            switch (sfdMain.FilterIndex)
                            {
                                case 1:
                                    // Image
                                    var bmp = new Bitmap(pbMain.Width, pbMain.Height);
                                    var picPainter = new Painter(Graphics.FromImage(bmp), pbMain.Width, pbMain.Height, painter.TreeRoot, painter.Mode, fdMain.Font);
                                    bmp.Save(path);
                                    break;
                                case 2:
                                    // Text
                                    File.WriteAllText(path, $"{painter.TreeRoot};");
                                    break;
                                case 3:
                                    // Tensor
                                    var algebra = tcAlgebra.SelectedTab.Text;
                                    var k = tcRangeK.SelectedTab.Text;
                                    var m = tcRangeM.SelectedTab.Text;
                                    double[][] matrix;
                                    var hasM = (algebra == "d2S" || algebra == "d2star");
                                    if (matrixes.TryGetValue(hasM ? $"{algebra}_{k}_{m}" : $"{algebra}_{k}", out matrix))
                                    {
                                        var name = names[hasM ? $"{algebra}_{k}_{m}" : $"{algebra}_{k}"];
                                        var builder = new StringBuilder();
                                        builder.Append(",");
                                        builder.Append($"{string.Join(",", name)}\r\n");
                                        for (var i = 0; i < matrix.Length; i++)
                                        {
                                            builder.Append($"{name[i]},{string.Join(",", matrix[i])}\r\n");
                                        }
                                        try
                                        {
                                            File.WriteAllText(path, builder.ToString());
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }
                                    }
                                    break;
                            }
                        }
                    })),
                    new MenuItem("Save All Images", new EventHandler((object sender2, EventArgs e2) =>
                    {
                        fbdMain.ShowDialog();
                        var path = fbdMain.SelectedPath;
                        if (!string.IsNullOrWhiteSpace(path))
                        {
                            var bmp = new Bitmap(pbMain.Width, pbMain.Height);
                            if (treeRoots != null)
                            {
                                foreach (var kv in treeRoots)
                                {
                                    var picPainter = new Painter(Graphics.FromImage(bmp), pbMain.Width, pbMain.Height, kv.Value, painter.Mode, fdMain.Font);
                                    bmp.Save(Path.Combine(path, $"{kv.Key}.bmp"));
                                }
                            }
                        }
                    })),
                    new MenuItem("Save All Trees", new EventHandler((object sender2, EventArgs e2) =>
                    {
                        fbdMain.ShowDialog();
                        var path = fbdMain.SelectedPath;
                        if (!string.IsNullOrWhiteSpace(path))
                        {
                            if (treeRoots != null)
                            {
                                foreach (var kv in treeRoots)
                                {
                                    File.WriteAllText(Path.Combine(path, $"{kv.Key}.txt"), kv.Value.ToString());
                                }
                            }
                        }
                    })),
                    new MenuItem("Save All Matrixes", new EventHandler((object sender2, EventArgs e2) =>
                    {
                        fbdMain.ShowDialog();
                        var path = fbdMain.SelectedPath;
                        if (treeRoots != null)
                        {
                            foreach (var kv in matrixes)
                            {
                                var name = names[kv.Key];
                                var builder = new StringBuilder();
                                builder.Append(",");
                                builder.Append($"{string.Join(",", name)}\r\n");
                                for (var i = 0; i < kv.Value.Length; i++)
                                {
                                    builder.Append($"{name[i]},{string.Join(",", kv.Value[i])}\r\n");
                                }
                                try
                                {
                                    File.WriteAllText(Path.Combine(path, $"{kv.Key}.csv"), builder.ToString());
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                    }))
                });
                ContextMenu.Show(pbMain, e.Location);
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (painter != null)
                {
                    foreach (var kv in painter.nodePositions)
                    {
                        if (Math.Abs(e.Location.X - kv.Key.X) + Math.Abs(e.Location.Y - kv.Key.Y) < 10)
                        {
                            var node = kv.Value;
                            var temp = node.leftChild;
                            node.leftChild = node.rightChild;
                            node.rightChild = temp;
                            break;
                        }
                    }
                    painter.Repaint();
                }
            }
        }

        private void tsmiImageFont_Click(object sender, EventArgs e)
        {
            fdMain.ShowDialog();
            Settings.font = fdMain.Font;
            RepaintTree();
        }

        private void tsmiChinese_Click(object sender, EventArgs e)
        {
            tsmiSettings.Text = "设置";
            tsmiImageFont.Text = "序列名字体";
            tsmiLanguage.Text = "语言";
            gbInput.Text = "输入";
            lvInput.Columns[0].Text = "序列名称";
            lvInput.Columns[1].Text = "长度";
            btnClear.Text = "清空";
            btnAdd.Text = "添加";
            gbConfig.Text = "聚类算法";
            gbK.Text = "K-mer 长度";
            gbM.Text = "马尔可夫距离（用于 d2S 和 d2Star）";
            gbDrawMethod.Text = "绘制方法";
            btnGenerate.Text = "生成";
            gbTree.Text = "树";
            tcImageType.TabPages[0].Text = "标准";
            tcImageType.TabPages[1].Text = "圆形";
        }

        private void tsmiEnglish_Click(object sender, EventArgs e)
        {
            tsmiSettings.Text = "Settings";
            tsmiImageFont.Text = "Image Font";
            tsmiLanguage.Text = "Language";
            gbInput.Text = "Input";
            lvInput.Columns[0].Text = "Sequence";
            lvInput.Columns[1].Text = "Length";
            btnClear.Text = "Clear";
            btnAdd.Text = "Add";
            gbConfig.Text = "Distance";
            gbK.Text = "K-mer length";
            gbM.Text = "Malkov model ( for d2S and d2Star )";
            gbDrawMethod.Text = "Draw Method";
            btnGenerate.Text = "Generate";
            gbTree.Text = "Tree";
            tcImageType.TabPages[0].Text = "Standard";
            tcImageType.TabPages[1].Text = "Circular";
        }

        private void clbAlgebra_MouseMove(object sender, MouseEventArgs e)
        {
            var top = clbAlgebra.Top;
            var bottom = clbAlgebra.Bottom;
            var i = 0;
            for (i = 0; i < clbAlgebra.Items.Count; i++)
            {
                bottom = top + clbAlgebra.GetItemHeight(i);
                if (e.Y < bottom)
                {
                    break;
                }
                top = bottom;
            }
            if (i >= clbAlgebra.Items.Count) i = clbAlgebra.Items.Count - 1;
            switch (clbAlgebra.Items[i])
            {
                case "Eu":
                    ttAlgebra.SetToolTip(clbAlgebra, "欧氏距离 Euclidean");
                    break;
                case "Ma":
                    ttAlgebra.SetToolTip(clbAlgebra, "马氏距离 Mahalanobis");
                    break;
                case "Ch":
                    ttAlgebra.SetToolTip(clbAlgebra, "切比雪夫距离 Chebyshev");
                    break;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (MessageBox.Show(this, "Save color config?", "Wait!", MessageBoxButtons.YesNoCancel))
            {
                case DialogResult.Yes:
                    foreach (var sequenceData in sequenceDatas.Values)
                    {
                        SaveColor(sequenceData);
                    }
                    break;
                case DialogResult.No:
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }

        private void SaveColor(SequenceData sequenceData)
        {
            if (File.Exists(sequenceData.filePath))
            {
                var sb = new StringBuilder();
                foreach (var line in File.ReadLines(sequenceData.filePath))
                {
                    var newLine = line;
                    if (line.StartsWith(">"))
                    {
                        newLine = Utility.RemoveConfigs(line);
                        if (sequenceData.color != Color.Black)
                        {
                            newLine += Utility.SerializeConfigs(new Dictionary<string, string>
                            {
                                ["color"] = ColorTranslator.ToHtml(sequenceData.color),
                            });
                        }
                    }
                    sb.AppendLine(newLine);
                }
                File.WriteAllText(sequenceData.filePath, sb.ToString());
            }
        }

        private void tsslOutput_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Join("\n", from output in outputs
                                              select $"[{output.time.Hour}:{output.time.Minute}:{output.time.Second}] {output.output}"));
        }

        private void cbUseSuper_CheckedChanged(object sender, EventArgs e)
        {
            Settings.useSuperList = cbUseSuper.Checked;
        }

        private void addOutgroupToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }
    }
}
