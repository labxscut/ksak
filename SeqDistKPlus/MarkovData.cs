using System;
using System.Linq;
using System.Collections.Generic;

namespace SeqDistKPlus
{
    class MarkovData
    {
        private SuperList<double> _listMarkov = new SuperList<double>();
        private Dictionary<int, SuperList<double>> _dicRtemp;

        public SuperList<double> ListMarkov { get => _listMarkov; set => _listMarkov = value; }
        public Dictionary<int, SuperList<double>> DicRtemp { get => _dicRtemp; set => _dicRtemp = value; }

        private SuperList<double> CalMarkovPossibility(int k, int r, int total, SuperList<int> list1, SuperList<int> list2, SequenceType sequenceType)
        {
            long count = 0;
            switch (sequenceType)
            {
                case SequenceType.Genome:
                    count = 1L << (k << 1);   //4的k次方
                    break;
                case SequenceType.Protein:
                    count = (long)Math.Pow(32, k);
                    break;
            }
            SuperList<double> arrPos = new SuperList<double>(count);

            SuperList<double> arr;

            if (DicRtemp.ContainsKey(r))
            {
                arr = DicRtemp[r];
            }
            else
            {
                arr = new SuperList<double>(list2.LongCount);
                for (long i = 0; i < list2.LongCount; i += GetSequenceTypeCount(sequenceType))
                {
                    double tmp = list2[i] + list2[i + 1] + list2[i + 2] + list2[i + 3];
                    for (int j = 0; j < GetSequenceTypeCount(sequenceType); j++)
                    {
                        if (tmp != 0)
                        {
                            arr[i + j] = list2[i + j] / tmp;
                        }
                    }
                }
                DicRtemp.Add(r, arr);
            }


            int end = k - r;
            long rCount = 0;
            switch (sequenceType)
            {
                case SequenceType.Genome:
                    rCount = 1L << (r << 1);     //4的r次方
                    break;
                case SequenceType.Protein:
                    rCount = (long)Math.Pow(32, r);
                    break;
            }
            long b = rCount - 1;

            for (int i = 0; i < rCount; i++)
            {
                double res = list1[i] * 1.0 / total;
                RecursionCal(i, res, arr, i, 0, end, arrPos, b, sequenceType);
            }

            return arrPos;
        }

        private SuperList<double> CalMarkovPossibility(int k, int r, SequenceData sd)
        {
            SuperList<double> preMarkov = sd.GetMarkovData(k - 1, r);
            long b = 0;
            switch (sd.sequenceType)
            {
                case SequenceType.Genome:
                    b = (1L << (r << 1)) - 1;  //4的r次方-1
                    break;
                case SequenceType.Protein:
                    b = (long)Math.Pow(32, r) - 1;
                    break;
            }
            SuperList<double> arr = sd.MarkovRtemp[r];
            long count = 0;
            switch (sd.sequenceType)
            {
                case SequenceType.Genome:
                    count = 1L << (k << 1);   //4的k次方
                    break;
                case SequenceType.Protein:
                    count = (long)Math.Pow(32, k);
                    break;
            }
            SuperList<double> arrPos = new SuperList<double>(count);

            long tmp = 0;
            long key = 0;
            long rKey = 0;
            for (long i = 0; i < preMarkov.LongCount; i++)
            {
                tmp = (b & i) * GetSequenceTypeCount(sd.sequenceType);
                key = i * GetSequenceTypeCount(sd.sequenceType);
                for (int j = 0; j < GetSequenceTypeCount(sd.sequenceType); j++)
                {
                    rKey = tmp + j;
                    arrPos[key + j] = preMarkov[i] * arr[rKey];
                }
            }
            return arrPos;
        }

        public static int GetSequenceTypeCount(SequenceType sequenceType)
        {
            switch (sequenceType)
            {
                case SequenceType.Genome:
                    return Constances.DNA_COUNTS;
                case SequenceType.Protein:
                    return Constances.PROTEIN_COUNTS;
            }
            return -1;
        }

