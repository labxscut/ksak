using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace SeqDistKPlus
{
    class Tree
    {
        static void Main2(string[] args)
        {

            //导入文件
            Console.WriteLine("输入文件");
            string path = Console.ReadLine();
            //path = path.Substring(1, path.Length - 2);径
            path = path.Trim('"');//处理路径，方便直接拖拽文件进入窗口，但不支持手动输入文件路
            //接收文件数据
            var data = File.ReadAllLines(path);
            data[0] = data[0].Trim();
            string[] seqName = data[0].Split();//从第一行数据读取序列名称
            int[] countTable = new int[seqName.Length];//定义一个与序列名数组相应的整数数组统计叶节点元素个数,用于UPGMA
            for (int i = 0; i < countTable.Length; i++)
            {
                countTable[i] = 1;
            }
            double[][] dst = new double[seqName.Length][];    //矩阵数据储存在交错数组中
            for (int a = 0; a < seqName.Length; a++)
            {
                dst[a] = new double[seqName.Length];
            }
            string[] temp = new string[seqName.Length + 1];
            for (int i = 0; i < seqName.Length; i++)
            {
                data[i + 1] = data[i + 1].Trim();
                temp = data[i + 1].Split();//从第二行开始读数据，第一行是序列名
                for (int j = 0; j < seqName.Length; j++)
                {
                    dst[i][j] = double.Parse(temp[j + 1]);//从第二个元素开始赋值到二维交错数组中，第一个元素是序列名
                }
            }
            //画树
            bool flag = true;
            string method;//画树方法标记
            string treeResult = "";//最终输出目标
            while (flag)
            {
                Console.WriteLine("请选择方法：1.UPGMA     2.NJ");
                method = Console.ReadLine();
                switch (method)
                {
                    case "1":
                        // UPGMA法画树
                        treeResult = Upgma(seqName, countTable, dst);
                        flag = false;
                        path = path.Insert(path.Length - 4, "_UPGMAtree");
                        break;
                    case "2":
                        //NJ法画树
                        treeResult = Nj(seqName, countTable, dst);
                        path = path.Insert(path.Length - 4, "_NJtree");
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("请正确输入");
                        break;
                }
            }
            //写入txt
            File.WriteAllText(path, treeResult);
            Console.WriteLine("finished!");
            Console.ReadKey();
            Main2(args);
        }


        /// <summary>
        /// UPGMA法画树
        /// </summary>
        /// <param name="nameList">序列名列表</param>
        /// <param name="leafCount">叶节点元素数列表</param>
        /// <param name="matrix">距离矩阵</param>
        /// <returns>返回聚类树</returns>
        public static string Upgma(string[] nameList, int[] leafCount, double[][] matrix)
        {
            int rowNum = 0;
            int columnNum = 0;
            do
            {
                MinOfMatrix(matrix, out rowNum, out columnNum);//找矩阵最小值
                NewNameList(ref nameList, matrix, rowNum, columnNum, "1");//更新序列名表
                NewMatrix(ref matrix, ref leafCount, rowNum, columnNum, "1");//更新矩阵和叶节点元素表
            } while (nameList.Length != 2);//最终生成2*2矩阵
            string result = Combine(nameList[0], nameList[1], BranchOfUpgma(matrix[0][1], matrix[0][0]), BranchOfUpgma(matrix[0][1], matrix[1][1]));
            return (result);
        }

        /// <summary>
        /// NJ法画树
        /// </summary>
        /// <param name="nameList">序列名列表</param>
        /// <param name="matrix">距离矩阵</param>
        /// <returns>返回聚类树</returns>
        public static string Nj(string[] nameList, int[] leafCount, double[][] matrix)
        {
            int rowNum = 0;
            int columnNum = 0;
            do
            {
                MinOfMatrix(QMatrix(matrix), out rowNum, out columnNum);//从速率校正矩阵找最小值
                NewNameList(ref nameList, matrix, rowNum, columnNum, "2");//更新序列名表
                NewMatrix(ref matrix, ref leafCount, rowNum, columnNum, "2");//更新矩阵
            } while (nameList.Length != 3);//最终3*3矩阵
            NewNameList(ref nameList, matrix, 0, 1, "2");
            NewMatrix(ref matrix, ref leafCount, 0, 1, "2");//最选任何节点进行结合都可以，无需进行速率校正
            string result = Combine(nameList[0], nameList[1], matrix[1][1] / 2, matrix[1][1] / 2);
            return (result);
        }

        /// <summary>
        /// 对角线元素为0的对称矩阵求其最小非0元素
        /// </summary>
        /// <param name="symmetricMatrix">输入的矩阵</param>
        /// <param name="x">最小元素所在行</param>
        /// <param name="y">最小元素所在列</param>
        /// <returns>返回最小值，返回其所在行列</returns>
        private static double MinOfMatrix(double[][] symmetricMatrix, out int x, out int y)
        {
            double min = 1000;
            x = 0;
            y = 0;
            for (int i = 0; i < symmetricMatrix.Length - 1; i++)//从第一行第二个元素扫到倒数第一行最后一个元素，避开对角元
            {
                for (int j = i + 1; j < symmetricMatrix.Length; j++)
                {
                    if (symmetricMatrix[i][j] < min)
                    {
                        min = symmetricMatrix[i][j];
                        x = i;
                        y = j;
                    }
                }
            }
            return (min);
        }

        /// <summary>
        /// 结合俩叶节点
        /// </summary>
        /// <param name="firLeaf">第一叶</param>
        /// <param name="secLeaf">第二叶</param>
        /// <param name="firBranch">第一叶支长</param>
        /// <param name="secBranch">第二叶支长</param>
        /// <returns>返回结合后的节点字符串</returns>
        private static string Combine(string firLeaf, string secLeaf, double firBranch, double secBranch)
        {
            return ("(" + firLeaf + ":" + firBranch + "," + secLeaf + ":" + secBranch + ")");//(a:branch of a,b:branch of b)
        }

        /// <summary>
        /// NJ法的支长计算
        /// </summary>
        /// <param name="d">两叶节点的距离</param>
        /// <param name="count">总节点数</param>
        /// <param name="r1">所求支长对应叶的净分化距离</param>
        /// <param name="r2">另一个叶的净分化距离</param>
        /// <returns>返回支长</returns>
        private static double BranchOfNj(double d, int count, double r1, double r2)
        {
            return ((d + (r1 - r2) / (count - 2)) / 2);
        }

        /// <summary>
        /// UPGMA法的支长计算
        /// </summary>
        /// <param name="d">两叶节点间距离</param>
        /// <param name="l">叶节点中最大支长</param>
        /// <returns></returns>
        private static double BranchOfUpgma(double d, double l)
        {
            return (d / 2 - l);
        }

        /// <summary>
        /// 速率校正矩阵计算
        /// </summary>
        /// <param name="originMatrix">距离矩阵</param>
        /// <returns>速率校正矩阵</returns>
        private static double[][] QMatrix(double[][] originMatrix)
        {
            double[][] qMatrix = new double[originMatrix.Length][];
            for (int k = 0; k < qMatrix.Length; k++)
            {
                qMatrix[k] = new double[qMatrix.Length];
            }

            for (int i = 0; i < qMatrix.Length; i++)
            {
                qMatrix[i][i] = 0;//对角元为0
                if (i != qMatrix.Length - 1)//最后一行不算
                {
                    for (int j = i + 1; j < qMatrix.Length; j++)//避开对角元
                    {
                        qMatrix[i][j] = originMatrix[i][j] * (originMatrix.Length - 2) - originMatrix[i].Sum() - originMatrix[j].Sum();
                        qMatrix[j][i] = qMatrix[i][j];//对称矩阵
                    }
                }
            }
            return (qMatrix);
        }

        /// <summary>
        /// 更新序列名数组
        /// </summary>
        /// <param name="list">序列名数组</param>
        /// <param name="calMatrix">距离矩阵</param>
        /// <param name="row">最小距离行号</param>
        /// <param name="column">最小距离列号</param>
        /// <param name="way">方法标记（"1"是upgma，"2"是nj）</param>
        private static void NewNameList(ref string[] list, double[][] calMatrix, int row, int column, string way)
        {
            List<string> temp = new List<string>();
            temp = list.ToList();
            temp.RemoveAt(row);
            temp.RemoveAt(column - 1);//删除两原有元素，将其结合成一个元素放到列末
            switch (way)
            {
                case "1"://UPGMA法
                    temp.Add(Combine(list[row], list[column], BranchOfUpgma(calMatrix[row][column], calMatrix[row][row]), BranchOfUpgma(calMatrix[row][column], calMatrix[column][column])));//BranchOfUpgma(calMatrix[row,column],calMatrix[row,row]),BranchOfUpgma(calMatrix[row,column],calMatrix[column,column])
                    break;
                case "2"://NJ法
                    temp.Add(Combine(list[row], list[column], BranchOfNj(calMatrix[row][column], calMatrix.Length, calMatrix[row].Sum(), calMatrix[column].Sum()), calMatrix[row][column] - BranchOfNj(calMatrix[row][column], calMatrix.Length, calMatrix[row].Sum(), calMatrix[column].Sum())));
                    break;
                default:
                    break;
            }
            list = new string[list.Length - 1];//更新
            list = temp.ToArray();
            temp.Clear();

        }

        /// <summary>
        /// UPGMA更新矩阵，新节点置于新矩阵末行末列
        /// </summary>
        /// <param name="mat">距离矩阵</param>
        /// <param name="powerTable">叶节点元素表</param>
        /// <param name="row">最小距离所在行号</param>
        /// <param name="column">最小距离所在列号</param>
        /// <param name="column">方法标记（"1"是upgma，"2"是nj）</param>
        private static void NewMatrix(ref double[][] mat, ref int[] powerTable, int row, int column, string way)
        {
            List<List<double>> temp = new List<List<double>>();
            for (int i = 0; i < mat.Length; i++)
            {
                temp.Add(mat[i].ToList());//mat赋值给temp
            }
            temp.RemoveAt(row);//删除对应行
            temp.RemoveAt(column - 1);
            for (int j = 0; j < mat.Length - 2; j++)
            {
                temp[j].RemoveAt(row);//删除对应列
                temp[j].RemoveAt(column - 1);
            }
            double[] newDst = new double[mat.Length - 1];//储存新的节点与其余节点的距离
            int a = 0;
            int b = 0;
            while (a < newDst.Length && b < mat.Length)//双指针计算其余节点与新节点的距离
            {
                if (b != row && b != column)//不更新已删除的行列数据
                {
                    switch (way)
                    {
                        case "1":
                            newDst[a] = (mat[row][b] * powerTable[row] + mat[column][b] * powerTable[column]) / (powerTable[row] + powerTable[column]);
                            //UPGMA更新距离
                            break;
                        case "2":
                            newDst[a] = (mat[row][b] + mat[column][b] - mat[row][column]) / 2;
                            //NJ法更新距离
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    a--;//b到已删除的元素，跳过，指针a不动
                }
                a++;
                b++;
            }
            if (way == "1")
            {
                newDst[newDst.Length - 1] = mat[row][column] / 2;//UPGMA用最后一个元素储存最大支长,即支长存于对角元中
            }
            else
            {
                newDst[newDst.Length - 1] = 0;
            }
            temp.Add(newDst.ToList());//新距离加到temp矩阵中最后一行
            for (int s = 0; s < mat.Length - 2; s++)//新距离加到temp矩阵中最后一列
            {
                temp[s].Add(newDst[s]);
            }
            mat = new double[mat.Length - 1][];//更新距离矩阵
            for (int t = 0; t < mat.Length; t++)
            {
                mat[t] = new double[mat.Length];
                mat[t] = temp[t].ToArray();
            }
            temp.Clear();
            List<int> tempTable = new List<int>();//更新叶节点元素数量，仅UPGMA有用
            tempTable = powerTable.ToList();
            tempTable.RemoveAt(row);
            tempTable.RemoveAt(column - 1);
            tempTable.Add(powerTable[row] + powerTable[column]);
            powerTable = new int[powerTable.Length - 1];//更新
            powerTable = tempTable.ToArray();
            tempTable.Clear();
        }
    }
}
