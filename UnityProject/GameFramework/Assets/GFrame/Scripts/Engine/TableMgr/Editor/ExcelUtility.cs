using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Excel;
using System.Data;
using System.IO;
//using Newtonsoft.Json;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
using System;

namespace GFrame
{


    public class ExcelUtility
    {

        /// <summary>
        /// 表格数据集合
        /// </summary>
        private DataSet mResultSet;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="excelFile">Excel file.</param>
        public ExcelUtility(string excelFile)
        {
            FileStream mStream = File.Open(excelFile, FileMode.Open, FileAccess.Read);
            IExcelDataReader mExcelReader = ExcelReaderFactory.CreateOpenXmlReader(mStream);
            mResultSet = mExcelReader.AsDataSet();
        }

        /// <summary>
        /// 转换为实体类列表
        /// </summary>
        public List<T> ConvertToList<T>()
        {
            //判断Excel文件中是否存在数据表
            if (mResultSet.Tables.Count < 1)
                return null;
            //默认读取第一个数据表
            DataTable mSheet = mResultSet.Tables[0];

            //判断数据表内是否存在数据
            if (mSheet.Rows.Count < 1)
                return null;

            //读取数据表行数和列数
            int rowCount = mSheet.Rows.Count;
            int colCount = mSheet.Columns.Count;

            //准备一个列表以保存全部数据
            List<T> list = new List<T>();

            //读取数据
            for (int i = 1; i < rowCount; i++)
            {
                //创建实例
                Type t = typeof(T);
                ConstructorInfo ct = t.GetConstructor(System.Type.EmptyTypes);
                T target = (T)ct.Invoke(null);
                for (int j = 0; j < colCount; j++)
                {
                    //读取第1行数据作为表头字段
                    string field = mSheet.Rows[0][j].ToString();
                    object value = mSheet.Rows[i][j];
                    //设置属性值
                    SetTargetProperty(target, field, value);
                }

                //添加至列表
                list.Add(target);
            }

            return list;
        }

        /// <summary>
        /// 转换为Json
        /// </summary>
        /// <param name="JsonPath">Json文件路径</param>
        /// <param name="Header">表头行数</param>
        public void ConvertToJson(string JsonPath, Encoding encoding)
        {
            //判断Excel文件中是否存在数据表
            if (mResultSet.Tables.Count < 1)
                return;

            //默认读取第一个数据表
            DataTable mSheet = mResultSet.Tables[0];

            //判断数据表内是否存在数据
            if (mSheet.Rows.Count < 4)
                return;

            //读取数据表行数和列数
            int rowCount = mSheet.Rows.Count;
            int colCount = mSheet.Columns.Count;

            //准备一个列表存储整个表的数据
            List<Dictionary<string, object>> table = new List<Dictionary<string, object>>();

            //读取数据
            for (int i = 4; i < rowCount; i++)
            {
                //准备一个字典存储每一行的数据
                Dictionary<string, object> row = new Dictionary<string, object>();
                for (int j = 0; j < colCount; j++)
                {
                    //读取第4行数据作为表头字段
                    string field = mSheet.Rows[3][j].ToString();
                    //Key-Value对应
                    row[field] = mSheet.Rows[i][j];
                }

                //添加到表数据中
                table.Add(row);
            }

            SerializeHelper.SerializeJson(JsonPath, table, false);
        }

        /// <summary>
        /// 转换为CSV
        /// </summary>
        public void ConvertToCSV(string CSVPath, Encoding encoding)
        {
            //判断Excel文件中是否存在数据表
            if (mResultSet.Tables.Count < 1)
                return;

            //默认读取第一个数据表
            DataTable mSheet = mResultSet.Tables[0];

            //判断数据表内是否存在数据
            if (mSheet.Rows.Count < 1)
                return;

            //读取数据表行数和列数
            int rowCount = mSheet.Rows.Count;
            int colCount = mSheet.Columns.Count;

            //创建一个StringBuilder存储数据
            StringBuilder stringBuilder = new StringBuilder();

            //读取数据
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    //使用","分割每一个数值
                    stringBuilder.Append(mSheet.Rows[i][j] + ",");
                }
                //使用换行符分割每一行
                stringBuilder.Append("\r\n");
            }