        /// <summary>
        /// 递归求解Markov概率
        /// </summary>
        /// <param name="rKey">（r-1）个符号</param>
        /// <param name="res"></param>
        /// <param name="arr">对应rKey的概率</param>
        /// <param name="key">累计转移的整体key</param>
        /// <param name="count">当前递归深度</param>
        /// <param name="end">递归深度次数（k-r）</param>
        /// <param name="arrMarkov">用来保存Markov概率结果</param>
        /// <param name="b">用来清rKey的最高位</param>
        private void RecursionCal(long rKey, double res, SuperList<double> arr, long key, int count, int end, SuperList<double> arrMarkov, long b, SequenceType sequenceType)
        {
            count++;
            if (end == count)
            {
                key = key * GetSequenceTypeCount(sequenceType);
                rKey = rKey * GetSequenceTypeCount(sequenceType);
                arrMarkov[key] = res * arr[rKey];
                for (int i = 1; i < GetSequenceTypeCount(sequenceType); i++)
                {
                    arrMarkov[key + i] = res * arr[rKey + i];
                }
                return;
            }
            else
            {
                for (int i = 0; i < GetSequenceTypeCount(sequenceType); i++)
                {
                    long newRkey = (rKey * GetSequenceTypeCount(sequenceType)) + i;
                    long newKey = (key * GetSequenceTypeCount(sequenceType)) + i;
                    double newRes = res * arr[newRkey];
                    newRkey = newRkey & b;
                    RecursionCal(newRkey, newRes, arr, newKey, count, end, arrMarkov, b, sequenceType);
                }
                return;
            }
        }


        /// <summary>
        /// 计算0阶马尔科夫
        /// </summary>
        /// <param name="k">k值</param>
        /// <param name="total">序列归一化长度</param>
        /// <param name="list1">kTuple统计数据表</param>
        /// <returns></returns>
        private SuperList<double> CalMarkovPossibility(int k, int total, SuperList<int> list1, SequenceType sequenceType)
        {
            long count = 0;
            switch (sequenceType)
            {
                case SequenceType.Genome:
                    count = 1L << (k << 1);   //4的k次方;
                    break;
                case SequenceType.Protein:
                    count = (long)Math.Pow(32, k);
                    break;
            }
            IList<double> listPos = new SuperList<double>(count);
            SuperList<double> arrMarkov = new SuperList<double>(count);
            double[] arr = new double[GetSequenceTypeCount(sequenceType)];
            for (int i = 0; i < GetSequenceTypeCount(sequenceType); i++)
            {
                arr[i] = list1[i] * 1.0 / total;
            }
            RecursionCal(k, 1, 0, 0, arrMarkov, arr);
            return arrMarkov;
        }

        /// <summary>
        /// 计算非零阶马尔科夫
        /// </summary>
        /// <param name="end"></param>
        /// <param name="res"></param>
        /// <param name="count"></param>
        /// <param name="key"></param>
        /// <param name="arrMarkov"></param>
        /// <param name="arr"></param>
        private void RecursionCal(int end, double res, int count, long key, SuperList<double> arrMarkov, double[] arr)
        {
            count++;
            if (end == count)
            {
                key = key * arr.Length;
                arrMarkov[key] = res * arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    arrMarkov[key + i] = res * arr[i];
                }
                return;
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    long newKey = (key * arr.Length) + i;
                    double newRes = res * arr[i];
                    RecursionCal(end, newRes, count, newKey, arrMarkov, arr);
                }
                return;
            }
        }


        /// <summary>
        /// 计算MArkov
        /// </summary>
        /// <param name="k">k值</param>
        /// <param name="m">马尔科夫阶数</param>
        /// <param name="sd">序列</param>
        public void CalMarkov(int k, int m, SequenceData sd)
        {
            //if (k <= m || k < 2)
            //{
            //    return;
            //}
            if (m == 0)  //0阶马尔科夫
            {
                int total = sd.GetTotal(1);
                SuperList<int> list1 = sd.GetKtupleData(1);
                ListMarkov = CalMarkovPossibility(k, total, list1, sd.sequenceType);
            }
            else
            {
                if (sd.ContainsMarkovKey(k - 1, m))
                {
                    ListMarkov = CalMarkovPossibility(k, m, sd);
                }
                else
                {
                    int total = sd.GetTotal(m);
                    SuperList<int> list1 = sd.GetKtupleData(m);
                    SuperList<int> list2 = sd.GetKtupleData(m + 1);
                    DicRtemp = sd.MarkovRtemp;
                    ListMarkov = CalMarkovPossibility(k, m, total, list1, list2, sd.sequenceType);
                }
            }
        }
    }
}
