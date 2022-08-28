using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

namespace SeqDistKPlus
{
    public class SequenceData
    {
        public string filePath { get; set; } = "";
        public SequenceType sequenceType { get; set; } = SequenceType.Genome;

        #region 私有字段

        /// <summary>
        /// key:k值   value:ktuple统计值数据
        /// </summary>
        private Dictionary<int, KtupleData> _dicKtuple = new Dictionary<int, KtupleData>();
        /// <summary>
        /// key:k值   value:markove概率值数据
        /// </summary>
        private Dictionary<int, Dictionary<int, MarkovData>> _dicMarkov = new Dictionary<int, Dictionary<int, MarkovData>>();
        /// <summary>
        /// key:k值    value:对应ktuple的统计值总和
        /// </summary>
        private Dictionary<int, int> _dicTotal = new Dictionary<int, int>();
        /// <summary>
        /// 序列的ID
        /// </summary>
        private int _id;
        /// <summary>
        /// 序列整形格式
        /// </summary>
        private List<List<int>> _lsitSequenceInt = new List<List<int>>();

        private Dictionary<int, SuperList<double>> _dicMarkovRtemp = new Dictionary<int, SuperList<double>>();
                                                 //A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z
        private readonly static int[] geneDic =  { 0,-1, 2,-1,-1,-1, 1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 3, 3,-1,-1,-1,-1,-1 };
        private readonly static int[] proteinDic={ 0,-1, 1, 2, 3, 4, 5, 6, 7,-1, 8, 9,10,11,12,13,14,15,16,17,18,19,20,-1,21,-1 };
        //A(0)丙|C(1)半胱|D(2)天冬|E(3)谷|F(4)苯丙|G(5)甘|H(6)组|I(7)异亮|K(8)赖|L(9)亮|M(10)甲硫|N(11)天冬酰胺|O(12)吡咯赖氨酸|P(13)脯氨酸|
        //Q(14)谷氨酰胺|R(15)精|S(16)丝|T(17)苏|U(18)硒半胱|V(19)缬|W(20)色|Y(21)酪
        private static int[] arrDic;

        public Color color { get; set; } = Color.Black;
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="filePath">序列文件的路径</param>
        public SequenceData(string filePath, int id = 0, SequenceType sequenceType = SequenceType.Genome)
        {
            this.sequenceType = sequenceType;
            switch (sequenceType)
            {
                case SequenceType.Genome:
                    arrDic = geneDic;
                    break;
                case SequenceType.Protein:
                    arrDic = proteinDic;
                    break;
            }
            GetSeqText(filePath);
            this.filePath = filePath;
            _id = id;
        }

        public SequenceData(string filePath, Color color, int id = 0, SequenceType sequenceType = SequenceType.Genome) : this(filePath, id, sequenceType)
        {
            this.color = color;
        }

        internal Dictionary<int, KtupleData> Ktuple { get => _dicKtuple; set => _dicKtuple = value; }
        internal Dictionary<int, Dictionary<int, MarkovData>> Markov { get => _dicMarkov; set => _dicMarkov = value; }

        internal Dictionary<int, SuperList<double>> MarkovRtemp { get => _dicMarkovRtemp; set => _dicMarkovRtemp = value; }
        public Dictionary<int, int> DicTotal { get => _dicTotal; set => _dicTotal = value; }
        public int ID { get => _id; set => _id = value; }
        public List<List<int>> SequenceInt { get => _lsitSequenceInt; set => _lsitSequenceInt = value; }