            //写入文件
            using (FileStream fileStream = new FileStream(CSVPath, FileMode.Create, FileAccess.Write))
            {
                using (TextWriter textWriter = new StreamWriter(fileStream, encoding))
                {
                    textWriter.Write(stringBuilder.ToString());
                }
            }

        }

        /// <summary>
        /// 导出为Xml
        /// </summary>
        public void ConvertToXml(string XmlFile)
        {
            //判断Excel文件中是否存在数据表
            if (mResultSet.Tables.Count < 1)
                return;

            //默认读取第一个数据表
            DataTable mSheet = mResultSet.Tables[0];

            //判断数据表内是否存在数据
            if (mSheet.Rows.Count < 1)
                return;

            //读取数据表行数和列数
            int rowCount = mSheet.Rows.Count;
            int colCount = mSheet.Columns.Count;

            //创建一个StringBuilder存储数据
            StringBuilder stringBuilder = new StringBuilder();
            //创建Xml文件头
            stringBuilder.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            stringBuilder.Append("\r\n");
            //创建根节点
            stringBuilder.Append("<Table>");
            stringBuilder.Append("\r\n");
            //读取数据
            for (int i = 1; i < rowCount; i++)
            {
                //创建子节点
                stringBuilder.Append("  <Row>");
                stringBuilder.Append("\r\n");
                for (int j = 0; j < colCount; j++)
                {
                    stringBuilder.Append("   <" + mSheet.Rows[0][j].ToString() + ">");
                    stringBuilder.Append(mSheet.Rows[i][j].ToString());
                    stringBuilder.Append("</" + mSheet.Rows[0][j].ToString() + ">");
                    stringBuilder.Append("\r\n");
                }
                //使用换行符分割每一行
                stringBuilder.Append("  </Row>");
                stringBuilder.Append("\r\n");
            }
            //闭合标签
            stringBuilder.Append("</Table>");
            //写入文件
            using (FileStream fileStream = new FileStream(XmlFile, FileMode.Create, FileAccess.Write))
            {
                using (TextWriter textWriter = new StreamWriter(fileStream, Encoding.GetEncoding("utf-8")))
                {
                    textWriter.Write(stringBuilder.ToString());
                }
            }
        }

        /// <summary>
        /// 设置目标实例的属性
        /// </summary>
        private void SetTargetProperty(object target, string propertyName, object propertyValue)
        {
            //获取类型
            Type mType = target.GetType();
            //获取属性集合
            PropertyInfo[] mPropertys = mType.GetProperties();
            foreach (PropertyInfo property in mPropertys)
            {
                if (property.Name == propertyName)
                {
                    property.SetValue(target, Convert.ChangeType(propertyValue, property.PropertyType), null);
                }
            }
        }

        public void WriteDataFile(string fileName)
        {
            //string fileName = PathHelper.Path2Name(path);
            fileName = fileName.Substring(0, 1).ToUpper() + fileName.Substring(1);
            DataTable mSheet = mResultSet.Tables[0];
            int rowCount = mSheet.Rows.Count;
            int colCount = mSheet.Columns.Count;
            /*———————————生成CS的Class类脚本————————————*/
            StringBuilder code = new StringBuilder();                //创建代码串
                                                                     //添加常见且必须的引用字符串
            code.Append("using UnityEngine; \n");
            code.Append("using System.Collections; \n");
            code.Append("using GFrame; \n");
            code.Append("namespace GameWish.Game \n");
            code.Append("{ \n");

            //产生类，所有可执行代码均在此类中运行
            code.Append("public partial class TD" + fileName + " { \n\t");
            for (int i = 0; i < colCount; i++)
            {
                Debug.LogError(mSheet.Rows[2][i].ToString());
                code.Append("public string ");
                code.Append(mSheet.Rows[3][i] + " { get; set; } " + "   //" + mSheet.Rows[0][i] + "\n\t");
                if (mSheet.Rows[2][i].ToString() == "int")
                {
                    code.Append("public int _" + mSheet.Rows[3][i] + " (){\n\t\t");
                    code.Append("int value = int.Parse(" + mSheet.Rows[3][i] + ");\n\t\t");
                    code.Append("return value;\n\t");
                    code.Append("}\n\t");
                }
                else if (mSheet.Rows[2][i].ToString() == "float")
                {
                    code.Append("  public float _" + mSheet.Rows[3][i] + " (){\n\t\t");
                    code.Append("float value = float.Parse(" + mSheet.Rows[3][i] + ");\n\t\t");
                    code.Append("return value;\n\t");
                    code.Append("}\n\t");
                }
                else if (mSheet.Rows[2][i].ToString() == "string")
                {
                    code.Append("  public string _" + mSheet.Rows[3][i] + " (){\n\t\t");
                    code.Append("string value = " + mSheet.Rows[3][i] + ";\n\t\t");
                    code.Append("return value;\n\t");
                    code.Append("}\n\t");
                }
            }
            code.Append("}\n\t");
            code.Append("}");
            string CSharpFilePath = ProjectPathConfig.tableScriptOutPutPath + "/Generate/";
            IO.CheckDirAndCreate(CSharpFilePath);

            IO.WriteFile(CSharpFilePath + "/TD" + fileName + ".cs", code.ToString());
            Log.i("成功生成c#的Class文件" + fileName + ".cs" + "在目录:" + CSharpFilePath + " 中");
        }
    }
}
