using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace TestDataSet
{
    public partial class Form1 : Form
    {
        private StringBuilder logBoxBuf = new StringBuilder();

        private int queryCnt = 0;

        #region ベーステーブル名定義

        // テーブル定義書より取得
        private List<string> baseTableList = new List<string>();
        private string[] baseTables =
            new string[]
            {
                "BushoMst"
                ,"ChikuMst"
                ,"ConstMst"
                ,"CrossCheckTbl"
                ,"DaichoSuishitsuKensaKomokuMst"
                ,"DaichoSuishitsuKensaTanKomokuMst"
                ,"FileKanriTbl"
                ,"FunctionMst"
                ,"GaikanKensaKekkaTbl"
                ,"GaikankensaKomokuMst"
                ,"GenbaShashinTbl"
                ,"GyoshaBukaiMst"
                ,"GyoshaEigyoChikuMst"
                ,"GyoshaEigyoshoMst"
                ,"GyoshaMst"
                ,"HenkinTbl"
                ,"HokenjoMst"
                ,"HoshoTorokuTbl"
                ,"HoteiKanriMst"
                ,"HoteiKensaRyokinMst"
                ,"IkkatsuSeikyuSaibanWrk"
                ,"IkoJokyoShukeiWrk"
                ,"JinendoGaikanYoteiOutputTbl"
                ,"JokasoDaichiRirekiTbl"
                ,"JokasoDaichoMst"
                ,"JokasoDiachoKanrenFileTbl"
                ,"JokasoHoyuTaniSochiGroupTbl"
                ,"JokasoMemoTbl"
                ,"JokasoMst"
                ,"KaikeiRendoDtlTbl"
                ,"KaikeiRendoHdrTbl"
                ,"KakuninKensaShubetsuHanteiMst"
                ,"KatashikiBetsuTaniSochiMst"
                ,"KatashikiBurowaMst"
                ,"KatashikiMst"
                ,"KeiryoShomeiIraiTbl"
                ,"KeiryoShomeiKekkaTbl"
                ,"KenchikuyotoDaibunruiMst"
                ,"KenchikuyotoMst"
                ,"KenchikuyotoShobunruiMst"
                ,"KensaDaicho11joHdrTbl"
                ,"KensaDaicho9joHdrTbl"
                ,"KensaDaichoDtlTbl"
                ,"KensainGeppoTbl"
                ,"KensaIraiKanrenFileTbl"
                ,"KensaIraiTbl"
                ,"KensaKeihatsuSuishinHiShukeiTbl"
                ,"KensaKekkaTbl"
                ,"KensaYoteiListWrk"
                ,"KokanHoshoTbl"
                ,"KurikoshiKinTbl"
                ,"KyodoKumiaiMst"
                ,"MaeukekinTbl"
                ,"MemoDaibunruiMst"
                ,"MemoMst"
                ,"MonitoringGroupMst"
                ,"MonitoringShosaiMst"
                ,"MonitoringTbl"
                ,"MstKeySaibanTbl"
                ,"NameMst"
                ,"NenKaihiTbl"
                ,"NippoDtlTbl"
                ,"NippoHdrTbl"
                ,"NyukinTbl"
                ,"OldBunshoMst"
                ,"OldGaikanCheckKoumokuMst"
                ,"OldShokenMst"
                ,"SaibanTbl"
                ,"SaiSaisuiTbl"
                ,"SaiSeikyuSyukeiWrk"
                ,"SaisuiinJukoRirekiTbl"
                ,"SaisuiinMst"
                ,"ScreeningKeisuMst"
                ,"SeikyuDtlTbl"
                ,"SeikyuHdrTbl"
                ,"SeikyuNyukinTbl"
                ,"SeikyuShimeSyoriWrk"
                ,"SeikyushoKagamiHdrTbl"
                ,"SeikyusyoKagamiTbl"
                ,"SetShikenKomokuMst"
                ,"ShishoKanriMst"
                ,"ShishoMst"
                ,"ShohizeiMst"
                ,"ShokenKekkaHosokuTbl"
                ,"ShokenKekkaTbl"
                ,"ShokenMst"
                ,"ShokuinMst"
                ,"ShoriHoshikiMst"
                ,"ShoriHoshikiSuishitsuKensaJisshiMst"
                ,"ShoyoSanteiJininShukeiTbl"
                ,"ShoyoSanteiJininShukeiWrk"
                ,"ShozokuMst"
                ,"SuishitsuIraiUketsukeWrk"
                ,"SuishitsuKekkaNmMst"
                ,"SuishitsuKensaSetMst"
                ,"SuishitsuMst"
                ,"SuishitsuNippoDtlTbl"
                ,"SuishitsuNippoHdrTbl"
                ,"SuishitsuNippoIraiNoInfoTbl"
                ,"SuishitsuShikenKoumokuMst"
                ,"TaniSochiGroupMst"
                ,"TaniSochiKensaJokyoMst"
                ,"TaniSochiKensaJokyoTeidoMst"
                ,"TaniSochiKensaKomokuMst"
                ,"TaniSochiMst"
                ,"UriageTbl"
                ,"WarekiMst"
                ,"YakushokuMst"
                ,"YoshiHanbaiDtlTbl"
                ,"YoshiHanbaiHdrTbl"
                ,"YoshiMst"
                ,"YoshiZaikoTbl"
                ,"YubinNoAdrMst"
                ,"ZenkaiKensaDataWrk"
            };


        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // set default param
            assemblyPathTextBox.Text = @"FukjBizSystem.exe";
            namespaceTextBox.Text = "FukjBizSystem.Application.DataSet";

            baseTableList = new List<string>(baseTables);

            logOutputTextBox.KeyDown += delegate(object sender2, KeyEventArgs e2)
            {
                if (e2.Control && e2.KeyCode == Keys.A)
                {
                    logOutputTextBox.SelectAll();
                }
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogOutputBegin();

            // *.DataSet名前空間内の全てのTableAdapterを取得
            IEnumerable<Type> adapList = GetTableAdapterList(namespaceTextBox.Text);

            // TableAdapterのGetDataMethodを実行
            foreach (Type adaperType in adapList)
            {
                ExecuteTableAdapter(adaperType);
            }

            LogOutputEnd();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LogOutputBegin();

            // *.DataSet名前空間内の全てのTableAdapterを取得
            IEnumerable<Type> adapList = GetTableAdapterList(namespaceTextBox.Text);

            // TableAdapterのGetDataMethodを実行
            foreach (Type adaperType in adapList)
            {
                OutputSelectQuery(adaperType);
            }

            LogOutputEnd();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LogOutputBegin();

            // *.DataSet名前空間内の全てのTableAdapterを取得
            IEnumerable<Type> adapList = GetTableAdapterList(namespaceTextBox.Text);

            // TableAdapterのGetDataMethodを実行
            foreach (Type adaperType in adapList)
            {
                OutputCustomSelectQueryMethod(adaperType);
            }

            LogOutputEnd();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LogOutputBegin();

            IList<Type> adapList;
            IList<Type> tblList;

            GetDataTableList(namespaceTextBox.Text, out adapList, out tblList);

            for (int i = 0; i < adapList.Count(); i++)
            {
                CompareDataTableType(tblList[i], adapList[i]);
            }

            LogOutputEnd();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LogOutputBegin();

            IList<Type> adapList;
            IList<Type> tblList;

            GetDataTableList(namespaceTextBox.Text, out adapList, out tblList);

            for (int i = 0; i < adapList.Count(); i++)
            {
                CompareDataTableColCnt(tblList[i], adapList[i]);
            }

            LogOutputEnd();
        }

        #region GetTableAdapterList
        /// <summary>
        /// TableAdapterの一覧を取得する
        /// </summary>
        /// <param name="rootNamespace"></param>
        /// <returns></returns>
        private IEnumerable<Type> GetTableAdapterList(string rootNamespace)
        {
            var theList = Assembly.LoadFile(System.IO.Path.GetFullPath(assemblyPathTextBox.Text)).GetTypes().ToList()
                .Where(t => t.Namespace != null && t.Name != null && t.Namespace.StartsWith(rootNamespace) && t.Name.EndsWith("TableAdapter")).ToList();

            return theList;
        }
        #endregion

        #region GetDataTableList
        /// <summary>
        /// TableAdapterの一覧を取得する
        /// </summary>
        /// <param name="rootNamespace"></param>
        /// <returns></returns>
        private void GetDataTableList(string rootNamespace, out IList<Type> adapList, out IList<Type> tblList)
        {
            var theList = Assembly.LoadFile(System.IO.Path.GetFullPath(assemblyPathTextBox.Text)).GetTypes().ToList()
                .Where(t => t.Namespace != null && t.Name != null && t.Namespace.StartsWith(rootNamespace) && t.Name.EndsWith("TableAdapter")).ToList();

            adapList = new List<Type>();
            tblList = new List<Type>();

            List<Type> types = Assembly.LoadFile(System.IO.Path.GetFullPath(assemblyPathTextBox.Text)).GetTypes().ToList()
                .Where(t => t.Namespace != null && t.Name != null && t.Namespace.StartsWith(rootNamespace)).ToList();

            foreach (Type t in theList)
            {
                string tblName = t.Name.Replace("TableAdapter", "");

                var tblType = from a in types
                              where a.Name == tblName + "DataTable"
                              select a;

                if (tblType.Count() > 0)
                {
                    adapList.Add(t);
                    tblList.Add(tblType.ElementAt(0));
                }
            }

            return;
        }
        #endregion

        #region OutputSelectQuery
        /// <summary>
        /// TableAdapterに含まれる、Queryの一覧を列挙する
        /// </summary>
        /// <param name="adapterType"></param>
        private void OutputSelectQuery(Type adapterType)
        {
            // TableAdapter実体作成(Instanciate TableAdapter)
            object adap = Activator.CreateInstance(adapterType);

            PropertyInfo propInfoCommand = adap.GetType().GetProperty("CommandCollection", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            DbCommand[] baseCommandCollection = (DbCommand[])propInfoCommand.GetValue(adap, null);

            StringBuilder buf = new StringBuilder();

            buf.AppendFormat("DataSet Name=[{0}]", adapterType.Namespace.Substring(0, adapterType.Namespace.Length - "TableAdapters".Length));
            buf.AppendLine();
            buf.AppendFormat("Class Name=[{0}]", adapterType.Name);
            buf.AppendLine();

            foreach (DbCommand baseCommand in baseCommandCollection)
            {
                buf.AppendFormat("Select Query=[{0}]", baseCommand.CommandText);
                buf.AppendLine();

                LogOutput(buf.ToString());
                queryCnt++;
            }
        }
        #endregion

        #region OutputCustomSelectQueryMethod
        /// <summary>
        /// TableAdapterに含まれる、動的Queryの一覧を列挙する
        /// </summary>
        /// <param name="adapterType"></param>
        private void OutputCustomSelectQueryMethod(Type adapterType)
        {
            // CommandCollectionを使用しない、カスタムのクエリメソッドの一覧を出力する

            // TableAdapter実体作成(Instanciate TableAdapter)
            object adap = Activator.CreateInstance(adapterType);

            StringBuilder buf = new StringBuilder();

            buf.AppendFormat("DataSet Name=[{0}]", adapterType.Namespace.Substring(0, adapterType.Namespace.Length - "TableAdapters".Length));
            buf.AppendLine();
            buf.AppendFormat("Class Name=[{0}]", adapterType.Name);
            buf.AppendLine();

            MethodInfo[] methInfoes = adap.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (MethodInfo methInfo in methInfoes)
            {
                // Method Calling Convention check
                // GetData should Returns DataTable(DataTableを返さないものは、GetXXXメソッドではないとみなす)
                if (!CheckGetDataConvention(methInfo))
                {
                    continue;
                }
                else
                {
                    object[] atts = methInfo.GetCustomAttributes(typeof(System.CodeDom.Compiler.GeneratedCodeAttribute), true);

                    // Method that returns DataTable and doesn't habe GeneratedCodeAttribute must be a custom query method
                    if (atts.Length == 0)
                    {
                        buf.AppendFormat("Custom SelectQueryMethod=[{0}]", methInfo.Name);
                        buf.AppendLine();

                        LogOutput(buf.ToString());
                    }
                }
            }
        }
        #endregion

        #region CheckGetDataConvention
        /// <summary>
        /// メソッドのシグネチャがDataTableを返すか、チェックする
        /// </summary>
        /// <param name="methInfo"></param>
        /// <returns></returns>
        private bool CheckGetDataConvention(MethodInfo methInfo)
        {
            // Method Calling Convention check
            // GetData should Returns DataTable(戻り値がDataTableまたはその継承クラスか)
            if (!IsDerivedClass(methInfo.ReturnType, typeof(DataTable)))
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Test Excecute GetData

        #region ExecuteTableAdapter
        /// <summary>
        /// TableAdapterの各メソッドを実行する
        /// </summary>
        /// <param name="adapterType"></param>
        private void ExecuteTableAdapter(Type adapterType)
        {
            // TableAdapter実体作成(Instanciate TableAdapter)
            object adap = Activator.CreateInstance(adapterType);

            MethodInfo[] methInfoes = adap.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            // Excecute each GetXXXMethods
            foreach (MethodInfo methInfo in methInfoes)
            {
                TestGetData(adapterType, methInfo);
            }
        }
        #endregion

        #region ExecuteCommand
        /// <summary>
        /// TableAdapterのメソッドを実行する
        /// </summary>
        /// <param name="adapterType"></param>
        /// <param name="methInfo"></param>
        private void ExecuteCommand(Type adapterType, MethodInfo methInfo)
        {
            // TableAdapter実体作成(Instanciate TableAdapter)
            object adap = Activator.CreateInstance(adapterType);

            List<object> paramList = new List<object>();
            ParameterInfo[] paramInfoes = methInfo.GetParameters();

            //bool hasNullableParam = false;

            //// パラメータチェック
            //foreach (ParameterInfo paramInfo in paramInfoes)
            //{
            //    if (paramInfo.ParameterType == typeof(string)) { hasNullableParam = true; }
            //    else if (paramInfo.ParameterType == typeof(object)) { hasNullableParam = true; }
            //}

            // use string.Empty as default string
            paramList = new List<object>();
            // create default parameter
            foreach (ParameterInfo paramInfo in paramInfoes)
            {
                if (paramInfo.ParameterType == typeof(string)) { paramList.Add(string.Empty); }
                else if (paramInfo.ParameterType == typeof(int)) { paramList.Add((int)0); }
                else if (paramInfo.ParameterType == typeof(long)) { paramList.Add((long)0); }
                else if (paramInfo.ParameterType == typeof(short)) { paramList.Add((short)0); }
                else if (paramInfo.ParameterType == typeof(uint)) { paramList.Add((uint)0); }
                else if (paramInfo.ParameterType == typeof(ulong)) { paramList.Add((ulong)0); }
                else if (paramInfo.ParameterType == typeof(ushort)) { paramList.Add((ushort)0); }
                else if (paramInfo.ParameterType == typeof(byte)) { paramList.Add((byte)0); }
                else if (paramInfo.ParameterType == typeof(sbyte)) { paramList.Add((sbyte)0); }
                else if (paramInfo.ParameterType == typeof(decimal)) { paramList.Add((decimal)0); }
                else if (paramInfo.ParameterType == typeof(double)) { paramList.Add((double)0); }
                else if (paramInfo.ParameterType == typeof(float)) { paramList.Add((float)0); }
                else if (paramInfo.ParameterType == typeof(DateTime)) { paramList.Add(DateTime.MinValue); }
                else if (paramInfo.ParameterType == typeof(bool)) { paramList.Add(false); }
                else if (paramInfo.ParameterType == typeof(object)) { paramList.Add((object)null); }
                else
                {
                    // assume GetDataByCondXXX-cond-class has default constructor
                    object value = Activator.CreateInstance(paramInfo.ParameterType);
                    paramList.Add(value);
                    //paramList.Add(null);
                }
            }

            //LogOutput("use string.Empty as default string");
            DoExecuteParam(adapterType, methInfo, paramList);

            // use " " (one space) as default string
            //paramList = new List<object>();
            //foreach (ParameterInfo paramInfo in paramInfoes)
            //{
            //    if (paramInfo.ParameterType == typeof(string)) { paramList.Add(" "); }
            //    else if (paramInfo.ParameterType == typeof(int)) { paramList.Add((int)0); }
            //    else if (paramInfo.ParameterType == typeof(long)) { paramList.Add((long)0); }
            //    else if (paramInfo.ParameterType == typeof(short)) { paramList.Add((short)0); }
            //    else if (paramInfo.ParameterType == typeof(decimal)) { paramList.Add((decimal)0); }
            //    else if (paramInfo.ParameterType == typeof(double)) { paramList.Add((double)0); }
            //    else if (paramInfo.ParameterType == typeof(float)) { paramList.Add((float)0); }
            //    else if (paramInfo.ParameterType == typeof(DateTime)) { paramList.Add(DateTime.MinValue); }
            //    else if (paramInfo.ParameterType == typeof(object)) { paramList.Add((object)null); }
            //    else if (paramInfo.ParameterType == typeof(bool)) { paramList.Add(false); }
            //    else { paramList.Add(null); }
            //}

            //LogOutput("use \" \" (one space) as default string");
            //DoExecuteParam(adapterType, methInfo, paramList);

            //// use null as default string
            //if (hasNullableParam)
            //{
            //    paramList = new List<object>();
            //    foreach (ParameterInfo paramInfo in paramInfoes)
            //    {
            //        if (paramInfo.ParameterType == typeof(string)) { paramList.Add(null); }
            //        else if (paramInfo.ParameterType == typeof(int)) { paramList.Add((int)0); }
            //        else if (paramInfo.ParameterType == typeof(long)) { paramList.Add((long)0); }
            //        else if (paramInfo.ParameterType == typeof(short)) { paramList.Add((short)0); }
            //        else if (paramInfo.ParameterType == typeof(decimal)) { paramList.Add((decimal)0); }
            //        else if (paramInfo.ParameterType == typeof(double)) { paramList.Add((double)0); }
            //        else if (paramInfo.ParameterType == typeof(float)) { paramList.Add((float)0); }
            //        else if (paramInfo.ParameterType == typeof(DateTime)) { paramList.Add(DateTime.MinValue); }
            //        else if (paramInfo.ParameterType == typeof(object)) { paramList.Add((object)null); }
            //        else if (paramInfo.ParameterType == typeof(bool)) { paramList.Add(false); }
            //        else { paramList.Add(null); }
            //    }

            //    LogOutput("use null as default string");
            //    DoExecuteParam(adapterType, methInfo, paramList);
            //}
        }
        #endregion

        #region DoExecuteParam
        /// <summary>
        /// 設定済みのパラメータでGetXXXをテスト実行する
        /// </summary>
        /// <param name="adapterType"></param>
        /// <param name="methInfo"></param>
        /// <param name="paramList"></param>
        private void DoExecuteParam(Type adapterType, MethodInfo methInfo, List<object> paramList)
        {
            // TableAdapter実体作成(Instanciate TableAdapter)
            object adap = Activator.CreateInstance(adapterType);

            StringBuilder buf = new StringBuilder();

            string LOG_FORMAT = "{0},{1},{2},{3},\"{4}\"";

            try
            {
                DateTime startTime = DateTime.Now;

                adap.GetType().InvokeMember(methInfo.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, adap, paramList.ToArray());

                DateTime endTime = DateTime.Now;

                if ((endTime - startTime).TotalMilliseconds > 1000)
                {
                    buf.AppendFormat(LOG_FORMAT
                        , adapterType.Namespace.Substring(0, adapterType.Namespace.Length - "TableAdapters".Length)
                        , adapterType.Name
                        , methInfo.Name
                        , "SlowQuery"
                        , string.Format("TotalSeconds=[{0}]", ((decimal)(endTime - startTime).TotalMilliseconds) / 1000)
                        );
                    buf.AppendLine();

                    LogOutput(buf.ToString());
                }
            }
            catch (MissingMethodException e)
            {
                buf.AppendFormat(LOG_FORMAT
                    , adapterType.Namespace.Substring(0, adapterType.Namespace.Length - "TableAdapters".Length)
                    , adapterType.Name
                    , methInfo.Name
                    , "QueryExcuteError"
                    , string.Format("Message=[{0}]", e.Message.Replace("\r", "").Replace("\n", ""))
                    );
                buf.AppendLine();

                LogOutput(buf.ToString());
            }
            catch (TargetInvocationException e)
            {
                buf.AppendFormat(LOG_FORMAT
                    , adapterType.Namespace.Substring(0, adapterType.Namespace.Length - "TableAdapters".Length)
                    , adapterType.Name
                    , methInfo.Name
                    , "QueryExcuteError"
                    , string.Format("Message=[{0}]", e.InnerException.Message.Replace("\r", "").Replace("\n", ""))
                    );
                buf.AppendLine();

                LogOutput(buf.ToString());
            }
            catch (Exception e)
            {
                buf.AppendFormat(LOG_FORMAT
                    , adapterType.Namespace.Substring(0, adapterType.Namespace.Length - "TableAdapters".Length)
                    , adapterType.Name
                    , methInfo.Name
                    , "QueryExcuteError"
                    , string.Format("Message=[{0}]", e.Message.Replace("\r", "").Replace("\n", ""))
                    );
                buf.AppendLine();

                LogOutput(buf.ToString());
            }
        }
        #endregion

        #region TestGetData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adapterType"></param>
        /// <param name="methInfo"></param>
        private void TestGetData(Type adapterType, MethodInfo methInfo)
        {
            // Method Calling Convention check
            // GetData should Returns DataTable(DataTableを返すか)
            if (!CheckGetDataConvention(methInfo))
            {
                return;
            }

            // 
            ExecuteCommand(adapterType, methInfo);
        }
        #endregion

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTableType"></param>
        /// <param name="adapterType"></param>
        private void CompareDataTableColCnt(Type dataTableType, Type adapterType)
        {
            string tblName = dataTableType.Name.Substring(0, dataTableType.Name.Length - "DataTable".Length);

            // ベーステーブル以外はスキップ
            if (!baseTableList.Contains(tblName))
            {
                return;
            }

            // TableAdapter実体作成(Instanciate TableAdapter)
            object adap = Activator.CreateInstance(adapterType);

            DataTable cdTable = (DataTable)Activator.CreateInstance(dataTableType);

            PropertyInfo propInfoCommand = adap.GetType().GetProperty("CommandCollection", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            DbCommand[] baseCommandCollection = (DbCommand[])propInfoCommand.GetValue(adap, null);

            string LOG_FORMAT = "{0},{1},{2},\"{3}\"";

            StringBuilder buf = new StringBuilder();

            if (baseCommandCollection.Count() == 0)
            {
                buf.AppendFormat(LOG_FORMAT
                    , adapterType.Namespace.Substring(0, adapterType.Namespace.Length - "TableAdapters".Length)
                    , adapterType.Name
                    , "No Command set"
                    , ""
                    );
                buf.AppendLine();
            }
            else
            {
                DbCommand baseCommand = baseCommandCollection.ElementAt(0);

                string query = string.Format("SELECT TOP 1 * FROM {0}", tblName);

                SqlCommand newCommand = new SqlCommand();
                newCommand.Connection = (SqlConnection)baseCommand.Connection;
                newCommand.CommandText = query;

                newCommand.Connection.Open();

                try
                {
                    SqlDataReader dbReader = (SqlDataReader)newCommand.ExecuteReader();

                    DataTable getTable = dbReader.GetSchemaTable();
                    int getColCount = getTable.Rows.Count;

                    if (cdTable.Columns.Count != getColCount)
                    {
                        buf.AppendFormat(LOG_FORMAT
                            , adapterType.Namespace.Substring(0, adapterType.Namespace.Length - "TableAdapters".Length)
                            , adapterType.Name
                            , "ColCntDiffer"
                            , string.Format("Name=[{0}]", tblName)
                            );
                        buf.AppendLine();
                    }
                }
                finally
                {
                    newCommand.Connection.Close();
                }
            }

            queryCnt++;

            LogOutput(buf.ToString());
        }

        private void CompareDataTableType(Type dataTableType, Type adapterType)
        {
            // TableAdapter実体作成(Instanciate TableAdapter)
            object adap = Activator.CreateInstance(adapterType);

            DataTable cdTable = (DataTable)Activator.CreateInstance(dataTableType);

            PropertyInfo propInfoCommand = adap.GetType().GetProperty("CommandCollection", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            DbCommand[] baseCommandCollection = (DbCommand[])propInfoCommand.GetValue(adap, null);

            string LOG_FORMAT = "{0},{1},{2},\"{3}\"";

            StringBuilder buf = new StringBuilder();

            foreach (DbCommand baseCommand in baseCommandCollection)
            {
                baseCommand.Connection.Open();
                try
                {
                    SqlDataReader dbReader = (SqlDataReader)baseCommand.ExecuteReader();

                    DataTable getTable = dbReader.GetSchemaTable();

                    // create col-type map
                    Dictionary<string, Type> colTypeMap = new Dictionary<string, Type>();
                    Dictionary<string, string> colTypeNameMap = new Dictionary<string, string>();
                    Dictionary<string, int> colLengthMap = new Dictionary<string, int>();

                    // Examine schema table
                    for (int i = 0; i < getTable.Rows.Count; i++)
                    {
                        // get type info from schema(For SQL Server)
                        Type t = (Type)getTable.Rows[i]["DataType"];

                        colTypeMap.Add((string)getTable.Rows[i]["ColumnName"], t);

                        int size = (int)getTable.Rows[i]["ColumnSize"];

                        colLengthMap.Add((string)getTable.Rows[i]["ColumnName"], size);
                    }

                    // compare get data types to dataTable
                    foreach (DataColumn col in cdTable.Columns)
                    {
                        if (!colTypeMap.ContainsKey(col.ColumnName))
                        {
                            continue;
                        }

                        if (col.DataType != colTypeMap[col.ColumnName])
                        {
                            buf.AppendFormat(LOG_FORMAT
                                , adapterType.Namespace.Substring(0, adapterType.Namespace.Length - "TableAdapters".Length)
                                , adapterType.Name
                                , "TypeDiffer"
                                , string.Format("Name=[{0}],DataTableType=[{1}],GetType[{2}]", col.ColumnName, col.DataType, colTypeMap[col.ColumnName])
                                );
                            buf.AppendLine();

                        }

                        if (col.MaxLength != -1 && col.MaxLength != colLengthMap[col.ColumnName])
                        {
                            if (col.MaxLength > colLengthMap[col.ColumnName])
                            {
                                buf.AppendFormat(LOG_FORMAT
                                    , adapterType.Namespace.Substring(0, adapterType.Namespace.Length - "TableAdapters".Length)
                                    , adapterType.Name
                                    , "LengthDiffer(DataTableLong)"
                                    , string.Format("Name=[{0}],DataTableLength=[{1}],GetLength[{2}]", col.ColumnName, col.MaxLength, colLengthMap[col.ColumnName])
                                    );
                                buf.AppendLine();
                            }
                            else
                            {
                                buf.AppendFormat(LOG_FORMAT
                                    , adapterType.Namespace.Substring(0, adapterType.Namespace.Length - "TableAdapters".Length)
                                    , adapterType.Name
                                    , "LengthDiffer(DataTableShort)"
                                    , string.Format("Name=[{0}],DataTableLength=[{1}],GetLength[{2}]", col.ColumnName, col.MaxLength, colLengthMap[col.ColumnName])
                                    );
                                buf.AppendLine();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    buf.AppendFormat(LOG_FORMAT
                        , adapterType.Namespace.Substring(0, adapterType.Namespace.Length - "TableAdapters".Length)
                        , adapterType.Name
                        , "QueryExcuteError"
                        , string.Format("Message=[{0}]", e.Message.Replace("\r", "").Replace("\n", ""))
                        );
                    buf.AppendLine();
                }
                finally
                {
                    baseCommand.Connection.Close();
                }

                queryCnt++;
            }

            LogOutput(buf.ToString());
        }

        private bool IsDerivedClass(Type derivedClass, Type baseClass)
        {
            Type currentType = derivedClass;

            while (true)
            {
                if (currentType == baseClass)
                {
                    return true;
                }

                currentType = currentType.BaseType;

                if (currentType == null)
                {
                    return false;
                }
            }
        }

        #region LogOutput

        private void LogOutputBegin()
        {
            logBoxBuf = new StringBuilder();
            queryCnt = 0;

            logOutputTextBox.Clear();
        }

        private void LogOutputEnd()
        {
            logBoxBuf.AppendFormat("Query Count=[{0}]", queryCnt);
            logBoxBuf.AppendLine();

            logOutputTextBox.Text += logBoxBuf.ToString();
        }

        private void LogOutput(string text)
        {
            logBoxBuf.AppendLine(text);

        }

        #endregion

    }

}