        /// <summary>
        /// 获取序列文本
        /// </summary>
        /// <param name="filePath">序列文件的路径</param>
        private void GetSeqText(string filePath)
        {
            StringBuilder sb = new StringBuilder();
            List<string> listSeqText = new List<string>();
            //Dictionary<char, int> dic = new Dictionary<char, int>(4);
            //dic.Add('A', 0);
            //dic.Add('G', 1);
            //dic.Add('C', 2);
            //dic.Add('T', 3);
            using (StreamReader sr = new StreamReader(filePath, Encoding.ASCII))
            {
                string firstLine = sr.ReadLine();
                if (firstLine[0] != '>')
                    sb.Append(firstLine);
                while (true)
                {
                    string tmp = sr.ReadLine();
                    if (tmp == null)
                        break;
                    sb.Append(tmp);
                }
            }
            switch (sequenceType)
            {
                case SequenceType.Genome:
                    listSeqText.AddRange(sb.ToString().Split(new char[] { 'N' }, StringSplitOptions.RemoveEmptyEntries));
                    break;
                case SequenceType.Protein:
                    listSeqText.AddRange(sb.ToString().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries));
                    break;
            }
            for (int i = 0; i < listSeqText.Count; i++)
            {
                SequenceInt.Add(new List<int>());
                foreach (char item in listSeqText[i])
                {
                    if (item >= 'A' && item <= 'Z')
                    {
                        int key = item - 'A';
                        if (arrDic[key] != -1)
                        {
                            SequenceInt[i].Add(arrDic[key]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 统计ktuple的个数
        /// </summary>
        /// <param name="k">ktuple的字长</param>
        public void CalKtupleCount(int k)
        {
            if (!Ktuple.ContainsKey(k))
            {
                Ktuple.Add(k, new KtupleData());
                int total = 0;
                total = Ktuple[k].CountKtuple(SequenceInt, k, sequenceType);
                DicTotal.Add(k, total);
            }
        }

        /// <summary>
        /// 计算Markov概率
        /// </summary>
        /// <param name="k">ktuple的字长</param>
        /// <param name="m">markov的阶数</param>
        public void CalMarkov(int k, int m)
        {
            if (k <= m || k < 2)
            {
                return;
            }
            if (!_dicMarkov.ContainsKey(k) || !_dicMarkov[k].ContainsKey(m))
            {
                MarkovData md = new MarkovData();
                md.CalMarkov(k, m, this);
                if (Markov.ContainsKey(k))
                {
                    Markov[k].Add(m, md);
                }
                else
                {
                    Markov.Add(k, new Dictionary<int, MarkovData>());
                    Markov[k].Add(m, md);
                }
            }
        }

        /// <summary>
        /// 获取ktuple的数据
        /// </summary>
        /// <param name="k">ktuple的字长</param>
        /// <returns></returns>
        public SuperList<int> GetKtupleData(int k)
        {
            if (!_dicKtuple.ContainsKey(k))
            {
                CalKtupleCount(k);
            }
            return _dicKtuple[k].ListKtuple;
        }

        /// <summary>
        /// 获取ktuple总个数
        /// </summary>
        /// <param name="k">ktuple的字长</param>
        /// <returns></returns>
        public int GetTotal(int k)
        {
            if (!_dicTotal.ContainsKey(k))
            {
                CalKtupleCount(k);
            }
            return DicTotal[k];
        }

        /// <summary>
        /// 获取markov的数据
        /// </summary>
        /// <param name="k">ktuple的字长</param>
        /// <param name="m">markov的阶数</param>
        /// <returns></returns>
        public SuperList<double> GetMarkovData(int k, int m)
        {
            if (!_dicMarkov.ContainsKey(k) || !_dicMarkov[k].ContainsKey(m))
            {
                CalMarkov(k, m);
            }
            return _dicMarkov[k][m].ListMarkov;
        }

        public bool ContainsMarkovKey(int k, int r)
        {
            if (_dicMarkov.ContainsKey(k) && _dicMarkov[k].ContainsKey(r))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 清空数据
        /// </summary>
        public void Clear()
        {
            _dicKtuple = null;
            _dicMarkov = null;
            _dicTotal = null;
            _lsitSequenceInt = null;
            _dicMarkovRtemp = null;
        }
    }
}
