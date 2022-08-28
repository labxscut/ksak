using System;
using System.Collections.Generic;
using System.Linq;

namespace SeqDistKPlus
{
    class KtupleData
    {
        #region 私有字段

        /// <summary>
        /// ktuple统计值
        /// </summary>
        private SuperList<int> _listKtuple = new SuperList<int>();
        /// <summary>
        /// 所有ktuple的统计值之和
        /// </summary>


        #endregion

        #region 属性
        public SuperList<int> ListKtuple { get => _listKtuple; set => _listKtuple = value; }

        #endregion

        #region 方法


        /// <summary>
        /// 计算kTuple统计值
        /// </summary>
        /// <param name="listSequenceInt">序列</param>
        /// <param name="k">k值</param>
        /// <returns></returns>
        public int CountKtuple(List<List<int>> listSequenceInt, int k, SequenceType sequenceType)
        {
            //统计
            int total = 0;
            long count = 0;
            switch (sequenceType)
            {
                case SequenceType.Genome:
                    count = 1L << (k << 1);  //4的k次方
                    break;
                case SequenceType.Protein:
                    count = (long)Math.Pow(32, k);
                    break;
            }
            SuperList<int> arrKtuple = new SuperList<int>(count);
            for (int i = 0; i < listSequenceInt.Count; i++)
            {
                if (listSequenceInt[i].Count >= k)
                {
                    total += (listSequenceInt[i].Count - k + 1);
                    GetKtupleCount(k, listSequenceInt[i], arrKtuple, sequenceType);
                }
            }
            _listKtuple = arrKtuple;
            return total;
        }


        /// <summary>
        /// 计算kTuple统计值
        /// </summary>
        /// <param name="k">k值</param>
        /// <param name="seqInt">序列的一部分</param>
        /// <param name="arrKtuple">统计结果数组</param>
        private void GetKtupleCount(int k, List<int> seqInt, SuperList<int> arrKtuple, SequenceType sequenceType)
        {
            int length = seqInt.Count - k + 1;

            long key = 0;

            for (int i = 0; i < k; i++)
            {
                key = (key * MarkovData.GetSequenceTypeCount(sequenceType)) + seqInt[i];
            }
            arrKtuple[key]++;
            long flag = 0;
            switch (sequenceType)
            {
                case SequenceType.Genome:
                    flag = (1L << ((k - 1) << 1)) - 1;   //4^(k-1)-1
                    break;
                case SequenceType.Protein:
                    flag = (long)Math.Pow(32, k - 1) - 1;    // 32^(k-1)-1
                    break;
            }
            for (int i = 1; i < length; i++)
            {
                key = ((key & flag) * MarkovData.GetSequenceTypeCount(sequenceType)) + seqInt[i + k - 1];   //向右滑动窗口一位
                arrKtuple[key]++;
            }
        }
        #endregion
    }
}
