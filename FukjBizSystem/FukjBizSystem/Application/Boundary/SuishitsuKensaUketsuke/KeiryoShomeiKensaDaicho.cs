using System;
using System.Data;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.KeiryoShomeiDaicho;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.Boundary.JokasoDaichoKanri;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.KeiryoShomeiDaicho;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.SuishitsuKensaUketsuke
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KeiryoShomeiKensaDaicho
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付        担当者    内容
    /// 2014/12/04　宗        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KeiryoShomeiKensaDaicho : FukjBaseForm
    {
        #region プロパティ

        // 下線付きフォント
        private Font underLineFont;

        /// <summary>
        /// ログインユーザーの所属支所コード
        /// </summary>
        private string LoginUserShozokuShishoCd = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;

        /// <summary>
        /// ログインユーザー名
        /// </summary>
        private string LoginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// クライアント端末名
        /// </summary>
        private string HostName = Dns.GetHostName();

        /// <summary>
        /// 画面モード
        /// </summary>
        enum DispMode
        {
            Load,
            Kakunin,
            Hensyu
        };

        /// <summary>
        /// 定数連番(法定検査の試験項目)
        /// </summary>
        private const string ConstRenbanPh           = "001";
        private const string ConstRenbanSs           = "002";
        private const string ConstRenbanBodA         = "003";
        private const string ConstRenbanNh4n         = "004";
        private const string ConstRenbanCl           = "005";
        private const string ConstRenbanCod          = "006";
        private const string ConstRenbanHekisanA     = "007";
        private const string ConstRenbanMlss         = "008";
        private const string ConstRenbanTnA          = "009";
        private const string ConstRenbanAbsA         = "010";
        private const string ConstRenbanTpA          = "011";
        private const string ConstRenbanRinsan       = "012";
        private const string ConstRenbanNo2nTeiryo   = "013";
        private const string ConstRenbanNo3nTeiryo   = "014";
        private const string ConstRenbanAbsB         = "015";
        private const string ConstRenbanTnB          = "016";
        private const string ConstRenbanTpB          = "017";
        private const string ConstRenbanShikido      = "018";
        private const string ConstRenbanBodB         = "019";
        private const string ConstRenbanHekisanKoyu  = "020";
        private const string ConstRenbanHekisanDoshoku = "021";
        private const string ConstRenbanHekisanB     = "022";
        private const string ConstRenbanNamari       = "023";
        private const string ConstRenbanAen          = "024";
        private const string ConstRenbanHouso        = "025";
        private const string ConstRenbanZanen        = "026";
        private const string ConstRenbanGaikan       = "027";
        private const string ConstRenbanShuki        = "028";
        private const string ConstRenbanTr           = "029";
        private const string ConstRenbanNo2nTeisei   = "030";
        private const string ConstRenbanNo3nTeisei   = "031";
        private const string ConstRenbanDaichokin    = "032";

        // 計量証明の試験項目コード
        private DataTable kmkCdDt = Common.Common.GetConstTable("049");

        /// <summary>
        /// チェック状態確認用
        /// </summary>
        private const string CheckOn = "True";
        private const string CheckOff = "False";

        /// <summary>
        /// 内部変更フラグ
        /// </summary>
        private bool insideFlg = true;

        /// <summary>
        /// 前回検索条件保持
        /// </summary>
        private IKensakuBtnClickALInput _searchAlInput;

        #endregion

        #region コンストラクタ

        public KeiryoShomeiKensaDaicho()
        {
            insideFlg = true;

            InitializeComponent();

            // ドメイン設定
            nendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 4);
            iraiNoFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);
            iraiNoToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);

            // ドメイン設定(DataGridView)
            // 20140108 sou Start 桁指定を整数桁→全桁に修正
            //listDataGridView.SetStdControlDomain(ph1Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(ondo1Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(ph2Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(ondo2Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //
            //listDataGridView.SetStdControlDomain(ss1Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            //listDataGridView.SetStdControlDomain(ss2Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            //
            //listDataGridView.SetStdControlDomain(bodA1Col.Index, ZControlDomain.ZG_STD_NUM, 2, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(bodA2Col.Index, ZControlDomain.ZG_STD_NUM, 2, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(nh4n1Col.Index, ZControlDomain.ZG_STD_NUM, 2, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(nh4n2Col.Index, ZControlDomain.ZG_STD_NUM, 2, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //
            //listDataGridView.SetStdControlDomain(cl1Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            //listDataGridView.SetStdControlDomain(cl2Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            //
            //listDataGridView.SetStdControlDomain(cod1Col.Index, ZControlDomain.ZG_STD_NUM, 2, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(cod2Col.Index, ZControlDomain.ZG_STD_NUM, 2, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(hekisanA1Col.Index, ZControlDomain.ZG_STD_NUM, 2, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(hekisanA2Col.Index, ZControlDomain.ZG_STD_NUM, 2, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //
            //listDataGridView.SetStdControlDomain(mlss1Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            //listDataGridView.SetStdControlDomain(mlss2Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            //
            //listDataGridView.SetStdControlDomain(tnA1Col.Index, ZControlDomain.ZG_STD_NUM, 2, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(tnA2Col.Index, ZControlDomain.ZG_STD_NUM, 2, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(absA1Col.Index, ZControlDomain.ZG_STD_NUM, 2, 2, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(absA2Col.Index, ZControlDomain.ZG_STD_NUM, 2, 2, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(tpA1Col.Index, ZControlDomain.ZG_STD_NUM, 2, 2, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(tpA2Col.Index, ZControlDomain.ZG_STD_NUM, 2, 2, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(rinsan1Col.Index, ZControlDomain.ZG_STD_NUM, 2, 2, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(rinsan2Col.Index, ZControlDomain.ZG_STD_NUM, 2, 2, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(no2nTeiryo1Col.Index, ZControlDomain.ZG_STD_NUM, 2, 2, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(no2nTeiryo2Col.Index, ZControlDomain.ZG_STD_NUM, 2, 2, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(no3nTeiryo1Col.Index, ZControlDomain.ZG_STD_NUM, 2, 2, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(no3nTeiryo2Col.Index, ZControlDomain.ZG_STD_NUM, 2, 2, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(absB1Col.Index, ZControlDomain.ZG_STD_NUM, 2, 2, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(absB2Col.Index, ZControlDomain.ZG_STD_NUM, 2, 2, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(tnB1Col.Index, ZControlDomain.ZG_STD_NUM, 2, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(tnB2Col.Index, ZControlDomain.ZG_STD_NUM, 2, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(tpB1Col.Index, ZControlDomain.ZG_STD_NUM, 2, 2, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(tpB2Col.Index, ZControlDomain.ZG_STD_NUM, 2, 2, InputValidateUtility.SignFlg.PositiveNegative);
            //
            //listDataGridView.SetStdControlDomain(shikido1Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            //listDataGridView.SetStdControlDomain(shikido2Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            //
            //listDataGridView.SetStdControlDomain(bodB1Col.Index, ZControlDomain.ZG_STD_NUM, 2, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(bodB2Col.Index, ZControlDomain.ZG_STD_NUM, 2, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(hekisanKoyu1Col.Index, ZControlDomain.ZG_STD_NUM, 2, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(hekisanKoyu2Col.Index, ZControlDomain.ZG_STD_NUM, 2, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(hekisanDoshoku1Col.Index, ZControlDomain.ZG_STD_NUM, 2, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(hekisanDoshoku2Col.Index, ZControlDomain.ZG_STD_NUM, 2, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(hekisanB1Col.Index, ZControlDomain.ZG_STD_NUM, 2, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(hekisanB2Col.Index, ZControlDomain.ZG_STD_NUM, 2, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(zanen1Col.Index, ZControlDomain.ZG_STD_NUM, 2, 2, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(zanen2Col.Index, ZControlDomain.ZG_STD_NUM, 2, 2, InputValidateUtility.SignFlg.PositiveNegative);
            //
            //listDataGridView.SetStdControlDomain(tr1Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            //listDataGridView.SetStdControlDomain(tr2Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            //listDataGridView.SetStdControlDomain(daichokin1Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            //listDataGridView.SetStdControlDomain(daichokin2Col.Index, ZControlDomain.ZG_STD_NUM, 2);

            listDataGridView.SetStdControlDomain(ph1Col.Index, ZControlDomain.ZG_STD_NUM, 4, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(ondo1Col.Index, ZControlDomain.ZG_STD_NUM, 4, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(ph2Col.Index, ZControlDomain.ZG_STD_NUM, 4, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(ondo2Col.Index, ZControlDomain.ZG_STD_NUM, 4, 1, InputValidateUtility.SignFlg.PositiveNegative);

            listDataGridView.SetStdControlDomain(ss1Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            listDataGridView.SetStdControlDomain(ss2Col.Index, ZControlDomain.ZG_STD_NUM, 2);

            listDataGridView.SetStdControlDomain(bodA1Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(bodA2Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(nh4n1Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(nh4n2Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);

            listDataGridView.SetStdControlDomain(cl1Col.Index, ZControlDomain.ZG_STD_NUM, 4);
            listDataGridView.SetStdControlDomain(cl2Col.Index, ZControlDomain.ZG_STD_NUM, 4);

            listDataGridView.SetStdControlDomain(cod1Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(cod2Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(hekisanA1Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(hekisanA2Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);

            listDataGridView.SetStdControlDomain(mlss1Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            listDataGridView.SetStdControlDomain(mlss2Col.Index, ZControlDomain.ZG_STD_NUM, 2);

            listDataGridView.SetStdControlDomain(tnA1Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(tnA2Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(absA1Col.Index, ZControlDomain.ZG_STD_NUM, 4, 2, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(absA2Col.Index, ZControlDomain.ZG_STD_NUM, 4, 2, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(tpA1Col.Index, ZControlDomain.ZG_STD_NUM, 4, 2, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(tpA2Col.Index, ZControlDomain.ZG_STD_NUM, 4, 2, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(rinsan1Col.Index, ZControlDomain.ZG_STD_NUM, 4, 2, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(rinsan2Col.Index, ZControlDomain.ZG_STD_NUM, 4, 2, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(no2nTeiryo1Col.Index, ZControlDomain.ZG_STD_NUM, 4, 2, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(no2nTeiryo2Col.Index, ZControlDomain.ZG_STD_NUM, 4, 2, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(no3nTeiryo1Col.Index, ZControlDomain.ZG_STD_NUM, 4, 2, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(no3nTeiryo2Col.Index, ZControlDomain.ZG_STD_NUM, 4, 2, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(absB1Col.Index, ZControlDomain.ZG_STD_NUM, 4, 2, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(absB2Col.Index, ZControlDomain.ZG_STD_NUM, 4, 2, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(tnB1Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(tnB2Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(tpB1Col.Index, ZControlDomain.ZG_STD_NUM, 4, 2, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(tpB2Col.Index, ZControlDomain.ZG_STD_NUM, 4, 2, InputValidateUtility.SignFlg.PositiveNegative);

            listDataGridView.SetStdControlDomain(shikido1Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            listDataGridView.SetStdControlDomain(shikido2Col.Index, ZControlDomain.ZG_STD_NUM, 2);

            listDataGridView.SetStdControlDomain(bodB1Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(bodB2Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(hekisanKoyu1Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(hekisanKoyu2Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(hekisanDoshoku1Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(hekisanDoshoku2Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(hekisanB1Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(hekisanB2Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(zanen1Col.Index, ZControlDomain.ZG_STD_NUM, 4, 2, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(zanen2Col.Index, ZControlDomain.ZG_STD_NUM, 4, 2, InputValidateUtility.SignFlg.PositiveNegative);

            listDataGridView.SetStdControlDomain(tr1Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            listDataGridView.SetStdControlDomain(tr2Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            listDataGridView.SetStdControlDomain(daichokin1Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            listDataGridView.SetStdControlDomain(daichokin2Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            // 20140108 sou End

            insideFlg = false;
        }

        #endregion

        #region イベント

        #region FormLoad
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SuishitsuKensaDaichoForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/04　宗        新規作成
        /// 2015/01/27  宗        取得する支所マスタを全件から事務局以外に変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuKensaDaichoForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.constMstConstKbn053TableAdapter.Fill(this.constMstDataSet.ConstMstConstKbn053);
                this.constMstConstKbn052TableAdapter.Fill(this.constMstDataSet.ConstMstConstKbn052);

                // フォームのフォントのベースに下線付きフォントを生成
                underLineFont = new Font(this.Font, this.Font.Style | FontStyle.Strikeout);

                // コンボボックスの選択リスト設定
                ComboBoxListSet();

//#if DEBUG
//                // 全項目表示
//                for(int idx = 0; idx < listDataGridView.ColumnCount; idx++)
//                {
//                    listDataGridView.Columns[idx].Visible = true;
//                }
//#else
                // スクロール固定
                listDataGridView.Columns[kanrishaKeninCol.Index].Frozen = true;
//#endif
                // ヘッダのVisualスタイルを無効化
                listDataGridView.EnableHeadersVisualStyles = false;
                // ヘッダの背景色を設定
                SetHeaderBackColor(ph1Col.Index, Color.Gold);
                SetHeaderBackColor(ss1Col.Index, Color.LawnGreen);
                SetHeaderBackColor(bodA1Col.Index, Color.Gold);
                SetHeaderBackColor(nh4n1Col.Index, Color.LawnGreen);
                SetHeaderBackColor(cl1Col.Index, Color.Gold);
                SetHeaderBackColor(cod1Col.Index, Color.LawnGreen);
                SetHeaderBackColor(hekisanA1Col.Index, Color.Gold);
                SetHeaderBackColor(mlss1Col.Index, Color.LawnGreen);
                SetHeaderBackColor(tnA1Col.Index, Color.Gold);
                SetHeaderBackColor(absA1Col.Index, Color.LawnGreen);
                SetHeaderBackColor(tpA1Col.Index, Color.Gold);
                SetHeaderBackColor(rinsan1Col.Index, Color.LawnGreen);
                SetHeaderBackColor(no2nTeiryo1Col.Index, Color.Gold);
                SetHeaderBackColor(no3nTeiryo1Col.Index, Color.LawnGreen);
                SetHeaderBackColor(absB1Col.Index, Color.Gold);
                SetHeaderBackColor(tnB1Col.Index, Color.LawnGreen);
                SetHeaderBackColor(tpB1Col.Index, Color.Gold);
                SetHeaderBackColor(shikido1Col.Index, Color.LawnGreen);
                SetHeaderBackColor(bodB1Col.Index, Color.Gold);
                SetHeaderBackColor(hekisanKoyu1Col.Index, Color.LawnGreen);
                SetHeaderBackColor(hekisanDoshoku1Col.Index, Color.Gold);
                SetHeaderBackColor(hekisanB1Col.Index, Color.LawnGreen);
                SetHeaderBackColor(namari1Col.Index, Color.Gold);
                SetHeaderBackColor(aen1Col.Index, Color.LawnGreen);
                SetHeaderBackColor(houso1Col.Index, Color.Gold);
                SetHeaderBackColor(zanen1Col.Index, Color.LawnGreen);
                SetHeaderBackColor(gaikan1Col.Index, Color.Gold);
                SetHeaderBackColor(shuki1Col.Index, Color.LawnGreen);
                SetHeaderBackColor(tr1Col.Index, Color.Gold);
                SetHeaderBackColor(no2nTeisei1Col.Index, Color.LawnGreen);
                SetHeaderBackColor(no3nTeisei1Col.Index, Color.Gold);
                SetHeaderBackColor(daichokin1Col.Index, Color.LawnGreen);

                // 全検査項目非表示
                for (int idx = ph1Col.Index; idx < kekkaKakuteiDtCol.Index; idx++)
                {
                    listDataGridView.Columns[idx].Visible = false;
                }

                // 20150116 habu 初期表示時は、台帳出力できない
                // 画面モード変更
                ModeChange(DispMode.Load);
                //ModeChange(DispMode.Kakunin);

                // 20150120 sou Start
                // 支所
                IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(new FormLoadALInput());
                //Utility.Utility.SetComboBoxList(shishoComboBox, alOutput.ShishoMstDataTable, "ShishoNm", "ShishoCd", true);
                Utility.Utility.SetComboBoxList(shishoComboBox, alOutput.ShishoMstExceptJimukyokuDataTable, "ShishoNm", "ShishoCd", true);
                // 20150120 sou End

                // 2015.01.05 toyoda Add Start
                // 検索条件の初期化
                SearchConditionClear();
                // 2015.01.05 toyoda Add End

                // 20150114 habu ラジオボタン処理修正
                // チェックボックス列のラジオボタン化
                listDataGridView.SetRadioGroup(new int[] { saiyotiPh1Col.Index, saiyotiPh2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiSs1Col.Index, saiyotiSs2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiBodA1Col.Index, saiyotiBodA2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiNh4n1Col.Index, saiyotiNh4n2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiCl1Col.Index, saiyotiCl2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiCod1Col.Index, saiyotiCod2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiHekisanA1Col.Index, saiyotiHekisanA2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiMlss1Col.Index, saiyotiMlss2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiTnA1Col.Index, saiyotiTnA2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiAbsA1Col.Index, saiyotiAbsA2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiTpA1Col.Index, saiyotiTpA2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiRinsan1Col.Index, saiyotiRinsan2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiNo2nTeiryo1Col.Index, saiyotiNo2nTeiryo2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiNo3nTeiryo1Col.Index, saiyotiNo3nTeiryo2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiAbsB1Col.Index, saiyotiAbsB2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiTnB1Col.Index, saiyotiTnB2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiTpB1Col.Index, saiyotiTpB2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiShikido1Col.Index, saiyotiShikido2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiBodB1Col.Index, saiyotiBodB2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiHekisanKoyu1Col.Index, saiyotiHekisanKoyu2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiHekisanDoshoku1Col.Index, saiyotiHekisanDoshoku2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiHekisanB1Col.Index, saiyotiHekisanB2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiNamari1Col.Index, saiyotiNamari2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiAen1Col.Index, saiyotiAen2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiHouso1Col.Index, saiyotiHouso2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiZanen1Col.Index, saiyotiZanen2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiGaikan1Col.Index, saiyotiGaikan2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiShuki1Col.Index, saiyotiShuki2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiTr1Col.Index, saiyotiTr2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiNo2nTeisei1Col.Index, saiyotiNo2nTeisei2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiNo3nTeisei1Col.Index, saiyotiNo3nTeisei2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiDaichokin1Col.Index, saiyotiDaichokin2Col.Index });

                // 20150127 sou Start DataGridViewの全列の並び替え不可
                foreach (DataGridViewColumn col in listDataGridView.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                // 20150127 sou End
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);

                // 画面を終了（前画面に戻る）
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region 検索条件の表示切替
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ViewChangeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/04　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ViewChangeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (viewChangeButton.Text == "▼")
                //if (searchPanel.Height == 30)
                {
                    searchPanel.Height = 94;
                    //listPanel.Top = 187;
                    //listPanel.Height = 339;
                    viewChangeButton.Text = "▲";
                }
                else
                {
                    searchPanel.Height = 30;
                    //listPanel.Top = 30;
                    //listPanel.Height = 475;
                    viewChangeButton.Text = "▼";
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region 依頼受付日の入力切替
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraiUketsukeDtCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/04　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraiUketsukeDtCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 依頼受付日の活性非活性切り替え
                if (iraiUketsukeDtCheckBox.Checked == true)
                {
                    iraiUketsukeDtFromDateTimePicker.Enabled = true;
                    iraiUketsukeDtToDateTimePicker.Enabled = true;
                }
                else
                {
                    iraiUketsukeDtFromDateTimePicker.Enabled = false;
                    iraiUketsukeDtToDateTimePicker.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region クリアボタン押下
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： clearButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/04　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 検索条件の初期化
                SearchConditionClear();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region 検索ボタン押下
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensakuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/04　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 内部変更On
                insideFlg = true;

                // 関連チェック
                if (!RelationCheck())
                {
                    return;
                }

                // 編集内容破棄チェック
                if (!EditCheck())
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") == DialogResult.No)
                    {
                        return;
                    }
                }

                // 20150120 sou Start
                // 選択リストの再設定(支所変更時)
                ComboBoxListSet();
                // 20150120 sou End

                // 検索条件生成
                IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();
                MakeSearchCond(alInput);

                // 検索
                DoSearch(alInput);

                // 検索条件保持
                _searchAlInput = alInput;

                // 画面モード変更、初回判定がある場合は編集モード
                ModeChange((!EditCheck()) ? DispMode.Hensyu : DispMode.Kakunin);
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                // 内部変更Off
                insideFlg = false;

                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region 台帳出力ボタン押下
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： daichoPrintButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/04　宗        新規作成
        /// 2015/01/19　habu      出力条件の指定を検索処理と合わせる
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void daichoPrintButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 実行確認
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "検査台帳を出力します。よろしいですか？") == DialogResult.No)
                {
                    return;
                }

                // 20150116 habu 編集済みの場合、破棄確認メッセージを表示する様に変更
                if (!EditCheck())
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "未確定分の編集内容は出力に反映されません。\r\n出力を行いますか？") == DialogResult.No)
                    {
                        return;
                    }
                }

                // 9条検査台帳出力
                IDaichoPrintBtnClickALInput alInput = new DaichoPrintBtnClickALInput();
                alInput.SearchCond = _searchAlInput.SearchCond;

                #region to be removed
                //alInput.Nendo = nendoTextBox.Text;
                //alInput.IraiDateKbn = iraiUketsukeDtCheckBox.Checked == true ? "1" : "0";
                //alInput.IraiDateFrom = iraiUketsukeDtFromDateTimePicker.Value.ToString("yyyyMMdd");
                //alInput.IraiDateTo = iraiUketsukeDtToDateTimePicker.Value.ToString("yyyyMMdd");
                //alInput.IraiNoFrom = string.IsNullOrEmpty(iraiNoFromTextBox.Text) == true ? string.Empty : iraiNoFromTextBox.Text.PadLeft(6, '0');
                //alInput.IraiNoTo = string.IsNullOrEmpty(iraiNoToTextBox.Text) == true ? string.Empty : iraiNoToTextBox.Text.PadLeft(6, '0');
                #endregion

                new DaichoPrintBtnClickApplicationLogic().Execute(alInput);

                //20150122 sou Start
                //MessageForm.Show2(MessageForm.DispModeType.Infomation, "出力が完了しました。");
                //20150122 sou End
            }
            catch (CustomException ce)
            {
                if ((ce.ResultCode == ResultCode.OperationError) && (ce.ExtensionCode == (int)Print9joKensaDaichoBusinessLogic.OperationErr.NoDataFound))
                {
                    TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), "出力データがありません。");
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "出力データがありません。");
                }
                else
                {
                    TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ce.ToString());
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ce.Message);
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region 確定ボタン押下
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kakuteiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/08　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kakuteiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (listDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "対象データがありません。");
                    return;
                }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集された内容を確定します。\r\nよろしいですか？") == DialogResult.No)
                {
                    return;
                }

                // DB更新
                IKakuteiBtnClickALInput alInput = new KakuteiBtnClickALInput();
                alInput.UpdateDt = Boundary.Common.Common.GetCurrentTimestamp();
                alInput.UpdateUser = LoginUser;
                alInput.UpdateTarm = HostName;
                alInput.listDataGridView = listDataGridView;
                new KakuteiBtnClickApplicationLogic().Execute(alInput);

                // 20150111 sou Start
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "確定処理が完了しました。");
                // 20150111 sou End

                #region 更新区分の初期化
                foreach (DataGridViewRow dgvr in listDataGridView.Rows)
                {
                    // 更新区分(検印)
                    dgvr.Cells[koshinKbnKenin.Index].Value = "0";

                    // 更新区分（pH）
                    dgvr.Cells[koshinKbnPh.Index].Value = "0";
                    // 更新区分（SS）
                    dgvr.Cells[koshinKbnSs.Index].Value = "0";
                    // 更新区分（BOD（A））
                    dgvr.Cells[koshinKbnBodA.Index].Value = "0";
                    // 更新区分（アンモニア性窒素）
                    dgvr.Cells[koshinKbnNh4n.Index].Value = "0";
                    // 更新区分（塩化物イオン）
                    dgvr.Cells[koshinKbnCl.Index].Value = "0";
                    // 更新区分（COD）
                    dgvr.Cells[koshinKbnCod.Index].Value = "0";
                    // 更新区分（ヘキサン抽出物質（A））
                    dgvr.Cells[koshinKbnHekisanA.Index].Value = "0";
                    // 更新区分（MLSS）
                    dgvr.Cells[koshinKbnMlss.Index].Value = "0";
                    // 更新区分（全窒素（A)）
                    dgvr.Cells[koshinKbnTnA.Index].Value = "0";
                    // 更新区分（陰イオン界面活性剤（A））
                    dgvr.Cells[koshinKbnAbsA.Index].Value = "0";
                    // 更新区分（全りん（A)）
                    dgvr.Cells[koshinKbnTpA.Index].Value = "0";
                    // 更新区分（りん酸イオン）
                    dgvr.Cells[koshinKbnRinsan.Index].Value = "0";
                    // 更新区分（亜硝酸性窒素（定量））
                    dgvr.Cells[koshinKbnNo2nTeiryo.Index].Value = "0";
                    // 更新区分（硝酸性窒素（定量））
                    dgvr.Cells[koshinKbnNo3nTeiryo.Index].Value = "0";
                    // 更新区分（陰イオン界面活性剤（B)）
                    dgvr.Cells[koshinKbnAbsB.Index].Value = "0";
                    // 更新区分（全窒素（B)）
                    dgvr.Cells[koshinKbnTnB.Index].Value = "0";
                    // 更新区分（全りん（B)）
                    dgvr.Cells[koshinKbnTpB.Index].Value = "0";
                    // 更新区分（色度）
                    dgvr.Cells[koshinKbnShikido.Index].Value = "0";
                    // 更新区分（BOD（B））
                    dgvr.Cells[koshinKbnBodB.Index].Value = "0";
                    // 更新区分（ヘキサン抽出物質（鉱油類））
                    dgvr.Cells[koshinKbnHekisanKoyu.Index].Value = "0";
                    // 更新区分（ヘキサン抽出物質（動植物油類））
                    dgvr.Cells[koshinKbnHekisanDoshoku.Index].Value = "0";
                    // 更新区分（ヘキサン抽出物質（B））
                    dgvr.Cells[koshinKbnHekisanB.Index].Value = "0";
                    // 更新区分（鉛）
                    dgvr.Cells[koshinKbnNamari.Index].Value = "0";
                    // 更新区分（亜鉛）
                    dgvr.Cells[koshinKbnAen.Index].Value = "0";
                    // 更新区分（ほう素）
                    dgvr.Cells[koshinKbnHouso.Index].Value = "0";
                    // 更新区分（残塩）
                    dgvr.Cells[koshinKbnZanen.Index].Value = "0";
                    // 更新区分（外観）
                    dgvr.Cells[koshinKbnGaikan.Index].Value = "0";
                    // 更新区分（臭気）
                    dgvr.Cells[koshinKbnShuki.Index].Value = "0";
                    // 更新区分（透視度）
                    dgvr.Cells[koshinKbnTr.Index].Value = "0";
                    // 更新区分（亜硝酸性窒素（定性））
                    dgvr.Cells[koshinKbnNo2nTeisei.Index].Value = "0";
                    // 更新区分（硝酸性窒素（定性））
                    dgvr.Cells[koshinKbnNo3nTeisei.Index].Value = "0";
                    // 更新区分（大腸菌群数）
                    dgvr.Cells[koshinKbnDaichokin.Index].Value = "0";

                    // 更新区分（SS/透視度）
                    dgvr.Cells[koshinKbnSsTr.Index].Value = "0";
                    // 更新区分（BOD/透視度）
                    dgvr.Cells[koshinKbnBodTr.Index].Value = "0";
                    // 更新区分（塩化物イオン確認検査）
                    dgvr.Cells[koshinKbnEnkaIon.Index].Value = "0";
                    // 更新区分（アンモニア確認検査）
                    dgvr.Cells[koshinKbnAnmonia.Index].Value = "0";
                    // 更新区分（アンモニアと全窒素）
                    dgvr.Cells[koshinKbnAnmoniaTn.Index].Value = "0";
                    // 更新区分（COD基準値オーバー）
                    dgvr.Cells[koshinKbnCodOver.Index].Value = "0";

                    // 更新区分（過去との比較）pH
                    dgvr.Cells[koshinKbnKakoPh.Index].Value = "0";
                    // 更新区分（過去との比較）SS
                    dgvr.Cells[koshinKbnKakoSs.Index].Value = "0";
                    // 更新区分（過去との比較）BOD（A）
                    dgvr.Cells[koshinKbnKakoBodA.Index].Value = "0";
                    // 更新区分（過去との比較）アンモニア性窒素
                    dgvr.Cells[koshinKbnKakoNh4n.Index].Value = "0";
                    // 更新区分（過去との比較）塩化物イオン
                    dgvr.Cells[koshinKbnKakoCl.Index].Value = "0";
                    // 更新区分（過去との比較）COD
                    dgvr.Cells[koshinKbnKakoCod.Index].Value = "0";
                    // 更新区分（過去との比較）ヘキサン抽出物質（A）
                    dgvr.Cells[koshinKbnKakoHekisanA.Index].Value = "0";
                    // 更新区分（過去との比較）MLSS
                    dgvr.Cells[koshinKbnKakoMlss.Index].Value = "0";
                    // 更新区分（過去との比較）全窒素（A)
                    dgvr.Cells[koshinKbnKakoTnA.Index].Value = "0";
                    // 更新区分（過去との比較）陰イオン界面活性剤（A）
                    dgvr.Cells[koshinKbnKakoAbsA.Index].Value = "0";
                    // 更新区分（過去との比較）全りん（A)
                    dgvr.Cells[koshinKbnKakoTpA.Index].Value = "0";
                    // 更新区分（過去との比較）りん酸イオン
                    dgvr.Cells[koshinKbnKakoRinsan.Index].Value = "0";
                    // 更新区分（過去との比較）亜硝酸性窒素（定量）
                    dgvr.Cells[koshinKbnKakoNo2nTeiryo.Index].Value = "0";
                    // 更新区分（過去との比較）硝酸性窒素（定量）
                    dgvr.Cells[koshinKbnKakoNo3nTeiryo.Index].Value = "0";
                    // 更新区分（過去との比較）陰イオン界面活性剤（B)
                    dgvr.Cells[koshinKbnKakoAbsB.Index].Value = "0";
                    // 更新区分（過去との比較）全窒素（B)
                    dgvr.Cells[koshinKbnKakoTnB.Index].Value = "0";
                    // 更新区分（過去との比較）全りん（B)
                    dgvr.Cells[koshinKbnKakoTpB.Index].Value = "0";
                    // 更新区分（過去との比較）色度
                    dgvr.Cells[koshinKbnKakoShikido.Index].Value = "0";
                    // 更新区分（過去との比較）BOD（B）
                    dgvr.Cells[koshinKbnKakoBodB.Index].Value = "0";
                    // 更新区分（過去との比較）ヘキサン抽出物質（鉱油類）
                    dgvr.Cells[koshinKbnKakoHekisanKoyu.Index].Value = "0";
                    // 更新区分（過去との比較）ヘキサン抽出物質（動植物油類）
                    dgvr.Cells[koshinKbnKakoHekisanDoshoku.Index].Value = "0";
                    // 更新区分（過去との比較）ヘキサン抽出物質（B）
                    dgvr.Cells[koshinKbnKakoHekisanB.Index].Value = "0";
                    // 更新区分（過去との比較）鉛
                    dgvr.Cells[koshinKbnKakoNamari.Index].Value = "0";
                    // 更新区分（過去との比較）亜鉛
                    dgvr.Cells[koshinKbnKakoAen.Index].Value = "0";
                    // 更新区分（過去との比較）ほう素
                    dgvr.Cells[koshinKbnKakoHouso.Index].Value = "0";
                    // 更新区分（過去との比較）残塩
                    dgvr.Cells[koshinKbnKakoZanen.Index].Value = "0";
                    // 更新区分（過去との比較）外観
                    dgvr.Cells[koshinKbnKakoGaikan.Index].Value = "0";
                    // 更新区分（過去との比較）臭気
                    dgvr.Cells[koshinKbnKakoShuki.Index].Value = "0";
                    // 更新区分（過去との比較）透視度
                    dgvr.Cells[koshinKbnKakoTr.Index].Value = "0";
                    // 更新区分（過去との比較）亜硝酸性窒素（定性）
                    dgvr.Cells[koshinKbnKakoNo2nTeisei.Index].Value = "0";
                    // 更新区分（過去との比較）硝酸性窒素（定性）
                    dgvr.Cells[koshinKbnKakoNo3nTeisei.Index].Value = "0";
                    // 更新区分（過去との比較）大腸菌群数
                    dgvr.Cells[koshinKbnKakoDaichokin.Index].Value = "0";
                }
                #endregion

                #region 文字色を初期化
                foreach (DataGridViewRow dgvr in listDataGridView.Rows)
                {
                    dgvr.Cells[ph1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[ph2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[ondo1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[ondo2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[ss1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[ss2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[bodA1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[bodA2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[nh4n1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[nh4n2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[cl1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[cl2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[cod1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[cod2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[hekisanA1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[hekisanA2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[mlss1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[mlss2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[tnA1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[tnA2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[absA1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[absA2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[tpA1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[tpA2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[rinsan1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[rinsan2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[no2nTeiryo1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[no2nTeiryo2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[no3nTeiryo1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[no3nTeiryo2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[absB1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[absB2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[tnB1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[tnB2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[tpB1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[tpB2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[shikido1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[shikido2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[bodB1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[bodB2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[hekisanKoyu1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[hekisanKoyu2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[hekisanDoshoku1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[hekisanDoshoku2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[hekisanB1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[hekisanB2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[namari1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[namari2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[aen1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[aen2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[houso1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[houso2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[zanen1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[zanen2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[gaikan1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[gaikan2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[shuki1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[shuki2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[tr1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[tr2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[no2nTeisei1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[no2nTeisei2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[no3nTeisei1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[no3nTeisei2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[daichokin1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[daichokin2Col.Index].Style.ForeColor = Color.Black;
                }
                #endregion

                // 20150116 habu 検索処理再実行
                // 検索
                DoSearch(_searchAlInput);

                // 画面モード変更
                ModeChange(DispMode.Kakunin);
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region 閉じるボタン押下
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： tojiruButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/04　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 編集内容破棄チェック
                if (!EditCheck())
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") == DialogResult.No)
                    {
                        return;
                    }
                }
                // 前画面に戻る
                Program.mForm.MovePrev();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region 検査台帳一覧のボタン押下
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： listDataGridView_CellContentClick
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/04　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void listDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 20150127 sou Start ヘッダ選択時は処理を抜ける
                if (e.RowIndex < 0) { return; }
                // 20150127 sou End

                // 過去情報ボタン
                if (e.ColumnIndex == kakoJohoCol.Index)
                {
                    // 浄化槽台帳画面に遷移
                    JokasoDaichoShosai frm = new JokasoDaichoShosai(
                        listDataGridView[jokasoHokenjoCdCol.Index, e.RowIndex].Value.ToString(),
                        listDataGridView[jokasoTorokuNendoCol.Index, e.RowIndex].Value.ToString(),
                        listDataGridView[jokasoRenbanCol.Index, e.RowIndex].Value.ToString(),
                        JokasoDaichoShosai.DispMode.View
                        );
                    Program.mForm.MoveNext(frm);
                }

                // チェックボックスセルの場合は、直ちに編集を終了する(直ちにValueChangedイベントを発生させるため)
                if (listDataGridView.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    // 20150114 habu ラジオ処理修正に伴い変更
                    this.Validate();
                    //listDataGridView.EndEdit();
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region 検査台帳一覧の値変更
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： listDataGridView_CellValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/07　宗        新規作成
        /// 2015/01/21  宗        結果コード変更時の判定を追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void listDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // 内部変更の場合は処理を抜ける
            if (insideFlg) return;

            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 内部変更On
                insideFlg = true;

                // 対象行を取得
                DataGridViewRow dgvr = listDataGridView.Rows[e.RowIndex];

                // 20150114 habu 共通での処理に変更
                #region to be removed
                //#region 採用値の反転
                //// pH
                //if (e.ColumnIndex == saiyotiPh1Col.Index
                //    && dgvr.Cells[e.ColumnIndex].Value.ToString() == CheckOn)
                //{
                //    dgvr.Cells[e.ColumnIndex + 7].Value = false;
                //}
                //else if (e.ColumnIndex == saiyotiPh2Col.Index
                //    && dgvr.Cells[e.ColumnIndex].Value.ToString() == CheckOn)
                //{
                //    dgvr.Cells[e.ColumnIndex - 7].Value = false;
                //}
                //// その他
                //if ((e.ColumnIndex == saiyotiSs1Col.Index
                //    || e.ColumnIndex == saiyotiBodA1Col.Index
                //    || e.ColumnIndex == saiyotiNh4n1Col.Index
                //    || e.ColumnIndex == saiyotiCl1Col.Index
                //    || e.ColumnIndex == saiyotiCod1Col.Index
                //    || e.ColumnIndex == saiyotiHekisanA1Col.Index
                //    || e.ColumnIndex == saiyotiMlss1Col.Index
                //    || e.ColumnIndex == saiyotiTnA1Col.Index
                //    || e.ColumnIndex == saiyotiAbsA1Col.Index
                //    || e.ColumnIndex == saiyotiTpA1Col.Index
                //    || e.ColumnIndex == saiyotiRinsan1Col.Index
                //    || e.ColumnIndex == saiyotiNo2nTeiryo1Col.Index
                //    || e.ColumnIndex == saiyotiNo3nTeiryo1Col.Index
                //    || e.ColumnIndex == saiyotiAbsB1Col.Index
                //    || e.ColumnIndex == saiyotiTnB1Col.Index
                //    || e.ColumnIndex == saiyotiTpB1Col.Index
                //    || e.ColumnIndex == saiyotiShikido1Col.Index
                //    || e.ColumnIndex == saiyotiBodB1Col.Index
                //    || e.ColumnIndex == saiyotiHekisanKoyu1Col.Index
                //    || e.ColumnIndex == saiyotiHekisanDoshoku1Col.Index
                //    || e.ColumnIndex == saiyotiHekisanB1Col.Index
                //    || e.ColumnIndex == saiyotiNamari1Col.Index
                //    || e.ColumnIndex == saiyotiAen1Col.Index
                //    || e.ColumnIndex == saiyotiHouso1Col.Index
                //    || e.ColumnIndex == saiyotiZanen1Col.Index
                //    || e.ColumnIndex == saiyotiGaikan1Col.Index
                //    || e.ColumnIndex == saiyotiShuki1Col.Index
                //    || e.ColumnIndex == saiyotiTr1Col.Index
                //    || e.ColumnIndex == saiyotiNo2nTeisei1Col.Index
                //    || e.ColumnIndex == saiyotiNo3nTeisei1Col.Index
                //    || e.ColumnIndex == saiyotiDaichokin1Col.Index
                //    )
                //    && dgvr.Cells[e.ColumnIndex].Value.ToString() == CheckOn)
                //{
                //    dgvr.Cells[e.ColumnIndex + 6].Value = false;
                //}
                //else if ((e.ColumnIndex == saiyotiSs2Col.Index
                //    || e.ColumnIndex == saiyotiBodA2Col.Index
                //    || e.ColumnIndex == saiyotiNh4n2Col.Index
                //    || e.ColumnIndex == saiyotiCl2Col.Index
                //    || e.ColumnIndex == saiyotiCod2Col.Index
                //    || e.ColumnIndex == saiyotiHekisanA2Col.Index
                //    || e.ColumnIndex == saiyotiMlss2Col.Index
                //    || e.ColumnIndex == saiyotiTnA2Col.Index
                //    || e.ColumnIndex == saiyotiAbsA2Col.Index
                //    || e.ColumnIndex == saiyotiTpA2Col.Index
                //    || e.ColumnIndex == saiyotiRinsan2Col.Index
                //    || e.ColumnIndex == saiyotiNo2nTeiryo2Col.Index
                //    || e.ColumnIndex == saiyotiNo3nTeiryo2Col.Index
                //    || e.ColumnIndex == saiyotiAbsB2Col.Index
                //    || e.ColumnIndex == saiyotiTnB2Col.Index
                //    || e.ColumnIndex == saiyotiTpB2Col.Index
                //    || e.ColumnIndex == saiyotiShikido2Col.Index
                //    || e.ColumnIndex == saiyotiBodB2Col.Index
                //    || e.ColumnIndex == saiyotiHekisanKoyu2Col.Index
                //    || e.ColumnIndex == saiyotiHekisanDoshoku2Col.Index
                //    || e.ColumnIndex == saiyotiHekisanB2Col.Index
                //    || e.ColumnIndex == saiyotiNamari2Col.Index
                //    || e.ColumnIndex == saiyotiAen2Col.Index
                //    || e.ColumnIndex == saiyotiHouso2Col.Index
                //    || e.ColumnIndex == saiyotiZanen2Col.Index
                //    || e.ColumnIndex == saiyotiGaikan2Col.Index
                //    || e.ColumnIndex == saiyotiShuki2Col.Index
                //    || e.ColumnIndex == saiyotiTr2Col.Index
                //    || e.ColumnIndex == saiyotiNo2nTeisei2Col.Index
                //    || e.ColumnIndex == saiyotiNo3nTeisei2Col.Index
                //    || e.ColumnIndex == saiyotiDaichokin2Col.Index
                //    )
                //    && dgvr.Cells[e.ColumnIndex].Value.ToString() == CheckOn)
                //{
                //    dgvr.Cells[e.ColumnIndex - 6].Value = false;
                //}
                //#endregion
                #endregion

                #region 変更した結果値を赤文字表示
                if (e.ColumnIndex == ph1Col.Index || e.ColumnIndex == ph2Col.Index
                    || e.ColumnIndex == ondo1Col.Index || e.ColumnIndex == ondo2Col.Index
                    || e.ColumnIndex == ss1Col.Index || e.ColumnIndex == ss2Col.Index
                    || e.ColumnIndex == bodA1Col.Index || e.ColumnIndex == bodA2Col.Index
                    || e.ColumnIndex == nh4n1Col.Index || e.ColumnIndex == nh4n2Col.Index
                    || e.ColumnIndex == cl1Col.Index || e.ColumnIndex == cl2Col.Index
                    || e.ColumnIndex == cod1Col.Index || e.ColumnIndex == cod2Col.Index
                    || e.ColumnIndex == hekisanA1Col.Index || e.ColumnIndex == hekisanA2Col.Index
                    || e.ColumnIndex == mlss1Col.Index || e.ColumnIndex == mlss2Col.Index
                    || e.ColumnIndex == tnA1Col.Index || e.ColumnIndex == tnA2Col.Index
                    || e.ColumnIndex == absA1Col.Index || e.ColumnIndex == absA2Col.Index
                    || e.ColumnIndex == tpA1Col.Index || e.ColumnIndex == tpA2Col.Index
                    || e.ColumnIndex == rinsan1Col.Index || e.ColumnIndex == rinsan2Col.Index
                    || e.ColumnIndex == no2nTeiryo1Col.Index || e.ColumnIndex == no2nTeiryo2Col.Index
                    || e.ColumnIndex == no3nTeiryo1Col.Index || e.ColumnIndex == no3nTeiryo2Col.Index
                    || e.ColumnIndex == absB1Col.Index || e.ColumnIndex == absB2Col.Index
                    || e.ColumnIndex == tnB1Col.Index || e.ColumnIndex == tnB2Col.Index
                    || e.ColumnIndex == tpB1Col.Index || e.ColumnIndex == tpB2Col.Index
                    || e.ColumnIndex == shikido1Col.Index || e.ColumnIndex == shikido2Col.Index
                    || e.ColumnIndex == bodB1Col.Index || e.ColumnIndex == bodB2Col.Index
                    || e.ColumnIndex == hekisanKoyu1Col.Index || e.ColumnIndex == hekisanKoyu2Col.Index
                    || e.ColumnIndex == hekisanDoshoku1Col.Index || e.ColumnIndex == hekisanDoshoku2Col.Index
                    || e.ColumnIndex == hekisanB1Col.Index || e.ColumnIndex == hekisanB2Col.Index
                    || e.ColumnIndex == namari1Col.Index || e.ColumnIndex == namari2Col.Index
                    || e.ColumnIndex == aen1Col.Index || e.ColumnIndex == aen2Col.Index
                    || e.ColumnIndex == houso1Col.Index || e.ColumnIndex == houso2Col.Index
                    || e.ColumnIndex == zanen1Col.Index || e.ColumnIndex == zanen2Col.Index
                    || e.ColumnIndex == gaikan1Col.Index || e.ColumnIndex == gaikan2Col.Index
                    || e.ColumnIndex == shuki1Col.Index || e.ColumnIndex == shuki2Col.Index
                    || e.ColumnIndex == tr1Col.Index || e.ColumnIndex == tr2Col.Index
                    || e.ColumnIndex == no2nTeisei1Col.Index || e.ColumnIndex == no2nTeisei2Col.Index
                    || e.ColumnIndex == no3nTeisei1Col.Index || e.ColumnIndex == no3nTeisei2Col.Index
                    || e.ColumnIndex == daichokin1Col.Index || e.ColumnIndex == daichokin2Col.Index
                    )
                {
                    dgvr.Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                }
                #endregion

                #region 試験項目毎の処理

                #region pH
                if (e.ColumnIndex == ph1Col.Index
                    || e.ColumnIndex == ph2Col.Index
                    || e.ColumnIndex == ph1KekkaCdCol.Index
                    || e.ColumnIndex == ph2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiPh1Col.Index
                    || e.ColumnIndex == saiyotiPh2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, ph1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyPh(dgvr, ph1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnPh.Index].Value = "1";
                }
                #endregion

                #region SS
                if (e.ColumnIndex == ss1Col.Index
                    || e.ColumnIndex == ss2Col.Index
                    || e.ColumnIndex == ss1KekkaCdCol.Index
                    || e.ColumnIndex == ss2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiSs1Col.Index
                    || e.ColumnIndex == saiyotiSs2Col.Index)
                {
                    // 確認検査種別の判定(SS/透視度)]
                    CheckKakuninKensaShubetsuSsTr(dgvr);
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, ss1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, ss1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnSs.Index].Value = "1";
                }
                #endregion

                #region BOD(A)
                if (e.ColumnIndex == bodA1Col.Index
                    || e.ColumnIndex == bodA2Col.Index
                    || e.ColumnIndex == bodA1KekkaCdCol.Index
                    || e.ColumnIndex == bodA2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiBodA1Col.Index
                    || e.ColumnIndex == saiyotiBodA2Col.Index)
                {
                    // 確認検査種別の判定(BOD/透視度)]
                    CheckKakuninKensaShubetsuBodTr(dgvr);
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, bodA1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, bodA1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnBodA.Index].Value = "1";
                }
                #endregion

                #region アンモニア性窒素
                if (e.ColumnIndex == nh4n1Col.Index
                    || e.ColumnIndex == nh4n2Col.Index
                    || e.ColumnIndex == nh4n1KekkaCdCol.Index
                    || e.ColumnIndex == nh4n2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiNh4n1Col.Index
                    || e.ColumnIndex == saiyotiNh4n2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, nh4n1Col.Index);
                    // 確認検査種別の判定(アンモニア確認検査)]
                    CheckKakuninKensaShubetsuAnmonia(dgvr);
                    // 確認検査種別の判定(アンモニアと全窒素の比較)]
                    CheckKakuninKensaShubetsuAnmoniaTn(dgvr);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, nh4n1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnNh4n.Index].Value = "1";
                }
                #endregion

                #region 塩化物イオン
                if (e.ColumnIndex == cl1Col.Index
                    || e.ColumnIndex == cl2Col.Index
                    || e.ColumnIndex == cl1KekkaCdCol.Index
                    || e.ColumnIndex == cl2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiCl1Col.Index
                    || e.ColumnIndex == saiyotiCl2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, cl1Col.Index);
                    // 確認検査種別の判定(塩化物イオン確認検査)]
                    CheckKakuninKensaShubetsuEnkaIon(dgvr);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, cl1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnCl.Index].Value = "1";
                }
                #endregion

                #region COD
                if (e.ColumnIndex == cod1Col.Index
                    || e.ColumnIndex == cod2Col.Index
                    || e.ColumnIndex == cod1KekkaCdCol.Index
                    || e.ColumnIndex == cod2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiCod1Col.Index
                    || e.ColumnIndex == saiyotiCod2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, cod1Col.Index);
                    // 確認検査種別の判定(COD基準値オーバー)]
                    CheckKakuninKensaShubetsuCodOver(dgvr);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, cod1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnCod.Index].Value = "1";
                }
                #endregion

                #region ヘキサン抽出物質（A）
                if (e.ColumnIndex == hekisanA1Col.Index
                    || e.ColumnIndex == hekisanA2Col.Index
                    || e.ColumnIndex == hekisanA1KekkaCdCol.Index
                    || e.ColumnIndex == hekisanA2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiHekisanA1Col.Index
                    || e.ColumnIndex == saiyotiHekisanA2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, hekisanA1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, hekisanA1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnHekisanA.Index].Value = "1";
                }
                #endregion

                #region MLSS
                if (e.ColumnIndex == mlss1Col.Index
                    || e.ColumnIndex == mlss2Col.Index
                    || e.ColumnIndex == mlss1KekkaCdCol.Index
                    || e.ColumnIndex == mlss2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiMlss1Col.Index
                    || e.ColumnIndex == saiyotiMlss2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, mlss1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, mlss1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnMlss.Index].Value = "1";
                }
                #endregion

                #region 全窒素（A)
                if (e.ColumnIndex == tnA1Col.Index
                    || e.ColumnIndex == tnA2Col.Index
                    || e.ColumnIndex == tnA1KekkaCdCol.Index
                    || e.ColumnIndex == tnA2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiTnA1Col.Index
                    || e.ColumnIndex == saiyotiTnA2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, tnA1Col.Index);
                    // 確認検査種別の判定(アンモニアと全窒素の比較)]
                    CheckKakuninKensaShubetsuAnmoniaTn(dgvr);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, tnA1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnTnA.Index].Value = "1";
                }
                #endregion

                #region 陰イオン界面活性剤（A）
                if (e.ColumnIndex == absA1Col.Index
                    || e.ColumnIndex == absA2Col.Index
                    || e.ColumnIndex == absA1KekkaCdCol.Index
                    || e.ColumnIndex == absA2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiAbsA1Col.Index
                    || e.ColumnIndex == saiyotiAbsA2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, absA1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, absA1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnAbsA.Index].Value = "1";
                }
                #endregion

                #region 全りん（A)
                if (e.ColumnIndex == tpA1Col.Index
                    || e.ColumnIndex == tpA2Col.Index
                    || e.ColumnIndex == tpA1KekkaCdCol.Index
                    || e.ColumnIndex == tpA2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiTpA1Col.Index
                    || e.ColumnIndex == saiyotiTpA2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, tpA1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, tpA1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnTpA.Index].Value = "1";
                }
                #endregion

                #region りん酸イオン
                if (e.ColumnIndex == rinsan1Col.Index
                    || e.ColumnIndex == rinsan2Col.Index
                    || e.ColumnIndex == rinsan1KekkaCdCol.Index
                    || e.ColumnIndex == rinsan2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiRinsan1Col.Index
                    || e.ColumnIndex == saiyotiRinsan2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, rinsan1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, rinsan1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnRinsan.Index].Value = "1";
                }
                #endregion

                #region 亜硝酸性窒素（定量）
                if (e.ColumnIndex == no2nTeiryo1Col.Index
                    || e.ColumnIndex == no2nTeiryo2Col.Index
                    || e.ColumnIndex == no2nTeiryo1KekkaCdCol.Index
                    || e.ColumnIndex == no2nTeiryo2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiNo2nTeiryo1Col.Index
                    || e.ColumnIndex == saiyotiNo2nTeiryo2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, no2nTeiryo1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, no2nTeiryo1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnNo2nTeiryo.Index].Value = "1";
                }
                #endregion

                #region 硝酸性窒素（定量）
                if (e.ColumnIndex == no3nTeiryo1Col.Index
                    || e.ColumnIndex == no3nTeiryo2Col.Index
                    || e.ColumnIndex == no3nTeiryo1KekkaCdCol.Index
                    || e.ColumnIndex == no3nTeiryo2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiNo3nTeiryo1Col.Index
                    || e.ColumnIndex == saiyotiNo3nTeiryo2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, no3nTeiryo1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, no3nTeiryo1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnNo3nTeiryo.Index].Value = "1";
                }
                #endregion

                #region 陰イオン界面活性剤（B)
                if (e.ColumnIndex == absB1Col.Index
                    || e.ColumnIndex == absB2Col.Index
                    || e.ColumnIndex == absB1KekkaCdCol.Index
                    || e.ColumnIndex == absB2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiAbsB1Col.Index
                    || e.ColumnIndex == saiyotiAbsB2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, absB1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, absB1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnAbsB.Index].Value = "1";
                }
                #endregion

                #region 全窒素（B)
                if (e.ColumnIndex == tnB1Col.Index
                    || e.ColumnIndex == tnB2Col.Index
                    || e.ColumnIndex == tnB1KekkaCdCol.Index
                    || e.ColumnIndex == tnB2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiTnB1Col.Index
                    || e.ColumnIndex == saiyotiTnB2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, tnB1Col.Index);
                    // 確認検査種別の判定(アンモニアと全窒素の比較)]
                    CheckKakuninKensaShubetsuAnmoniaTn(dgvr);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, tnB1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnTnB.Index].Value = "1";
                }
                #endregion

                #region 全りん（B)
                if (e.ColumnIndex == tpB1Col.Index
                    || e.ColumnIndex == tpB2Col.Index
                    || e.ColumnIndex == tpB1KekkaCdCol.Index
                    || e.ColumnIndex == tpB2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiTpB1Col.Index
                    || e.ColumnIndex == saiyotiTpB2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, tpB1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, tpB1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnTpB.Index].Value = "1";
                }
                #endregion

                #region 色度
                if (e.ColumnIndex == shikido1Col.Index
                    || e.ColumnIndex == shikido2Col.Index
                    || e.ColumnIndex == shikido1KekkaCdCol.Index
                    || e.ColumnIndex == shikido2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiShikido1Col.Index
                    || e.ColumnIndex == saiyotiShikido2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, shikido1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, shikido1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnShikido.Index].Value = "1";
                }
                #endregion

                #region BOD（B）
                if (e.ColumnIndex == bodB1Col.Index
                    || e.ColumnIndex == bodB2Col.Index
                    || e.ColumnIndex == bodB1KekkaCdCol.Index
                    || e.ColumnIndex == bodB2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiBodB1Col.Index
                    || e.ColumnIndex == saiyotiBodB2Col.Index)
                {
                    // 確認検査種別の判定(BOD/透視度)]
                    CheckKakuninKensaShubetsuBodTr(dgvr);
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, bodB1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, bodB1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnBodB.Index].Value = "1";
                }
                #endregion

                #region ヘキサン抽出物質（鉱油類）
                if (e.ColumnIndex == hekisanKoyu1Col.Index
                    || e.ColumnIndex == hekisanKoyu2Col.Index
                    || e.ColumnIndex == hekisanKoyu1KekkaCdCol.Index
                    || e.ColumnIndex == hekisanKoyu2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiHekisanKoyu1Col.Index
                    || e.ColumnIndex == saiyotiHekisanKoyu2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, hekisanKoyu1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, hekisanKoyu1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnHekisanKoyu.Index].Value = "1";
                }
                #endregion

                #region ヘキサン抽出物質（動植物油類）
                if (e.ColumnIndex == hekisanDoshoku1Col.Index
                    || e.ColumnIndex == hekisanDoshoku2Col.Index
                    || e.ColumnIndex == hekisanDoshoku1KekkaCdCol.Index
                    || e.ColumnIndex == hekisanDoshoku2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiHekisanDoshoku1Col.Index
                    || e.ColumnIndex == saiyotiHekisanDoshoku2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, hekisanDoshoku1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, hekisanDoshoku1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnHekisanDoshoku.Index].Value = "1";
                }
                #endregion

                #region ヘキサン抽出物質（B）
                if (e.ColumnIndex == hekisanB1Col.Index
                    || e.ColumnIndex == hekisanB2Col.Index
                    || e.ColumnIndex == hekisanB1KekkaCdCol.Index
                    || e.ColumnIndex == hekisanB2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiHekisanB1Col.Index
                    || e.ColumnIndex == saiyotiHekisanB2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, hekisanB1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, hekisanB1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnHekisanB.Index].Value = "1";
                }
                #endregion

                #region 鉛
                if (e.ColumnIndex == namari1Col.Index
                    || e.ColumnIndex == namari2Col.Index
                    || e.ColumnIndex == namari1KekkaCdCol.Index
                    || e.ColumnIndex == namari2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiNamari1Col.Index
                    || e.ColumnIndex == saiyotiNamari2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, namari1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, namari1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnNamari.Index].Value = "1";
                }
                #endregion

                #region 亜鉛
                if (e.ColumnIndex == aen1Col.Index
                    || e.ColumnIndex == aen2Col.Index
                    || e.ColumnIndex == aen1KekkaCdCol.Index
                    || e.ColumnIndex == aen2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiAen1Col.Index
                    || e.ColumnIndex == saiyotiAen2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, aen1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, aen1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnAen.Index].Value = "1";
                }
                #endregion

                #region ほう素
                if (e.ColumnIndex == houso1Col.Index
                    || e.ColumnIndex == houso2Col.Index
                    || e.ColumnIndex == houso1KekkaCdCol.Index
                    || e.ColumnIndex == houso2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiHouso1Col.Index
                    || e.ColumnIndex == saiyotiHouso2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, houso1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, houso1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnHouso.Index].Value = "1";
                }
                #endregion

                #region 残塩
                if (e.ColumnIndex == zanen1Col.Index
                    || e.ColumnIndex == zanen2Col.Index
                    || e.ColumnIndex == zanen1KekkaCdCol.Index
                    || e.ColumnIndex == zanen2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiZanen1Col.Index
                    || e.ColumnIndex == saiyotiZanen2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, zanen1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, zanen1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnZanen.Index].Value = "1";
                }
                #endregion

                #region 外観
                if (e.ColumnIndex == gaikan1Col.Index
                    || e.ColumnIndex == gaikan2Col.Index
                    || e.ColumnIndex == gaikan1KekkaCdCol.Index
                    || e.ColumnIndex == gaikan2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiGaikan1Col.Index
                    || e.ColumnIndex == saiyotiGaikan2Col.Index)
                {
                    //// 確認検査種別の判定(過去との比較)]
                    //CheckKakuninKensaShubetsuKako(dgvr, gaikan1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, gaikan1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnGaikan.Index].Value = "1";
                }
                #endregion

                #region 臭気
                if (e.ColumnIndex == shuki1Col.Index
                    || e.ColumnIndex == shuki2Col.Index
                    || e.ColumnIndex == shuki1KekkaCdCol.Index
                    || e.ColumnIndex == shuki2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiShuki1Col.Index
                    || e.ColumnIndex == saiyotiShuki2Col.Index)
                {
                    //// 確認検査種別の判定(過去との比較)]
                    //CheckKakuninKensaShubetsuKako(dgvr, shuki1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, shuki1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnShuki.Index].Value = "1";
                }
                #endregion

                #region 透視度
                if (e.ColumnIndex == tr1Col.Index
                    || e.ColumnIndex == tr2Col.Index
                    || e.ColumnIndex == tr1KekkaCdCol.Index
                    || e.ColumnIndex == tr2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiTr1Col.Index
                    || e.ColumnIndex == saiyotiTr2Col.Index)
                {
                    // 確認検査種別の判定(SS/透視度)]
                    CheckKakuninKensaShubetsuSsTr(dgvr);
                    // 確認検査種別の判定(BOD/透視度)]
                    CheckKakuninKensaShubetsuBodTr(dgvr);
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, tr1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, tr1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnTr.Index].Value = "1";
                }
                #endregion

                #region 亜硝酸性窒素（定性）
                if (e.ColumnIndex == no2nTeisei1Col.Index
                    || e.ColumnIndex == no2nTeisei2Col.Index
                    || e.ColumnIndex == no2nTeisei1KekkaCdCol.Index
                    || e.ColumnIndex == no2nTeisei2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiNo2nTeisei1Col.Index
                    || e.ColumnIndex == saiyotiNo2nTeisei2Col.Index)
                {
                    //// 確認検査種別の判定(過去との比較)]
                    //CheckKakuninKensaShubetsuKako(dgvr, no2nTeisei1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, no2nTeisei1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnNo2nTeisei.Index].Value = "1";
                }
                #endregion

                #region 硝酸性窒素（定性）
                if (e.ColumnIndex == no3nTeisei1Col.Index
                    || e.ColumnIndex == no3nTeisei2Col.Index
                    || e.ColumnIndex == no3nTeisei1KekkaCdCol.Index
                    || e.ColumnIndex == no3nTeisei2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiNo3nTeisei1Col.Index
                    || e.ColumnIndex == saiyotiNo3nTeisei2Col.Index)
                {
                    //// 確認検査種別の判定(過去との比較)]
                    //CheckKakuninKensaShubetsuKako(dgvr, no3nTeisei1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, no3nTeisei1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnNo3nTeisei.Index].Value = "1";
                }
                #endregion

                #region 大腸菌群数
                if (e.ColumnIndex == daichokin1Col.Index
                    || e.ColumnIndex == daichokin2Col.Index
                    || e.ColumnIndex == daichokin1KekkaCdCol.Index
                    || e.ColumnIndex == daichokin2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiDaichokin1Col.Index
                    || e.ColumnIndex == saiyotiDaichokin2Col.Index)
                {
                    // 確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, daichokin1Col.Index);
                    // 確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    // 状態設定
                    SetKmkPropatyAll(dgvr, daichokin1Col.Index);
                    // 更新区分
                    dgvr.Cells[koshinKbnDaichokin.Index].Value = "1";
                }
                #endregion

                #endregion

                // 課長検印、副課長検印、管理者検印
                if (e.ColumnIndex == kachoKeninCol.Index
                    || e.ColumnIndex == hukukachoKeninCol.Index
                    || e.ColumnIndex == kanrishaKeninCol.Index)
                {
                    // 状態設定(検印)
                    SetKmkPropaty(dgvr);
                    //更新区分（検印）
                    dgvr.Cells[koshinKbnKenin.Index].Value = "1";
                }

                // 内部変更Off
                insideFlg = false;
                // 画面モード変更
                ModeChange(DispMode.Hensyu);
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                // 20150114 habu finallyで戻すように変更(法定検査台帳側と合わせる)
                // 内部変更Off
                insideFlg = false;

                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region 一括検印(課長)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kachoCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/07　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kachoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // レコード0件の場合は処理を抜ける
                if (listDataGridView.RowCount == 0) return;

                if (kachoKeninCheckBox.Checked == true)
                {
                    // チェックを付けた場合
                    foreach (DataGridViewRow dgvr in listDataGridView.Rows)
                    {
                        // 検印可否判定
                        dgvr.Cells[kachoKeninCol.Index].Value = keninKahiHantei(dgvr);
                    }
                }
                else
                {
                    // チェックを外した場合
                    foreach (DataGridViewRow gridRow in listDataGridView.Rows)
                    {
                        gridRow.Cells[kachoKeninCol.Index].Value = false;
                    }
                }
                // 画面モード変更
                ModeChange(DispMode.Hensyu);
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region 一括検印(副課長)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hukukachoCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/07　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hukukachoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // レコード0件の場合は処理を抜ける
                if (listDataGridView.RowCount == 0) return;

                if (hukukachoKeninCheckBox.Checked == true)
                {
                    // チェックを付けた場合
                    foreach (DataGridViewRow dgvr in listDataGridView.Rows)
                    {
                        // 検印可否判定
                        dgvr.Cells[hukukachoKeninCol.Index].Value = keninKahiHantei(dgvr);
                    }
                }
                else
                {
                    // チェックを外した場合
                    foreach (DataGridViewRow gridRow in listDataGridView.Rows)
                    {
                        gridRow.Cells[hukukachoKeninCol.Index].Value = false;
                    }
                }
                // 画面モード変更
                ModeChange(DispMode.Hensyu);
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region 一括検印(管理者)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kanrishaCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/07　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kanrishaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // レコード0件の場合は処理を抜ける
                if (listDataGridView.RowCount == 0) return;

                if (kanrishaKeninCheckBox.Checked == true)
                {
                    // チェックを付けた場合
                    foreach (DataGridViewRow dgvr in listDataGridView.Rows)
                    {
                        // 検印可否判定
                        dgvr.Cells[kanrishaKeninCol.Index].Value = keninKahiHantei(dgvr);
                    }
                }
                else
                {
                    // チェックを外した場合
                    foreach (DataGridViewRow gridRow in listDataGridView.Rows)
                    {
                        gridRow.Cells[kanrishaKeninCol.Index].Value = false;
                    }
                }
                // 画面モード変更
                ModeChange(DispMode.Hensyu);
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region 入力値の複写(依頼受付日)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraiUketsukeDtFromDateTimePicker_ValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/04　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraiUketsukeDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            iraiUketsukeDtToDateTimePicker.Value = iraiUketsukeDtFromDateTimePicker.Value;
        }
        #endregion

        #region 入力値の複写(検体番号)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraiNoFromTextBox_TextChanged
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/04　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraiNoFromTextBox_TextChanged(object sender, EventArgs e)
        {
            iraiNoToTextBox.Text = iraiNoFromTextBox.Text;
        }
        #endregion

        #region ファンクションキー押下
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KeiryoShomeiKensaDaicho_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KeiryoShomeiKensaDaicho_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        daichoOutputButton.PerformClick();
                        break;

                    case Keys.F5:
                        kakuteiButton.PerformClick();
                        break;

                    case Keys.F7:
                    case Keys.Alt | Keys.C:
                        clearButton.PerformClick();
                        break;

                    case Keys.F8:
                    case Keys.Alt | Keys.F:
                        kensakuButton.PerformClick();
                        break;

                    case Keys.F12:
                    case Keys.Alt | Keys.X:
                        tojiruButton.PerformClick();
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region 列ヘッダの背景色変更
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetHeaderBackColor
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/04　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetHeaderBackColor(int col, Color colorType)
        {
            listDataGridView.Columns[col].HeaderCell.Style.BackColor = colorType;
            listDataGridView.Columns[col + 1].HeaderCell.Style.BackColor = colorType;
            listDataGridView.Columns[col + 2].HeaderCell.Style.BackColor = colorType;
            listDataGridView.Columns[col + 3].HeaderCell.Style.BackColor = colorType;
            listDataGridView.Columns[col + 4].HeaderCell.Style.BackColor = colorType;
            listDataGridView.Columns[col + 5].HeaderCell.Style.BackColor = colorType;
            listDataGridView.Columns[col + 6].HeaderCell.Style.BackColor = colorType;
            listDataGridView.Columns[col + 7].HeaderCell.Style.BackColor = colorType;
            listDataGridView.Columns[col + 8].HeaderCell.Style.BackColor = colorType;
            listDataGridView.Columns[col + 9].HeaderCell.Style.BackColor = colorType;
            if (col == ph1Col.Index)
            {
                listDataGridView.Columns[col + 10].HeaderCell.Style.BackColor = colorType;
                listDataGridView.Columns[col + 11].HeaderCell.Style.BackColor = colorType;
            }
        }
        #endregion

        #region 画面モード変更
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ModeChange
        /// <summary>
        /// 
        /// </summary>
        /// <input>
        /// DispMode mode 画面モード
        /// </input>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/03　宗        新規作成
        /// 2015/01/16　habu      初期表示モード追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ModeChange(DispMode mode)
        {
            // 画面モード別のコントロール制御
            switch (mode)
            {
                case DispMode.Load:
                    // 台帳出力ボタン
                    daichoOutputButton.Enabled = false;
                    // 確定ボタン
                    kakuteiButton.Enabled = false;

                    break;
                case DispMode.Kakunin:
                    // 台帳出力ボタン
                    daichoOutputButton.Enabled = true;
                    // 確定ボタン
                    kakuteiButton.Enabled = false;

                    break;
                case DispMode.Hensyu:
                    // 台帳出力ボタン
                    daichoOutputButton.Enabled = true;
                    // 確定ボタン
                    kakuteiButton.Enabled = true;

                    break;
            }

            return;
        }
        #endregion

        #region 検索
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearch
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/04　宗        新規作成
        /// 2014/12/29  小松　　　複数の検査項目が絡む確認検査の場合の実施有無を判定する条件を、1つでも該当すれば実施するように修正
        /// 2015/01/16  habu　　　検索条件を再利用できるように変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch(IKensakuBtnClickALInput alInput)
        {
            // 検査台帳一覧のクリア
            listDataGridView.Rows.Clear();

            // データ取得
            GetData(alInput);

            #region 各種判定
            foreach(DataGridViewRow dgvr in listDataGridView.Rows)
            {
                #region 確認検査種別(SS/透視度)
                // どちらかに該当すれば実施
                if ((((dgvr.Cells[saiyotiSs1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[ss1KensaShubetsuSsTr.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuSs1Col.Index].Value.ToString() == "1"))

                    || ((dgvr.Cells[saiyotiSs2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[ss2KensaShubetsuSsTr.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuSs2Col.Index].Value.ToString() == "1")))

                    ||
                    (((dgvr.Cells[saiyotiTr1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[tr1KensaShubetsuBodTr.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuTr1Col.Index].Value.ToString() == "1"))

                    || ((dgvr.Cells[saiyotiTr2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[tr2KensaShubetsuBodTr.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuTr2Col.Index].Value.ToString() == "1"))))
                {
                    CheckKakuninKensaShubetsuSsTr(dgvr);
                }
                #endregion

                #region 確認検査種別(BOD/透視度)
                // どちらかに該当すれば実施
                if (((((dgvr.Cells[saiyotiBodA1Col.Index].Value.ToString() == CheckOn) 
                    && (dgvr.Cells[bodA1KensaShubetsuBodTr.Index].Value.ToString() == "0") 
                    && (dgvr.Cells[kekkaNyuryokuBodA1Col.Index].Value.ToString() == "1"))

                    || ((dgvr.Cells[saiyotiBodA2Col.Index].Value.ToString() == CheckOn) 
                    && (dgvr.Cells[bodA2KensaShubetsuBodTr.Index].Value.ToString() == "0") 
                    && (dgvr.Cells[kekkaNyuryokuBodA2Col.Index].Value.ToString() == "1")))

                    || (((dgvr.Cells[saiyotiBodB1Col.Index].Value.ToString() == CheckOn) 
                    && (dgvr.Cells[bodB1KensaShubetsuBodTr.Index].Value.ToString() == "0") 
                    && (dgvr.Cells[kekkaNyuryokuBodB1Col.Index].Value.ToString() == "1"))

                    || ((dgvr.Cells[saiyotiBodB2Col.Index].Value.ToString() == CheckOn) 
                    && (dgvr.Cells[bodB2KensaShubetsuBodTr.Index].Value.ToString() == "0") 
                    && (dgvr.Cells[kekkaNyuryokuBodB2Col.Index].Value.ToString() == "1"))))

                    || 
                    (((dgvr.Cells[saiyotiTr1Col.Index].Value.ToString() == CheckOn) 
                    && (dgvr.Cells[tr1KensaShubetsuBodTr.Index].Value.ToString() == "0") 
                    && (dgvr.Cells[kekkaNyuryokuTr1Col.Index].Value.ToString() == "1"))

                    || ((dgvr.Cells[saiyotiTr2Col.Index].Value.ToString() == CheckOn) 
                    && (dgvr.Cells[tr2KensaShubetsuBodTr.Index].Value.ToString() == "0") 
                    && (dgvr.Cells[kekkaNyuryokuTr2Col.Index].Value.ToString() == "1"))))
                {
                    CheckKakuninKensaShubetsuBodTr(dgvr);
                }
                #endregion

                #region 確認検査種別(過去の結果との比較)
                {
                    // pH
                    if ((dgvr.Cells[saiyotiPh1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[ph1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuPh1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, ph1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiPh2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[ph2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuPh2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, ph2Col.Index);
                    }
                    // SS
                    if ((dgvr.Cells[saiyotiSs1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[ss1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuSs1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, ss1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiSs2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[ss2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuSs2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, ss2Col.Index);
                    }
                    // BOD（A）
                    if ((dgvr.Cells[saiyotiBodA1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[bodA1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuBodA1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, bodA1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiBodA2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[bodA2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuBodA2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, bodA2Col.Index);
                    }
                    // アンモニア性窒素
                    if ((dgvr.Cells[saiyotiNh4n1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[nh4n1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuNh4n1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, nh4n1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiNh4n2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[nh4n2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuNh4n2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, nh4n2Col.Index);
                    }
                    // 塩化物イオン
                    if ((dgvr.Cells[saiyotiCl1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[cl1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, cl1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiCl2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[cl2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuCl2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, cl2Col.Index);
                    }
                    // COD
                    if ((dgvr.Cells[saiyotiCod1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[cod1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuCod1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, cod1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiCod2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[cod2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuCod2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, cod2Col.Index);
                    }
                    // ヘキサン抽出物質（A）
                    if ((dgvr.Cells[saiyotiHekisanA1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[hekisanA1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuHekisanA1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, hekisanA1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiHekisanA2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[hekisanA2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuHekisanA2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, hekisanA2Col.Index);
                    }
                    // MLSS
                    if ((dgvr.Cells[saiyotiMlss1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[mlss1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuMlss1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, mlss1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiMlss2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[mlss2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuMlss2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, mlss2Col.Index);
                    }
                    // 全窒素（A)
                    if ((dgvr.Cells[saiyotiTnA1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[tnA1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuTnA1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, tnA1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiTnA2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[tnA2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuTnA2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, tnA2Col.Index);
                    }
                    // 陰イオン界面活性剤（A）
                    if ((dgvr.Cells[saiyotiAbsA1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[absA1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuAbsA1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, absA1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiAbsA2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[absA2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuAbsA2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, absA2Col.Index);
                    }
                    // 全りん（A)
                    if ((dgvr.Cells[saiyotiTpA1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[tpA1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuTpA1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, tpA1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiTpA2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[tpA2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuTpA2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, tpA2Col.Index);
                    }
                    // りん酸イオン
                    if ((dgvr.Cells[saiyotiRinsan1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[rinsan1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuRinsan1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, rinsan1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiRinsan2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[rinsan2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuRinsan2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, rinsan2Col.Index);
                    }
                    // 亜硝酸性窒素（定量）
                    if ((dgvr.Cells[saiyotiNo2nTeiryo1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[no2nTeiryo1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuNo2nTeiryo1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, no2nTeiryo1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiNo2nTeiryo2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[no2nTeiryo2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuNo2nTeiryo2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, no2nTeiryo2Col.Index);
                    }
                    // 硝酸性窒素（定量）
                    if ((dgvr.Cells[saiyotiNo3nTeiryo1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[no3nTeiryo1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuNo3nTeiryo1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, no3nTeiryo1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiNo3nTeiryo2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[no3nTeiryo2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuNo3nTeiryo2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, no3nTeiryo2Col.Index);
                    }
                    // 陰イオン界面活性剤（B)
                    if ((dgvr.Cells[saiyotiAbsB1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[absB1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuAbsB1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, absB1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiAbsB2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[absB2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuAbsB2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, absB2Col.Index);
                    }
                    // 全窒素（B)
                    if ((dgvr.Cells[saiyotiTnB1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[tnB1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuTnB1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, tnB1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiTnB2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[tnB2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuTnB2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, tnB2Col.Index);
                    }
                    // 全りん（B)
                    if ((dgvr.Cells[saiyotiTpB1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[tpB1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuTpB1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, tpB1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiTpB2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[tpB2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuTpB2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, tpB2Col.Index);
                    }
                    // 色度
                    if ((dgvr.Cells[saiyotiShikido1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[shikido1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuShikido1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, shikido1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiShikido2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[shikido2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuShikido2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, shikido2Col.Index);
                    }
                    // BOD（B）
                    if ((dgvr.Cells[saiyotiBodB1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[bodB1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuBodB1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, bodB1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiBodB2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[bodB2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuBodB2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, bodB2Col.Index);
                    }
                    // ヘキサン抽出物質（鉱油類）
                    if ((dgvr.Cells[saiyotiHekisanKoyu1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[hekisanKoyu1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuHekisanKoyu1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, hekisanKoyu1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiHekisanKoyu2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[hekisanKoyu2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuHekisanKoyu2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, hekisanKoyu2Col.Index);
                    }
                    // ヘキサン抽出物質（動植物油類）
                    if ((dgvr.Cells[saiyotiHekisanDoshoku1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[hekisanDoshoku1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuHekisanDoshoku1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, hekisanDoshoku1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiHekisanDoshoku2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[hekisanDoshoku2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuHekisanDoshoku2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, hekisanDoshoku2Col.Index);
                    }
                    // ヘキサン抽出物質（B）
                    if ((dgvr.Cells[saiyotiHekisanB1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[hekisanB1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuHekisanB1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, hekisanB1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiHekisanB2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[hekisanB2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuHekisanB2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, hekisanB2Col.Index);
                    }
                    // 鉛
                    if ((dgvr.Cells[saiyotiNamari1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[namari1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuNamari1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, namari1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiNamari2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[namari2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuNamari2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, namari2Col.Index);
                    }
                    // 亜鉛
                    if ((dgvr.Cells[saiyotiAen1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[aen1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuAen1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, aen1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiAen2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[aen2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuAen2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, aen2Col.Index);
                    }
                    // ほう素
                    if ((dgvr.Cells[saiyotiHouso1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[houso1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuHouso1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, houso1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiHouso2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[houso2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuHouso2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, houso2Col.Index);
                    }
                    // 残塩
                    if ((dgvr.Cells[saiyotiZanen1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[zanen1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuZanen1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, zanen1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiZanen2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[zanen2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuZanen2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, zanen2Col.Index);
                    }
                    //// 外観
                    //if ((dgvr.Cells[saiyotiGaikan1Col.Index].Value.ToString() == CheckOn)
                    //    && (dgvr.Cells[gaikan1KensaShubetsuKako.Index].Value.ToString() == "0")
                    //    && (dgvr.Cells[kekkaNyuryokuGaikan1Col.Index].Value.ToString() == "1"))
                    //{
                    //    CheckKakuninKensaShubetsuKako(dgvr, gaikan1Col.Index);
                    //}
                    //else if ((dgvr.Cells[saiyotiGaikan2Col.Index].Value.ToString() == CheckOn)
                    //    && (dgvr.Cells[gaikan2KensaShubetsuKako.Index].Value.ToString() == "0")
                    //    && (dgvr.Cells[kekkaNyuryokuGaikan2Col.Index].Value.ToString() == "1"))
                    //{
                    //    CheckKakuninKensaShubetsuKako(dgvr, gaikan2Col.Index);
                    //}
                    //// 臭気
                    //if ((dgvr.Cells[saiyotiShuki1Col.Index].Value.ToString() == CheckOn)
                    //    && (dgvr.Cells[shuki1KensaShubetsuKako.Index].Value.ToString() == "0")
                    //    && (dgvr.Cells[kekkaNyuryokuShuki1Col.Index].Value.ToString() == "1"))
                    //{
                    //    CheckKakuninKensaShubetsuKako(dgvr, shuki1Col.Index);
                    //}
                    //else if ((dgvr.Cells[saiyotiShuki2Col.Index].Value.ToString() == CheckOn)
                    //    && (dgvr.Cells[shuki2KensaShubetsuKako.Index].Value.ToString() == "0")
                    //    && (dgvr.Cells[kekkaNyuryokuShuki2Col.Index].Value.ToString() == "1"))
                    //{
                    //    CheckKakuninKensaShubetsuKako(dgvr, shuki2Col.Index);
                    //}
                    // 透視度
                    if ((dgvr.Cells[saiyotiTr1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[tr1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuTr1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, tr1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiTr2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[tr2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuTr2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, tr2Col.Index);
                    }
                    // 大腸菌群数
                    if ((dgvr.Cells[saiyotiDaichokin1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[daichokin1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuDaichokin1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, daichokin1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiDaichokin2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[daichokin2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuDaichokin2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, daichokin2Col.Index);
                    }
                }
                #endregion

                #region 確認検査種別(塩化物イオン確認検査)
                if (((dgvr.Cells[saiyotiCl1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[cl1KensaShubetsuEnkaIon.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() == "1"))

                    || ((dgvr.Cells[saiyotiCl2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[cl2KensaShubetsuEnkaIon.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuCl2Col.Index].Value.ToString() == "1")))
                {
                    CheckKakuninKensaShubetsuEnkaIon(dgvr);
                }
                #endregion

                #region 確認検査種別(アンモニア確認検査)
                if (((dgvr.Cells[saiyotiNh4n1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[nh4n1KensaShubetsuAnmonia.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuNh4n1Col.Index].Value.ToString() == "1"))

                    || ((dgvr.Cells[saiyotiNh4n2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[nh4n2KensaShubetsuAnmonia.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuNh4n2Col.Index].Value.ToString() == "1")))
                {
                    CheckKakuninKensaShubetsuAnmonia(dgvr);
                }
                #endregion

                #region 確認検査種別(アンモニアと全窒素の比較)
                // どちらかに該当すれば実施
                if ((((dgvr.Cells[saiyotiNh4n1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[nh4n1KensaShubetsuAnmoniaTn.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuNh4n1Col.Index].Value.ToString() == "1"))

                    || ((dgvr.Cells[saiyotiNh4n2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[nh4n2KensaShubetsuAnmoniaTn.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuNh4n2Col.Index].Value.ToString() == "1")))

                    || 
                    ((((dgvr.Cells[saiyotiTnA1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[tnA1KensaShubetsuAnmoniaTn.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuTnA1Col.Index].Value.ToString() == "1"))
 
                    || ((dgvr.Cells[saiyotiTnA2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[tnA2KensaShubetsuAnmoniaTn.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuTnA2Col.Index].Value.ToString() == "1")))

                    || (((dgvr.Cells[saiyotiTnB1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[tnB1KensaShubetsuAnmoniaTn.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuTnB1Col.Index].Value.ToString() == "1"))

                    || ((dgvr.Cells[saiyotiTnB2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[tnB2KensaShubetsuAnmoniaTn.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuTnB2Col.Index].Value.ToString() == "1")))))
                {
                    CheckKakuninKensaShubetsuAnmoniaTn(dgvr);
                }
                #endregion

                #region 確認検査種別(COD基準値オーバー)
                if (((dgvr.Cells[saiyotiCod1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[cod1KensaShubetsuCodOver.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuCod1Col.Index].Value.ToString() == "1"))

                    || ((dgvr.Cells[saiyotiCod2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[cod2KensaShubetsuCodOver.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuCod2Col.Index].Value.ToString() == "1")))
                {
                    CheckKakuninKensaShubetsuCodOver(dgvr);
                }
                #endregion

                // 確認検査種別の判定結果を表示
                DispKakuninKensaShubetsu(dgvr);

                // 背景色の判定
                CheckBackColor(dgvr);

                // 各検査項目の状態設定
                SetKmkPropaty(dgvr);
            }
            #endregion

            // 表示項目＆非表示項目の切り替え
            ChangeDisplayColumn();
        }
        #endregion

        #region 該当データ取得
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetData
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/04　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void GetData(IKensakuBtnClickALInput alInput)
        {
            // 依頼情報を検索
            //IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();
            //MakeSearchCond(alInput);

            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            // 件数判定
            if (alOutput.KeiryoShomeiDaichoDT == null || alOutput.KeiryoShomeiDaichoDT.Count == 0)
            {
                listCountLabel.Text = "0件";

                // リスト数 = 0
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
            else
            {
                listCountLabel.Text = alOutput.KeiryoShomeiDaichoDT.Count.ToString() + "件";
            }

            // 該当データ
            KensaDaicho9joHdrTblDataSet.KeiryoShomeiDaichoSearchDataTable table = alOutput.KeiryoShomeiDaichoDT;
            // 該当データの更新日
            KensaDaicho9joHdrTblDataSet.KeiryoShomeiDaichoUpdateDtDataTable tableUpdateDt = alOutput.KeiryoShomeiDaichoUpdateDtDT;

            // 取得結果を一覧に設定
            foreach (KensaDaicho9joHdrTblDataSet.KeiryoShomeiDaichoSearchRow row in table.Rows)
            {
                SetData(row);
            }
            SetUpdateDt(tableUpdateDt);
        }
        #endregion

        #region 検索条件設定
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/04　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSearchCond(IKensakuBtnClickALInput alInput)
        {
            // 各項目の値設定
            KeiryoShomeiDaichoSearchCond searchCond = new KeiryoShomeiDaichoSearchCond();

            // 支所コード
            //searchCond.ShishoCd = LoginUserShozokuShishoCd;
            searchCond.ShishoCd = shishoComboBox.SelectedValue.ToString();

            // 試験項目コードを設定
            searchCond.KmkCdPh = GetKmkCd(ConstRenbanPh);
            searchCond.KmkCdSs = GetKmkCd(ConstRenbanSs);
            searchCond.KmkCdBodA = GetKmkCd(ConstRenbanBodA);
            searchCond.KmkCdNh4n = GetKmkCd(ConstRenbanNh4n);
            searchCond.KmkCdCl = GetKmkCd(ConstRenbanCl);
            searchCond.KmkCdCod = GetKmkCd(ConstRenbanCod);
            searchCond.KmkCdHekisanA = GetKmkCd(ConstRenbanHekisanA);
            searchCond.KmkCdMlss = GetKmkCd(ConstRenbanMlss);
            searchCond.KmkCdTnA = GetKmkCd(ConstRenbanTnA);
            searchCond.KmkCdAbsA = GetKmkCd(ConstRenbanAbsA);
            searchCond.KmkCdTpA = GetKmkCd(ConstRenbanTpA);
            searchCond.KmkCdRinsan = GetKmkCd(ConstRenbanRinsan);
            searchCond.KmkCdNo2nTeiryo = GetKmkCd(ConstRenbanNo2nTeiryo);
            searchCond.KmkCdNo3nTeiryo = GetKmkCd(ConstRenbanNo3nTeiryo);
            searchCond.KmkCdAbsB = GetKmkCd(ConstRenbanAbsB);
            searchCond.KmkCdTnB = GetKmkCd(ConstRenbanTnB);
            searchCond.KmkCdTpB = GetKmkCd(ConstRenbanTpB);
            searchCond.KmkCdShikido = GetKmkCd(ConstRenbanShikido);
            searchCond.KmkCdBodB = GetKmkCd(ConstRenbanBodB);
            searchCond.KmkCdHekisanKoyu = GetKmkCd(ConstRenbanHekisanKoyu);
            searchCond.KmkCdHekisanDoshoku = GetKmkCd(ConstRenbanHekisanDoshoku);
            searchCond.KmkCdHekisanB = GetKmkCd(ConstRenbanHekisanB);
            searchCond.KmkCdNamari = GetKmkCd(ConstRenbanNamari);
            searchCond.KmkCdAen = GetKmkCd(ConstRenbanAen);
            searchCond.KmkCdHouso = GetKmkCd(ConstRenbanHouso);
            searchCond.KmkCdZanen = GetKmkCd(ConstRenbanZanen);
            searchCond.KmkCdGaikan = GetKmkCd(ConstRenbanGaikan);
            searchCond.KmkCdShuki = GetKmkCd(ConstRenbanShuki);
            searchCond.KmkCdTr = GetKmkCd(ConstRenbanTr);
            searchCond.KmkCdNo2nTeisei = GetKmkCd(ConstRenbanNo2nTeisei);
            searchCond.KmkCdNo3nTeisei = GetKmkCd(ConstRenbanNo3nTeisei);
            searchCond.KmkCdDaichokin = GetKmkCd(ConstRenbanDaichokin);

            // 年度
            searchCond.Nendo = nendoTextBox.Text;

            // 依頼受付日入力区分
            if (iraiUketsukeDtCheckBox.Checked == true)
            {
                searchCond.IraiUketsukeDtInputKbn = "1";
            }
            else
            {
                searchCond.IraiUketsukeDtInputKbn = "0";
            }
            // 依頼受付日(開始)
            searchCond.IraiUketsukeFromDt = iraiUketsukeDtFromDateTimePicker.Value.ToString("yyyyMMdd");
            // 依頼受付日(開始)
            searchCond.IraiUketsukeToDt = iraiUketsukeDtToDateTimePicker.Value.ToString("yyyyMMdd");

            // 依頼No(開始)
            searchCond.IraiNoFrom = string.IsNullOrEmpty(iraiNoFromTextBox.Text) == true ? string.Empty : iraiNoFromTextBox.Text.PadLeft(6, '0');
            // 依頼No(終了)
            searchCond.IraiNoTo = string.IsNullOrEmpty(iraiNoToTextBox.Text) == true ? string.Empty : iraiNoToTextBox.Text.PadLeft(6, '0');

            alInput.SearchCond = searchCond;
            alInput.UpdateDtSearchCond = searchCond;
        }
        #endregion

        #region 取得データを設定
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetData
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/04　宗        新規作成
        /// 2015/01/22  宗        試験項目毎の桁数制限を追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetData(KensaDaicho9joHdrTblDataSet.KeiryoShomeiDaichoSearchRow row)
        {
            // 未入力項目は、該当項目を、黄色で表示する
            // 確定検査対象の場合は、該当項目を、青色で表示する

            // 初回検査結果＆確定検査結果設定
            var newRow = new DataGridViewRow();
            newRow.CreateCells(this.listDataGridView);

            // 計量証明検査依頼年度
            newRow.Cells[keiryoShomeiIraiNendoCol.Index].Value = row.KeiryoShomeiIraiNendo;
            // 計量証明支所コード
            newRow.Cells[keiryoShomeiIraiSishoCdCol.Index].Value = row.KeiryoShomeiIraiSishoCd;
            // 計量証明依頼連番
            newRow.Cells[keiryoShomeiIraiRenbanCol.Index].Value = row.KeiryoShomeiIraiRenban;
            // 浄化槽保健所コード
            newRow.Cells[jokasoHokenjoCdCol.Index].Value = row.KeiryoShomeiJokasoDaichoHokenjoCd;
            // 浄化槽台帳登録年度
            newRow.Cells[jokasoTorokuNendoCol.Index].Value = row.KeiryoShomeiJokasoDaichoNendo;
            // 浄化槽台帳連番
            newRow.Cells[jokasoRenbanCol.Index].Value = row.KeiryoShomeiJokasoDaichoRenban;
            // 依頼年度
            newRow.Cells[iraiNendoCol.Index].Value = row.IraiNendo;
            // 支所コード
            newRow.Cells[shishoCdCol.Index].Value = row.ShishoCd;
            // 検体番号
            newRow.Cells[iraiNoCol.Index].Value = row.SuishitsuKensaIraiNo;
            // 水質コード
            newRow.Cells[suishitsuCdCol.Index].Value = row.IsKeiryoShomeiSuisitsuCdNull() == true ? string.Empty : row.KeiryoShomeiSuisitsuCd;
            // 水質の種類
            newRow.Cells[suishitsuShuruiCol.Index].Value = row.IsSuishitsuNmNull() == true ? string.Empty : row.SuishitsuNm;
            // 処理方式区分
            newRow.Cells[shoriHoshikiKbnCol.Index].Value = row.IsKeiryoShomeiShoriHousikiKbnNull() == true ? string.Empty : row.KeiryoShomeiShoriHousikiKbn;
            // 処理方式コード
            newRow.Cells[shoriHoshikiCdCol.Index].Value = row.IsKeiryoShomeiShoriHousikiCdNull() == true ? string.Empty : row.KeiryoShomeiShoriHousikiCd;
            // 処理方式区分名
            newRow.Cells[shoriHoshikiKbnNmCol.Index].Value = row.IsShoriHoshikiShubetsuNmNull() == true ? string.Empty : row.ShoriHoshikiShubetsuNm;
            // 処理方式名
            newRow.Cells[shoriHoshikiNmCol.Index].Value = row.IsShoriHoshikiNmNull() == true ? string.Empty : row.ShoriHoshikiNm;
            // 課長検印
            newRow.Cells[kachoKeninCol.Index].Value = row.IsKachoKeninKbnNull() == true ? false : row.KachoKeninKbn == "1" ? true : false;
            // 副課長検印
            newRow.Cells[hukukachoKeninCol.Index].Value = row.IsHukuKachoKeninKbnNull() == true ? false : row.HukuKachoKeninKbn == "1" ? true : false;
            // 計量管理者検印
            newRow.Cells[kanrishaKeninCol.Index].Value = row.IsKeiryoKanrishaKeninKbnNull() == true ? false : row.KeiryoKanrishaKeninKbn == "1" ? true : false;

            #region pH
            // 結果入力区分（pH1）
            newRow.Cells[kekkaNyuryokuPh1Col.Index].Value = row.IsPh1KekkaNyuryokuNull() == true ? string.Empty : row.Ph1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuPh1Col.Index].Value.ToString() == "1")
            {
                // pH1
                newRow.Cells[ph1Col.Index].Value = row.IsPh1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanPh), row.Ph1KekkaValue.ToString());
                // 温度1
                //newRow.Cells[ondo1Col.Index].Value = row.IsPh1KekkaOndoNull() == true ? string.Empty : row.Ph1KekkaOndo.ToString();
                newRow.Cells[ondo1Col.Index].Value = row.IsPh1KekkaOndoNull() == true ? string.Empty : 
                    KensaHanteiUtility.HyojiKetasuHosei("000", row.Ph1KekkaOndo.ToString());
                // 結果コード（pH1）
                newRow.Cells[ph1KekkaCdCol.Index].Value = row.IsPh1KekkaCdNull() == true ? string.Empty : row.Ph1KekkaCd;
                // 確認検査種別（pH1）
                newRow.Cells[kakuninKensaPh1Col.Index].Value = row.IsPh1KensaShubetsuNull() == true ? string.Empty : row.Ph1KensaShubetsu;
            }
            // 採用値（pH1）
            newRow.Cells[saiyotiPh1Col.Index].Value = row.IsPh1SaiyoKbnNull() == true ? false : row.Ph1SaiyoKbn == "1" ? true : false;
            // pH1確認検査種別（過去との比較）
            newRow.Cells[ph1KensaShubetsuKako.Index].Value = row.IsPh1KensaShubetsuKakoNull() == true ? string.Empty : row.Ph1KensaShubetsuKako;

            // 結果入力区分（pH2）
            newRow.Cells[kekkaNyuryokuPh2Col.Index].Value = row.IsPh2KekkaNyuryokuNull() == true ? string.Empty : row.Ph2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuPh2Col.Index].Value.ToString() == "1")
            {
                // pH2
                newRow.Cells[ph2Col.Index].Value = row.IsPh2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanPh), row.Ph2KekkaValue.ToString());
                // 温度2
                //newRow.Cells[ondo2Col.Index].Value = row.IsPh2KekkaOndoNull() == true ? string.Empty : row.Ph2KekkaOndo.ToString();
                newRow.Cells[ondo2Col.Index].Value = row.IsPh2KekkaOndoNull() == true ? string.Empty : 
                    KensaHanteiUtility.HyojiKetasuHosei("000", row.Ph2KekkaOndo.ToString());
                // 結果コード（pH2）
                newRow.Cells[ph2KekkaCdCol.Index].Value = row.IsPh2KekkaCdNull() == true ? string.Empty : row.Ph2KekkaCd;
                // 確認検査種別（pH2）
                newRow.Cells[kakuninKensaPh2Col.Index].Value = row.IsPh2KensaShubetsuNull() == true ? string.Empty : row.Ph2KensaShubetsu;
            }
            // 採用値（pH2）
            newRow.Cells[saiyotiPh2Col.Index].Value = row.IsPh2SaiyoKbnNull() == true ? false : row.Ph2SaiyoKbn == "1" ? true : false;
            // pH2確認検査種別（過去との比較）
            newRow.Cells[ph2KensaShubetsuKako.Index].Value = row.IsPh2KensaShubetsuKakoNull() == true ? string.Empty : row.Ph2KensaShubetsuKako;
            // 更新区分（過去との比較）pH
            newRow.Cells[koshinKbnKakoPh.Index].Value = "0";
            #endregion

            #region SS
            // 結果入力区分（SS1）
            newRow.Cells[kekkaNyuryokuSs1Col.Index].Value = row.IsSs1KekkaNyuryokuNull() == true ? string.Empty : row.Ss1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuSs1Col.Index].Value.ToString() == "1")
            {
                // SS1
                newRow.Cells[ss1Col.Index].Value = row.IsSs1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanSs), row.Ss1KekkaValue.ToString());
                // 結果コード（SS1）
                newRow.Cells[ss1KekkaCdCol.Index].Value = row.IsSs1KekkaCdNull() == true ? string.Empty : row.Ss1KekkaCd;
                // 確認検査種別（SS1）
                newRow.Cells[kakuninKensaSs1Col.Index].Value = row.IsSs1KensaShubetsuNull() == true ? string.Empty : row.Ss1KensaShubetsu;
            }
            // 採用値（SS1）
            newRow.Cells[saiyotiSs1Col.Index].Value = row.IsSs1SaiyoKbnNull() == true ? false : row.Ss1SaiyoKbn == "1" ? true : false;
            // SS1確認検査種別（過去との比較）
            newRow.Cells[ss1KensaShubetsuKako.Index].Value = row.IsSs1KensaShubetsuKakoNull() == true ? string.Empty : row.Ss1KensaShubetsuKako;

            // 結果入力区分（SS2）
            newRow.Cells[kekkaNyuryokuSs2Col.Index].Value = row.IsSs2KekkaNyuryokuNull() == true ? string.Empty : row.Ss2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuSs2Col.Index].Value.ToString() == "1")
            {
                // SS2
                newRow.Cells[ss2Col.Index].Value = row.IsSs2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanSs), row.Ss2KekkaValue.ToString());
                // 結果コード（SS2）
                newRow.Cells[ss2KekkaCdCol.Index].Value = row.IsSs2KekkaCdNull() == true ? string.Empty : row.Ss2KekkaCd;
                // 確認検査種別（SS2）
                newRow.Cells[kakuninKensaSs2Col.Index].Value = row.IsSs2KensaShubetsuNull() == true ? string.Empty : row.Ss2KensaShubetsu;
            }
            // 採用値（SS2）
            newRow.Cells[saiyotiSs2Col.Index].Value = row.IsSs2SaiyoKbnNull() == true ? false : row.Ss2SaiyoKbn == "1" ? true : false;
            // SS2確認検査種別（過去との比較）
            newRow.Cells[ss2KensaShubetsuKako.Index].Value = row.IsSs2KensaShubetsuKakoNull() == true ? string.Empty : row.Ss2KensaShubetsuKako;

            // 更新区分（過去との比較）SS
            newRow.Cells[koshinKbnKakoSs.Index].Value = "0";
            #endregion

            #region BODA
            // 結果入力区分（BOD（A）1）
            newRow.Cells[kekkaNyuryokuBodA1Col.Index].Value = row.IsBodA1KekkaNyuryokuNull() == true ? string.Empty : row.BodA1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuBodA1Col.Index].Value.ToString() == "1")
            {
                // BOD（A）1
                newRow.Cells[bodA1Col.Index].Value = row.IsBodA1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanBodA), row.BodA1KekkaValue.ToString());
                // 結果コード（BOD（A）1）
                newRow.Cells[bodA1KekkaCdCol.Index].Value = row.IsBodA1KekkaCdNull() == true ? string.Empty : row.BodA1KekkaCd;
                // 確認検査種別（BOD（A）1）
                newRow.Cells[kakuninKensaBodA1Col.Index].Value = row.IsBodA1KensaShubetsuNull() == true ? string.Empty : row.BodA1KensaShubetsu;
            }
            // 採用値（BOD（A）1）
            newRow.Cells[saiyotiBodA1Col.Index].Value = row.IsBodA1SaiyoKbnNull() == true ? false : row.BodA1SaiyoKbn == "1" ? true : false;
            // BOD（A）1確認検査種別（過去との比較）
            newRow.Cells[bodA1KensaShubetsuKako.Index].Value = row.IsBodA1KensaShubetsuKakoNull() == true ? string.Empty : row.BodA1KensaShubetsuKako;

            // 結果入力区分（BOD（A）2）
            newRow.Cells[kekkaNyuryokuBodA2Col.Index].Value = row.IsBodA2KekkaNyuryokuNull() == true ? string.Empty : row.BodA2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuBodA2Col.Index].Value.ToString() == "1")
            {
                // BOD（A）2
                newRow.Cells[bodA2Col.Index].Value = row.IsBodA2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanBodA), row.BodA2KekkaValue.ToString());
                // 結果コード（BOD（A）2）
                newRow.Cells[bodA2KekkaCdCol.Index].Value = row.IsBodA2KekkaCdNull() == true ? string.Empty : row.BodA2KekkaCd;
                // 確認検査種別（BOD（A）2）
                newRow.Cells[kakuninKensaBodA2Col.Index].Value = row.IsBodA2KensaShubetsuNull() == true ? string.Empty : row.BodA2KensaShubetsu;
            }
            // 採用値（BOD（A）2）
            newRow.Cells[saiyotiBodA2Col.Index].Value = row.IsBodA2SaiyoKbnNull() == true ? false : row.BodA2SaiyoKbn == "1" ? true : false;
            // BOD（A）2確認検査種別（過去との比較）
            newRow.Cells[bodA2KensaShubetsuKako.Index].Value = row.IsBodA2KensaShubetsuKakoNull() == true ? string.Empty : row.BodA2KensaShubetsuKako;

            // 更新区分（過去との比較）BOD（A）
            newRow.Cells[koshinKbnKakoBodA.Index].Value = "0";
            #endregion

            #region アンモニア性窒素
            // 結果入力区分（アンモニア性窒素1）
            newRow.Cells[kekkaNyuryokuNh4n1Col.Index].Value = row.IsNh4n1KekkaNyuryokuNull() == true ? string.Empty : row.Nh4n1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuNh4n1Col.Index].Value.ToString() == "1")
            {
                // アンモニア性窒素1
                newRow.Cells[nh4n1Col.Index].Value = row.IsNh4n1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanNh4n), row.Nh4n1KekkaValue.ToString());
                // 結果コード（アンモニア性窒素1）
                newRow.Cells[nh4n1KekkaCdCol.Index].Value = row.IsNh4n1KekkaCdNull() == true ? string.Empty : row.Nh4n1KekkaCd;
                // 確認検査種別（アンモニア性窒素1）
                newRow.Cells[kakuninKensaNh4n1Col.Index].Value = row.IsNh4n1KensaShubetsuNull() == true ? string.Empty : row.Nh4n1KensaShubetsu;
            }
            // 採用値（アンモニア性窒素1）
            newRow.Cells[saiyotiNh4n1Col.Index].Value = row.IsNh4n1SaiyoKbnNull() == true ? false : row.Nh4n1SaiyoKbn == "1" ? true : false;
            // アンモニア性窒素1確認検査種別（過去との比較）
            newRow.Cells[nh4n1KensaShubetsuKako.Index].Value = row.IsNh4n1KensaShubetsuKakoNull() == true ? string.Empty : row.Nh4n1KensaShubetsuKako;

            // 結果入力区分（アンモニア性窒素2）
            newRow.Cells[kekkaNyuryokuNh4n2Col.Index].Value = row.IsNh4n2KekkaNyuryokuNull() == true ? string.Empty : row.Nh4n2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuNh4n2Col.Index].Value.ToString() == "1")
            {
                // アンモニア性窒素2
                newRow.Cells[nh4n2Col.Index].Value = row.IsNh4n2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanNh4n), row.Nh4n2KekkaValue.ToString());
                // 結果コード（アンモニア性窒素2）
                newRow.Cells[nh4n2KekkaCdCol.Index].Value = row.IsNh4n2KekkaCdNull() == true ? string.Empty : row.Nh4n2KekkaCd;
                // 確認検査種別（アンモニア性窒素2）
                newRow.Cells[kakuninKensaNh4n2Col.Index].Value = row.IsNh4n2KensaShubetsuNull() == true ? string.Empty : row.Nh4n2KensaShubetsu;
            }
            // 採用値（アンモニア性窒素2）
            newRow.Cells[saiyotiNh4n2Col.Index].Value = row.IsNh4n2SaiyoKbnNull() == true ? false : row.Nh4n2SaiyoKbn == "1" ? true : false;
            // アンモニア性窒素2確認検査種別（過去との比較）
            newRow.Cells[nh4n2KensaShubetsuKako.Index].Value = row.IsNh4n2KensaShubetsuKakoNull() == true ? string.Empty : row.Nh4n2KensaShubetsuKako;

            // 更新区分（過去との比較）アンモニア性窒素
            newRow.Cells[koshinKbnKakoNh4n.Index].Value = "0";
            #endregion

            #region 塩化物イオン
            // 結果入力区分（塩化物イオン1）
            newRow.Cells[kekkaNyuryokuCl1Col.Index].Value = row.IsCl1KekkaNyuryokuNull() == true ? string.Empty : row.Cl1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() == "1")
            {
                // 塩化物イオン1
                newRow.Cells[cl1Col.Index].Value = row.IsCl1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanCl), row.Cl1KekkaValue.ToString());
                // 結果コード（塩化物イオン1）
                newRow.Cells[cl1KekkaCdCol.Index].Value = row.IsCl1KekkaCdNull() == true ? string.Empty : row.Cl1KekkaCd;
                // 確認検査種別（塩化物イオン1）
                newRow.Cells[kakuninKensaCl1Col.Index].Value = row.IsCl1KensaShubetsuNull() == true ? string.Empty : row.Cl1KensaShubetsu;
            }
            // 採用値（塩化物イオン1）
            newRow.Cells[saiyotiCl1Col.Index].Value = row.IsCl1SaiyoKbnNull() == true ? false : row.Cl1SaiyoKbn == "1" ? true : false;
            // 塩化物イオン1確認検査種別（過去との比較）
            newRow.Cells[cl1KensaShubetsuKako.Index].Value = row.IsCl1KensaShubetsuKakoNull() == true ? string.Empty : row.Cl1KensaShubetsuKako;

            // 結果入力区分（塩化物イオン2）
            newRow.Cells[kekkaNyuryokuCl2Col.Index].Value = row.IsCl2KekkaNyuryokuNull() == true ? string.Empty : row.Cl2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuCl2Col.Index].Value.ToString() == "1")
            {
                // 塩化物イオン2
                newRow.Cells[cl2Col.Index].Value = row.IsCl2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanCl), row.Cl2KekkaValue.ToString());
                // 結果コード（塩化物イオン2）
                newRow.Cells[cl2KekkaCdCol.Index].Value = row.IsCl2KekkaCdNull() == true ? string.Empty : row.Cl2KekkaCd;
                // 確認検査種別（塩化物イオン2）
                newRow.Cells[kakuninKensaCl2Col.Index].Value = row.IsCl2KensaShubetsuNull() == true ? string.Empty : row.Cl2KensaShubetsu;
            }
            // 採用値（塩化物イオン2）
            newRow.Cells[saiyotiCl2Col.Index].Value = row.IsCl2SaiyoKbnNull() == true ? false : row.Cl2SaiyoKbn == "1" ? true : false;
            // 塩化物イオン2確認検査種別（過去との比較）
            newRow.Cells[cl2KensaShubetsuKako.Index].Value = row.IsCl2KensaShubetsuKakoNull() == true ? string.Empty : row.Cl2KensaShubetsuKako;

            // 更新区分（過去との比較）塩化物イオン
            newRow.Cells[koshinKbnKakoCl.Index].Value = "0";
            #endregion

            #region COD
            // 結果入力区分（COD1）
            newRow.Cells[kekkaNyuryokuCod1Col.Index].Value = row.IsCod1KekkaNyuryokuNull() == true ? string.Empty : row.Cod1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuCod1Col.Index].Value.ToString() == "1")
            {
                // COD1
                newRow.Cells[cod1Col.Index].Value = row.IsCod1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanCod), row.Cod1KekkaValue.ToString());
                // 結果コード（COD1）
                newRow.Cells[cod1KekkaCdCol.Index].Value = row.IsCod1KekkaCdNull() == true ? string.Empty : row.Cod1KekkaCd;
                // 確認検査種別（COD1）
                newRow.Cells[kakuninKensaCod1Col.Index].Value = row.IsCod1KensaShubetsuNull() == true ? string.Empty : row.Cod1KensaShubetsu;
            }
            // 採用値（COD1）
            newRow.Cells[saiyotiCod1Col.Index].Value = row.IsCod1SaiyoKbnNull() == true ? false : row.Cod1SaiyoKbn == "1" ? true : false;
            // COD1確認検査種別（過去との比較）
            newRow.Cells[cod1KensaShubetsuKako.Index].Value = row.IsCod1KensaShubetsuKakoNull() == true ? string.Empty : row.Cod1KensaShubetsuKako;

            // 結果入力区分（COD2）
            newRow.Cells[kekkaNyuryokuCod2Col.Index].Value = row.IsCod2KekkaNyuryokuNull() == true ? string.Empty : row.Cod2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuCod2Col.Index].Value.ToString() == "1")
            {
                // COD2
                newRow.Cells[cod2Col.Index].Value = row.IsCod2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanPh), row.Cod2KekkaValue.ToString());
                // 結果コード（COD2）
                newRow.Cells[cod2KekkaCdCol.Index].Value = row.IsCod2KekkaCdNull() == true ? string.Empty : row.Cod2KekkaCd;
                // 確認検査種別（COD2）
                newRow.Cells[kakuninKensaCod2Col.Index].Value = row.IsCod2KensaShubetsuNull() == true ? string.Empty : row.Cod2KensaShubetsu;
            }
            // 採用値（COD2）
            newRow.Cells[saiyotiCod2Col.Index].Value = row.IsCod2SaiyoKbnNull() == true ? false : row.Cod2SaiyoKbn == "1" ? true : false;
            // COD2確認検査種別（過去との比較）
            newRow.Cells[cod2KensaShubetsuKako.Index].Value = row.IsCod2KensaShubetsuKakoNull() == true ? string.Empty : row.Cod2KensaShubetsuKako;

            // 更新区分（過去との比較）COD
            newRow.Cells[koshinKbnKakoCod.Index].Value = "0";
            #endregion

            #region ヘキサン抽出物質A
            // 結果入力区分（ヘキサン抽出物質（A）1）
            newRow.Cells[kekkaNyuryokuHekisanA1Col.Index].Value = row.IsHekisanA1KekkaNyuryokuNull() == true ? string.Empty : row.HekisanA1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuHekisanA1Col.Index].Value.ToString() == "1")
            {
                // ヘキサン抽出物質（A）1
                newRow.Cells[hekisanA1Col.Index].Value = row.IsHekisanA1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanHekisanA), row.HekisanA1KekkaValue.ToString());
                // 結果コード（ヘキサン抽出物質（A）1）
                newRow.Cells[hekisanA1KekkaCdCol.Index].Value = row.IsHekisanA1KekkaCdNull() == true ? string.Empty : row.HekisanA1KekkaCd;
                // 確認検査種別（ヘキサン抽出物質（A）1）
                newRow.Cells[kakuninKensaHekisanA1Col.Index].Value = row.IsHekisanA1KensaShubetsuNull() == true ? string.Empty : row.HekisanA1KensaShubetsu;
            }
            // 採用値（ヘキサン抽出物質（A）1）
            newRow.Cells[saiyotiHekisanA1Col.Index].Value = row.IsHekisanA1SaiyoKbnNull() == true ? false : row.HekisanA1SaiyoKbn == "1" ? true : false;
            // ヘキサン抽出物質（A）1確認検査種別（過去との比較）
            newRow.Cells[hekisanA1KensaShubetsuKako.Index].Value = row.IsHekisanA1KensaShubetsuKakoNull() == true ? string.Empty : row.HekisanA1KensaShubetsuKako;

            // 結果入力区分（ヘキサン抽出物質（A）2）
            newRow.Cells[kekkaNyuryokuHekisanA2Col.Index].Value = row.IsHekisanA2KekkaNyuryokuNull() == true ? string.Empty : row.HekisanA2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuHekisanA2Col.Index].Value.ToString() == "1")
            {
                // ヘキサン抽出物質（A）2
                newRow.Cells[hekisanA2Col.Index].Value = row.IsHekisanA2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanHekisanA), row.HekisanA2KekkaValue.ToString());
                // 結果コード（ヘキサン抽出物質（A）2）
                newRow.Cells[hekisanA2KekkaCdCol.Index].Value = row.IsHekisanA2KekkaCdNull() == true ? string.Empty : row.HekisanA2KekkaCd;
                // 確認検査種別（ヘキサン抽出物質（A）2）
                newRow.Cells[kakuninKensaHekisanA2Col.Index].Value = row.IsHekisanA2KensaShubetsuNull() == true ? string.Empty : row.HekisanA2KensaShubetsu;
            }
            // 採用値（ヘキサン抽出物質（A）2）
            newRow.Cells[saiyotiHekisanA2Col.Index].Value = row.IsHekisanA2SaiyoKbnNull() == true ? false : row.HekisanA2SaiyoKbn == "1" ? true : false;
            // ヘキサン抽出物質（A）2確認検査種別（過去との比較）
            newRow.Cells[hekisanA2KensaShubetsuKako.Index].Value = row.IsHekisanA2KensaShubetsuKakoNull() == true ? string.Empty : row.HekisanA2KensaShubetsuKako;

            // 更新区分（過去との比較）ヘキサン抽出物質（A）
            newRow.Cells[koshinKbnKakoHekisanA.Index].Value = "0";
            #endregion

            #region MLSS
            // 結果入力区分（MLSS1）
            newRow.Cells[kekkaNyuryokuMlss1Col.Index].Value = row.IsMlss1KekkaNyuryokuNull() == true ? string.Empty : row.Mlss1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuMlss1Col.Index].Value.ToString() == "1")
            {
                // MLSS1
                newRow.Cells[mlss1Col.Index].Value = row.IsMlss1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanMlss), row.Mlss1KekkaValue.ToString());
                // 結果コード（MLSS1）
                newRow.Cells[mlss1KekkaCdCol.Index].Value = row.IsMlss1KekkaCdNull() == true ? string.Empty : row.Mlss1KekkaCd;
                // 確認検査種別（MLSS1）
                newRow.Cells[kakuninKensaMlss1Col.Index].Value = row.IsMlss1KensaShubetsuNull() == true ? string.Empty : row.Mlss1KensaShubetsu;
            }
            // 採用値（MLSS1）
            newRow.Cells[saiyotiMlss1Col.Index].Value = row.IsMlss1SaiyoKbnNull() == true ? false : row.Mlss1SaiyoKbn == "1" ? true : false;
            // MLSS1確認検査種別（過去との比較）
            newRow.Cells[mlss1KensaShubetsuKako.Index].Value = row.IsMlss1KensaShubetsuKakoNull() == true ? string.Empty : row.Mlss1KensaShubetsuKako;

            // 結果入力区分（MLSS2）
            newRow.Cells[kekkaNyuryokuMlss2Col.Index].Value = row.IsMlss2KekkaNyuryokuNull() == true ? string.Empty : row.Mlss2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuMlss2Col.Index].Value.ToString() == "1")
            {
                // MLSS2
                newRow.Cells[mlss2Col.Index].Value = row.IsMlss2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanMlss), row.Mlss2KekkaValue.ToString());
                // 結果コード（MLSS2）
                newRow.Cells[mlss2KekkaCdCol.Index].Value = row.IsMlss2KekkaCdNull() == true ? string.Empty : row.Mlss2KekkaCd;
                // 確認検査種別（MLSS2）
                newRow.Cells[kakuninKensaMlss2Col.Index].Value = row.IsMlss2KensaShubetsuNull() == true ? string.Empty : row.Mlss2KensaShubetsu;
            }
            // 採用値（MLSS2）
            newRow.Cells[saiyotiMlss2Col.Index].Value = row.IsMlss2SaiyoKbnNull() == true ? false : row.Mlss2SaiyoKbn == "1" ? true : false;
            // MLSS2確認検査種別（過去との比較）
            newRow.Cells[mlss2KensaShubetsuKako.Index].Value = row.IsMlss2KensaShubetsuKakoNull() == true ? string.Empty : row.Mlss2KensaShubetsuKako;

            // 更新区分（過去との比較）MLSS
            newRow.Cells[koshinKbnKakoMlss.Index].Value = "0";
            #endregion

            #region 全窒素A
            // 結果入力区分（全窒素（A)1）
            newRow.Cells[kekkaNyuryokuTnA1Col.Index].Value = row.IsTnA1KekkaNyuryokuNull() == true ? string.Empty : row.TnA1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuTnA1Col.Index].Value.ToString() == "1")
            {
                // 全窒素（A)1
                newRow.Cells[tnA1Col.Index].Value = row.IsTnA1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanTnA), row.TnA1KekkaValue.ToString());
                // 結果コード（全窒素（A)1）
                newRow.Cells[tnA1KekkaCdCol.Index].Value = row.IsTnA1KekkaCdNull() == true ? string.Empty : row.TnA1KekkaCd;
                // 確認検査種別（全窒素（A)1）
                newRow.Cells[kakuninKensaTnA1Col.Index].Value = row.IsTnA1KensaShubetsuNull() == true ? string.Empty : row.TnA1KensaShubetsu;
            }
            // 採用値（全窒素（A)1）
            newRow.Cells[saiyotiTnA1Col.Index].Value = row.IsTnA1SaiyoKbnNull() == true ? false : row.TnA1SaiyoKbn == "1" ? true : false;
            // 全窒素（A)1確認検査種別（過去との比較）
            newRow.Cells[tnA1KensaShubetsuKako.Index].Value = row.IsTnA1KensaShubetsuKakoNull() == true ? string.Empty : row.TnA1KensaShubetsuKako;

            // 結果入力区分（全窒素（A)2）
            newRow.Cells[kekkaNyuryokuTnA2Col.Index].Value = row.IsTnA2KekkaNyuryokuNull() == true ? string.Empty : row.TnA2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuTnA2Col.Index].Value.ToString() == "1")
            {
                // 全窒素（A)2
                newRow.Cells[tnA2Col.Index].Value = row.IsTnA2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanTnA), row.TnA2KekkaValue.ToString());
                // 結果コード（全窒素（A)2）
                newRow.Cells[tnA2KekkaCdCol.Index].Value = row.IsTnA2KekkaCdNull() == true ? string.Empty : row.TnA2KekkaCd;
                // 確認検査種別（全窒素（A)2）
                newRow.Cells[kakuninKensaTnA2Col.Index].Value = row.IsTnA2KensaShubetsuNull() == true ? string.Empty : row.TnA2KensaShubetsu;
            }
            // 採用値（全窒素（A)2）
            newRow.Cells[saiyotiTnA2Col.Index].Value = row.IsTnA2SaiyoKbnNull() == true ? false : row.TnA2SaiyoKbn == "1" ? true : false;
            // 全窒素（A)2確認検査種別（過去との比較）
            newRow.Cells[tnA2KensaShubetsuKako.Index].Value = row.IsTnA2KensaShubetsuKakoNull() == true ? string.Empty : row.TnA2KensaShubetsuKako;

            // 更新区分（過去との比較）全窒素（A)
            newRow.Cells[koshinKbnKakoTnA.Index].Value = "0";
            #endregion

            #region 陰イオン界面活性剤A
            // 結果入力区分（陰イオン界面活性剤（A）1）
            newRow.Cells[kekkaNyuryokuAbsA1Col.Index].Value = row.IsAbsA1KekkaNyuryokuNull() == true ? string.Empty : row.AbsA1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuAbsA1Col.Index].Value.ToString() == "1")
            {
                // 陰イオン界面活性剤（A）1
                newRow.Cells[absA1Col.Index].Value = row.IsAbsA1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanAbsA), row.AbsA1KekkaValue.ToString());
                // 結果コード（陰イオン界面活性剤（A）1）
                newRow.Cells[absA1KekkaCdCol.Index].Value = row.IsAbsA1KekkaCdNull() == true ? string.Empty : row.AbsA1KekkaCd;
                // 確認検査種別（陰イオン界面活性剤（A）1）
                newRow.Cells[kakuninKensaAbsA1Col.Index].Value = row.IsAbsA1KensaShubetsuNull() == true ? string.Empty : row.AbsA1KensaShubetsu;
            }
            // 採用値（陰イオン界面活性剤（A）1）
            newRow.Cells[saiyotiAbsA1Col.Index].Value = row.IsAbsA1SaiyoKbnNull() == true ? false : row.AbsA1SaiyoKbn == "1" ? true : false;
            // 陰イオン界面活性剤（A）1確認検査種別（過去との比較）
            newRow.Cells[absA1KensaShubetsuKako.Index].Value = row.IsAbsA1KensaShubetsuKakoNull() == true ? string.Empty : row.AbsA1KensaShubetsuKako;

            // 結果入力区分（陰イオン界面活性剤（A）2）
            newRow.Cells[kekkaNyuryokuAbsA2Col.Index].Value = row.IsAbsA2KekkaNyuryokuNull() == true ? string.Empty : row.AbsA2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuAbsA2Col.Index].Value.ToString() == "1")
            {
                // 陰イオン界面活性剤（A）2
                newRow.Cells[absA2Col.Index].Value = row.IsAbsA2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanAbsA), row.AbsA2KekkaValue.ToString());
                // 結果コード（陰イオン界面活性剤（A）2）
                newRow.Cells[absA2KekkaCdCol.Index].Value = row.IsAbsA2KekkaCdNull() == true ? string.Empty : row.AbsA2KekkaCd;
                // 確認検査種別（陰イオン界面活性剤（A）2）
                newRow.Cells[kakuninKensaAbsA2Col.Index].Value = row.IsAbsA2KensaShubetsuNull() == true ? string.Empty : row.AbsA2KensaShubetsu;
            }
            // 採用値（陰イオン界面活性剤（A）2）
            newRow.Cells[saiyotiAbsA2Col.Index].Value = row.IsAbsA2SaiyoKbnNull() == true ? false : row.AbsA2SaiyoKbn == "1" ? true : false;
            // 陰イオン界面活性剤（A）2確認検査種別（過去との比較）
            newRow.Cells[absA2KensaShubetsuKako.Index].Value = row.IsAbsA2KensaShubetsuKakoNull() == true ? string.Empty : row.AbsA2KensaShubetsuKako;

            // 更新区分（過去との比較）陰イオン界面活性剤（A）
            newRow.Cells[koshinKbnKakoAbsA.Index].Value = "0";
            #endregion

            #region 全りんA
            // 結果入力区分（全りん（A)1）
            newRow.Cells[kekkaNyuryokuTpA1Col.Index].Value = row.IsTpA1KekkaNyuryokuNull() == true ? string.Empty : row.TpA1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuTpA1Col.Index].Value.ToString() == "1")
            {
                // 全りん（A)1
                newRow.Cells[tpA1Col.Index].Value = row.IsTpA1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanTpA), row.TpA1KekkaValue.ToString());
                // 結果コード（全りん（A)1）
                newRow.Cells[tpA1KekkaCdCol.Index].Value = row.IsTpA1KekkaCdNull() == true ? string.Empty : row.TpA1KekkaCd;
                // 確認検査種別（全りん（A)1）
                newRow.Cells[kakuninKensaTpA1Col.Index].Value = row.IsTpA1KensaShubetsuNull() == true ? string.Empty : row.TpA1KensaShubetsu;
            }
            // 採用値（全りん（A)1）
            newRow.Cells[saiyotiTpA1Col.Index].Value = row.IsTpA1SaiyoKbnNull() == true ? false : row.TpA1SaiyoKbn == "1" ? true : false;
            // 全りん（A)1確認検査種別（過去との比較）
            newRow.Cells[tpA1KensaShubetsuKako.Index].Value = row.IsTpA1KensaShubetsuKakoNull() == true ? string.Empty : row.TpA1KensaShubetsuKako;

            // 結果入力区分（全りん（A)2）
            newRow.Cells[kekkaNyuryokuTpA2Col.Index].Value = row.IsTpA2KekkaNyuryokuNull() == true ? string.Empty : row.TpA2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuTpA2Col.Index].Value.ToString() == "1")
            {
                // 全りん（A)2
                newRow.Cells[tpA2Col.Index].Value = row.IsTpA2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanTpA), row.TpA2KekkaValue.ToString());
                // 結果コード（全りん（A)2）
                newRow.Cells[tpA2KekkaCdCol.Index].Value = row.IsTpA2KekkaCdNull() == true ? string.Empty : row.TpA2KekkaCd;
                // 確認検査種別（全りん（A)2）
                newRow.Cells[kakuninKensaTpA2Col.Index].Value = row.IsTpA2KensaShubetsuNull() == true ? string.Empty : row.TpA2KensaShubetsu;
            }
            // 採用値（全りん（A)2）
            newRow.Cells[saiyotiTpA2Col.Index].Value = row.IsTpA2SaiyoKbnNull() == true ? false : row.TpA2SaiyoKbn == "1" ? true : false;
            // 全りん（A)2確認検査種別（過去との比較）
            newRow.Cells[tpA2KensaShubetsuKako.Index].Value = row.IsTpA2KensaShubetsuKakoNull() == true ? string.Empty : row.TpA2KensaShubetsuKako;

            // 更新区分（過去との比較）全りん（A)
            newRow.Cells[koshinKbnKakoTpA.Index].Value = "0";
            #endregion

            #region りん酸イオン
            // 結果入力区分（りん酸イオン1）
            newRow.Cells[kekkaNyuryokuRinsan1Col.Index].Value = row.IsRinsan1KekkaNyuryokuNull() == true ? string.Empty : row.Rinsan1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuRinsan1Col.Index].Value.ToString() == "1")
            {
                // りん酸イオン1
                newRow.Cells[rinsan1Col.Index].Value = row.IsRinsan1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanRinsan), row.Rinsan1KekkaValue.ToString());
                // 結果コード（りん酸イオン1）
                newRow.Cells[rinsan1KekkaCdCol.Index].Value = row.IsRinsan1KekkaCdNull() == true ? string.Empty : row.Rinsan1KekkaCd;
                // 確認検査種別（りん酸イオン1）
                newRow.Cells[kakuninKensaRinsan1Col.Index].Value = row.IsRinsan1KensaShubetsuNull() == true ? string.Empty : row.Rinsan1KensaShubetsu;
            }
            // 採用値（りん酸イオン1）
            newRow.Cells[saiyotiRinsan1Col.Index].Value = row.IsRinsan1SaiyoKbnNull() == true ? false : row.Rinsan1SaiyoKbn == "1" ? true : false;
            // りん酸イオン1確認検査種別（過去との比較）
            newRow.Cells[rinsan1KensaShubetsuKako.Index].Value = row.IsRinsan1KensaShubetsuKakoNull() == true ? string.Empty : row.Rinsan1KensaShubetsuKako;

            // 結果入力区分（りん酸イオン2）
            newRow.Cells[kekkaNyuryokuRinsan2Col.Index].Value = row.IsRinsan2KekkaNyuryokuNull() == true ? string.Empty : row.Rinsan2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuRinsan2Col.Index].Value.ToString() == "1")
            {
                // りん酸イオン2
                newRow.Cells[rinsan2Col.Index].Value = row.IsRinsan2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanRinsan), row.Rinsan2KekkaValue.ToString());
                // 結果コード（りん酸イオン2）
                newRow.Cells[rinsan2KekkaCdCol.Index].Value = row.IsRinsan2KekkaCdNull() == true ? string.Empty : row.Rinsan2KekkaCd;
                // 確認検査種別（りん酸イオン2）
                newRow.Cells[kakuninKensaRinsan2Col.Index].Value = row.IsRinsan2KensaShubetsuNull() == true ? string.Empty : row.Rinsan2KensaShubetsu;
            }
            // 採用値（りん酸イオン2）
            newRow.Cells[saiyotiRinsan2Col.Index].Value = row.IsRinsan2SaiyoKbnNull() == true ? false : row.Rinsan2SaiyoKbn == "1" ? true : false;
            // りん酸イオン2確認検査種別（過去との比較）
            newRow.Cells[rinsan2KensaShubetsuKako.Index].Value = row.IsRinsan2KensaShubetsuKakoNull() == true ? string.Empty : row.Rinsan2KensaShubetsuKako;

            // 更新区分（過去との比較）りん酸イオン
            newRow.Cells[koshinKbnKakoRinsan.Index].Value = "0";
            #endregion

            #region 亜硝酸性窒素(定量)
            // 結果入力区分（亜硝酸性窒素（定量）1）
            newRow.Cells[kekkaNyuryokuNo2nTeiryo1Col.Index].Value = row.IsNo2nTeiryo1KekkaNyuryokuNull() == true ? string.Empty : row.No2nTeiryo1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuNo2nTeiryo1Col.Index].Value.ToString() == "1")
            {
                // 亜硝酸性窒素（定量）1
                newRow.Cells[no2nTeiryo1Col.Index].Value = row.IsNo2nTeiryo1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanNo2nTeiryo), row.No2nTeiryo1KekkaValue.ToString());
                // 結果コード（亜硝酸性窒素（定量）1）
                newRow.Cells[no2nTeiryo1KekkaCdCol.Index].Value = row.IsNo2nTeiryo1KekkaCdNull() == true ? string.Empty : row.No2nTeiryo1KekkaCd;
                // 確認検査種別（亜硝酸性窒素（定量）1）
                newRow.Cells[kakuninKensaNo2nTeiryo1Col.Index].Value = row.IsNo2nTeiryo1KensaShubetsuNull() == true ? string.Empty : row.No2nTeiryo1KensaShubetsu;
            }
            // 採用値（亜硝酸性窒素（定量）1）
            newRow.Cells[saiyotiNo2nTeiryo1Col.Index].Value = row.IsNo2nTeiryo1SaiyoKbnNull() == true ? false : row.No2nTeiryo1SaiyoKbn == "1" ? true : false;
            // 亜硝酸性窒素（定量）1確認検査種別（過去との比較）
            newRow.Cells[no2nTeiryo1KensaShubetsuKako.Index].Value = row.IsNo2nTeiryo1KensaShubetsuKakoNull() == true ? string.Empty : row.No2nTeiryo1KensaShubetsuKako;

            // 結果入力区分（亜硝酸性窒素（定量）2）
            newRow.Cells[kekkaNyuryokuNo2nTeiryo2Col.Index].Value = row.IsNo2nTeiryo2KekkaNyuryokuNull() == true ? string.Empty : row.No2nTeiryo2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuNo2nTeiryo2Col.Index].Value.ToString() == "1")
            {
                // 亜硝酸性窒素（定量）2
                newRow.Cells[no2nTeiryo2Col.Index].Value = row.IsNo2nTeiryo2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanNo2nTeiryo), row.No2nTeiryo2KekkaValue.ToString());
                // 結果コード（亜硝酸性窒素（定量）2）
                newRow.Cells[no2nTeiryo2KekkaCdCol.Index].Value = row.IsNo2nTeiryo2KekkaCdNull() == true ? string.Empty : row.No2nTeiryo2KekkaCd;
                // 確認検査種別（亜硝酸性窒素（定量）2）
                newRow.Cells[kakuninKensaNo2nTeiryo2Col.Index].Value = row.IsNo2nTeiryo2KensaShubetsuNull() == true ? string.Empty : row.No2nTeiryo2KensaShubetsu;
            }
            // 採用値（亜硝酸性窒素（定量）2）
            newRow.Cells[saiyotiNo2nTeiryo2Col.Index].Value = row.IsNo2nTeiryo2SaiyoKbnNull() == true ? false : row.No2nTeiryo2SaiyoKbn == "1" ? true : false;
            // 亜硝酸性窒素（定量）2確認検査種別（過去との比較）
            newRow.Cells[no2nTeiryo2KensaShubetsuKako.Index].Value = row.IsNo2nTeiryo2KensaShubetsuKakoNull() == true ? string.Empty : row.No2nTeiryo2KensaShubetsuKako;

            // 更新区分（過去との比較）亜硝酸性窒素（定量）
            newRow.Cells[koshinKbnKakoNo2nTeiryo.Index].Value = "0";
            #endregion

            #region 硝酸性窒素(定量)
            // 結果入力区分（硝酸性窒素（定量）1）
            newRow.Cells[kekkaNyuryokuNo3nTeiryo1Col.Index].Value = row.IsNo3nTeiryo1KekkaNyuryokuNull() == true ? string.Empty : row.No3nTeiryo1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuNo3nTeiryo1Col.Index].Value.ToString() == "1")
            {
                // 硝酸性窒素（定量）1
                newRow.Cells[no3nTeiryo1Col.Index].Value = row.IsNo3nTeiryo1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanNo3nTeiryo), row.No3nTeiryo1KekkaValue.ToString());
                // 結果コード（硝酸性窒素（定量）1）
                newRow.Cells[no3nTeiryo1KekkaCdCol.Index].Value = row.IsNo3nTeiryo1KekkaCdNull() == true ? string.Empty : row.No3nTeiryo1KekkaCd;
                // 確認検査種別（硝酸性窒素（定量）1）
                newRow.Cells[kakuninKensaNo3nTeiryo1Col.Index].Value = row.IsNo3nTeiryo1KensaShubetsuNull() == true ? string.Empty : row.No3nTeiryo1KensaShubetsu;
            }
            // 採用値（硝酸性窒素（定量）1）
            newRow.Cells[saiyotiNo3nTeiryo1Col.Index].Value = row.IsNo3nTeiryo1SaiyoKbnNull() == true ? false : row.No3nTeiryo1SaiyoKbn == "1" ? true : false;
            // 硝酸性窒素（定量）1確認検査種別（過去との比較）
            newRow.Cells[no3nTeiryo1KensaShubetsuKako.Index].Value = row.IsNo3nTeiryo1KensaShubetsuKakoNull() == true ? string.Empty : row.No3nTeiryo1KensaShubetsuKako;

            // 結果入力区分（硝酸性窒素（定量）2）
            newRow.Cells[kekkaNyuryokuNo3nTeiryo2Col.Index].Value = row.IsNo3nTeiryo2KekkaNyuryokuNull() == true ? string.Empty : row.No3nTeiryo2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuNo3nTeiryo2Col.Index].Value.ToString() == "1")
            {
                // 硝酸性窒素（定量）2
                newRow.Cells[no3nTeiryo2Col.Index].Value = row.IsNo3nTeiryo2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanNo3nTeiryo), row.No3nTeiryo2KekkaValue.ToString());
                // 結果コード（硝酸性窒素（定量）2）
                newRow.Cells[no3nTeiryo2KekkaCdCol.Index].Value = row.IsNo3nTeiryo2KekkaCdNull() == true ? string.Empty : row.No3nTeiryo2KekkaCd;
                // 確認検査種別（硝酸性窒素（定量）2）
                newRow.Cells[kakuninKensaNo3nTeiryo2Col.Index].Value = row.IsNo3nTeiryo2KensaShubetsuNull() == true ? string.Empty : row.No3nTeiryo2KensaShubetsu;
            }
            // 採用値（硝酸性窒素（定量）2）
            newRow.Cells[saiyotiNo3nTeiryo2Col.Index].Value = row.IsNo3nTeiryo2SaiyoKbnNull() == true ? false : row.No3nTeiryo2SaiyoKbn == "1" ? true : false;
            // 硝酸性窒素（定量）2確認検査種別（過去との比較）
            newRow.Cells[no3nTeiryo2KensaShubetsuKako.Index].Value = row.IsNo3nTeiryo2KensaShubetsuKakoNull() == true ? string.Empty : row.No3nTeiryo2KensaShubetsuKako;

            // 更新区分（過去との比較）硝酸性窒素（定量）
            newRow.Cells[koshinKbnKakoNo3nTeiryo.Index].Value = "0";
            #endregion

            #region 陰イオン界面活性剤B
            // 結果入力区分（陰イオン界面活性剤（B)1）
            newRow.Cells[kekkaNyuryokuAbsB1Col.Index].Value = row.IsAbsB1KekkaNyuryokuNull() == true ? string.Empty : row.AbsB1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuAbsB1Col.Index].Value.ToString() == "1")
            {
                // 陰イオン界面活性剤（B)1
                newRow.Cells[absB1Col.Index].Value = row.IsAbsB1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanAbsB), row.AbsB1KekkaValue.ToString());
                // 結果コード（陰イオン界面活性剤（B)1）
                newRow.Cells[absB1KekkaCdCol.Index].Value = row.IsAbsB1KekkaCdNull() == true ? string.Empty : row.AbsB1KekkaCd;
                // 確認検査種別（陰イオン界面活性剤（B)1）
                newRow.Cells[kakuninKensaAbsB1Col.Index].Value = row.IsAbsB1KensaShubetsuNull() == true ? string.Empty : row.AbsB1KensaShubetsu;
            }
            // 採用値（陰イオン界面活性剤（B)1）
            newRow.Cells[saiyotiAbsB1Col.Index].Value = row.IsAbsB1SaiyoKbnNull() == true ? false : row.AbsB1SaiyoKbn == "1" ? true : false;
            // 陰イオン界面活性剤（B)1確認検査種別（過去との比較）
            newRow.Cells[absB1KensaShubetsuKako.Index].Value = row.IsAbsB1KensaShubetsuKakoNull() == true ? string.Empty : row.AbsB1KensaShubetsuKako;

            // 結果入力区分（陰イオン界面活性剤（B)2）
            newRow.Cells[kekkaNyuryokuAbsB2Col.Index].Value = row.IsAbsB2KekkaNyuryokuNull() == true ? string.Empty : row.AbsB2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuAbsB2Col.Index].Value.ToString() == "1")
            {
                // 陰イオン界面活性剤（B)2
                newRow.Cells[absB2Col.Index].Value = row.IsAbsB2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanAbsB), row.AbsB2KekkaValue.ToString());
                // 結果コード（陰イオン界面活性剤（B)2）
                newRow.Cells[absB2KekkaCdCol.Index].Value = row.IsAbsB2KekkaCdNull() == true ? string.Empty : row.AbsB2KekkaCd;
                // 確認検査種別（陰イオン界面活性剤（B)2）
                newRow.Cells[kakuninKensaAbsB2Col.Index].Value = row.IsAbsB2KensaShubetsuNull() == true ? string.Empty : row.AbsB2KensaShubetsu;
            }
            // 採用値（陰イオン界面活性剤（B)2）
            newRow.Cells[saiyotiAbsB2Col.Index].Value = row.IsAbsB2SaiyoKbnNull() == true ? false : row.AbsB2SaiyoKbn == "1" ? true : false;
            // 陰イオン界面活性剤（B)2確認検査種別（過去との比較）
            newRow.Cells[absB2KensaShubetsuKako.Index].Value = row.IsAbsB2KensaShubetsuKakoNull() == true ? string.Empty : row.AbsB2KensaShubetsuKako;

            // 更新区分（過去との比較）陰イオン界面活性剤（B)
            newRow.Cells[koshinKbnKakoAbsB.Index].Value = "0";
            #endregion

            #region 全窒素B
            // 結果入力区分（全窒素（B)1）
            newRow.Cells[kekkaNyuryokuTnB1Col.Index].Value = row.IsTnB1KekkaNyuryokuNull() == true ? string.Empty : row.TnB1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuTnB1Col.Index].Value.ToString() == "1")
            {
                // 全窒素（B)1
                newRow.Cells[tnB1Col.Index].Value = row.IsTnB1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanTnB), row.TnB1KekkaValue.ToString());
                // 結果コード（全窒素（B)1）
                newRow.Cells[tnB1KekkaCdCol.Index].Value = row.IsTnB1KekkaCdNull() == true ? string.Empty : row.TnB1KekkaCd;
                // 確認検査種別（全窒素（B)1）
                newRow.Cells[kakuninKensaTnB1Col.Index].Value = row.IsTnB1KensaShubetsuNull() == true ? string.Empty : row.TnB1KensaShubetsu;
            }
            // 採用値（全窒素（B)1）
            newRow.Cells[saiyotiTnB1Col.Index].Value = row.IsTnB1SaiyoKbnNull() == true ? false : row.TnB1SaiyoKbn == "1" ? true : false;
            // 全窒素（B)1確認検査種別（過去との比較）
            newRow.Cells[tnB1KensaShubetsuKako.Index].Value = row.IsTnB1KensaShubetsuKakoNull() == true ? string.Empty : row.TnB1KensaShubetsuKako;

            // 結果入力区分（全窒素（B)2）
            newRow.Cells[kekkaNyuryokuTnB2Col.Index].Value = row.IsTnB2KekkaNyuryokuNull() == true ? string.Empty : row.TnB2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuTnB2Col.Index].Value.ToString() == "1")
            {
                // 全窒素（B)2
                newRow.Cells[tnB2Col.Index].Value = row.IsTnB2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanTnB), row.TnB2KekkaValue.ToString());
                // 結果コード（全窒素（B)2）
                newRow.Cells[tnB2KekkaCdCol.Index].Value = row.IsTnB2KekkaCdNull() == true ? string.Empty : row.TnB2KekkaCd;
                // 確認検査種別（全窒素（B)2）
                newRow.Cells[kakuninKensaTnB2Col.Index].Value = row.IsTnB2KensaShubetsuNull() == true ? string.Empty : row.TnB2KensaShubetsu;
            }
            // 採用値（全窒素（B)2）
            newRow.Cells[saiyotiTnB2Col.Index].Value = row.IsTnB2SaiyoKbnNull() == true ? false : row.TnB2SaiyoKbn == "1" ? true : false;
            // 全窒素（B)2確認検査種別（過去との比較）
            newRow.Cells[tnB2KensaShubetsuKako.Index].Value = row.IsTnB2KensaShubetsuKakoNull() == true ? string.Empty : row.TnB2KensaShubetsuKako;

            // 更新区分（過去との比較）全窒素（B)
            newRow.Cells[koshinKbnKakoTnB.Index].Value = "0";
            #endregion

            #region 全りんB
            // 結果入力区分（全りん（B)1）
            newRow.Cells[kekkaNyuryokuTpB1Col.Index].Value = row.IsTpB1KekkaNyuryokuNull() == true ? string.Empty : row.TpB1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuTpB1Col.Index].Value.ToString() == "1")
            {
                // 全りん（B)1
                newRow.Cells[tpB1Col.Index].Value = row.IsTpB1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanTpB), row.TpB1KekkaValue.ToString());
                // 結果コード（全りん（B)1）
                newRow.Cells[tpB1KekkaCdCol.Index].Value = row.IsTpB1KekkaCdNull() == true ? string.Empty : row.TpB1KekkaCd;
                // 確認検査種別（全りん（B)1）
                newRow.Cells[kakuninKensaTpB1Col.Index].Value = row.IsTpB1KensaShubetsuNull() == true ? string.Empty : row.TpB1KensaShubetsu;
            }
            // 採用値（全りん（B)1）
            newRow.Cells[saiyotiTpB1Col.Index].Value = row.IsTpB1SaiyoKbnNull() == true ? false : row.TpB1SaiyoKbn == "1" ? true : false;
            // 全りん（B)1確認検査種別（過去との比較）
            newRow.Cells[tpB1KensaShubetsuKako.Index].Value = row.IsTpB1KensaShubetsuKakoNull() == true ? string.Empty : row.TpB1KensaShubetsuKako;

            // 結果入力区分（全りん（B)2）
            newRow.Cells[kekkaNyuryokuTpB2Col.Index].Value = row.IsTpB2KekkaNyuryokuNull() == true ? string.Empty : row.TpB2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuTpB2Col.Index].Value.ToString() == "1")
            {
                // 全りん（B)2
                newRow.Cells[tpB2Col.Index].Value = row.IsTpB2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanTpB), row.TpB2KekkaValue.ToString());
                // 結果コード（全りん（B)2）
                newRow.Cells[tpB2KekkaCdCol.Index].Value = row.IsTpB2KekkaCdNull() == true ? string.Empty : row.TpB2KekkaCd;
                // 確認検査種別（全りん（B)2）
                newRow.Cells[kakuninKensaTpB2Col.Index].Value = row.IsTpB2KensaShubetsuNull() == true ? string.Empty : row.TpB2KensaShubetsu;
            }
            // 採用値（全りん（B)2）
            newRow.Cells[saiyotiTpB2Col.Index].Value = row.IsTpB2SaiyoKbnNull() == true ? false : row.TpB2SaiyoKbn == "1" ? true : false;
            // 全りん（B)2確認検査種別（過去との比較）
            newRow.Cells[tpB2KensaShubetsuKako.Index].Value = row.IsTpB2KensaShubetsuKakoNull() == true ? string.Empty : row.TpB2KensaShubetsuKako;

            // 更新区分（過去との比較）全りん（B)
            newRow.Cells[koshinKbnKakoTpB.Index].Value = "0";
            #endregion

            #region 色度
            // 結果入力区分（色度1）
            newRow.Cells[kekkaNyuryokuShikido1Col.Index].Value = row.IsShikido1KekkaNyuryokuNull() == true ? string.Empty : row.Shikido1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuShikido1Col.Index].Value.ToString() == "1")
            {
                // 色度1
                newRow.Cells[shikido1Col.Index].Value = row.IsShikido1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanShikido), row.Shikido1KekkaValue.ToString());
                // 結果コード（色度1）
                newRow.Cells[shikido1KekkaCdCol.Index].Value = row.IsShikido1KekkaCdNull() == true ? string.Empty : row.Shikido1KekkaCd;
                // 確認検査種別（色度1）
                newRow.Cells[kakuninKensaShikido1Col.Index].Value = row.IsShikido1KensaShubetsuNull() == true ? string.Empty : row.Shikido1KensaShubetsu;
            }
            // 採用値（色度1）
            newRow.Cells[saiyotiShikido1Col.Index].Value = row.IsShikido1SaiyoKbnNull() == true ? false : row.Shikido1SaiyoKbn == "1" ? true : false;
            // 色度1確認検査種別（過去との比較）
            newRow.Cells[shikido1KensaShubetsuKako.Index].Value = row.IsShikido1KensaShubetsuKakoNull() == true ? string.Empty : row.Shikido1KensaShubetsuKako;

            // 結果入力区分（色度2）
            newRow.Cells[kekkaNyuryokuShikido2Col.Index].Value = row.IsShikido2KekkaNyuryokuNull() == true ? string.Empty : row.Shikido2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuShikido2Col.Index].Value.ToString() == "1")
            {
                // 色度2
                newRow.Cells[shikido2Col.Index].Value = row.IsShikido2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanShikido), row.Shikido2KekkaValue.ToString());
                // 結果コード（色度2）
                newRow.Cells[shikido2KekkaCdCol.Index].Value = row.IsShikido2KekkaCdNull() == true ? string.Empty : row.Shikido2KekkaCd;
                // 確認検査種別（色度2）
                newRow.Cells[kakuninKensaShikido2Col.Index].Value = row.IsShikido2KensaShubetsuNull() == true ? string.Empty : row.Shikido2KensaShubetsu;
            }
            // 採用値（色度2）
            newRow.Cells[saiyotiShikido2Col.Index].Value = row.IsShikido2SaiyoKbnNull() == true ? false : row.Shikido2SaiyoKbn == "1" ? true : false;
            // 色度2確認検査種別（過去との比較）
            newRow.Cells[shikido2KensaShubetsuKako.Index].Value = row.IsShikido2KensaShubetsuKakoNull() == true ? string.Empty : row.Shikido2KensaShubetsuKako;

            // 更新区分（過去との比較）色度
            newRow.Cells[koshinKbnKakoShikido.Index].Value = "0";
            #endregion

            #region BODB
            // 結果入力区分（BOD（B）1）
            newRow.Cells[kekkaNyuryokuBodB1Col.Index].Value = row.IsBodB1KekkaNyuryokuNull() == true ? string.Empty : row.BodB1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuBodB1Col.Index].Value.ToString() == "1")
            {
                // BOD（B）1
                newRow.Cells[bodB1Col.Index].Value = row.IsBodB1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanBodB), row.BodB1KekkaValue.ToString());
                // 結果コード（BOD（B）1）
                newRow.Cells[bodB1KekkaCdCol.Index].Value = row.IsBodB1KekkaCdNull() == true ? string.Empty : row.BodB1KekkaCd;
                // 確認検査種別（BOD（B）1）
                newRow.Cells[kakuninKensaBodB1Col.Index].Value = row.IsBodB1KensaShubetsuNull() == true ? string.Empty : row.BodB1KensaShubetsu;
            }
            // 採用値（BOD（B）1）
            newRow.Cells[saiyotiBodB1Col.Index].Value = row.IsBodB1SaiyoKbnNull() == true ? false : row.BodB1SaiyoKbn == "1" ? true : false;
            // BOD（B）1確認検査種別（過去との比較）
            newRow.Cells[bodB1KensaShubetsuKako.Index].Value = row.IsBodB1KensaShubetsuKakoNull() == true ? string.Empty : row.BodB1KensaShubetsuKako;

            // 結果入力区分（BOD（B）2）
            newRow.Cells[kekkaNyuryokuBodB2Col.Index].Value = row.IsBodB2KekkaNyuryokuNull() == true ? string.Empty : row.BodB2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuBodB2Col.Index].Value.ToString() == "1")
            {
                // BOD（B）2
                newRow.Cells[bodB2Col.Index].Value = row.IsBodB2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanBodB), row.BodB2KekkaValue.ToString());
                // 結果コード（BOD（B）2）
                newRow.Cells[bodB2KekkaCdCol.Index].Value = row.IsBodB2KekkaCdNull() == true ? string.Empty : row.BodB2KekkaCd;
                // 確認検査種別（BOD（B）2）
                newRow.Cells[kakuninKensaBodB2Col.Index].Value = row.IsBodB2KensaShubetsuNull() == true ? string.Empty : row.BodB2KensaShubetsu;
            }
            // 採用値（BOD（B）2）
            newRow.Cells[saiyotiBodB2Col.Index].Value = row.IsBodB2SaiyoKbnNull() == true ? false : row.BodB2SaiyoKbn == "1" ? true : false;
            // BOD（B）2確認検査種別（過去との比較）
            newRow.Cells[bodB2KensaShubetsuKako.Index].Value = row.IsBodB2KensaShubetsuKakoNull() == true ? string.Empty : row.BodB2KensaShubetsuKako;

            // 更新区分（過去との比較）BOD（B）
            newRow.Cells[koshinKbnKakoBodB.Index].Value = "0";
            #endregion

            #region ヘキサン抽出物質(鉱油類)
            // 結果入力区分（ヘキサン抽出物質（鉱油類）1）
            newRow.Cells[kekkaNyuryokuHekisanKoyu1Col.Index].Value = row.IsHekisanKoyu1KekkaNyuryokuNull() == true ? string.Empty : row.HekisanKoyu1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuHekisanKoyu1Col.Index].Value.ToString() == "1")
            {
                // ヘキサン抽出物質（鉱油類）1
                newRow.Cells[hekisanKoyu1Col.Index].Value = row.IsHekisanKoyu1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanHekisanKoyu), row.HekisanKoyu1KekkaValue.ToString());
                // 結果コード（ヘキサン抽出物質（鉱油類）1）
                newRow.Cells[hekisanKoyu1KekkaCdCol.Index].Value = row.IsHekisanKoyu1KekkaCdNull() == true ? string.Empty : row.HekisanKoyu1KekkaCd;
                // 確認検査種別（ヘキサン抽出物質（鉱油類）1）
                newRow.Cells[kakuninKensaHekisanKoyu1Col.Index].Value = row.IsHekisanKoyu1KensaShubetsuNull() == true ? string.Empty : row.HekisanKoyu1KensaShubetsu;
            }
            // 採用値（ヘキサン抽出物質（鉱油類）1）
            newRow.Cells[saiyotiHekisanKoyu1Col.Index].Value = row.IsHekisanKoyu1SaiyoKbnNull() == true ? false : row.HekisanKoyu1SaiyoKbn == "1" ? true : false;
            // ヘキサン抽出物質（鉱油類）1確認検査種別（過去との比較）
            newRow.Cells[hekisanKoyu1KensaShubetsuKako.Index].Value = row.IsHekisanKoyu1KensaShubetsuKakoNull() == true ? string.Empty : row.HekisanKoyu1KensaShubetsuKako;

            // 結果入力区分（ヘキサン抽出物質（鉱油類）2）
            newRow.Cells[kekkaNyuryokuHekisanKoyu2Col.Index].Value = row.IsHekisanKoyu2KekkaNyuryokuNull() == true ? string.Empty : row.HekisanKoyu2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuHekisanKoyu2Col.Index].Value.ToString() == "1")
            {
                // ヘキサン抽出物質（鉱油類）2
                newRow.Cells[hekisanKoyu2Col.Index].Value = row.IsHekisanKoyu2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanHekisanKoyu), row.HekisanKoyu2KekkaValue.ToString());
                // 結果コード（ヘキサン抽出物質（鉱油類）2）
                newRow.Cells[hekisanKoyu2KekkaCdCol.Index].Value = row.IsHekisanKoyu2KekkaCdNull() == true ? string.Empty : row.HekisanKoyu2KekkaCd;
                // 確認検査種別（ヘキサン抽出物質（鉱油類）2）
                newRow.Cells[kakuninKensaHekisanKoyu2Col.Index].Value = row.IsHekisanKoyu2KensaShubetsuNull() == true ? string.Empty : row.HekisanKoyu2KensaShubetsu;
            }
            // 採用値（ヘキサン抽出物質（鉱油類）2）
            newRow.Cells[saiyotiHekisanKoyu2Col.Index].Value = row.IsHekisanKoyu2SaiyoKbnNull() == true ? false : row.HekisanKoyu2SaiyoKbn == "1" ? true : false;
            // ヘキサン抽出物質（鉱油類）2確認検査種別（過去との比較）
            newRow.Cells[hekisanKoyu2KensaShubetsuKako.Index].Value = row.IsHekisanKoyu2KensaShubetsuKakoNull() == true ? string.Empty : row.HekisanKoyu2KensaShubetsuKako;

            // 更新区分（過去との比較）ヘキサン抽出物質（鉱油類）
            newRow.Cells[koshinKbnKakoHekisanKoyu.Index].Value = "0";
            #endregion

            #region ヘキサン抽出物質(動植物油類)
            // 結果入力区分（ヘキサン抽出物質（動植物油類）1）
            newRow.Cells[kekkaNyuryokuHekisanDoshoku1Col.Index].Value = row.IsHekisanDoshoku1KekkaNyuryokuNull() == true ? string.Empty : row.HekisanDoshoku1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuHekisanDoshoku1Col.Index].Value.ToString() == "1")
            {
                // ヘキサン抽出物質（動植物油類）1
                newRow.Cells[hekisanDoshoku1Col.Index].Value = row.IsHekisanDoshoku1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanHekisanDoshoku), row.HekisanDoshoku1KekkaValue.ToString());
                // 結果コード（ヘキサン抽出物質（動植物油類）1）
                newRow.Cells[hekisanDoshoku1KekkaCdCol.Index].Value = row.IsHekisanDoshoku1KekkaCdNull() == true ? string.Empty : row.HekisanDoshoku1KekkaCd;
                // 確認検査種別（ヘキサン抽出物質（動植物油類）1）
                newRow.Cells[kakuninKensaHekisanDoshoku1Col.Index].Value = row.IsHekisanDoshoku1KensaShubetsuNull() == true ? string.Empty : row.HekisanDoshoku1KensaShubetsu;
            }
            // 採用値（ヘキサン抽出物質（動植物油類）1）
            newRow.Cells[saiyotiHekisanDoshoku1Col.Index].Value = row.IsHekisanDoshoku1SaiyoKbnNull() == true ? false : row.HekisanDoshoku1SaiyoKbn == "1" ? true : false;
            // ヘキサン抽出物質（動植物油類）1確認検査種別（過去との比較）
            newRow.Cells[hekisanDoshoku1KensaShubetsuKako.Index].Value = row.IsHekisanDoshoku1KensaShubetsuKakoNull() == true ? string.Empty : row.HekisanDoshoku1KensaShubetsuKako;

            // 結果入力区分（ヘキサン抽出物質（動植物油類）2）
            newRow.Cells[kekkaNyuryokuHekisanDoshoku2Col.Index].Value = row.IsHekisanDoshoku2KekkaNyuryokuNull() == true ? string.Empty : row.HekisanDoshoku2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuHekisanDoshoku2Col.Index].Value.ToString() == "1")
            {
                // ヘキサン抽出物質（動植物油類）2
                newRow.Cells[hekisanDoshoku2Col.Index].Value = row.IsHekisanDoshoku2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanHekisanDoshoku), row.HekisanDoshoku2KekkaValue.ToString());
                // 結果コード（ヘキサン抽出物質（動植物油類）2）
                newRow.Cells[hekisanDoshoku2KekkaCdCol.Index].Value = row.IsHekisanDoshoku2KekkaCdNull() == true ? string.Empty : row.HekisanDoshoku2KekkaCd;
                // 確認検査種別（ヘキサン抽出物質（動植物油類）2）
                newRow.Cells[kakuninKensaHekisanDoshoku2Col.Index].Value = row.IsHekisanDoshoku2KensaShubetsuNull() == true ? string.Empty : row.HekisanDoshoku2KensaShubetsu;
            }
            // 採用値（ヘキサン抽出物質（動植物油類）2）
            newRow.Cells[saiyotiHekisanDoshoku2Col.Index].Value = row.IsHekisanDoshoku2SaiyoKbnNull() == true ? false : row.HekisanDoshoku2SaiyoKbn == "1" ? true : false;
            // ヘキサン抽出物質（動植物油類）2確認検査種別（過去との比較）
            newRow.Cells[hekisanDoshoku2KensaShubetsuKako.Index].Value = row.IsHekisanDoshoku2KensaShubetsuKakoNull() == true ? string.Empty : row.HekisanDoshoku2KensaShubetsuKako;

            // 更新区分（過去との比較）ヘキサン抽出物質（動植物油類）
            newRow.Cells[koshinKbnKakoHekisanDoshoku.Index].Value = "0";
            #endregion

            #region ヘキサン抽出物質B
            // 結果入力区分（ヘキサン抽出物質（B）1）
            newRow.Cells[kekkaNyuryokuHekisanB1Col.Index].Value = row.IsHekisanB1KekkaNyuryokuNull() == true ? string.Empty : row.HekisanB1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuHekisanB1Col.Index].Value.ToString() == "1")
            {
                // ヘキサン抽出物質（B）1
                newRow.Cells[hekisanB1Col.Index].Value = row.IsHekisanB1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanHekisanB), row.HekisanB1KekkaValue.ToString());
                // 結果コード（ヘキサン抽出物質（B）1）
                newRow.Cells[hekisanB1KekkaCdCol.Index].Value = row.IsHekisanB1KekkaCdNull() == true ? string.Empty : row.HekisanB1KekkaCd;
                // 確認検査種別（ヘキサン抽出物質（B）1）
                newRow.Cells[kakuninKensaHekisanB1Col.Index].Value = row.IsHekisanB1KensaShubetsuNull() == true ? string.Empty : row.HekisanB1KensaShubetsu;
            }
            // 採用値（ヘキサン抽出物質（B）1）
            newRow.Cells[saiyotiHekisanB1Col.Index].Value = row.IsHekisanB1SaiyoKbnNull() == true ? false : row.HekisanB1SaiyoKbn == "1" ? true : false;
            // ヘキサン抽出物質（B）1確認検査種別（過去との比較）
            newRow.Cells[hekisanB1KensaShubetsuKako.Index].Value = row.IsHekisanB1KensaShubetsuKakoNull() == true ? string.Empty : row.HekisanB1KensaShubetsuKako;

            // 結果入力区分（ヘキサン抽出物質（B）2）
            newRow.Cells[kekkaNyuryokuHekisanB2Col.Index].Value = row.IsHekisanB2KekkaNyuryokuNull() == true ? string.Empty : row.HekisanB2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuHekisanB2Col.Index].Value.ToString() == "1")
            {
                // ヘキサン抽出物質（B）2
                newRow.Cells[hekisanB2Col.Index].Value = row.IsHekisanB2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanHekisanB), row.HekisanB2KekkaValue.ToString());
                // 結果コード（ヘキサン抽出物質（B）2）
                newRow.Cells[hekisanB2KekkaCdCol.Index].Value = row.IsHekisanB2KekkaCdNull() == true ? string.Empty : row.HekisanB2KekkaCd;
                // 確認検査種別（ヘキサン抽出物質（B）2）
                newRow.Cells[kakuninKensaHekisanB2Col.Index].Value = row.IsHekisanB2KensaShubetsuNull() == true ? string.Empty : row.HekisanB2KensaShubetsu;
            }
            // 採用値（ヘキサン抽出物質（B）2）
            newRow.Cells[saiyotiHekisanB2Col.Index].Value = row.IsHekisanB2SaiyoKbnNull() == true ? false : row.HekisanB2SaiyoKbn == "1" ? true : false;
            // ヘキサン抽出物質（B）2確認検査種別（過去との比較）
            newRow.Cells[hekisanB2KensaShubetsuKako.Index].Value = row.IsHekisanB2KensaShubetsuKakoNull() == true ? string.Empty : row.HekisanB2KensaShubetsuKako;

            // 更新区分（過去との比較）ヘキサン抽出物質（B）
            newRow.Cells[koshinKbnKakoHekisanB.Index].Value = "0";
            #endregion

            #region 鉛
            // 結果入力区分（鉛1）
            newRow.Cells[kekkaNyuryokuNamari1Col.Index].Value = row.IsNamari1KekkaNyuryokuNull() == true ? string.Empty : row.Namari1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuNamari1Col.Index].Value.ToString() == "1")
            {
                // 鉛1
                newRow.Cells[namari1Col.Index].Value = row.IsNamari1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanNamari), row.Namari1KekkaValue.ToString());
                // 結果コード（鉛1）
                newRow.Cells[namari1KekkaCdCol.Index].Value = row.IsNamari1KekkaCdNull() == true ? string.Empty : row.Namari1KekkaCd;
                // 確認検査種別（鉛1）
                newRow.Cells[kakuninKensaNamari1Col.Index].Value = row.IsNamari1KensaShubetsuNull() == true ? string.Empty : row.Namari1KensaShubetsu;
            }
            // 採用値（鉛1）
            newRow.Cells[saiyotiNamari1Col.Index].Value = row.IsNamari1SaiyoKbnNull() == true ? false : row.Namari1SaiyoKbn == "1" ? true : false;
            // 鉛1確認検査種別（過去との比較）
            newRow.Cells[namari1KensaShubetsuKako.Index].Value = row.IsNamari1KensaShubetsuKakoNull() == true ? string.Empty : row.Namari1KensaShubetsuKako;

            // 結果入力区分（鉛2）
            newRow.Cells[kekkaNyuryokuNamari2Col.Index].Value = row.IsNamari2KekkaNyuryokuNull() == true ? string.Empty : row.Namari2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuNamari2Col.Index].Value.ToString() == "1")
            {
                // 鉛2
                newRow.Cells[namari2Col.Index].Value = row.IsNamari2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanNamari), row.Namari2KekkaValue.ToString());
                // 結果コード（鉛2）
                newRow.Cells[namari2KekkaCdCol.Index].Value = row.IsNamari2KekkaCdNull() == true ? string.Empty : row.Namari2KekkaCd;
                // 確認検査種別（鉛2）
                newRow.Cells[kakuninKensaNamari2Col.Index].Value = row.IsNamari2KensaShubetsuNull() == true ? string.Empty : row.Namari2KensaShubetsu;
            }
            // 採用値（鉛2）
            newRow.Cells[saiyotiNamari2Col.Index].Value = row.IsNamari2SaiyoKbnNull() == true ? false : row.Namari2SaiyoKbn == "1" ? true : false;
            // 鉛2確認検査種別（過去との比較）
            newRow.Cells[namari2KensaShubetsuKako.Index].Value = row.IsNamari2KensaShubetsuKakoNull() == true ? string.Empty : row.Namari2KensaShubetsuKako;

            // 更新区分（過去との比較）鉛
            newRow.Cells[koshinKbnKakoNamari.Index].Value = "0";
            #endregion

            #region 亜鉛
            // 結果入力区分（亜鉛1）
            newRow.Cells[kekkaNyuryokuAen1Col.Index].Value = row.IsAen1KekkaNyuryokuNull() == true ? string.Empty : row.Aen1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuAen1Col.Index].Value.ToString() == "1")
            {
                // 亜鉛1
                newRow.Cells[aen1Col.Index].Value = row.IsAen1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanAen), row.Aen1KekkaValue.ToString());
                // 結果コード（亜鉛1）
                newRow.Cells[aen1KekkaCdCol.Index].Value = row.IsAen1KekkaCdNull() == true ? string.Empty : row.Aen1KekkaCd;
                // 確認検査種別（亜鉛1）
                newRow.Cells[kakuninKensaAen1Col.Index].Value = row.IsAen1KensaShubetsuNull() == true ? string.Empty : row.Aen1KensaShubetsu;
            }
            // 採用値（亜鉛1）
            newRow.Cells[saiyotiAen1Col.Index].Value = row.IsAen1SaiyoKbnNull() == true ? false : row.Aen1SaiyoKbn == "1" ? true : false;
            // 亜鉛1確認検査種別（過去との比較）
            newRow.Cells[aen1KensaShubetsuKako.Index].Value = row.IsAen1KensaShubetsuKakoNull() == true ? string.Empty : row.Aen1KensaShubetsuKako;

            // 結果入力区分（亜鉛2）
            newRow.Cells[kekkaNyuryokuAen2Col.Index].Value = row.IsAen2KekkaNyuryokuNull() == true ? string.Empty : row.Aen2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuAen2Col.Index].Value.ToString() == "1")
            {
                // 亜鉛2
                newRow.Cells[aen2Col.Index].Value = row.IsAen2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanAen), row.Aen2KekkaValue.ToString());
                // 結果コード（亜鉛2）
                newRow.Cells[aen2KekkaCdCol.Index].Value = row.IsAen2KekkaCdNull() == true ? string.Empty : row.Aen2KekkaCd;
                // 確認検査種別（亜鉛2）
                newRow.Cells[kakuninKensaAen2Col.Index].Value = row.IsAen2KensaShubetsuNull() == true ? string.Empty : row.Aen2KensaShubetsu;
            }
            // 採用値（亜鉛2）
            newRow.Cells[saiyotiAen2Col.Index].Value = row.IsAen2SaiyoKbnNull() == true ? false : row.Aen2SaiyoKbn == "1" ? true : false;
            // 亜鉛2確認検査種別（過去との比較）
            newRow.Cells[aen2KensaShubetsuKako.Index].Value = row.IsAen2KensaShubetsuKakoNull() == true ? string.Empty : row.Aen2KensaShubetsuKako;

            // 更新区分（過去との比較）亜鉛
            newRow.Cells[koshinKbnKakoAen.Index].Value = "0";
            #endregion

            #region ほう素
            // 結果入力区分（ほう素1）
            newRow.Cells[kekkaNyuryokuHouso1Col.Index].Value = row.IsHouso1KekkaNyuryokuNull() == true ? string.Empty : row.Houso1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuHouso1Col.Index].Value.ToString() == "1")
            {
                // ほう素1
                newRow.Cells[houso1Col.Index].Value = row.IsHouso1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanHouso), row.Houso1KekkaValue.ToString());
                // 結果コード（ほう素1）
                newRow.Cells[houso1KekkaCdCol.Index].Value = row.IsHouso1KekkaCdNull() == true ? string.Empty : row.Houso1KekkaCd;
                // 確認検査種別（ほう素1）
                newRow.Cells[kakuninKensaHouso1Col.Index].Value = row.IsHouso1KensaShubetsuNull() == true ? string.Empty : row.Houso1KensaShubetsu;
            }
            // 採用値（ほう素1）
            newRow.Cells[saiyotiHouso1Col.Index].Value = row.IsHouso1SaiyoKbnNull() == true ? false : row.Houso1SaiyoKbn == "1" ? true : false;
            // ほう素1確認検査種別（過去との比較）
            newRow.Cells[houso1KensaShubetsuKako.Index].Value = row.IsHouso1KensaShubetsuKakoNull() == true ? string.Empty : row.Houso1KensaShubetsuKako;

            // 結果入力区分（ほう素2）
            newRow.Cells[kekkaNyuryokuHouso2Col.Index].Value = row.IsHouso2KekkaNyuryokuNull() == true ? string.Empty : row.Houso2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuHouso2Col.Index].Value.ToString() == "1")
            {
                // ほう素2
                newRow.Cells[houso2Col.Index].Value = row.IsHouso2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanHouso), row.Houso2KekkaValue.ToString());
                // 結果コード（ほう素2）
                newRow.Cells[houso2KekkaCdCol.Index].Value = row.IsHouso2KekkaCdNull() == true ? string.Empty : row.Houso2KekkaCd;
                // 確認検査種別（ほう素2）
                newRow.Cells[kakuninKensaHouso2Col.Index].Value = row.IsHouso2KensaShubetsuNull() == true ? string.Empty : row.Houso2KensaShubetsu;
            }
            // 採用値（ほう素2）
            newRow.Cells[saiyotiHouso2Col.Index].Value = row.IsHouso2SaiyoKbnNull() == true ? false : row.Houso2SaiyoKbn == "1" ? true : false;
            // ほう素2確認検査種別（過去との比較）
            newRow.Cells[houso2KensaShubetsuKako.Index].Value = row.IsHouso2KensaShubetsuKakoNull() == true ? string.Empty : row.Houso2KensaShubetsuKako;

            // 更新区分（過去との比較）ほう素
            newRow.Cells[koshinKbnKakoHouso.Index].Value = "0";
            #endregion

            #region 残塩
            // 結果入力区分（残塩1）
            newRow.Cells[kekkaNyuryokuZanen1Col.Index].Value = row.IsZanen1KekkaNyuryokuNull() == true ? string.Empty : row.Zanen1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuZanen1Col.Index].Value.ToString() == "1")
            {
                // 残塩1
                newRow.Cells[zanen1Col.Index].Value = row.IsZanen1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanZanen), row.Zanen1KekkaValue.ToString());
                // 結果コード（残塩1）
                newRow.Cells[zanen1KekkaCdCol.Index].Value = row.IsZanen1KekkaCdNull() == true ? string.Empty : row.Zanen1KekkaCd;
                // 確認検査種別（残塩1）
                newRow.Cells[kakuninKensaZanen1Col.Index].Value = row.IsZanen1KensaShubetsuNull() == true ? string.Empty : row.Zanen1KensaShubetsu;
            }
            // 採用値（残塩1）
            newRow.Cells[saiyotiZanen1Col.Index].Value = row.IsZanen1SaiyoKbnNull() == true ? false : row.Zanen1SaiyoKbn == "1" ? true : false;
            // 残塩1確認検査種別（過去との比較）
            newRow.Cells[zanen1KensaShubetsuKako.Index].Value = row.IsZanen1KensaShubetsuKakoNull() == true ? string.Empty : row.Zanen1KensaShubetsuKako;

            // 結果入力区分（残塩2）
            newRow.Cells[kekkaNyuryokuZanen2Col.Index].Value = row.IsZanen2KekkaNyuryokuNull() == true ? string.Empty : row.Zanen2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuZanen2Col.Index].Value.ToString() == "1")
            {
                // 残塩2
                newRow.Cells[zanen2Col.Index].Value = row.IsZanen2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanZanen), row.Zanen2KekkaValue.ToString());
                // 結果コード（残塩2）
                newRow.Cells[zanen2KekkaCdCol.Index].Value = row.IsZanen2KekkaCdNull() == true ? string.Empty : row.Zanen2KekkaCd;
                // 確認検査種別（残塩2）
                newRow.Cells[kakuninKensaZanen2Col.Index].Value = row.IsZanen2KensaShubetsuNull() == true ? string.Empty : row.Zanen2KensaShubetsu;
            }
            // 採用値（残塩2）
            newRow.Cells[saiyotiZanen2Col.Index].Value = row.IsZanen2SaiyoKbnNull() == true ? false : row.Zanen2SaiyoKbn == "1" ? true : false;
            // 残塩2確認検査種別（過去との比較）
            newRow.Cells[zanen2KensaShubetsuKako.Index].Value = row.IsZanen2KensaShubetsuKakoNull() == true ? string.Empty : row.Zanen2KensaShubetsuKako;

            // 更新区分（過去との比較）残塩
            newRow.Cells[koshinKbnKakoZanen.Index].Value = "0";
            #endregion

            #region 外観
            // 結果入力区分（外観1）
            newRow.Cells[kekkaNyuryokuGaikan1Col.Index].Value = row.IsGaikan1KekkaNyuryokuNull() == true ? string.Empty : row.Gaikan1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuGaikan1Col.Index].Value.ToString() == "1")
            {
                // 外観1
                newRow.Cells[gaikan1Col.Index].Value = row.IsGaikan1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanGaikan), row.Gaikan1KekkaValue.ToString());
                // 結果コード（外観1）
                newRow.Cells[gaikan1KekkaCdCol.Index].Value = row.IsGaikan1KekkaCdNull() == true ? string.Empty : row.Gaikan1KekkaCd;
                // 確認検査種別（外観1）
                newRow.Cells[kakuninKensaGaikan1Col.Index].Value = row.IsGaikan1KensaShubetsuNull() == true ? string.Empty : row.Gaikan1KensaShubetsu;
            }
            // 採用値（外観1）
            newRow.Cells[saiyotiGaikan1Col.Index].Value = row.IsGaikan1SaiyoKbnNull() == true ? false : row.Gaikan1SaiyoKbn == "1" ? true : false;
            // 外観1確認検査種別（過去との比較）
            newRow.Cells[gaikan1KensaShubetsuKako.Index].Value = row.IsGaikan1KensaShubetsuKakoNull() == true ? string.Empty : row.Gaikan1KensaShubetsuKako;

            // 結果入力区分（外観2）
            newRow.Cells[kekkaNyuryokuGaikan2Col.Index].Value = row.IsGaikan2KekkaNyuryokuNull() == true ? string.Empty : row.Gaikan2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuGaikan2Col.Index].Value.ToString() == "1")
            {
                // 外観2
                newRow.Cells[gaikan2Col.Index].Value = row.IsGaikan2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanGaikan), row.Gaikan2KekkaValue.ToString());
                // 結果コード（外観2）
                newRow.Cells[gaikan2KekkaCdCol.Index].Value = row.IsGaikan2KekkaCdNull() == true ? string.Empty : row.Gaikan2KekkaCd;
                // 確認検査種別（外観2）
                newRow.Cells[kakuninKensaGaikan2Col.Index].Value = row.IsGaikan2KensaShubetsuNull() == true ? string.Empty : row.Gaikan2KensaShubetsu;
            }
            // 採用値（外観2）
            newRow.Cells[saiyotiGaikan2Col.Index].Value = row.IsGaikan2SaiyoKbnNull() == true ? false : row.Gaikan2SaiyoKbn == "1" ? true : false;
            // 外観2確認検査種別（過去との比較）
            newRow.Cells[gaikan2KensaShubetsuKako.Index].Value = row.IsGaikan2KensaShubetsuKakoNull() == true ? string.Empty : row.Gaikan2KensaShubetsuKako;

            // 更新区分（過去との比較）外観
            newRow.Cells[koshinKbnKakoGaikan.Index].Value = "0";
            #endregion

            #region 臭気
            // 結果入力区分（臭気1）
            newRow.Cells[kekkaNyuryokuShuki1Col.Index].Value = row.IsShuki1KekkaNyuryokuNull() == true ? string.Empty : row.Shuki1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuShuki1Col.Index].Value.ToString() == "1")
            {
                // 臭気1
                newRow.Cells[shuki1Col.Index].Value = row.IsShuki1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanShuki), row.Shuki1KekkaValue.ToString());
                // 結果コード（臭気1）
                newRow.Cells[shuki1KekkaCdCol.Index].Value = row.IsShuki1KekkaCdNull() == true ? string.Empty : row.Shuki1KekkaCd;
                // 確認検査種別（臭気1）
                newRow.Cells[kakuninKensaShuki1Col.Index].Value = row.IsShuki1KensaShubetsuNull() == true ? string.Empty : row.Shuki1KensaShubetsu;
            }
            // 採用値（臭気1）
            newRow.Cells[saiyotiShuki1Col.Index].Value = row.IsShuki1SaiyoKbnNull() == true ? false : row.Shuki1SaiyoKbn == "1" ? true : false;
            // 臭気1確認検査種別（過去との比較）
            newRow.Cells[shuki1KensaShubetsuKako.Index].Value = row.IsShuki1KensaShubetsuKakoNull() == true ? string.Empty : row.Shuki1KensaShubetsuKako;

            // 結果入力区分（臭気2）
            newRow.Cells[kekkaNyuryokuShuki2Col.Index].Value = row.IsShuki2KekkaNyuryokuNull() == true ? string.Empty : row.Shuki2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuShuki2Col.Index].Value.ToString() == "1")
            {
                // 臭気2
                newRow.Cells[shuki2Col.Index].Value = row.IsShuki2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanShuki), row.Shuki2KekkaValue.ToString());
                // 結果コード（臭気2）
                newRow.Cells[shuki2KekkaCdCol.Index].Value = row.IsShuki2KekkaCdNull() == true ? string.Empty : row.Shuki2KekkaCd;
                // 確認検査種別（臭気2）
                newRow.Cells[kakuninKensaShuki2Col.Index].Value = row.IsShuki2KensaShubetsuNull() == true ? string.Empty : row.Shuki2KensaShubetsu;
            }
            // 採用値（臭気2）
            newRow.Cells[saiyotiShuki2Col.Index].Value = row.IsShuki2SaiyoKbnNull() == true ? false : row.Shuki2SaiyoKbn == "1" ? true : false;
            // 臭気2確認検査種別（過去との比較）
            newRow.Cells[shuki2KensaShubetsuKako.Index].Value = row.IsShuki2KensaShubetsuKakoNull() == true ? string.Empty : row.Shuki2KensaShubetsuKako;

            // 更新区分（過去との比較）臭気
            newRow.Cells[koshinKbnKakoShuki.Index].Value = "0";
            #endregion

            #region 透視度
            // 結果入力区分（透視度1）
            newRow.Cells[kekkaNyuryokuTr1Col.Index].Value = row.IsTr1KekkaNyuryokuNull() == true ? string.Empty : row.Tr1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuTr1Col.Index].Value.ToString() == "1")
            {
                // 透視度1
                newRow.Cells[tr1Col.Index].Value = row.IsTr1KekkaValueNull() == true ? string.Empty
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanTr), row.Tr1KekkaValue.ToString());
                // 結果コード（透視度1）
                newRow.Cells[tr1KekkaCdCol.Index].Value = row.IsTr1KekkaCdNull() == true ? string.Empty : row.Tr1KekkaCd;
                // 確認検査種別（透視度1）
                newRow.Cells[kakuninKensaTr1Col.Index].Value = row.IsTr1KensaShubetsuNull() == true ? string.Empty : row.Tr1KensaShubetsu;
            }
            // 採用値（透視度1）
            newRow.Cells[saiyotiTr1Col.Index].Value = row.IsTr1SaiyoKbnNull() == true ? false : row.Tr1SaiyoKbn == "1" ? true : false;
            // 透視度1確認検査種別（過去との比較）
            newRow.Cells[tr1KensaShubetsuKako.Index].Value = row.IsTr1KensaShubetsuKakoNull() == true ? string.Empty : row.Tr1KensaShubetsuKako;

            // 結果入力区分（透視度2）
            newRow.Cells[kekkaNyuryokuTr2Col.Index].Value = row.IsTr2KekkaNyuryokuNull() == true ? string.Empty : row.Tr2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuTr2Col.Index].Value.ToString() == "1")
            {
                // 透視度2
                newRow.Cells[tr2Col.Index].Value = row.IsTr2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanTr), row.Tr2KekkaValue.ToString());
                // 結果コード（透視度2）
                newRow.Cells[tr2KekkaCdCol.Index].Value = row.IsTr2KekkaCdNull() == true ? string.Empty : row.Tr2KekkaCd;
                // 確認検査種別（透視度2）
                newRow.Cells[kakuninKensaTr2Col.Index].Value = row.IsTr2KensaShubetsuNull() == true ? string.Empty : row.Tr2KensaShubetsu;
            }
            // 採用値（透視度2）
            newRow.Cells[saiyotiTr2Col.Index].Value = row.IsTr2SaiyoKbnNull() == true ? false : row.Tr2SaiyoKbn == "1" ? true : false;
            // 透視度2確認検査種別（過去との比較）
            newRow.Cells[tr2KensaShubetsuKako.Index].Value = row.IsTr2KensaShubetsuKakoNull() == true ? string.Empty : row.Tr2KensaShubetsuKako;

            // 更新区分（過去との比較）透視度
            newRow.Cells[koshinKbnKakoTr.Index].Value = "0";
            #endregion

            #region 亜硝酸性窒素(定性)
            // 結果入力区分（亜硝酸性窒素（定性）1）
            newRow.Cells[kekkaNyuryokuNo2nTeisei1Col.Index].Value = row.IsNo2nTeisei1KekkaNyuryokuNull() == true ? string.Empty : row.No2nTeisei1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuNo2nTeisei1Col.Index].Value.ToString() == "1")
            {
                // 亜硝酸性窒素（定性）1
                newRow.Cells[no2nTeisei1Col.Index].Value = row.IsNo2nTeisei1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanNo2nTeisei), row.No2nTeisei1KekkaValue.ToString());
                // 結果コード（亜硝酸性窒素（定性）1）
                newRow.Cells[no2nTeisei1KekkaCdCol.Index].Value = row.IsNo2nTeisei1KekkaCdNull() == true ? string.Empty : row.No2nTeisei1KekkaCd;
                // 確認検査種別（亜硝酸性窒素（定性）1）
                newRow.Cells[kakuninKensaNo2nTeisei1Col.Index].Value = row.IsNo2nTeisei1KensaShubetsuNull() == true ? string.Empty : row.No2nTeisei1KensaShubetsu;
            }
            // 採用値（亜硝酸性窒素（定性）1）
            newRow.Cells[saiyotiNo2nTeisei1Col.Index].Value = row.IsNo2nTeisei1SaiyoKbnNull() == true ? false : row.No2nTeisei1SaiyoKbn == "1" ? true : false;
            // 亜硝酸性窒素（定性）1確認検査種別（過去との比較）
            newRow.Cells[no2nTeisei1KensaShubetsuKako.Index].Value = row.IsNo2nTeisei1KensaShubetsuKakoNull() == true ? string.Empty : row.No2nTeisei1KensaShubetsuKako;

            // 結果入力区分（亜硝酸性窒素（定性）2）
            newRow.Cells[kekkaNyuryokuNo2nTeisei2Col.Index].Value = row.IsNo2nTeisei2KekkaNyuryokuNull() == true ? string.Empty : row.No2nTeisei2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuNo2nTeisei2Col.Index].Value.ToString() == "1")
            {
                // 亜硝酸性窒素（定性）2
                newRow.Cells[no2nTeisei2Col.Index].Value = row.IsNo2nTeisei2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanNo2nTeisei), row.No2nTeisei2KekkaValue.ToString());
                // 結果コード（亜硝酸性窒素（定性）2）
                newRow.Cells[no2nTeisei2KekkaCdCol.Index].Value = row.IsNo2nTeisei2KekkaCdNull() == true ? string.Empty : row.No2nTeisei2KekkaCd;
                // 確認検査種別（亜硝酸性窒素（定性）2）
                newRow.Cells[kakuninKensaNo2nTeisei2Col.Index].Value = row.IsNo2nTeisei2KensaShubetsuNull() == true ? string.Empty : row.No2nTeisei2KensaShubetsu;
            }
            // 採用値（亜硝酸性窒素（定性）2）
            newRow.Cells[saiyotiNo2nTeisei2Col.Index].Value = row.IsNo2nTeisei2SaiyoKbnNull() == true ? false : row.No2nTeisei2SaiyoKbn == "1" ? true : false;
            // 亜硝酸性窒素（定性）2確認検査種別（過去との比較）
            newRow.Cells[no2nTeisei2KensaShubetsuKako.Index].Value = row.IsNo2nTeisei2KensaShubetsuKakoNull() == true ? string.Empty : row.No2nTeisei2KensaShubetsuKako;

            // 更新区分（過去との比較）亜硝酸性窒素（定性）
            newRow.Cells[koshinKbnKakoNo2nTeisei.Index].Value = "0";
            #endregion

            #region 硝酸性窒素(定性)
            // 結果入力区分（硝酸性窒素（定性）1）
            newRow.Cells[kekkaNyuryokuNo3nTeisei1Col.Index].Value = row.IsNo3nTeisei1KekkaNyuryokuNull() == true ? string.Empty : row.No3nTeisei1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuNo3nTeisei1Col.Index].Value.ToString() == "1")
            {
                // 硝酸性窒素（定性）1
                newRow.Cells[no3nTeisei1Col.Index].Value = row.IsNo3nTeisei1KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanNo3nTeisei), row.No3nTeisei1KekkaValue.ToString());
                // 結果コード（硝酸性窒素（定性）1）
                newRow.Cells[no3nTeisei1KekkaCdCol.Index].Value = row.IsNo3nTeisei1KekkaCdNull() == true ? string.Empty : row.No3nTeisei1KekkaCd;
                // 確認検査種別（硝酸性窒素（定性）1）
                newRow.Cells[kakuninKensaNo3nTeisei1Col.Index].Value = row.IsNo3nTeisei1KensaShubetsuNull() == true ? string.Empty : row.No3nTeisei1KensaShubetsu;
            }
            // 採用値（硝酸性窒素（定性）1）
            newRow.Cells[saiyotiNo3nTeisei1Col.Index].Value = row.IsNo3nTeisei1SaiyoKbnNull() == true ? false : row.No3nTeisei1SaiyoKbn == "1" ? true : false;
            // 硝酸性窒素（定性）1確認検査種別（過去との比較）
            newRow.Cells[no3nTeisei1KensaShubetsuKako.Index].Value = row.IsNo3nTeisei1KensaShubetsuKakoNull() == true ? string.Empty : row.No3nTeisei1KensaShubetsuKako;

            // 結果入力区分（硝酸性窒素（定性）2）
            newRow.Cells[kekkaNyuryokuNo3nTeisei2Col.Index].Value = row.IsNo3nTeisei2KekkaNyuryokuNull() == true ? string.Empty : row.No3nTeisei2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuNo3nTeisei2Col.Index].Value.ToString() == "1")
            {
                // 硝酸性窒素（定性）2
                newRow.Cells[no3nTeisei2Col.Index].Value = row.IsNo3nTeisei2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanNo3nTeisei), row.No3nTeisei2KekkaValue.ToString());
                // 結果コード（硝酸性窒素（定性）2）
                newRow.Cells[no3nTeisei2KekkaCdCol.Index].Value = row.IsNo3nTeisei2KekkaCdNull() == true ? string.Empty : row.No3nTeisei2KekkaCd;
                // 確認検査種別（硝酸性窒素（定性）2）
                newRow.Cells[kakuninKensaNo3nTeisei2Col.Index].Value = row.IsNo3nTeisei2KensaShubetsuNull() == true ? string.Empty : row.No3nTeisei2KensaShubetsu;
            }
            // 採用値（硝酸性窒素（定性）2）
            newRow.Cells[saiyotiNo3nTeisei2Col.Index].Value = row.IsNo3nTeisei2SaiyoKbnNull() == true ? false : row.No3nTeisei2SaiyoKbn == "1" ? true : false;
            // 硝酸性窒素（定性）2確認検査種別（過去との比較）
            newRow.Cells[no3nTeisei2KensaShubetsuKako.Index].Value = row.IsNo3nTeisei2KensaShubetsuKakoNull() == true ? string.Empty : row.No3nTeisei2KensaShubetsuKako;

            // 更新区分（過去との比較）硝酸性窒素（定性）
            newRow.Cells[koshinKbnKakoNo3nTeisei.Index].Value = "0";
            #endregion

            #region 大腸菌群数
            // 結果入力区分（大腸菌群数1）
            newRow.Cells[kekkaNyuryokuDaichokin1Col.Index].Value = row.IsDaichokin1KekkaNyuryokuNull() == true ? string.Empty : row.Daichokin1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuDaichokin1Col.Index].Value.ToString() == "1")
            {
                // 大腸菌群数1
                newRow.Cells[daichokin1Col.Index].Value = row.IsDaichokin1KekkaValueNull() == true ? string.Empty
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanDaichokin),row.Daichokin1KekkaValue.ToString());
                
                // 結果コード（大腸菌群数1）
                newRow.Cells[daichokin1KekkaCdCol.Index].Value = row.IsDaichokin1KekkaCdNull() == true ? string.Empty : row.Daichokin1KekkaCd;
                // 確認検査種別（大腸菌群数1）
                newRow.Cells[kakuninKensaDaichokin1Col.Index].Value = row.IsDaichokin1KensaShubetsuNull() == true ? string.Empty : row.Daichokin1KensaShubetsu;
            }
            // 採用値（大腸菌群数1）
            newRow.Cells[saiyotiDaichokin1Col.Index].Value = row.IsDaichokin1SaiyoKbnNull() == true ? false : row.Daichokin1SaiyoKbn == "1" ? true : false;
            // 大腸菌群数1確認検査種別（過去との比較）
            newRow.Cells[daichokin1KensaShubetsuKako.Index].Value = row.IsDaichokin1KensaShubetsuKakoNull() == true ? string.Empty : row.Daichokin1KensaShubetsuKako;

            // 結果入力区分（大腸菌群数2）
            newRow.Cells[kekkaNyuryokuDaichokin2Col.Index].Value = row.IsDaichokin2KekkaNyuryokuNull() == true ? string.Empty : row.Daichokin2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuDaichokin2Col.Index].Value.ToString() == "1")
            {
                // 大腸菌群数2
                newRow.Cells[daichokin2Col.Index].Value = row.IsDaichokin2KekkaValueNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanDaichokin), row.Daichokin2KekkaValue.ToString());
                // 結果コード（大腸菌群数2）
                newRow.Cells[daichokin2KekkaCdCol.Index].Value = row.IsDaichokin2KekkaCdNull() == true ? string.Empty : row.Daichokin2KekkaCd;
                // 確認検査種別（大腸菌群数2）
                newRow.Cells[kakuninKensaDaichokin2Col.Index].Value = row.IsDaichokin2KensaShubetsuNull() == true ? string.Empty : row.Daichokin2KensaShubetsu;
            }
            // 採用値（大腸菌群数2）
            newRow.Cells[saiyotiDaichokin2Col.Index].Value = row.IsDaichokin2SaiyoKbnNull() == true ? false : row.Daichokin2SaiyoKbn == "1" ? true : false;
            // 大腸菌群数2確認検査種別（過去との比較）
            newRow.Cells[daichokin2KensaShubetsuKako.Index].Value = row.IsDaichokin2KensaShubetsuKakoNull() == true ? string.Empty : row.Daichokin2KensaShubetsuKako;

            // 更新区分（過去との比較）大腸菌群数
            newRow.Cells[koshinKbnKakoDaichokin.Index].Value = "0";
            #endregion

            // 結果確定日
            newRow.Cells[kekkaKakuteiDtCol.Index].Value = row.IsKensaKekkaKakuteiDtNull() == true ? string.Empty : row.KensaKekkaKakuteiDt;
            // 更新区分(検印)
            newRow.Cells[koshinKbnKenin.Index].Value = "0";
            // 更新区分（pH）
            newRow.Cells[koshinKbnPh.Index].Value = "0";
            // 更新区分（SS）
            newRow.Cells[koshinKbnSs.Index].Value = "0";
            // 更新区分（BOD（A））
            newRow.Cells[koshinKbnBodA.Index].Value = "0";
            // 更新区分（アンモニア性窒素）
            newRow.Cells[koshinKbnNh4n.Index].Value = "0";
            // 更新区分（塩化物イオン）
            newRow.Cells[koshinKbnCl.Index].Value = "0";
            // 更新区分（COD）
            newRow.Cells[koshinKbnCod.Index].Value = "0";
            // 更新区分（ヘキサン抽出物質（A））
            newRow.Cells[koshinKbnHekisanA.Index].Value = "0";
            // 更新区分（MLSS）
            newRow.Cells[koshinKbnMlss.Index].Value = "0";
            // 更新区分（全窒素（A)）
            newRow.Cells[koshinKbnTnA.Index].Value = "0";
            // 更新区分（陰イオン界面活性剤（A））
            newRow.Cells[koshinKbnAbsA.Index].Value = "0";
            // 更新区分（全りん（A)）
            newRow.Cells[koshinKbnTpA.Index].Value = "0";
            // 更新区分（りん酸イオン）
            newRow.Cells[koshinKbnRinsan.Index].Value = "0";
            // 更新区分（亜硝酸性窒素（定量））
            newRow.Cells[koshinKbnNo2nTeiryo.Index].Value = "0";
            // 更新区分（硝酸性窒素（定量））
            newRow.Cells[koshinKbnNo3nTeiryo.Index].Value = "0";
            // 更新区分（陰イオン界面活性剤（B)）
            newRow.Cells[koshinKbnAbsB.Index].Value = "0";
            // 更新区分（全窒素（B)）
            newRow.Cells[koshinKbnTnB.Index].Value = "0";
            // 更新区分（全りん（B)）
            newRow.Cells[koshinKbnTpB.Index].Value = "0";
            // 更新区分（色度）
            newRow.Cells[koshinKbnShikido.Index].Value = "0";
            // 更新区分（BOD（B））
            newRow.Cells[koshinKbnBodB.Index].Value = "0";
            // 更新区分（ヘキサン抽出物質（鉱油類））
            newRow.Cells[koshinKbnHekisanKoyu.Index].Value = "0";
            // 更新区分（ヘキサン抽出物質（動植物油類））
            newRow.Cells[koshinKbnHekisanDoshoku.Index].Value = "0";
            // 更新区分（ヘキサン抽出物質（B））
            newRow.Cells[koshinKbnHekisanB.Index].Value = "0";
            // 更新区分（鉛）
            newRow.Cells[koshinKbnNamari.Index].Value = "0";
            // 更新区分（亜鉛）
            newRow.Cells[koshinKbnAen.Index].Value = "0";
            // 更新区分（ほう素）
            newRow.Cells[koshinKbnHouso.Index].Value = "0";
            // 更新区分（残塩）
            newRow.Cells[koshinKbnZanen.Index].Value = "0";
            // 更新区分（外観）
            newRow.Cells[koshinKbnGaikan.Index].Value = "0";
            // 更新区分（臭気）
            newRow.Cells[koshinKbnShuki.Index].Value = "0";
            // 更新区分（透視度）
            newRow.Cells[koshinKbnTr.Index].Value = "0";
            // 更新区分（亜硝酸性窒素（定性））
            newRow.Cells[koshinKbnNo2nTeisei.Index].Value = "0";
            // 更新区分（硝酸性窒素（定性））
            newRow.Cells[koshinKbnNo3nTeisei.Index].Value = "0";
            // 更新区分（大腸菌群数）
            newRow.Cells[koshinKbnDaichokin.Index].Value = "0";
            // 更新区分（SS/透視度）
            newRow.Cells[koshinKbnSsTr.Index].Value = "0";
            // 更新区分（BOD/透視度）
            newRow.Cells[koshinKbnBodTr.Index].Value = "0";
            // 更新区分（塩化物イオン確認検査）
            newRow.Cells[koshinKbnEnkaIon.Index].Value = "0";
            // 更新区分（アンモニア確認検査）
            newRow.Cells[koshinKbnAnmonia.Index].Value = "0";
            // 更新区分（アンモニアと全窒素比較）
            newRow.Cells[koshinKbnAnmoniaTn.Index].Value = "0";
            // 更新区分（COD基準値オーバー）
            newRow.Cells[koshinKbnCodOver.Index].Value = "0";
            // SS1確認検査種別（SS/透視度）
            newRow.Cells[ss1KensaShubetsuSsTr.Index].Value = row.IsSs1KensaShubetsuSsTrNull() == true ? string.Empty : row.Ss1KensaShubetsuSsTr;
            // SS2確認検査種別（SS/透視度）
            newRow.Cells[ss2KensaShubetsuSsTr.Index].Value = row.IsSs2KensaShubetsuSsTrNull() == true ? string.Empty : row.Ss2KensaShubetsuSsTr;
            // 透視度1確認検査種別（SS/透視度）
            newRow.Cells[tr1KensaShubetsuSsTr.Index].Value = row.IsTr1KensaShubetsuSsTrNull() == true ? string.Empty : row.Tr1KensaShubetsuSsTr;
            // 透視度2確認検査種別（SS/透視度）
            newRow.Cells[tr2KensaShubetsuSsTr.Index].Value = row.IsTr2KensaShubetsuSsTrNull() == true ? string.Empty : row.Tr2KensaShubetsuSsTr;
            // BOD（A）1確認検査種別（BOD/透視度）
            newRow.Cells[bodA1KensaShubetsuBodTr.Index].Value = row.IsBodA1KensaShubetsuBodTrNull() == true ? string.Empty : row.BodA1KensaShubetsuBodTr;
            // BOD（A）2確認検査種別（BOD/透視度）
            newRow.Cells[bodA2KensaShubetsuBodTr.Index].Value = row.IsBodA2KensaShubetsuBodTrNull() == true ? string.Empty : row.BodA2KensaShubetsuBodTr;
            // BOD（B）1確認検査種別（BOD/透視度）
            newRow.Cells[bodB1KensaShubetsuBodTr.Index].Value = row.IsBodB1KensaShubetsuBodTrNull() == true ? string.Empty : row.BodB1KensaShubetsuBodTr;
            // BOD（B）2確認検査種別（BOD/透視度）
            newRow.Cells[bodB2KensaShubetsuBodTr.Index].Value = row.IsBodB2KensaShubetsuBodTrNull() == true ? string.Empty : row.BodB2KensaShubetsuBodTr;
            // 透視度1確認検査種別（BOD/透視度）
            newRow.Cells[tr1KensaShubetsuBodTr.Index].Value = row.IsTr1KensaShubetsuBodTrNull() == true ? string.Empty : row.Tr1KensaShubetsuBodTr;
            // 透視度2確認検査種別（BOD/透視度）
            newRow.Cells[tr2KensaShubetsuBodTr.Index].Value = row.IsTr2KensaShubetsuBodTrNull() == true ? string.Empty : row.Tr2KensaShubetsuBodTr;
            // 塩化物イオン1確認検査種別（塩化物イオン確認検査）
            newRow.Cells[cl1KensaShubetsuEnkaIon.Index].Value = row.IsCl1KensaShubetsuEnkaIonNull() == true ? string.Empty : row.Cl1KensaShubetsuEnkaIon;
            // 塩化物イオン2確認検査種別（塩化物イオン確認検査）
            newRow.Cells[cl2KensaShubetsuEnkaIon.Index].Value = row.IsCl2KensaShubetsuEnkaIonNull() == true ? string.Empty : row.Cl2KensaShubetsuEnkaIon;
            // アンモニア性窒素1確認検査種別（アンモニア確認検査）
            newRow.Cells[nh4n1KensaShubetsuAnmonia.Index].Value = row.IsNh4n1KensaShubetsuAnmoniaNull() == true ? string.Empty : row.Nh4n1KensaShubetsuAnmonia;
            // アンモニア性窒素2確認検査種別（アンモニア確認検査）
            newRow.Cells[nh4n2KensaShubetsuAnmonia.Index].Value = row.IsNh4n2KensaShubetsuAnmoniaNull() == true ? string.Empty : row.Nh4n2KensaShubetsuAnmonia;
            // アンモニア性窒素1確認検査種別（アンモニアと全窒素比較）
            newRow.Cells[nh4n1KensaShubetsuAnmoniaTn.Index].Value = row.IsNh4n1KensaShubetsuAnmoniaTnNull() == true ? string.Empty : row.Nh4n1KensaShubetsuAnmoniaTn;
            // アンモニア性窒素2確認検査種別（アンモニアと全窒素比較）
            newRow.Cells[nh4n2KensaShubetsuAnmoniaTn.Index].Value = row.IsNh4n2KensaShubetsuAnmoniaTnNull() == true ? string.Empty : row.Nh4n2KensaShubetsuAnmoniaTn;
            // 全窒素（A）1確認検査種別（アンモニアと全窒素比較）
            newRow.Cells[tnA1KensaShubetsuAnmoniaTn.Index].Value = row.IsTnA1KensaShubetsuAnmoniaTnNull() == true ? string.Empty : row.TnA1KensaShubetsuAnmoniaTn;
            // 全窒素（A）2確認検査種別（アンモニアと全窒素比較）
            newRow.Cells[tnA2KensaShubetsuAnmoniaTn.Index].Value = row.IsTnA2KensaShubetsuAnmoniaTnNull() == true ? string.Empty : row.TnA2KensaShubetsuAnmoniaTn;
            // 全窒素（B）1確認検査種別（アンモニアと全窒素比較）
            newRow.Cells[tnB1KensaShubetsuAnmoniaTn.Index].Value = row.IsTnB1KensaShubetsuAnmoniaTnNull() == true ? string.Empty : row.TnB1KensaShubetsuAnmoniaTn;
            // 全窒素（B）2確認検査種別（アンモニアと全窒素比較）
            newRow.Cells[tnB2KensaShubetsuAnmoniaTn.Index].Value = row.IsTnB2KensaShubetsuAnmoniaTnNull() == true ? string.Empty : row.TnB2KensaShubetsuAnmoniaTn;
            // COD1確認検査種別（COD基準値オーバー）
            newRow.Cells[cod1KensaShubetsuCodOver.Index].Value = row.IsCod1KensaShubetsuCodOverNull() == true ? string.Empty : row.Cod1KensaShubetsuCodOver;
            // COD2確認検査種別（COD基準値オーバー）
            newRow.Cells[cod2KensaShubetsuCodOver.Index].Value = row.IsCod2KensaShubetsuCodOverNull() == true ? string.Empty : row.Cod2KensaShubetsuCodOver;
            // 検査依頼受付日
            newRow.Cells[uketsukeDt.Index].Value = row.IsUketsukeDtNull() == true ? string.Empty : row.UketsukeDt;

            // 一覧に追加
            listDataGridView.Rows.Add(newRow);
        }
        #endregion

        #region 取得した更新日を設定
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetUpdateDt
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/08　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetUpdateDt(KensaDaicho9joHdrTblDataSet.KeiryoShomeiDaichoUpdateDtDataTable table)
        {
            foreach(KensaDaicho9joHdrTblDataSet.KeiryoShomeiDaichoUpdateDtRow row in table.Rows)
            {
                // 一覧の該当列をサーチ
                foreach (DataGridViewRow dgvr in listDataGridView.Rows)
                {
                    if((dgvr.Cells[iraiNendoCol.Index].Value.ToString() == row.IraiNendo)
                        && (dgvr.Cells[shishoCdCol.Index].Value.ToString() == row.ShishoCd)
                        && (dgvr.Cells[iraiNoCol.Index].Value.ToString() == row.SuishitsuKensaIraiNo))
                    {
                        #region 各テーブルの更新日を設定
                        dgvr.Cells[hdrUpdateDtCol.Index].Value = row.HdrUpdateDt.ToString();

                        dgvr.Cells[iraiUpdateDtCol.Index].Value = row.IraiUpdateDt.ToString();

                        dgvr.Cells[phKekkaUpdateDtCol.Index].Value = row.IsPhKekkaUpdateDtNull() == true ? string.Empty : row.PhKekkaUpdateDt.ToString();
                        dgvr.Cells[ssKekkaUpdateDtCol.Index].Value = row.IsSsKekkaUpdateDtNull() == true ? string.Empty : row.SsKekkaUpdateDt.ToString();
                        dgvr.Cells[bodAKekkaUpdateDtCol.Index].Value = row.IsBodAKekkaUpdateDtNull() == true ? string.Empty : row.BodAKekkaUpdateDt.ToString();
                        dgvr.Cells[nh4nKekkaUpdateDtCol.Index].Value = row.IsNh4nKekkaUpdateDtNull() == true ? string.Empty : row.Nh4nKekkaUpdateDt.ToString();
                        dgvr.Cells[clKekkaUpdateDtCol.Index].Value = row.IsClKekkaUpdateDtNull() == true ? string.Empty : row.ClKekkaUpdateDt.ToString();
                        dgvr.Cells[codKekkaUpdateDtCol.Index].Value = row.IsCodKekkaUpdateDtNull() == true ? string.Empty : row.CodKekkaUpdateDt.ToString();
                        dgvr.Cells[hekisanAKekkaUpdateDtCol.Index].Value = row.IsHekisanAKekkaUpdateDtNull() == true ? string.Empty : row.HekisanAKekkaUpdateDt.ToString();
                        dgvr.Cells[mlssKekkaUpdateDtCol.Index].Value = row.IsMlssKekkaUpdateDtNull() == true ? string.Empty : row.MlssKekkaUpdateDt.ToString();
                        dgvr.Cells[tnAKekkaUpdateDtCol.Index].Value = row.IsTnAKekkaUpdateDtNull() == true ? string.Empty : row.TnAKekkaUpdateDt.ToString();
                        dgvr.Cells[absAKekkaUpdateDtCol.Index].Value = row.IsAbsAKekkaUpdateDtNull() == true ? string.Empty : row.AbsAKekkaUpdateDt.ToString();
                        dgvr.Cells[tpAKekkaUpdateDtCol.Index].Value = row.IsTpAKekkaUpdateDtNull() == true ? string.Empty : row.TpAKekkaUpdateDt.ToString();
                        dgvr.Cells[rinsanKekkaUpdateDtCol.Index].Value = row.IsRinsanKekkaUpdateDtNull() == true ? string.Empty : row.RinsanKekkaUpdateDt.ToString();
                        dgvr.Cells[no2nTeiryoKekkaUpdateDtCol.Index].Value = row.IsNo2nTeiryoKekkaUpdateDtNull() == true ? string.Empty : row.No2nTeiryoKekkaUpdateDt.ToString();
                        dgvr.Cells[no3nTeiryoKekkaUpdateDtCol.Index].Value = row.IsNo3nTeiryoKekkaUpdateDtNull() == true ? string.Empty : row.No3nTeiryoKekkaUpdateDt.ToString();
                        dgvr.Cells[absBKekkaUpdateDtCol.Index].Value = row.IsAbsBKekkaUpdateDtNull() == true ? string.Empty : row.AbsBKekkaUpdateDt.ToString();
                        dgvr.Cells[tnBKekkaUpdateDtCol.Index].Value = row.IsTnBKekkaUpdateDtNull() == true ? string.Empty : row.TnBKekkaUpdateDt.ToString();
                        dgvr.Cells[tpBKekkaUpdateDtCol.Index].Value = row.IsTpBKekkaUpdateDtNull() == true ? string.Empty : row.TpBKekkaUpdateDt.ToString();
                        dgvr.Cells[shikidoKekkaUpdateDtCol.Index].Value = row.IsShikidoKekkaUpdateDtNull() == true ? string.Empty : row.ShikidoKekkaUpdateDt.ToString();
                        dgvr.Cells[bodBKekkaUpdateDtCol.Index].Value = row.IsBodBKekkaUpdateDtNull() == true ? string.Empty : row.BodBKekkaUpdateDt.ToString();
                        dgvr.Cells[hekisanKoyuKekkaUpdateDtCol.Index].Value = row.IsHekisanKoyuKekkaUpdateDtNull() == true ? string.Empty : row.HekisanKoyuKekkaUpdateDt.ToString();
                        dgvr.Cells[hekisanDoshokuKekkaUpdateDtCol.Index].Value = row.IsHekisanDoshokuKekkaUpdateDtNull() == true ? string.Empty : row.HekisanDoshokuKekkaUpdateDt.ToString();
                        dgvr.Cells[hekisanBKekkaUpdateDtCol.Index].Value = row.IsHekisanBKekkaUpdateDtNull() == true ? string.Empty : row.HekisanBKekkaUpdateDt.ToString();
                        dgvr.Cells[namariKekkaUpdateDtCol.Index].Value = row.IsNamariKekkaUpdateDtNull() == true ? string.Empty : row.NamariKekkaUpdateDt.ToString();
                        dgvr.Cells[aenKekkaUpdateDtCol.Index].Value = row.IsAenKekkaUpdateDtNull() == true ? string.Empty : row.AenKekkaUpdateDt.ToString();
                        dgvr.Cells[housoKekkaUpdateDtCol.Index].Value = row.IsHousoKekkaUpdateDtNull() == true ? string.Empty : row.HousoKekkaUpdateDt.ToString();
                        dgvr.Cells[zanenKekkaUpdateDtCol.Index].Value = row.IsZanenKekkaUpdateDtNull() == true ? string.Empty : row.ZanenKekkaUpdateDt.ToString();
                        dgvr.Cells[gaikanKekkaUpdateDtCol.Index].Value = row.IsGaikanKekkaUpdateDtNull() == true ? string.Empty : row.GaikanKekkaUpdateDt.ToString();
                        dgvr.Cells[shukiKekkaUpdateDtCol.Index].Value = row.IsShukiKekkaUpdateDtNull() == true ? string.Empty : row.ShukiKekkaUpdateDt.ToString();
                        dgvr.Cells[trKekkaUpdateDtCol.Index].Value = row.IsTrKekkaUpdateDtNull() == true ? string.Empty : row.TrKekkaUpdateDt.ToString();
                        dgvr.Cells[no2nTeiseiKekkaUpdateDtCol.Index].Value = row.IsNo2nTeiseiKekkaUpdateDtNull() == true ? string.Empty : row.No2nTeiseiKekkaUpdateDt.ToString();
                        dgvr.Cells[no3nTeiseiKekkaUpdateDtCol.Index].Value = row.IsNo3nTeiseiKekkaUpdateDtNull() == true ? string.Empty : row.No3nTeiseiKekkaUpdateDt.ToString();
                        dgvr.Cells[daichokinKekkaUpdateDtCol.Index].Value = row.IsDaichokinKekkaUpdateDtNull() == true ? string.Empty : row.DaichokinKekkaUpdateDt.ToString();

                        dgvr.Cells[ph1UpdateDtCol.Index].Value = row.IsPh1DtlUpdateDtNull() == true ? string.Empty : row.Ph1DtlUpdateDt.ToString();
                        dgvr.Cells[ph2UpdateDtCol.Index].Value = row.IsPh2DtlUpdateDtNull() == true ? string.Empty : row.Ph2DtlUpdateDt.ToString();
                        dgvr.Cells[ss1UpdateDtCol.Index].Value = row.IsSs1DtlUpdateDtNull() == true ? string.Empty : row.Ss1DtlUpdateDt.ToString();
                        dgvr.Cells[ss2UpdateDtCol.Index].Value = row.IsSs2DtlUpdateDtNull() == true ? string.Empty : row.Ss2DtlUpdateDt.ToString();
                        dgvr.Cells[bodA1UpdateDtCol.Index].Value = row.IsBodA1DtlUpdateDtNull() == true ? string.Empty : row.BodA1DtlUpdateDt.ToString();
                        dgvr.Cells[bodA2UpdateDtCol.Index].Value = row.IsBodA2DtlUpdateDtNull() == true ? string.Empty : row.BodA2DtlUpdateDt.ToString();
                        dgvr.Cells[nh4n1UpdateDtCol.Index].Value = row.IsNh4n1DtlUpdateDtNull() == true ? string.Empty : row.Nh4n1DtlUpdateDt.ToString();
                        dgvr.Cells[nh4n2UpdateDtCol.Index].Value = row.IsNh4n2DtlUpdateDtNull() == true ? string.Empty : row.Nh4n2DtlUpdateDt.ToString();
                        dgvr.Cells[cl1UpdateDtCol.Index].Value = row.IsCl1DtlUpdateDtNull() == true ? string.Empty : row.Cl1DtlUpdateDt.ToString();
                        dgvr.Cells[cl2UpdateDtCol.Index].Value = row.IsCl2DtlUpdateDtNull() == true ? string.Empty : row.Cl2DtlUpdateDt.ToString();
                        dgvr.Cells[cod1UpdateDtCol.Index].Value = row.IsCod1DtlUpdateDtNull() == true ? string.Empty : row.Cod1DtlUpdateDt.ToString();
                        dgvr.Cells[cod2UpdateDtCol.Index].Value = row.IsCod2DtlUpdateDtNull() == true ? string.Empty : row.Cod2DtlUpdateDt.ToString();
                        dgvr.Cells[hekisanA1UpdateDtCol.Index].Value = row.IsHekisanA1DtlUpdateDtNull() == true ? string.Empty : row.HekisanA1DtlUpdateDt.ToString();
                        dgvr.Cells[hekisanA2UpdateDtCol.Index].Value = row.IsHekisanA2DtlUpdateDtNull() == true ? string.Empty : row.HekisanA2DtlUpdateDt.ToString();
                        dgvr.Cells[mlss1UpdateDtCol.Index].Value = row.IsMlss1DtlUpdateDtNull() == true ? string.Empty : row.Mlss1DtlUpdateDt.ToString();
                        dgvr.Cells[mlss2UpdateDtCol.Index].Value = row.IsMlss2DtlUpdateDtNull() == true ? string.Empty : row.Mlss2DtlUpdateDt.ToString();
                        dgvr.Cells[tnA1UpdateDtCol.Index].Value = row.IsTnA1DtlUpdateDtNull() == true ? string.Empty : row.TnA1DtlUpdateDt.ToString();
                        dgvr.Cells[tnA2UpdateDtCol.Index].Value = row.IsTnA2DtlUpdateDtNull() == true ? string.Empty : row.TnA2DtlUpdateDt.ToString();
                        dgvr.Cells[absA1UpdateDtCol.Index].Value = row.IsAbsA1DtlUpdateDtNull() == true ? string.Empty : row.AbsA1DtlUpdateDt.ToString();
                        dgvr.Cells[absA2UpdateDtCol.Index].Value = row.IsAbsA2DtlUpdateDtNull() == true ? string.Empty : row.AbsA2DtlUpdateDt.ToString();
                        dgvr.Cells[tpA1UpdateDtCol.Index].Value = row.IsTpA1DtlUpdateDtNull() == true ? string.Empty : row.TpA1DtlUpdateDt.ToString();
                        dgvr.Cells[tpA2UpdateDtCol.Index].Value = row.IsTpA2DtlUpdateDtNull() == true ? string.Empty : row.TpA2DtlUpdateDt.ToString();
                        dgvr.Cells[rinsan1UpdateDtCol.Index].Value = row.IsRinsan1DtlUpdateDtNull() == true ? string.Empty : row.Rinsan1DtlUpdateDt.ToString();
                        dgvr.Cells[rinsan2UpdateDtCol.Index].Value = row.IsRinsan2DtlUpdateDtNull() == true ? string.Empty : row.Rinsan2DtlUpdateDt.ToString();
                        dgvr.Cells[no2nTeiryo1UpdateDtCol.Index].Value = row.IsNo2nTeiryo1DtlUpdateDtNull() == true ? string.Empty : row.No2nTeiryo1DtlUpdateDt.ToString();
                        dgvr.Cells[no2nTeiryo2UpdateDtCol.Index].Value = row.IsNo2nTeiryo2DtlUpdateDtNull() == true ? string.Empty : row.No2nTeiryo2DtlUpdateDt.ToString();
                        dgvr.Cells[no3nTeiryo1UpdateDtCol.Index].Value = row.IsNo3nTeiryo1DtlUpdateDtNull() == true ? string.Empty : row.No3nTeiryo1DtlUpdateDt.ToString();
                        dgvr.Cells[no3nTeiryo2UpdateDtCol.Index].Value = row.IsNo3nTeiryo2DtlUpdateDtNull() == true ? string.Empty : row.No3nTeiryo2DtlUpdateDt.ToString();
                        dgvr.Cells[absB1UpdateDtCol.Index].Value = row.IsAbsB1DtlUpdateDtNull() == true ? string.Empty : row.AbsB1DtlUpdateDt.ToString();
                        dgvr.Cells[absB2UpdateDtCol.Index].Value = row.IsAbsB2DtlUpdateDtNull() == true ? string.Empty : row.AbsB2DtlUpdateDt.ToString();
                        dgvr.Cells[tnB1UpdateDtCol.Index].Value = row.IsTnB1DtlUpdateDtNull() == true ? string.Empty : row.TnB1DtlUpdateDt.ToString();
                        dgvr.Cells[tnB2UpdateDtCol.Index].Value = row.IsTnB2DtlUpdateDtNull() == true ? string.Empty : row.TnB2DtlUpdateDt.ToString();
                        dgvr.Cells[tpB1UpdateDtCol.Index].Value = row.IsTpB1DtlUpdateDtNull() == true ? string.Empty : row.TpB1DtlUpdateDt.ToString();
                        dgvr.Cells[tpB2UpdateDtCol.Index].Value = row.IsTpB2DtlUpdateDtNull() == true ? string.Empty : row.TpB2DtlUpdateDt.ToString();
                        dgvr.Cells[shikido1UpdateDtCol.Index].Value = row.IsShikido1DtlUpdateDtNull() == true ? string.Empty : row.Shikido1DtlUpdateDt.ToString();
                        dgvr.Cells[shikido2UpdateDtCol.Index].Value = row.IsShikido2DtlUpdateDtNull() == true ? string.Empty : row.Shikido2DtlUpdateDt.ToString();
                        dgvr.Cells[bodB1UpdateDtCol.Index].Value = row.IsBodB1DtlUpdateDtNull() == true ? string.Empty : row.BodB1DtlUpdateDt.ToString();
                        dgvr.Cells[bodB2UpdateDtCol.Index].Value = row.IsBodB2DtlUpdateDtNull() == true ? string.Empty : row.BodB2DtlUpdateDt.ToString();
                        dgvr.Cells[hekisanKoyu1UpdateDtCol.Index].Value = row.IsHekisanKoyu1DtlUpdateDtNull() == true ? string.Empty : row.HekisanKoyu1DtlUpdateDt.ToString();
                        dgvr.Cells[hekisanKoyu2UpdateDtCol.Index].Value = row.IsHekisanKoyu2DtlUpdateDtNull() == true ? string.Empty : row.HekisanKoyu2DtlUpdateDt.ToString();
                        dgvr.Cells[hekisanDoshoku1UpdateDtCol.Index].Value = row.IsHekisanDoshoku1DtlUpdateDtNull() == true ? string.Empty : row.HekisanDoshoku1DtlUpdateDt.ToString();
                        dgvr.Cells[hekisanDoshoku2UpdateDtCol.Index].Value = row.IsHekisanDoshoku2DtlUpdateDtNull() == true ? string.Empty : row.HekisanDoshoku2DtlUpdateDt.ToString();
                        dgvr.Cells[hekisanB1UpdateDtCol.Index].Value = row.IsHekisanB1DtlUpdateDtNull() == true ? string.Empty : row.HekisanB1DtlUpdateDt.ToString();
                        dgvr.Cells[hekisanB2UpdateDtCol.Index].Value = row.IsHekisanB2DtlUpdateDtNull() == true ? string.Empty : row.HekisanB2DtlUpdateDt.ToString();
                        dgvr.Cells[namari1UpdateDtCol.Index].Value = row.IsNamari1DtlUpdateDtNull() == true ? string.Empty : row.Namari1DtlUpdateDt.ToString();
                        dgvr.Cells[namari2UpdateDtCol.Index].Value = row.IsNamari2DtlUpdateDtNull() == true ? string.Empty : row.Namari2DtlUpdateDt.ToString();
                        dgvr.Cells[aen1UpdateDtCol.Index].Value = row.IsAen1DtlUpdateDtNull() == true ? string.Empty : row.Aen1DtlUpdateDt.ToString();
                        dgvr.Cells[aen2UpdateDtCol.Index].Value = row.IsAen2DtlUpdateDtNull() == true ? string.Empty : row.Aen2DtlUpdateDt.ToString();
                        dgvr.Cells[houso1UpdateDtCol.Index].Value = row.IsHouso1DtlUpdateDtNull() == true ? string.Empty : row.Houso1DtlUpdateDt.ToString();
                        dgvr.Cells[houso2UpdateDtCol.Index].Value = row.IsHouso2DtlUpdateDtNull() == true ? string.Empty : row.Houso2DtlUpdateDt.ToString();
                        dgvr.Cells[zanen1UpdateDtCol.Index].Value = row.IsZanen1DtlUpdateDtNull() == true ? string.Empty : row.Zanen1DtlUpdateDt.ToString();
                        dgvr.Cells[zanen2UpdateDtCol.Index].Value = row.IsZanen2DtlUpdateDtNull() == true ? string.Empty : row.Zanen2DtlUpdateDt.ToString();
                        dgvr.Cells[gaikan1UpdateDtCol.Index].Value = row.IsGaikan1DtlUpdateDtNull() == true ? string.Empty : row.Gaikan1DtlUpdateDt.ToString();
                        dgvr.Cells[gaikan2UpdateDtCol.Index].Value = row.IsGaikan2DtlUpdateDtNull() == true ? string.Empty : row.Gaikan2DtlUpdateDt.ToString();
                        dgvr.Cells[shuki1UpdateDtCol.Index].Value = row.IsShuki1DtlUpdateDtNull() == true ? string.Empty : row.Shuki1DtlUpdateDt.ToString();
                        dgvr.Cells[shuki2UpdateDtCol.Index].Value = row.IsShuki2DtlUpdateDtNull() == true ? string.Empty : row.Shuki2DtlUpdateDt.ToString();
                        dgvr.Cells[tr1UpdateDtCol.Index].Value = row.IsTr1DtlUpdateDtNull() == true ? string.Empty : row.Tr1DtlUpdateDt.ToString();
                        dgvr.Cells[tr2UpdateDtCol.Index].Value = row.IsTr2DtlUpdateDtNull() == true ? string.Empty : row.Tr2DtlUpdateDt.ToString();
                        dgvr.Cells[no2nTeisei1UpdateDtCol.Index].Value = row.IsNo2nTeisei1DtlUpdateDtNull() == true ? string.Empty : row.No2nTeisei1DtlUpdateDt.ToString();
                        dgvr.Cells[no2nTeisei2UpdateDtCol.Index].Value = row.IsNo2nTeisei2DtlUpdateDtNull() == true ? string.Empty : row.No2nTeisei2DtlUpdateDt.ToString();
                        dgvr.Cells[no3nTeisei1UpdateDtCol.Index].Value = row.IsNo3nTeisei1DtlUpdateDtNull() == true ? string.Empty : row.No3nTeisei1DtlUpdateDt.ToString();
                        dgvr.Cells[no3nTeisei2UpdateDtCol.Index].Value = row.IsNo3nTeisei2DtlUpdateDtNull() == true ? string.Empty : row.No3nTeisei2DtlUpdateDt.ToString();
                        dgvr.Cells[daichokin1UpdateDtCol.Index].Value = row.IsDaichokin1DtlUpdateDtNull() == true ? string.Empty : row.Daichokin1DtlUpdateDt.ToString();
                        dgvr.Cells[daichokin2UpdateDtCol.Index].Value = row.IsDaichokin2DtlUpdateDtNull() == true ? string.Empty : row.Daichokin2DtlUpdateDt.ToString();
                        #endregion

                        break;
                    }
                }
            }
        }
        #endregion

        #region 確認検査種別(SS/透視度)
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckKakuninKensaShubetsuSsTr
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/07　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CheckKakuninKensaShubetsuSsTr(DataGridViewRow dgvr)
        {
            string paramSs = string.Empty;
            string paramTr = string.Empty;

            // SS
            if (dgvr.Cells[saiyotiSs1Col.Index].Value.ToString() == CheckOn)
            {
                paramSs = dgvr.Cells[ss1Col.Index].Value == null ? string.Empty : dgvr.Cells[ss1Col.Index].Value.ToString();
            }
            else if (dgvr.Cells[saiyotiSs2Col.Index].Value.ToString() == CheckOn)
            {
                paramSs = dgvr.Cells[ss2Col.Index].Value == null ? string.Empty : dgvr.Cells[ss2Col.Index].Value.ToString();
            }
            // 透視度
            if (dgvr.Cells[saiyotiTr1Col.Index].Value.ToString() == CheckOn)
            {
                paramTr = dgvr.Cells[tr1Col.Index].Value == null ? string.Empty : dgvr.Cells[tr1Col.Index].Value.ToString();
            }
            else if (dgvr.Cells[saiyotiTr2Col.Index].Value.ToString() == CheckOn)
            {
                paramTr = dgvr.Cells[tr2Col.Index].Value == null ? string.Empty : dgvr.Cells[tr2Col.Index].Value.ToString();
            }

            // 判定
            string res = KensaHanteiUtility.KakuninKensaShubetsuSSToshido(
                dgvr.Cells[suishitsuCdCol.Index].Value.ToString(),
                paramSs,
                paramTr,
                dgvr.Cells[jokasoHokenjoCdCol.Index].Value.ToString(),
                dgvr.Cells[jokasoTorokuNendoCol.Index].Value.ToString(),
                dgvr.Cells[jokasoRenbanCol.Index].Value.ToString()
                );

            // 更新状態設定
            dgvr.Cells[koshinKbnSsTr.Index].Value = "1";

            // 判定結果設定
            if (res == "1")
            {
                // SS
                if (dgvr.Cells[saiyotiSs1Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[ss1KensaShubetsuSsTr.Index].Value = "2";
                }
                else if (dgvr.Cells[saiyotiSs2Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[ss2KensaShubetsuSsTr.Index].Value = "2";
                }
                // 透視度
                if (dgvr.Cells[saiyotiTr1Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[tr1KensaShubetsuSsTr.Index].Value = "2";
                }
                else if (dgvr.Cells[saiyotiTr2Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[tr2KensaShubetsuSsTr.Index].Value = "2";
                }
            }
            else
            {
                // SS
                if (dgvr.Cells[saiyotiSs1Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[ss1KensaShubetsuSsTr.Index].Value = "1";
                }
                else if (dgvr.Cells[saiyotiSs2Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[ss2KensaShubetsuSsTr.Index].Value = "1";
                }
                // 透視度
                if (dgvr.Cells[saiyotiTr1Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[tr1KensaShubetsuSsTr.Index].Value = "1";
                }
                else if (dgvr.Cells[saiyotiTr2Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[tr2KensaShubetsuSsTr.Index].Value = "1";
                }
            }
        }
        #endregion

        #region 確認検査種別(BOD/透視度)
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckKakuninKensaShubetsuBodTr
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/07　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CheckKakuninKensaShubetsuBodTr(DataGridViewRow dgvr)
        {
            string paramBodA = string.Empty;
            string paramBodB = string.Empty;
            string paramTr = string.Empty;

            // BOD(A)
            if (dgvr.Cells[saiyotiBodA1Col.Index].Value.ToString() == CheckOn)
            {
                paramBodA = dgvr.Cells[bodA1Col.Index].Value == null ? string.Empty : dgvr.Cells[bodA1Col.Index].Value.ToString();
            }
            else if (dgvr.Cells[saiyotiBodA2Col.Index].Value.ToString() == CheckOn)
            {
                paramBodA = dgvr.Cells[bodA2Col.Index].Value == null ? string.Empty : dgvr.Cells[bodA2Col.Index].Value.ToString();
            }
            // BOD(B)
            if (dgvr.Cells[saiyotiBodB1Col.Index].Value.ToString() == CheckOn)
            {
                paramBodB = dgvr.Cells[bodB1Col.Index].Value == null ? string.Empty : dgvr.Cells[bodB1Col.Index].Value.ToString();
            }
            else if (dgvr.Cells[saiyotiBodB2Col.Index].Value.ToString() == CheckOn)
            {
                paramBodB = dgvr.Cells[bodB2Col.Index].Value == null ? string.Empty : dgvr.Cells[bodB2Col.Index].Value.ToString();
            }
            // 透視度
            if (dgvr.Cells[saiyotiTr1Col.Index].Value.ToString() == CheckOn)
            {
                paramTr = dgvr.Cells[tr1Col.Index].Value == null ? string.Empty : dgvr.Cells[tr1Col.Index].Value.ToString();
            }
            else if (dgvr.Cells[saiyotiTr2Col.Index].Value.ToString() == CheckOn)
            {
                paramTr = dgvr.Cells[tr2Col.Index].Value == null ? string.Empty : dgvr.Cells[tr2Col.Index].Value.ToString();
            }

            // 判定(A)
            string resA = KensaHanteiUtility.KakuninKensaShubetsuBODToshido(
                dgvr.Cells[suishitsuCdCol.Index].Value.ToString(),
                paramBodA,
                paramTr,
                dgvr.Cells[jokasoHokenjoCdCol.Index].Value.ToString(),
                dgvr.Cells[jokasoTorokuNendoCol.Index].Value.ToString(),
                dgvr.Cells[jokasoRenbanCol.Index].Value.ToString()
                );
            // 判定(B)
            string resB = KensaHanteiUtility.KakuninKensaShubetsuBODToshido(
                dgvr.Cells[suishitsuCdCol.Index].Value.ToString(),
                paramBodB,
                paramTr,
                dgvr.Cells[jokasoHokenjoCdCol.Index].Value.ToString(),
                dgvr.Cells[jokasoTorokuNendoCol.Index].Value.ToString(),
                dgvr.Cells[jokasoRenbanCol.Index].Value.ToString()
                );

            // 更新状態設定
            dgvr.Cells[koshinKbnBodTr.Index].Value = "1";

            // 判定結果設定
            if (resA == "1" || resB == "1")
            {
                // BOD(A)
                if ((dgvr.Cells[saiyotiBodA1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuBodA1Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[bodA1KensaShubetsuBodTr.Index].Value = "2";
                }
                else if ((dgvr.Cells[saiyotiBodA2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuBodA2Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[bodA2KensaShubetsuBodTr.Index].Value = "2";
                }
                // BOD(B)
                if ((dgvr.Cells[saiyotiBodB1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuBodB1Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[bodB1KensaShubetsuBodTr.Index].Value = "2";
                }
                else if ((dgvr.Cells[saiyotiBodB2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuBodB2Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[bodB2KensaShubetsuBodTr.Index].Value = "2";
                }
                // 透視度
                if (dgvr.Cells[saiyotiTr1Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[tr1KensaShubetsuBodTr.Index].Value = "2";
                }
                else if (dgvr.Cells[saiyotiTr2Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[tr2KensaShubetsuBodTr.Index].Value = "2";
                }
            }
            else
            {
                // BOD(A)
                if (dgvr.Cells[saiyotiBodA1Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[bodA1KensaShubetsuBodTr.Index].Value = "1";
                }
                else if (dgvr.Cells[saiyotiBodA2Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[bodA2KensaShubetsuBodTr.Index].Value = "1";
                }
                // BOD(B)
                if (dgvr.Cells[saiyotiBodB1Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[bodB1KensaShubetsuBodTr.Index].Value = "1";
                }
                else if (dgvr.Cells[saiyotiBodB2Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[bodB2KensaShubetsuBodTr.Index].Value = "1";
                }
                // 透視度
                if (dgvr.Cells[saiyotiTr1Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[tr1KensaShubetsuBodTr.Index].Value = "1";
                }
                else if (dgvr.Cells[saiyotiTr2Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[tr2KensaShubetsuBodTr.Index].Value = "1";
                }
            }
        }
        #endregion

        #region 確認検査種別(過去との比較)
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckKakuninKensaShubetsuKako
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/07　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CheckKakuninKensaShubetsuKako(DataGridViewRow dgvr, int index)
        {
            #region 試験項目コード
            string kmkCd = string.Empty;
            if ((index == ph1Col.Index) || (index == ph2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanPh);
            }
            if ((index == ss1Col.Index) || (index == ss2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanSs);
            }
            if ((index == bodA1Col.Index) || (index == bodA2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanBodA);
            }
            if ((index == nh4n1Col.Index) || (index == nh4n2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanNh4n);
            }
            if ((index == cl1Col.Index) || (index == cl2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanCl);
            }
            if ((index == cod1Col.Index) || (index == cod2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanCod);
            }
            if ((index == hekisanA1Col.Index) || (index == hekisanA2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanHekisanA);
            }
            if ((index == mlss1Col.Index) || (index == mlss2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanMlss);
            }
            if ((index == tnA1Col.Index) || (index == tnA2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanTnA);
            }
            if ((index == absA1Col.Index) || (index == absA2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanAbsA);
            }
            if ((index == tpA1Col.Index) || (index == tpA2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanTpA);
            }
            if ((index == rinsan1Col.Index) || (index == rinsan2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanRinsan);
            }
            if ((index == no2nTeiryo1Col.Index) || (index == no2nTeiryo2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanNo2nTeiryo);
            }
            if ((index == no3nTeiryo1Col.Index) || (index == no3nTeiryo2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanNo3nTeiryo);
            }
            if ((index == absB1Col.Index) || (index == absB2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanAbsB);
            }
            if ((index == tnB1Col.Index) || (index == tnB2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanTnB);
            }
            if ((index == tpB1Col.Index) || (index == tpB2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanTpB);
            }
            if ((index == shikido1Col.Index) || (index == shikido2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanShikido);
            }
            if ((index == bodB1Col.Index) || (index == bodB2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanBodB);
            }
            if ((index == hekisanKoyu1Col.Index) || (index == hekisanKoyu2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanHekisanKoyu);
            }
            if ((index == hekisanDoshoku1Col.Index) || (index == hekisanDoshoku2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanHekisanDoshoku);
            }
            if ((index == hekisanB1Col.Index) || (index == hekisanB2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanHekisanB);
            }
            if ((index == namari1Col.Index) || (index == namari2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanNamari);
            }
            if ((index == aen1Col.Index) || (index == aen2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanAen);
            }
            if ((index == houso1Col.Index) || (index == houso2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanHouso);
            }
            if ((index == zanen1Col.Index) || (index == zanen2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanZanen);
            }
            if ((index == gaikan1Col.Index) || (index == gaikan2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanGaikan);
            }
            if ((index == shuki1Col.Index) || (index == shuki2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanShuki);
            }
            if ((index == tr1Col.Index) || (index == tr2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanTr);
            }
            if ((index == no2nTeisei1Col.Index) || (index == no2nTeisei2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanNo2nTeisei);
            }
            if ((index == no3nTeisei1Col.Index) || (index == no3nTeisei2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanNo3nTeisei);
            }
            if ((index == daichokin1Col.Index) || (index == daichokin2Col.Index))
            {
                kmkCd = GetKmkCd(ConstRenbanDaichokin);
            }
            #endregion

            #region 判定
            string hantei = string.Empty;
            hantei = KensaHanteiUtility.KakuninKensaShubetsuKakoHikaku(
                "2",
                dgvr.Cells[jokasoHokenjoCdCol.Index].Value.ToString(),
                dgvr.Cells[jokasoTorokuNendoCol.Index].Value.ToString(),
                dgvr.Cells[jokasoRenbanCol.Index].Value.ToString(),
                dgvr.Cells[uketsukeDt.Index].Value.ToString(),
                kmkCd,
                decimal.Parse(dgvr.Cells[index].Value.ToString())
                );

            string res = string.Empty;
            if (hantei == "1")
            {
                res = "2";
            }
            else
            {
                res = "1";
            }
            #endregion

            #region 更新状態設定
            if ((index == ph1Col.Index) || (index == ph2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoPh.Index].Value = "1";
            }
            if ((index == ss1Col.Index) || (index == ss2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoSs.Index].Value = "1";
            }
            if ((index == bodA1Col.Index) || (index == bodA2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoBodA.Index].Value = "1";
            }
            if ((index == nh4n1Col.Index) || (index == nh4n2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoNh4n.Index].Value = "1";
            }
            if ((index == cl1Col.Index) || (index == cl2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoCl.Index].Value = "1";
            }
            if ((index == cod1Col.Index) || (index == cod2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoCod.Index].Value = "1";
            }
            if ((index == hekisanA1Col.Index) || (index == hekisanA2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoHekisanA.Index].Value = "1";
            }
            if ((index == mlss1Col.Index) || (index == mlss2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoMlss.Index].Value = "1";
            }
            if ((index == tnA1Col.Index) || (index == tnA2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoTnA.Index].Value = "1";
            }
            if ((index == absA1Col.Index) || (index == absA2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoAbsA.Index].Value = "1";
            }
            if ((index == tpA1Col.Index) || (index == tpA2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoTpA.Index].Value = "1";
            }
            if ((index == rinsan1Col.Index) || (index == rinsan2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoRinsan.Index].Value = "1";
            }
            if ((index == no2nTeiryo1Col.Index) || (index == no2nTeiryo2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoNo2nTeiryo.Index].Value = "1";
            }
            if ((index == no3nTeiryo1Col.Index) || (index == no3nTeiryo2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoNo3nTeiryo.Index].Value = "1";
            }
            if ((index == absB1Col.Index) || (index == absB2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoAbsB.Index].Value = "1";
            }
            if ((index == tnB1Col.Index) || (index == tnB2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoTnB.Index].Value = "1";
            }
            if ((index == tpB1Col.Index) || (index == tpB2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoTpB.Index].Value = "1";
            }
            if ((index == shikido1Col.Index) || (index == shikido2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoShikido.Index].Value = "1";
            }
            if ((index == bodB1Col.Index) || (index == bodB2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoBodB.Index].Value = "1";
            }
            if ((index == hekisanKoyu1Col.Index) || (index == hekisanKoyu2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoHekisanKoyu.Index].Value = "1";
            }
            if ((index == hekisanDoshoku1Col.Index) || (index == hekisanDoshoku2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoHekisanDoshoku.Index].Value = "1";
            }
            if ((index == hekisanB1Col.Index) || (index == hekisanB2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoHekisanB.Index].Value = "1";
            }
            if ((index == namari1Col.Index) || (index == namari2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoNamari.Index].Value = "1";
            }
            if ((index == aen1Col.Index) || (index == aen2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoAen.Index].Value = "1";
            }
            if ((index == houso1Col.Index) || (index == houso2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoHouso.Index].Value = "1";
            }
            if ((index == zanen1Col.Index) || (index == zanen2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoZanen.Index].Value = "1";
            }
            if ((index == gaikan1Col.Index) || (index == gaikan2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoGaikan.Index].Value = "1";
            }
            if ((index == shuki1Col.Index) || (index == shuki2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoShuki.Index].Value = "1";
            }
            if ((index == tr1Col.Index) || (index == tr2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoTr.Index].Value = "1";
            }
            if ((index == no2nTeisei1Col.Index) || (index == no2nTeisei2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoNo2nTeisei.Index].Value = "1";
            }
            if ((index == no3nTeisei1Col.Index) || (index == no3nTeisei2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoNo3nTeisei.Index].Value = "1";
            }
            if ((index == daichokin1Col.Index) || (index == daichokin2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoDaichokin.Index].Value = "1";
            }
            #endregion

            // 判定結果設定
            if ((index == ph1Col.Index) || (index == ph2Col.Index))
            {
                dgvr.Cells[index + 5].Value = res;
            }
            else
            {
                dgvr.Cells[index + 4].Value = res;
            }

        }
        #endregion

        #region 確認検査種別(塩化物イオン確認検査)
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckKakuninKensaShubetsuEnkaIon
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/07　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CheckKakuninKensaShubetsuEnkaIon(DataGridViewRow dgvr)
        {
            string paramCl = string.Empty;

            // 塩化物イオン
            if (dgvr.Cells[saiyotiCl1Col.Index].Value.ToString() == CheckOn)
            {
                paramCl = dgvr.Cells[cl1Col.Index].Value == null ? string.Empty : dgvr.Cells[cl1Col.Index].Value.ToString();
            }
            else if (dgvr.Cells[saiyotiCl2Col.Index].Value.ToString() == CheckOn)
            {
                paramCl = dgvr.Cells[cl2Col.Index].Value == null ? string.Empty : dgvr.Cells[cl2Col.Index].Value.ToString();
            }

            // 判定
            string res = KensaHanteiUtility.KakuninKensaShubetsuEnkabutsuIonKensa(
                paramCl,
                dgvr.Cells[jokasoHokenjoCdCol.Index].Value.ToString(),
                dgvr.Cells[jokasoTorokuNendoCol.Index].Value.ToString(),
                dgvr.Cells[jokasoRenbanCol.Index].Value.ToString()
                );

            // 更新状態設定
            dgvr.Cells[koshinKbnEnkaIon.Index].Value = "1";

            // 判定結果設定
            if (res == "1")
            {
                if (dgvr.Cells[saiyotiCl1Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[cl1KensaShubetsuEnkaIon.Index].Value = "2";
                }
                else if (dgvr.Cells[saiyotiCl2Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[cl2KensaShubetsuEnkaIon.Index].Value = "2";
                }
            }
            else
            {
                if (dgvr.Cells[saiyotiCl1Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[cl1KensaShubetsuEnkaIon.Index].Value = "1";
                }
                else if (dgvr.Cells[saiyotiCl2Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[cl2KensaShubetsuEnkaIon.Index].Value = "1";
                }
            }
        }
        #endregion

        #region 確認検査種別(アンモニア確認検査)
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckKakuninKensaShubetsuAnmonia
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/07　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CheckKakuninKensaShubetsuAnmonia(DataGridViewRow dgvr)
        {
            string paramAnmonia = string.Empty;

            // アンモニア性窒素
            if (dgvr.Cells[saiyotiNh4n1Col.Index].Value.ToString() == CheckOn)
            {
                paramAnmonia = dgvr.Cells[nh4n1Col.Index].Value == null ? string.Empty : dgvr.Cells[nh4n1Col.Index].Value.ToString();
            }
            else if (dgvr.Cells[saiyotiNh4n2Col.Index].Value.ToString() == CheckOn)
            {
                paramAnmonia = dgvr.Cells[nh4n2Col.Index].Value == null ? string.Empty : dgvr.Cells[nh4n2Col.Index].Value.ToString();
            }

            // 判定
            string res = KensaHanteiUtility.KakuninKensaShubetsuAnmoniaKensa(
                paramAnmonia,
                dgvr.Cells[jokasoHokenjoCdCol.Index].Value.ToString(),
                dgvr.Cells[jokasoTorokuNendoCol.Index].Value.ToString(),
                dgvr.Cells[jokasoRenbanCol.Index].Value.ToString()
                );

            // 更新状態設定
            dgvr.Cells[koshinKbnAnmonia.Index].Value = "1";

            // 判定結果設定
            if (res == "1")
            {
                // アンモニア性窒素
                if (dgvr.Cells[saiyotiNh4n1Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[nh4n1KensaShubetsuAnmonia.Index].Value = "2";
                }
                else if (dgvr.Cells[saiyotiNh4n2Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[nh4n2KensaShubetsuAnmonia.Index].Value = "2";
                }
            }
            else
            {
                // アンモニア性窒素
                if (dgvr.Cells[saiyotiNh4n1Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[nh4n1KensaShubetsuAnmonia.Index].Value = "1";
                }
                else if (dgvr.Cells[saiyotiNh4n2Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[nh4n2KensaShubetsuAnmonia.Index].Value = "1";
                }
            }
        }
        #endregion

        #region 確認検査種別(アンモニアと全窒素の比較)
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckKakuninKensaShubetsuAnmoniaTn
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/07　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CheckKakuninKensaShubetsuAnmoniaTn(DataGridViewRow dgvr)
        {
            string paramAnmonia = string.Empty;
            string paramTnA = string.Empty;
            string paramTnB = string.Empty;

            // アンモニア性窒素
            if (dgvr.Cells[saiyotiNh4n1Col.Index].Value.ToString() == CheckOn)
            {
                paramAnmonia = dgvr.Cells[nh4n1Col.Index].Value == null ? string.Empty : dgvr.Cells[nh4n1Col.Index].Value.ToString();
            }
            else if (dgvr.Cells[saiyotiNh4n2Col.Index].Value.ToString() == CheckOn)
            {
                paramAnmonia = dgvr.Cells[nh4n2Col.Index].Value == null ? string.Empty : dgvr.Cells[nh4n2Col.Index].Value.ToString();
            }
            // 全窒素(A)
            if (dgvr.Cells[saiyotiTnA1Col.Index].Value.ToString() == CheckOn)
            {
                paramTnA = dgvr.Cells[tnA1Col.Index].Value == null ? string.Empty : dgvr.Cells[tnA1Col.Index].Value.ToString();
            }
            else if (dgvr.Cells[saiyotiTnA2Col.Index].Value.ToString() == CheckOn)
            {
                paramTnA = dgvr.Cells[tnA2Col.Index].Value == null ? string.Empty : dgvr.Cells[tnA2Col.Index].Value.ToString();
            }
            // 全窒素(B)
            if (dgvr.Cells[saiyotiTnB1Col.Index].Value.ToString() == CheckOn)
            {
                paramTnB = dgvr.Cells[tnB1Col.Index].Value == null ? string.Empty : dgvr.Cells[tnB1Col.Index].Value.ToString();
            }
            else if (dgvr.Cells[saiyotiTnB2Col.Index].Value.ToString() == CheckOn)
            {
                paramTnB = dgvr.Cells[tnB1Col.Index].Value == null ? string.Empty : dgvr.Cells[tnB2Col.Index].Value.ToString();
            }

            // 判定(A)
            string resA = KensaHanteiUtility.KakuninKensaShubetsuAnmoniaTNHikaku(
                paramAnmonia,
                paramTnA
                );
            // 判定(B)
            string resB = KensaHanteiUtility.KakuninKensaShubetsuAnmoniaTNHikaku(
                paramAnmonia,
                paramTnB
                );

            // 更新状態設定
            dgvr.Cells[koshinKbnAnmoniaTn.Index].Value = "1";

            // 判定結果設定
            if (resA == "1" || resB == "1")
            {
                // アンモニア性窒素
                if (dgvr.Cells[saiyotiNh4n1Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[nh4n1KensaShubetsuAnmoniaTn.Index].Value = "2";
                }
                else if (dgvr.Cells[saiyotiNh4n2Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[nh4n2KensaShubetsuAnmoniaTn.Index].Value = "2";
                }
                // 全窒素(A)
                if ((dgvr.Cells[saiyotiTnA1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuTnA1Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[tnA1KensaShubetsuAnmoniaTn.Index].Value = "2";
                }
                else if ((dgvr.Cells[saiyotiTnA2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuTnA2Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[tnA2KensaShubetsuAnmoniaTn.Index].Value = "2";
                }
                // 全窒素(B)
                if ((dgvr.Cells[saiyotiTnB1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuTnB1Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[tnB1KensaShubetsuAnmoniaTn.Index].Value = "2";
                }
                else if ((dgvr.Cells[saiyotiTnB2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuTnB2Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[tnB2KensaShubetsuAnmoniaTn.Index].Value = "2";
                }
            }
            else
            {
                // アンモニア性窒素
                if (dgvr.Cells[saiyotiNh4n1Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[nh4n1KensaShubetsuAnmoniaTn.Index].Value = "1";
                }
                else if (dgvr.Cells[saiyotiNh4n2Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[nh4n2KensaShubetsuAnmoniaTn.Index].Value = "1";
                }
                // 全窒素(A)
                if (dgvr.Cells[saiyotiTnA1Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[tnA1KensaShubetsuAnmoniaTn.Index].Value = "1";
                }
                else if (dgvr.Cells[saiyotiTnA2Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[tnA2KensaShubetsuAnmoniaTn.Index].Value = "1";
                }
                // 全窒素(B)
                if (dgvr.Cells[saiyotiTnB1Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[tnB1KensaShubetsuAnmoniaTn.Index].Value = "1";
                }
                else if (dgvr.Cells[saiyotiTnB2Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[tnB2KensaShubetsuAnmoniaTn.Index].Value = "1";
                }
            }
        }
        #endregion

        #region 確認検査種別(COD基準値オーバー)
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckKakuninKensaShubetsuCodOver
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/07　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CheckKakuninKensaShubetsuCodOver(DataGridViewRow dgvr)
        {
            string paramCod = string.Empty;

            // COD
            if (dgvr.Cells[saiyotiCod1Col.Index].Value.ToString() == CheckOn)
            {
                paramCod = dgvr.Cells[cod1Col.Index].Value == null ? string.Empty : dgvr.Cells[cod1Col.Index].Value.ToString();
            }
            else if (dgvr.Cells[saiyotiCod2Col.Index].Value.ToString() == CheckOn)
            {
                paramCod = dgvr.Cells[cod2Col.Index].Value == null ? string.Empty : dgvr.Cells[cod2Col.Index].Value.ToString();
            }

            // 判定
            string res = KensaHanteiUtility.KakuninKensaShubetsuCODKijyunOver(
                paramCod
                );

            // 更新状態設定
            dgvr.Cells[koshinKbnCodOver.Index].Value = "1";

            // 判定結果設定
            if (res == "1")
            {
                if (dgvr.Cells[saiyotiCod1Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[cod1KensaShubetsuCodOver.Index].Value = "2";
                }
                else if (dgvr.Cells[saiyotiCod2Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[cod2KensaShubetsuCodOver.Index].Value = "2";
                }
            }
            else
            {
                if (dgvr.Cells[saiyotiCod1Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[cod1KensaShubetsuCodOver.Index].Value = "1";
                }
                else if (dgvr.Cells[saiyotiCod2Col.Index].Value.ToString() == CheckOn)
                {
                    dgvr.Cells[cod2KensaShubetsuCodOver.Index].Value = "1";
                }
            }
        }
        #endregion

        #region 確認検査種別の判定結果を表示
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DispKakuninKensaShubetsu
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/07　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DispKakuninKensaShubetsu(DataGridViewRow dgvr)
        {
            #region 初期化
            string ph1 = string.Empty;
            string ph2 = string.Empty;
            string ss1 = string.Empty;
            string ss2 = string.Empty;
            string bodA1 = string.Empty;
            string bodA2 = string.Empty;
            string nh4n1 = string.Empty;
            string nh4n2 = string.Empty;
            string cl1 = string.Empty;
            string cl2 = string.Empty;
            string cod1 = string.Empty;
            string cod2 = string.Empty;
            string hekisanA1 = string.Empty;
            string hekisanA2 = string.Empty;
            string mlss1 = string.Empty;
            string mlss2 = string.Empty;
            string tnA1 = string.Empty;
            string tnA2 = string.Empty;
            string absA1 = string.Empty;
            string absA2 = string.Empty;
            string tpA1 = string.Empty;
            string tpA2 = string.Empty;
            string rinsan1 = string.Empty;
            string rinsan2 = string.Empty;
            string no2nTeiryo1 = string.Empty;
            string no2nTeiryo2 = string.Empty;
            string no3nTeiryo1 = string.Empty;
            string no3nTeiryo2 = string.Empty;
            string absB1 = string.Empty;
            string absB2 = string.Empty;
            string tnB1 = string.Empty;
            string tnB2 = string.Empty;
            string tpB1 = string.Empty;
            string tpB2 = string.Empty;
            string shikido1 = string.Empty;
            string shikido2 = string.Empty;
            string bodB1 = string.Empty;
            string bodB2 = string.Empty;
            string hekisanKoyu1 = string.Empty;
            string hekisanKoyu2 = string.Empty;
            string hekisanDoshoku1 = string.Empty;
            string hekisanDoshoku2 = string.Empty;
            string hekisanB1 = string.Empty;
            string hekisanB2 = string.Empty;
            string namari1 = string.Empty;
            string namari2 = string.Empty;
            string aen1 = string.Empty;
            string aen2 = string.Empty;
            string houso1 = string.Empty;
            string houso2 = string.Empty;
            string zanen1 = string.Empty;
            string zanen2 = string.Empty;
            string gaikan1 = string.Empty;
            string gaikan2 = string.Empty;
            string shuki1 = string.Empty;
            string shuki2 = string.Empty;
            string tr1 = string.Empty;
            string tr2 = string.Empty;
            string no2nTeisei1 = string.Empty;
            string no2nTeisei2 = string.Empty;
            string no3nTeisei1 = string.Empty;
            string no3nTeisei2 = string.Empty;
            string daichokin1 = string.Empty;
            string daichokin2 = string.Empty;
            #endregion

            #region 表示文字列編集(SS/透視度)
            if (dgvr.Cells[ss1KensaShubetsuSsTr.Index].Value.ToString() == "2")
            {
                ss1 += "A";
            }
            if (dgvr.Cells[ss2KensaShubetsuSsTr.Index].Value.ToString() == "2")
            {
                ss1 += "A";
            }
            if (dgvr.Cells[tr1KensaShubetsuBodTr.Index].Value.ToString() == "2")
            {
                tr1 += "A";
            }
            if (dgvr.Cells[tr2KensaShubetsuBodTr.Index].Value.ToString() == "2")
            {
                tr2 += "A";
            }
            #endregion

            #region 表示文字列編集(BOD/透視度)
            if (dgvr.Cells[bodA1KensaShubetsuBodTr.Index].Value.ToString() == "2")
            {
                bodA1 += "B";
            }
            if (dgvr.Cells[bodA2KensaShubetsuBodTr.Index].Value.ToString() == "2")
            {
                bodA2 += "B";
            }
            if (dgvr.Cells[bodB1KensaShubetsuBodTr.Index].Value.ToString() == "2")
            {
                bodB1 += "B";
            }
            if (dgvr.Cells[bodB2KensaShubetsuBodTr.Index].Value.ToString() == "2")
            {
                bodB2 += "B";
            }
            if (dgvr.Cells[tr1KensaShubetsuBodTr.Index].Value.ToString() == "2")
            {
                tr1 += "B";
            }
            if (dgvr.Cells[tr2KensaShubetsuBodTr.Index].Value.ToString() == "2")
            {
                tr2 += "B";
            }
            #endregion

            #region 表示文字列編集(過去との比較)
            if (dgvr.Cells[ph1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                ph1 += "C";
            }
            if (dgvr.Cells[ph2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                ph2 += "C";
            }
            if (dgvr.Cells[ss1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                ss1 += "C";
            }
            if (dgvr.Cells[ss2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                ss2 += "C";
            }
            if (dgvr.Cells[bodA1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                bodA1 += "C";
            }
            if (dgvr.Cells[bodA2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                bodA2 += "C";
            }
            if (dgvr.Cells[nh4n1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                nh4n1 += "C";
            }
            if (dgvr.Cells[nh4n2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                nh4n2 += "C";
            }
            if (dgvr.Cells[cl1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                cl1 += "C";
            }
            if (dgvr.Cells[cl2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                cl2 += "C";
            }
            if (dgvr.Cells[cod1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                cod1 += "C";
            }
            if (dgvr.Cells[cod2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                cod2 += "C";
            }
            if (dgvr.Cells[hekisanA1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                hekisanA1 += "C";
            }
            if (dgvr.Cells[hekisanA2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                hekisanA2 += "C";
            }
            if (dgvr.Cells[mlss1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                mlss1 += "C";
            }
            if (dgvr.Cells[mlss2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                mlss2 += "C";
            }
            if (dgvr.Cells[tnA1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                tnA1 += "C";
            }
            if (dgvr.Cells[tnA2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                tnA2 += "C";
            }
            if (dgvr.Cells[absA1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                absA1 += "C";
            }
            if (dgvr.Cells[absA2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                absA2 += "C";
            }
            if (dgvr.Cells[tpA1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                tpA1 += "C";
            }
            if (dgvr.Cells[tpA2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                tpA2 += "C";
            }
            if (dgvr.Cells[rinsan1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                rinsan1 += "C";
            }
            if (dgvr.Cells[rinsan2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                rinsan2 += "C";
            }
            if (dgvr.Cells[no2nTeiryo1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                no2nTeiryo1 += "C";
            }
            if (dgvr.Cells[no2nTeiryo2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                no2nTeiryo2 += "C";
            }
            if (dgvr.Cells[no3nTeiryo1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                no3nTeiryo1 += "C";
            }
            if (dgvr.Cells[no3nTeiryo2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                no3nTeiryo2 += "C";
            }
            if (dgvr.Cells[absB1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                absB1 += "C";
            }
            if (dgvr.Cells[absB2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                absB2 += "C";
            }
            if (dgvr.Cells[tnB1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                tnB1 += "C";
            }
            if (dgvr.Cells[tnB2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                tnB2 += "C";
            }
            if (dgvr.Cells[tpB1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                tpB1 += "C";
            }
            if (dgvr.Cells[tpB2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                tpB2 += "C";
            }
            if (dgvr.Cells[shikido1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                shikido1 += "C";
            }
            if (dgvr.Cells[shikido2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                shikido2 += "C";
            }
            if (dgvr.Cells[bodB1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                bodB1 += "C";
            }
            if (dgvr.Cells[bodB2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                bodB2 += "C";
            }
            if (dgvr.Cells[hekisanKoyu1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                hekisanKoyu1 += "C";
            }
            if (dgvr.Cells[hekisanKoyu2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                hekisanKoyu2 += "C";
            }
            if (dgvr.Cells[hekisanDoshoku1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                hekisanDoshoku1 += "C";
            }
            if (dgvr.Cells[hekisanDoshoku2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                hekisanDoshoku2 += "C";
            }
            if (dgvr.Cells[hekisanB1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                hekisanB1 += "C";
            }
            if (dgvr.Cells[hekisanB2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                hekisanB2 += "C";
            }
            if (dgvr.Cells[namari1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                namari1 += "C";
            }
            if (dgvr.Cells[namari2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                namari2 += "C";
            }
            if (dgvr.Cells[aen1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                aen1 += "C";
            }
            if (dgvr.Cells[aen2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                aen2 += "C";
            }
            if (dgvr.Cells[houso1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                houso1 += "C";
            }
            if (dgvr.Cells[houso2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                houso2 += "C";
            }
            if (dgvr.Cells[zanen1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                zanen1 += "C";
            }
            if (dgvr.Cells[zanen2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                zanen2 += "C";
            }
            if (dgvr.Cells[gaikan1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                gaikan1 += "C";
            }
            if (dgvr.Cells[gaikan2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                gaikan2 += "C";
            }
            if (dgvr.Cells[shuki1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                shuki1 += "C";
            }
            if (dgvr.Cells[shuki2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                shuki2 += "C";
            }
            if (dgvr.Cells[tr1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                tr1 += "C";
            }
            if (dgvr.Cells[tr2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                tr2 += "C";
            }
            if (dgvr.Cells[no2nTeisei1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                no2nTeisei1 += "C";
            }
            if (dgvr.Cells[no2nTeisei2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                no2nTeisei2 += "C";
            }
            if (dgvr.Cells[no3nTeisei1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                no3nTeisei1 += "C";
            }
            if (dgvr.Cells[no3nTeisei2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                no3nTeisei2 += "C";
            }
            if (dgvr.Cells[daichokin1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                daichokin1 += "C";
            }
            if (dgvr.Cells[daichokin2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                daichokin2 += "C";
            }
            #endregion

            #region 表示文字列編集(塩化物イオン確認検査)
            if (dgvr.Cells[cl1KensaShubetsuEnkaIon.Index].Value.ToString() == "2")
            {
                cl1 += "D";
            }
            if (dgvr.Cells[cl2KensaShubetsuEnkaIon.Index].Value.ToString() == "2")
            {
                cl2 += "D";
            }
            #endregion

            #region 表示文字列編集(アンモニア確認検査)
            if (dgvr.Cells[nh4n1KensaShubetsuAnmonia.Index].Value.ToString() == "2")
            {
                nh4n1 += "E";
            }
            if (dgvr.Cells[nh4n2KensaShubetsuAnmonia.Index].Value.ToString() == "2")
            {
                nh4n2 += "E";
            }
            #endregion

            #region 表示文字列編集(アンモニアと全窒素の比較)
            if (dgvr.Cells[nh4n1KensaShubetsuAnmoniaTn.Index].Value.ToString() == "2")
            {
                nh4n1 += "F";
            }
            if (dgvr.Cells[nh4n2KensaShubetsuAnmoniaTn.Index].Value.ToString() == "2")
            {
                nh4n2 += "F";
            }
            if (dgvr.Cells[tnA1KensaShubetsuAnmoniaTn.Index].Value.ToString() == "2")
            {
                tnA1 += "F";
            }
            if (dgvr.Cells[tnA2KensaShubetsuAnmoniaTn.Index].Value.ToString() == "2")
            {
                tnA2 += "F";
            }
            if (dgvr.Cells[tnB1KensaShubetsuAnmoniaTn.Index].Value.ToString() == "2")
            {
                tnB1 += "F";
            }
            if (dgvr.Cells[tnB2KensaShubetsuAnmoniaTn.Index].Value.ToString() == "2")
            {
                tnB2 += "F";
            }
            #endregion

            #region 表示文字列編集(COD基準値オーバー)
            if (dgvr.Cells[cod1KensaShubetsuCodOver.Index].Value.ToString() == "2")
            {
                cod1 += "G";
            }
            if (dgvr.Cells[cod2KensaShubetsuCodOver.Index].Value.ToString() == "2")
            {
                cod2 += "G";
            }
            #endregion

            #region 結果表示
            dgvr.Cells[kakuninKensaPh1Col.Index].Value = ph1;
            dgvr.Cells[kakuninKensaPh2Col.Index].Value = ph2;
            dgvr.Cells[kakuninKensaSs1Col.Index].Value = ss1;
            dgvr.Cells[kakuninKensaSs2Col.Index].Value = ss2;
            dgvr.Cells[kakuninKensaBodA1Col.Index].Value = bodA1;
            dgvr.Cells[kakuninKensaBodA2Col.Index].Value = bodA2;
            dgvr.Cells[kakuninKensaNh4n1Col.Index].Value = nh4n1;
            dgvr.Cells[kakuninKensaNh4n2Col.Index].Value = nh4n2;
            dgvr.Cells[kakuninKensaCl1Col.Index].Value = cl1;
            dgvr.Cells[kakuninKensaCl2Col.Index].Value = cl2;
            dgvr.Cells[kakuninKensaCod1Col.Index].Value = cod1;
            dgvr.Cells[kakuninKensaCod2Col.Index].Value = cod2;
            dgvr.Cells[kakuninKensaHekisanA1Col.Index].Value = hekisanA1;
            dgvr.Cells[kakuninKensaHekisanA2Col.Index].Value = hekisanA2;
            dgvr.Cells[kakuninKensaMlss1Col.Index].Value = mlss1;
            dgvr.Cells[kakuninKensaMlss2Col.Index].Value = mlss2;
            dgvr.Cells[kakuninKensaTnA1Col.Index].Value = tnA1;
            dgvr.Cells[kakuninKensaTnA2Col.Index].Value = tnA2;
            dgvr.Cells[kakuninKensaAbsA1Col.Index].Value = absA1;
            dgvr.Cells[kakuninKensaAbsA2Col.Index].Value = absA2;
            dgvr.Cells[kakuninKensaTpA1Col.Index].Value = tpA1;
            dgvr.Cells[kakuninKensaTpA2Col.Index].Value = tpA2;
            dgvr.Cells[kakuninKensaRinsan1Col.Index].Value = rinsan1;
            dgvr.Cells[kakuninKensaRinsan2Col.Index].Value = rinsan2;
            dgvr.Cells[kakuninKensaNo2nTeiryo1Col.Index].Value = no2nTeiryo1;
            dgvr.Cells[kakuninKensaNo2nTeiryo2Col.Index].Value = no2nTeiryo2;
            dgvr.Cells[kakuninKensaNo3nTeiryo1Col.Index].Value = no3nTeiryo1;
            dgvr.Cells[kakuninKensaNo3nTeiryo2Col.Index].Value = no3nTeiryo2;
            dgvr.Cells[kakuninKensaAbsB1Col.Index].Value = absB1;
            dgvr.Cells[kakuninKensaAbsB2Col.Index].Value = absB2;
            dgvr.Cells[kakuninKensaTnB1Col.Index].Value = tnB1;
            dgvr.Cells[kakuninKensaTnB2Col.Index].Value = tnB2;
            dgvr.Cells[kakuninKensaTpB1Col.Index].Value = tpB1;
            dgvr.Cells[kakuninKensaTpB2Col.Index].Value = tpB2;
            dgvr.Cells[kakuninKensaShikido1Col.Index].Value = shikido1;
            dgvr.Cells[kakuninKensaShikido2Col.Index].Value = shikido2;
            dgvr.Cells[kakuninKensaBodB1Col.Index].Value = bodB1;
            dgvr.Cells[kakuninKensaBodB2Col.Index].Value = bodB2;
            dgvr.Cells[kakuninKensaHekisanKoyu1Col.Index].Value = hekisanKoyu1;
            dgvr.Cells[kakuninKensaHekisanKoyu2Col.Index].Value = hekisanKoyu2;
            dgvr.Cells[kakuninKensaHekisanDoshoku1Col.Index].Value = hekisanDoshoku1;
            dgvr.Cells[kakuninKensaHekisanDoshoku2Col.Index].Value = hekisanDoshoku2;
            dgvr.Cells[kakuninKensaHekisanB1Col.Index].Value = hekisanB1;
            dgvr.Cells[kakuninKensaHekisanB2Col.Index].Value = hekisanB2;
            dgvr.Cells[kakuninKensaNamari1Col.Index].Value = namari1;
            dgvr.Cells[kakuninKensaNamari2Col.Index].Value = namari2;
            dgvr.Cells[kakuninKensaAen1Col.Index].Value = aen1;
            dgvr.Cells[kakuninKensaAen2Col.Index].Value = aen2;
            dgvr.Cells[kakuninKensaHouso1Col.Index].Value = houso1;
            dgvr.Cells[kakuninKensaHouso2Col.Index].Value = houso2;
            dgvr.Cells[kakuninKensaZanen1Col.Index].Value = zanen1;
            dgvr.Cells[kakuninKensaZanen2Col.Index].Value = zanen2;
            dgvr.Cells[kakuninKensaGaikan1Col.Index].Value = gaikan1;
            dgvr.Cells[kakuninKensaGaikan2Col.Index].Value = gaikan2;
            dgvr.Cells[kakuninKensaShuki1Col.Index].Value = shuki1;
            dgvr.Cells[kakuninKensaShuki2Col.Index].Value = shuki2;
            dgvr.Cells[kakuninKensaTr1Col.Index].Value = tr1;
            dgvr.Cells[kakuninKensaTr2Col.Index].Value = tr2;
            dgvr.Cells[kakuninKensaNo2nTeisei1Col.Index].Value = no2nTeisei1;
            dgvr.Cells[kakuninKensaNo2nTeisei2Col.Index].Value = no2nTeisei2;
            dgvr.Cells[kakuninKensaNo3nTeisei1Col.Index].Value = no3nTeisei1;
            dgvr.Cells[kakuninKensaNo3nTeisei2Col.Index].Value = no3nTeisei2;
            dgvr.Cells[kakuninKensaDaichokin1Col.Index].Value = daichokin1;
            dgvr.Cells[kakuninKensaDaichokin2Col.Index].Value = daichokin2;
            #endregion
        }
        #endregion

        #region 背景色の判定
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckBackColor
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/05　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CheckBackColor(DataGridViewRow dgvr)
        {
            #region 未入力
            if (dgvr.Cells[kekkaNyuryokuPh1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, ph1Col.Index, ph2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuPh2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, ph1Col.Index, ph2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuSs1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, ss1Col.Index, ss2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuSs2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, ss1Col.Index, ss2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuBodA1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, bodA1Col.Index, bodA2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuBodA2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, bodA1Col.Index, bodA2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNh4n1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, nh4n1Col.Index, nh4n2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNh4n2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, nh4n1Col.Index, nh4n2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, cl1Col.Index, cl2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuCl2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, cl1Col.Index, cl2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuCod1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, cod1Col.Index, cod2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuCod2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, cod1Col.Index, cod2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuHekisanA1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, hekisanA1Col.Index, hekisanA2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuHekisanA2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, hekisanA1Col.Index, hekisanA2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuMlss1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, mlss1Col.Index, mlss2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuMlss2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, mlss1Col.Index, mlss2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTnA1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, tnA1Col.Index, tnA2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTnA2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, tnA1Col.Index, tnA2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuAbsA1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, absA1Col.Index, absA2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuAbsA2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, absA1Col.Index, absA2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTpA1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, tpA1Col.Index, tpA2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTpA2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, tpA1Col.Index, tpA2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuRinsan1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, rinsan1Col.Index, rinsan2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuRinsan2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, rinsan1Col.Index, rinsan2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNo2nTeiryo1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, no2nTeiryo1Col.Index, no2nTeiryo2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNo2nTeiryo2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, no2nTeiryo1Col.Index, no2nTeiryo2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNo3nTeiryo1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, no3nTeiryo1Col.Index, no3nTeiryo2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNo3nTeiryo2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, no3nTeiryo1Col.Index, no3nTeiryo2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuAbsB1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, absB1Col.Index, absB2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuAbsB2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, absB1Col.Index, absB2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTnB1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, tnB1Col.Index, tnB2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTnB2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, tnB1Col.Index, tnB2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTpB1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, tpB1Col.Index, tpB2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTpB2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, tpB1Col.Index, tpB2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuShikido1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, shikido1Col.Index, shikido2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuShikido2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, shikido1Col.Index, shikido2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuBodB1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, bodB1Col.Index, bodB2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuBodB2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, bodB1Col.Index, bodB2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuHekisanKoyu1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, hekisanKoyu1Col.Index, hekisanKoyu2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuHekisanKoyu2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, hekisanKoyu1Col.Index, hekisanKoyu2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuHekisanDoshoku1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, hekisanDoshoku1Col.Index, hekisanDoshoku2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuHekisanDoshoku2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, hekisanDoshoku1Col.Index, hekisanDoshoku2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuHekisanB1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, hekisanB1Col.Index, hekisanB2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuHekisanB2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, hekisanB1Col.Index, hekisanB2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNamari1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, namari1Col.Index, namari2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNamari2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, namari1Col.Index, namari2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuAen1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, aen1Col.Index, aen2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuAen2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, aen1Col.Index, aen2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuHouso1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, houso1Col.Index, houso2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuHouso2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, houso1Col.Index, houso2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuZanen1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, zanen1Col.Index, zanen2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuZanen2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, zanen1Col.Index, zanen2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuGaikan1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, gaikan1Col.Index, gaikan2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuGaikan2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, gaikan1Col.Index, gaikan2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuShuki1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, shuki1Col.Index, shuki2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuShuki2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, shuki1Col.Index, shuki2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTr1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, tr1Col.Index, tr2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTr2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, tr1Col.Index, tr2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNo2nTeisei1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, no2nTeisei1Col.Index, no2nTeisei2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNo2nTeisei2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, no2nTeisei1Col.Index, no2nTeisei2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNo3nTeisei1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, no3nTeisei1Col.Index, no3nTeisei2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNo3nTeisei2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, no3nTeisei1Col.Index, no3nTeisei2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuDaichokin1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, daichokin1Col.Index, daichokin2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuDaichokin2Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, daichokin1Col.Index, daichokin2Col.Index);
            }
            #endregion

            #region 確認検査対象
            if (dgvr.Cells[kakuninKensaPh1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, ph1Col.Index, ph2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaPh2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, ph1Col.Index, ph2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaSs1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, ss1Col.Index, ss2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaSs2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, ss1Col.Index, ss2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaBodA1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, bodA1Col.Index, bodA2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaBodA2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, bodA1Col.Index, bodA2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaNh4n1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, nh4n1Col.Index, nh4n2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaNh4n2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, nh4n1Col.Index, nh4n2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaCl1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, cl1Col.Index, cl2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaCl2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, cl1Col.Index, cl2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaCod1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, cod1Col.Index, cod2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaCod2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, cod1Col.Index, cod2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaHekisanA1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, hekisanA1Col.Index, hekisanA2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaHekisanA2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, hekisanA1Col.Index, hekisanA2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaMlss1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, mlss1Col.Index, mlss2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaMlss2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, mlss1Col.Index, mlss2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaTnA1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, tnA1Col.Index, tnA2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaTnA2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, tnA1Col.Index, tnA2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaAbsA1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, absA1Col.Index, absA2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaAbsA2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, absA1Col.Index, absA2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaTpA1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, tpA1Col.Index, tpA2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaTpA2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, tpA1Col.Index, tpA2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaRinsan1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, rinsan1Col.Index, rinsan2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaRinsan2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, rinsan1Col.Index, rinsan2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaNo2nTeiryo1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, no2nTeiryo1Col.Index, no2nTeiryo2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaNo2nTeiryo2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, no2nTeiryo1Col.Index, no2nTeiryo2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaNo3nTeiryo1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, no3nTeiryo1Col.Index, no3nTeiryo2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaNo3nTeiryo2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, no3nTeiryo1Col.Index, no3nTeiryo2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaAbsB1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, absB1Col.Index, absB2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaAbsB2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, absB1Col.Index, absB2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaTnB1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, tnB1Col.Index, tnB2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaTnB2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, tnB1Col.Index, tnB2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaTpB1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, tpB1Col.Index, tpB2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaTpB2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, tpB1Col.Index, tpB2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaShikido1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, shikido1Col.Index, shikido2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaShikido2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, shikido1Col.Index, shikido2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaBodB1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, bodB1Col.Index, bodB2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaBodB2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, bodB1Col.Index, bodB2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaHekisanKoyu1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, hekisanKoyu1Col.Index, hekisanKoyu2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaHekisanKoyu2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, hekisanKoyu1Col.Index, hekisanKoyu2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaHekisanDoshoku1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, hekisanDoshoku1Col.Index, hekisanDoshoku2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaHekisanDoshoku2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, hekisanDoshoku1Col.Index, hekisanDoshoku2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaHekisanB1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, hekisanB1Col.Index, hekisanB2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaHekisanB2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, hekisanB1Col.Index, hekisanB2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaNamari1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, namari1Col.Index, namari2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaNamari2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, namari1Col.Index, namari2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaAen1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, aen1Col.Index, aen2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaAen2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, aen1Col.Index, aen2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaHouso1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, houso1Col.Index, houso2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaHouso2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, houso1Col.Index, houso2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaZanen1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, zanen1Col.Index, zanen2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaZanen2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, zanen1Col.Index, zanen2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaGaikan1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, gaikan1Col.Index, gaikan2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaGaikan2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, gaikan1Col.Index, gaikan2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaShuki1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, shuki1Col.Index, shuki2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaShuki2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, shuki1Col.Index, shuki2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaTr1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, tr1Col.Index, tr2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaTr2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, tr1Col.Index, tr2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaNo2nTeisei1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, no2nTeisei1Col.Index, no2nTeisei2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaNo2nTeisei2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, no2nTeisei1Col.Index, no2nTeisei2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaNo3nTeisei1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, no3nTeisei1Col.Index, no3nTeisei2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaNo3nTeisei2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, no3nTeisei1Col.Index, no3nTeisei2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaDaichokin1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, daichokin1Col.Index, daichokin2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaDaichokin2Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, daichokin1Col.Index, daichokin2Col.Index);
            }
            #endregion

            #region 対象外
            if (dgvr.Cells[kekkaNyuryokuPh1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, ph1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuPh2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, ph2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuSs1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, ss1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuSs2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, ss2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuBodA1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, bodA1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuBodA2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, bodA2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNh4n1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, nh4n1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNh4n2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, nh4n2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, cl1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuCl2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, cl2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuCod1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, cod1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuCod2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, cod2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuHekisanA1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, hekisanA1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuHekisanA2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, hekisanA2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuMlss1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, mlss1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuMlss2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, mlss2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTnA1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, tnA1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTnA2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, tnA2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuAbsA1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, absA1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuAbsA2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, absA2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTpA1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, tpA1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTpA2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, tpA2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuRinsan1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, rinsan1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuRinsan2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, rinsan2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNo2nTeiryo1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, no2nTeiryo1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNo2nTeiryo2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, no2nTeiryo2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNo3nTeiryo1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, no3nTeiryo1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNo3nTeiryo2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, no3nTeiryo2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuAbsB1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, absB1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuAbsB2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, absB2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTnB1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, tnB1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTnB2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, tnB2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTpB1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, tpB1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTpB2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, tpB2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuShikido1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, shikido1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuShikido2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, shikido2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuBodB1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, bodB1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuBodB2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, bodB2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuHekisanKoyu1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, hekisanKoyu1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuHekisanKoyu2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, hekisanKoyu2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuHekisanDoshoku1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, hekisanDoshoku1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuHekisanDoshoku2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, hekisanDoshoku2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuHekisanB1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, hekisanB1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuHekisanB2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, hekisanB2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNamari1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, namari1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNamari2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, namari2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuAen1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, aen1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuAen2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, aen2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuHouso1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, houso1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuHouso2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, houso2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuZanen1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, zanen1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuZanen2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, zanen2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuGaikan1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, gaikan1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuGaikan2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, gaikan2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuShuki1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, shuki1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuShuki2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, shuki2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTr1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, tr1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTr2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, tr2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNo2nTeisei1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, no2nTeisei1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNo2nTeisei2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, no2nTeisei2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNo3nTeisei1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, no3nTeisei1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuNo3nTeisei2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, no3nTeisei2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuDaichokin1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, daichokin1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuDaichokin2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, daichokin2Col.Index);
            }
            #endregion
        }
        #endregion

        #region 背景色の設定
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetBackColor
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/05　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetBackColor(DataGridViewRow dgvr, Color color, int col1Idx, int col2Idx = -1)
        {
            dgvr.Cells[col1Idx].Style.BackColor = color;
            dgvr.Cells[col1Idx + 1].Style.BackColor = color;
            dgvr.Cells[col1Idx + 2].Style.BackColor = color;
            dgvr.Cells[col1Idx + 3].Style.BackColor = color;
            if ((col1Idx == ph1Col.Index) || (col1Idx == ph2Col.Index))
            {
                dgvr.Cells[col1Idx + 4].Style.BackColor = color;
            }

            if (col2Idx >= 0)
            {
                dgvr.Cells[col2Idx].Style.BackColor = color;
                dgvr.Cells[col2Idx + 1].Style.BackColor = color;
                dgvr.Cells[col2Idx + 2].Style.BackColor = color;
                dgvr.Cells[col2Idx + 3].Style.BackColor = color;
                if ((col2Idx == ph1Col.Index) || (col2Idx == ph2Col.Index))
                {
                    dgvr.Cells[col2Idx + 4].Style.BackColor = color;
                }
            }
        }
        #endregion

        #region 各検査項目の状態設定
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetKmkPropaty
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/05　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetKmkPropaty(DataGridViewRow dgvr)
        {
            // 状態設定
            if ((dgvr.Cells[kachoKeninCol.Index].Value.ToString() == CheckOn)
                || (dgvr.Cells[hukukachoKeninCol.Index].Value.ToString() == CheckOn)
                || (dgvr.Cells[kanrishaKeninCol.Index].Value.ToString() == CheckOn))
            {
                // 状態設定(検印)
                SetKmkPropatyKenin(dgvr);
            }
            else
            {
                #region 各試験項目の状態設定
                // 状態設定(pH)
                SetKmkPropatyPh(dgvr, ph1Col.Index);
                // 状態設定(SS)
                SetKmkPropatyAll(dgvr, ss1Col.Index);
                // 状態設定(BOD（A）)
                SetKmkPropatyAll(dgvr, bodA1Col.Index);
                // 状態設定(アンモニア性窒素)
                SetKmkPropatyAll(dgvr, nh4n1Col.Index);
                // 状態設定(塩化物イオン)
                SetKmkPropatyAll(dgvr, cl1Col.Index);
                // 状態設定(COD)
                SetKmkPropatyAll(dgvr, cod1Col.Index);
                // 状態設定(ヘキサン抽出物質（A）)
                SetKmkPropatyAll(dgvr, hekisanA1Col.Index);
                // 状態設定(MLSS)
                SetKmkPropatyAll(dgvr, mlss1Col.Index);
                // 状態設定(全窒素（A))
                SetKmkPropatyAll(dgvr, tnA1Col.Index);
                // 状態設定(陰イオン界面活性剤（A）)
                SetKmkPropatyAll(dgvr, absA1Col.Index);
                // 状態設定(全りん（A))
                SetKmkPropatyAll(dgvr, tpA1Col.Index);
                // 状態設定(りん酸イオン)
                SetKmkPropatyAll(dgvr, rinsan1Col.Index);
                // 状態設定(亜硝酸性窒素（定量）)
                SetKmkPropatyAll(dgvr, no2nTeiryo1Col.Index);
                // 状態設定(硝酸性窒素（定量）)
                SetKmkPropatyAll(dgvr, no3nTeiryo1Col.Index);
                // 状態設定(陰イオン界面活性剤（B))
                SetKmkPropatyAll(dgvr, absB1Col.Index);
                // 状態設定(全窒素（B))
                SetKmkPropatyAll(dgvr, tnB1Col.Index);
                // 状態設定(全りん（B))
                SetKmkPropatyAll(dgvr, tpB1Col.Index);
                // 状態設定(色度)
                SetKmkPropatyAll(dgvr, shikido1Col.Index);
                // 状態設定(BOD（B）)
                SetKmkPropatyAll(dgvr, bodB1Col.Index);
                // 状態設定(ヘキサン抽出物質（鉱油類）)
                SetKmkPropatyAll(dgvr, hekisanKoyu1Col.Index);
                // 状態設定(ヘキサン抽出物質（動植物油類）)
                SetKmkPropatyAll(dgvr, hekisanDoshoku1Col.Index);
                // 状態設定(ヘキサン抽出物質（B）)
                SetKmkPropatyAll(dgvr, hekisanB1Col.Index);
                // 状態設定(鉛)
                SetKmkPropatyAll(dgvr, namari1Col.Index);
                // 状態設定(亜鉛)
                SetKmkPropatyAll(dgvr, aen1Col.Index);
                // 状態設定(ほう素)
                SetKmkPropatyAll(dgvr, houso1Col.Index);
                // 状態設定(残塩)
                SetKmkPropatyAll(dgvr, zanen1Col.Index);
                // 状態設定(外観)
                SetKmkPropatyAll(dgvr, gaikan1Col.Index);
                // 状態設定(臭気)
                SetKmkPropatyAll(dgvr, shuki1Col.Index);
                // 状態設定(透視度)
                SetKmkPropatyAll(dgvr, tr1Col.Index);
                // 状態設定(亜硝酸性窒素（定性）)
                SetKmkPropatyAll(dgvr, no2nTeisei1Col.Index);
                // 状態設定(硝酸性窒素（定性）)
                SetKmkPropatyAll(dgvr, no3nTeisei1Col.Index);
                // 状態設定(大腸菌群数)
                SetKmkPropatyAll(dgvr, daichokin1Col.Index);
                #endregion

                // 検印可否判定
                if (keninKahiHantei(dgvr))
                {
                    dgvr.Cells[kachoKeninCol.Index].ReadOnly = false;
                    dgvr.Cells[hukukachoKeninCol.Index].ReadOnly = false;
                    dgvr.Cells[kanrishaKeninCol.Index].ReadOnly = false;
                }
                else
                {
                    dgvr.Cells[kachoKeninCol.Index].ReadOnly = true;
                    dgvr.Cells[hukukachoKeninCol.Index].ReadOnly = true;
                    dgvr.Cells[kanrishaKeninCol.Index].ReadOnly = true;
                }
            }
        }
        #endregion

        #region 各検査項目の状態設定(検印)
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetKmkPropatyKentai
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/05　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetKmkPropatyKenin(DataGridViewRow dgvr)
        {
            // pH1
            dgvr.Cells[ph1Col.Index].ReadOnly = true;
            dgvr.Cells[ondo1Col.Index].ReadOnly = true;
            dgvr.Cells[ph1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiPh1Col.Index].ReadOnly = true;
            // pH2
            dgvr.Cells[ph2Col.Index].ReadOnly = true;
            dgvr.Cells[ondo2Col.Index].ReadOnly = true;
            dgvr.Cells[ph2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiPh2Col.Index].ReadOnly = true;
            // SS1
            dgvr.Cells[ss1Col.Index].ReadOnly = true;
            dgvr.Cells[ss1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiSs1Col.Index].ReadOnly = true;
            // SS2
            dgvr.Cells[ss2Col.Index].ReadOnly = true;
            dgvr.Cells[ss2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiSs2Col.Index].ReadOnly = true;
            // BOD（A）1
            dgvr.Cells[bodA1Col.Index].ReadOnly = true;
            dgvr.Cells[bodA1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiBodA1Col.Index].ReadOnly = true;
            // BOD（A）2
            dgvr.Cells[bodA2Col.Index].ReadOnly = true;
            dgvr.Cells[bodA2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiBodA2Col.Index].ReadOnly = true;
            // アンモニア性窒素1
            dgvr.Cells[nh4n1Col.Index].ReadOnly = true;
            dgvr.Cells[nh4n1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiNh4n1Col.Index].ReadOnly = true;
            // アンモニア性窒素2
            dgvr.Cells[nh4n2Col.Index].ReadOnly = true;
            dgvr.Cells[nh4n2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiNh4n2Col.Index].ReadOnly = true;
            // 塩化物イオン1
            dgvr.Cells[cl1Col.Index].ReadOnly = true;
            dgvr.Cells[cl1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiCl1Col.Index].ReadOnly = true;
            // 塩化物イオン2
            dgvr.Cells[cl2Col.Index].ReadOnly = true;
            dgvr.Cells[cl2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiCl2Col.Index].ReadOnly = true;
            // COD1
            dgvr.Cells[cod1Col.Index].ReadOnly = true;
            dgvr.Cells[cod1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiCod1Col.Index].ReadOnly = true;
            // COD2
            dgvr.Cells[cod2Col.Index].ReadOnly = true;
            dgvr.Cells[cod2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiCod2Col.Index].ReadOnly = true;
            // ヘキサン抽出物質（A）1
            dgvr.Cells[hekisanA1Col.Index].ReadOnly = true;
            dgvr.Cells[hekisanA1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiHekisanA1Col.Index].ReadOnly = true;
            // ヘキサン抽出物質（A）2
            dgvr.Cells[hekisanA2Col.Index].ReadOnly = true;
            dgvr.Cells[hekisanA2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiHekisanA2Col.Index].ReadOnly = true;
            // MLSS1
            dgvr.Cells[mlss1Col.Index].ReadOnly = true;
            dgvr.Cells[mlss1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiMlss1Col.Index].ReadOnly = true;
            // MLSS2
            dgvr.Cells[mlss2Col.Index].ReadOnly = true;
            dgvr.Cells[mlss2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiMlss2Col.Index].ReadOnly = true;
            // 全窒素（A)1
            dgvr.Cells[tnA1Col.Index].ReadOnly = true;
            dgvr.Cells[tnA1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiTnA1Col.Index].ReadOnly = true;
            // 全窒素（A)2
            dgvr.Cells[tnA2Col.Index].ReadOnly = true;
            dgvr.Cells[tnA2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiTnA2Col.Index].ReadOnly = true;
            // 陰イオン界面活性剤（A）1
            dgvr.Cells[absA1Col.Index].ReadOnly = true;
            dgvr.Cells[absA1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiAbsA1Col.Index].ReadOnly = true;
            // 陰イオン界面活性剤（A）2
            dgvr.Cells[absA2Col.Index].ReadOnly = true;
            dgvr.Cells[absA2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiAbsA2Col.Index].ReadOnly = true;
            // 全りん（A)1
            dgvr.Cells[tpA1Col.Index].ReadOnly = true;
            dgvr.Cells[tpA1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiTpA1Col.Index].ReadOnly = true;
            // 全りん（A)2
            dgvr.Cells[tpA2Col.Index].ReadOnly = true;
            dgvr.Cells[tpA2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiTpA2Col.Index].ReadOnly = true;
            // りん酸イオン1
            dgvr.Cells[rinsan1Col.Index].ReadOnly = true;
            dgvr.Cells[rinsan1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiRinsan1Col.Index].ReadOnly = true;
            // りん酸イオン2
            dgvr.Cells[rinsan2Col.Index].ReadOnly = true;
            dgvr.Cells[rinsan2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiRinsan2Col.Index].ReadOnly = true;
            // 亜硝酸性窒素（定量）1
            dgvr.Cells[no2nTeiryo1Col.Index].ReadOnly = true;
            dgvr.Cells[no2nTeiryo1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiNo2nTeiryo1Col.Index].ReadOnly = true;
            // 亜硝酸性窒素（定量）2
            dgvr.Cells[no2nTeiryo2Col.Index].ReadOnly = true;
            dgvr.Cells[no2nTeiryo2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiNo2nTeiryo2Col.Index].ReadOnly = true;
            // 硝酸性窒素（定量）1
            dgvr.Cells[no3nTeiryo1Col.Index].ReadOnly = true;
            dgvr.Cells[no3nTeiryo1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiNo3nTeiryo1Col.Index].ReadOnly = true;
            // 硝酸性窒素（定量）2
            dgvr.Cells[no3nTeiryo2Col.Index].ReadOnly = true;
            dgvr.Cells[no3nTeiryo2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiNo3nTeiryo2Col.Index].ReadOnly = true;
            // 陰イオン界面活性剤（B)1
            dgvr.Cells[absB1Col.Index].ReadOnly = true;
            dgvr.Cells[absB1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiAbsB1Col.Index].ReadOnly = true;
            // 陰イオン界面活性剤（B)2
            dgvr.Cells[absB2Col.Index].ReadOnly = true;
            dgvr.Cells[absB2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiAbsB2Col.Index].ReadOnly = true;
            // 全窒素（B)1
            dgvr.Cells[tnB1Col.Index].ReadOnly = true;
            dgvr.Cells[tnB1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiTnB1Col.Index].ReadOnly = true;
            // 全窒素（B)2
            dgvr.Cells[tnB2Col.Index].ReadOnly = true;
            dgvr.Cells[tnB2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiTnB2Col.Index].ReadOnly = true;
            // 全りん（B)1
            dgvr.Cells[tpB1Col.Index].ReadOnly = true;
            dgvr.Cells[tpB1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiTpB1Col.Index].ReadOnly = true;
            // 全りん（B)2
            dgvr.Cells[tpB2Col.Index].ReadOnly = true;
            dgvr.Cells[tpB2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiTpB2Col.Index].ReadOnly = true;
            // 色度1
            dgvr.Cells[shikido1Col.Index].ReadOnly = true;
            dgvr.Cells[shikido1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiShikido1Col.Index].ReadOnly = true;
            // 色度2
            dgvr.Cells[shikido2Col.Index].ReadOnly = true;
            dgvr.Cells[shikido2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiShikido2Col.Index].ReadOnly = true;
            // BOD（B）1
            dgvr.Cells[bodB1Col.Index].ReadOnly = true;
            dgvr.Cells[bodB1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiBodB1Col.Index].ReadOnly = true;
            // BOD（B）2
            dgvr.Cells[bodB2Col.Index].ReadOnly = true;
            dgvr.Cells[bodB2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiBodB2Col.Index].ReadOnly = true;
            // ヘキサン抽出物質（鉱油類）1
            dgvr.Cells[hekisanKoyu1Col.Index].ReadOnly = true;
            dgvr.Cells[hekisanKoyu1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiHekisanKoyu1Col.Index].ReadOnly = true;
            // ヘキサン抽出物質（鉱油類）2
            dgvr.Cells[hekisanKoyu2Col.Index].ReadOnly = true;
            dgvr.Cells[hekisanKoyu2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiHekisanKoyu2Col.Index].ReadOnly = true;
            // ヘキサン抽出物質（動植物油類）1
            dgvr.Cells[hekisanDoshoku1Col.Index].ReadOnly = true;
            dgvr.Cells[hekisanDoshoku1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiHekisanDoshoku1Col.Index].ReadOnly = true;
            // ヘキサン抽出物質（動植物油類）2
            dgvr.Cells[hekisanDoshoku2Col.Index].ReadOnly = true;
            dgvr.Cells[hekisanDoshoku2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiHekisanDoshoku2Col.Index].ReadOnly = true;
            // ヘキサン抽出物質（B）1
            dgvr.Cells[hekisanB1Col.Index].ReadOnly = true;
            dgvr.Cells[hekisanB1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiHekisanB1Col.Index].ReadOnly = true;
            // ヘキサン抽出物質（B）2
            dgvr.Cells[hekisanB2Col.Index].ReadOnly = true;
            dgvr.Cells[hekisanB2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiHekisanB2Col.Index].ReadOnly = true;
            // 鉛1
            dgvr.Cells[namari1Col.Index].ReadOnly = true;
            dgvr.Cells[namari1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiNamari1Col.Index].ReadOnly = true;
            // 鉛2
            dgvr.Cells[namari2Col.Index].ReadOnly = true;
            dgvr.Cells[namari2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiNamari2Col.Index].ReadOnly = true;
            // 亜鉛1
            dgvr.Cells[aen1Col.Index].ReadOnly = true;
            dgvr.Cells[aen1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiAen1Col.Index].ReadOnly = true;
            // 亜鉛2
            dgvr.Cells[aen2Col.Index].ReadOnly = true;
            dgvr.Cells[aen2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiAen2Col.Index].ReadOnly = true;
            // ほう素1
            dgvr.Cells[houso1Col.Index].ReadOnly = true;
            dgvr.Cells[houso1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiHouso1Col.Index].ReadOnly = true;
            // ほう素2
            dgvr.Cells[houso2Col.Index].ReadOnly = true;
            dgvr.Cells[houso2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiHouso2Col.Index].ReadOnly = true;
            // 残塩1
            dgvr.Cells[zanen1Col.Index].ReadOnly = true;
            dgvr.Cells[zanen1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiZanen1Col.Index].ReadOnly = true;
            // 残塩2
            dgvr.Cells[zanen2Col.Index].ReadOnly = true;
            dgvr.Cells[zanen2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiZanen2Col.Index].ReadOnly = true;
            // 外観1
            dgvr.Cells[gaikan1Col.Index].ReadOnly = true;
            dgvr.Cells[gaikan1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiGaikan1Col.Index].ReadOnly = true;
            // 外観2
            dgvr.Cells[gaikan2Col.Index].ReadOnly = true;
            dgvr.Cells[gaikan2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiGaikan2Col.Index].ReadOnly = true;
            // 臭気1
            dgvr.Cells[shuki1Col.Index].ReadOnly = true;
            dgvr.Cells[shuki1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiShuki1Col.Index].ReadOnly = true;
            // 臭気2
            dgvr.Cells[shuki2Col.Index].ReadOnly = true;
            dgvr.Cells[shuki2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiShuki2Col.Index].ReadOnly = true;
            // 透視度1
            dgvr.Cells[tr1Col.Index].ReadOnly = true;
            dgvr.Cells[tr1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiTr1Col.Index].ReadOnly = true;
            // 透視度2
            dgvr.Cells[tr2Col.Index].ReadOnly = true;
            dgvr.Cells[tr2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiTr2Col.Index].ReadOnly = true;
            // 亜硝酸性窒素（定性）1
            dgvr.Cells[no2nTeisei1Col.Index].ReadOnly = true;
            dgvr.Cells[no2nTeisei1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiNo2nTeisei1Col.Index].ReadOnly = true;
            // 亜硝酸性窒素（定性）2
            dgvr.Cells[no2nTeisei2Col.Index].ReadOnly = true;
            dgvr.Cells[no2nTeisei2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiNo2nTeisei2Col.Index].ReadOnly = true;
            // 硝酸性窒素（定性）1
            dgvr.Cells[no3nTeisei1Col.Index].ReadOnly = true;
            dgvr.Cells[no3nTeisei1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiNo3nTeisei1Col.Index].ReadOnly = true;
            // 硝酸性窒素（定性）2
            dgvr.Cells[no3nTeisei2Col.Index].ReadOnly = true;
            dgvr.Cells[no3nTeisei2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiNo3nTeisei2Col.Index].ReadOnly = true;
            // 大腸菌群数1
            dgvr.Cells[daichokin1Col.Index].ReadOnly = true;
            dgvr.Cells[daichokin1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiDaichokin1Col.Index].ReadOnly = true;
            // 大腸菌群数2
            dgvr.Cells[daichokin2Col.Index].ReadOnly = true;
            dgvr.Cells[daichokin2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiDaichokin2Col.Index].ReadOnly = true;
        }
        #endregion

        #region 各検査項目の状態設定(pH)
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetKmkPropatyPh
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/05　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetKmkPropatyPh(DataGridViewRow dgvr, int index)
        {
            // 採用値(初回)
            dgvr.Cells[index + 4].ReadOnly = (dgvr.Cells[index + 6].Value.ToString() == "1" ? false : true);
            // 採用値(再検査)
            dgvr.Cells[index + 11].ReadOnly = (dgvr.Cells[index + 13].Value.ToString() == "1" ? false : true);

            // 状態設定(初回)
            if ((dgvr.Cells[index + 4].Value.ToString() == CheckOn)
                && (dgvr.Cells[index + 6].Value.ToString() == "1"))
            {
                //pH1
                dgvr.Cells[index].ReadOnly = false;
                dgvr.Cells[index].Style.Font = listDataGridView.DefaultCellStyle.Font;
                //温度1
                dgvr.Cells[index + 1].ReadOnly = false;
                dgvr.Cells[index + 1].Style.Font = listDataGridView.DefaultCellStyle.Font;
                //結果コード（pH1）
                dgvr.Cells[index + 2].ReadOnly = false;
                //pH2
                dgvr.Cells[index + 7].ReadOnly = true;
                dgvr.Cells[index + 7].Style.Font = underLineFont;
                //温度2
                dgvr.Cells[index + 8].ReadOnly = true;
                dgvr.Cells[index + 8].Style.Font = underLineFont;
                //結果コード（pH2）
                dgvr.Cells[index + 9].ReadOnly = true;
            }
            // 状態設定(再検査)
            else if ((dgvr.Cells[index + 11].Value.ToString() == CheckOn)
                && (dgvr.Cells[index + 13].Value.ToString() == "1"))
            {
                //pH1
                dgvr.Cells[index].ReadOnly = true;
                dgvr.Cells[index].Style.Font = underLineFont;
                //温度1
                dgvr.Cells[index + 1].ReadOnly = true;
                dgvr.Cells[index + 1].Style.Font = underLineFont;
                //結果コード（pH1）
                dgvr.Cells[index + 2].ReadOnly = true;
                //pH2
                dgvr.Cells[index + 7].ReadOnly = false;
                dgvr.Cells[index + 7].Style.Font = listDataGridView.DefaultCellStyle.Font;
                //温度2
                dgvr.Cells[index + 8].ReadOnly = false;
                dgvr.Cells[index + 8].Style.Font = listDataGridView.DefaultCellStyle.Font;
                //結果コード（pH2）
                dgvr.Cells[index + 9].ReadOnly = false;
            }
            // 対象外 or 未入力
            else
            {
                dgvr.Cells[index].ReadOnly = true;
                dgvr.Cells[index].Style.Font = listDataGridView.DefaultCellStyle.Font;
                dgvr.Cells[index + 1].ReadOnly = true;
                dgvr.Cells[index + 1].Style.Font = listDataGridView.DefaultCellStyle.Font;
                dgvr.Cells[index + 2].ReadOnly = true;
                dgvr.Cells[index + 2].Style.Font = listDataGridView.DefaultCellStyle.Font;
                dgvr.Cells[index + 7].ReadOnly = true;
                dgvr.Cells[index + 7].Style.Font = listDataGridView.DefaultCellStyle.Font;
                dgvr.Cells[index + 8].ReadOnly = true;
                dgvr.Cells[index + 8].Style.Font = listDataGridView.DefaultCellStyle.Font;
                dgvr.Cells[index + 9].ReadOnly = true;
                dgvr.Cells[index + 9].Style.Font = listDataGridView.DefaultCellStyle.Font;
            }
        }
        #endregion

        #region 各検査項目の状態設定(共通)
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetKmkPropatyAll
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/05　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetKmkPropatyAll(DataGridViewRow dgvr, int index)
        {
            // 採用値(初回)
            dgvr.Cells[index + 3].ReadOnly = (dgvr.Cells[index + 5].Value.ToString() == "1" ? false : true);
            // 採用値(再検査)
            dgvr.Cells[index + 9].ReadOnly = (dgvr.Cells[index + 11].Value.ToString() == "1" ? false : true);

            // 状態設定(初回)
            if ((dgvr.Cells[index + 3].Value.ToString() == CheckOn)
                && (dgvr.Cells[index + 5].Value.ToString() == "1"))
            {
                // 結果値1
                dgvr.Cells[index].ReadOnly = false;
                dgvr.Cells[index].Style.Font = listDataGridView.DefaultCellStyle.Font;
                // 結果コード1
                dgvr.Cells[index + 1].ReadOnly = false;
                // 結果値2
                dgvr.Cells[index + 6].ReadOnly = true;
                dgvr.Cells[index + 6].Style.Font = underLineFont;
                // 結果コード2
                dgvr.Cells[index + 7].ReadOnly = true;
            }
            // 状態設定(再検査)
            else if ((dgvr.Cells[index + 9].Value.ToString() == CheckOn)
                && (dgvr.Cells[index + 11].Value.ToString() == "1"))
            {
                // 結果値1
                dgvr.Cells[index].ReadOnly = true;
                dgvr.Cells[index].Style.Font = underLineFont;
                // 結果コード1
                dgvr.Cells[index + 1].ReadOnly = true;
                // 結果値2
                dgvr.Cells[index + 6].ReadOnly = false;
                dgvr.Cells[index + 6].Style.Font = listDataGridView.DefaultCellStyle.Font;
                // 結果コード2
                dgvr.Cells[index + 7].ReadOnly = false;
            }
            // 対象外 or 未入力
            else
            {
                dgvr.Cells[index].ReadOnly = true;
                dgvr.Cells[index].Style.Font = listDataGridView.DefaultCellStyle.Font;
                dgvr.Cells[index + 1].ReadOnly = true;
                dgvr.Cells[index + 1].Style.Font = listDataGridView.DefaultCellStyle.Font;
                dgvr.Cells[index + 6].ReadOnly = true;
                dgvr.Cells[index + 6].Style.Font = listDataGridView.DefaultCellStyle.Font;
                dgvr.Cells[index + 7].ReadOnly = true;
                dgvr.Cells[index + 7].Style.Font = listDataGridView.DefaultCellStyle.Font;
            }
        }
        #endregion

        #region 検印可否判定
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： keninKahiHantei
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/05　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool keninKahiHantei(DataGridViewRow dgvr)
        {
            bool res = true;

            // 検印不可判定(検査結果未入力)
            if((dgvr.Cells[kekkaNyuryokuPh1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuPh2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuSs1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuSs2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuBodA1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuBodA2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuNh4n1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuNh4n2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuCl2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuCod1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuCod2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuHekisanA1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuHekisanA2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuMlss1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuMlss2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuTnA1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuTnA2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuAbsA1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuAbsA2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuTpA1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuTpA2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuRinsan1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuRinsan2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuNo2nTeiryo1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuNo2nTeiryo2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuNo3nTeiryo1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuNo3nTeiryo2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuAbsB1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuAbsB2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuTnB1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuTnB2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuTpB1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuTpB2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuShikido1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuShikido2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuBodB1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuBodB2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuHekisanKoyu1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuHekisanKoyu2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuHekisanDoshoku1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuHekisanDoshoku2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuHekisanB1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuHekisanB2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuNamari1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuNamari2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuAen1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuAen2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuHouso1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuHouso2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuZanen1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuZanen2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuGaikan1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuGaikan2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuShuki1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuShuki2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuTr1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuTr2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuNo2nTeisei1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuNo2nTeisei2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuNo3nTeisei1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuNo3nTeisei2Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuDaichokin1Col.Index].Value.ToString() == "0")
                ||	(dgvr.Cells[kekkaNyuryokuDaichokin2Col.Index].Value.ToString() == "0"))
            {
                res = false;
            }

            return res;
        }
        #endregion

        #region 関連チェック
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RelationCheck
        /// <summary>
        /// 
        /// </summary>
        /// <output>戻り値：true = 正常、false  = エラー</output>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/04　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool RelationCheck()
        {
            if (shishoComboBox.SelectedIndex == 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "支所が選択されていません。");
                return false;
            }

            // 依頼受付日の関連チェック
            if (iraiUketsukeDtCheckBox.Checked)
            {
                if (iraiUketsukeDtFromDateTimePicker.Value > iraiUketsukeDtToDateTimePicker.Value)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "範囲指定が正しくありません。依頼受付日の大小関係を確認してください。");
                    return false;
                }
            }

            // 依頼Noの関連チェック
            if (!string.IsNullOrEmpty(iraiNoFromTextBox.Text) && (!string.IsNullOrEmpty(iraiNoToTextBox.Text)))
            {
                if (int.Parse(iraiNoFromTextBox.Text) > int.Parse(iraiNoToTextBox.Text))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "範囲指定が正しくありません。検体番号の大小関係を確認してください。");
                    return false;
                }
            }

            // 正常
            return true;
        }
        #endregion

        #region 編集内容破棄チェック
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RelationCheck
        /// <summary>
        /// 
        /// </summary>
        /// <output>戻り値：正常 = true、エラー = false</output>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/04　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool EditCheck()
        {
            bool res = true;

            // 検査台帳一覧の件数分繰り返す
            foreach (DataGridViewRow dgvr in listDataGridView.Rows)
            {
                // 各結果値の更新区分に"1"がある場合
                if ((dgvr.Cells[koshinKbnPh.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnSs.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnBodA.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnNh4n.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnCl.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnCod.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnHekisanA.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnMlss.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnTnA.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnAbsA.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnTpA.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnRinsan.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnNo2nTeiryo.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnNo3nTeiryo.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnAbsB.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnTnB.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnTpB.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnShikido.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnBodB.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnHekisanKoyu.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnHekisanDoshoku.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnHekisanB.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnNamari.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnAen.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnHouso.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnZanen.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnGaikan.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnShuki.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnTr.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnNo2nTeisei.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnNo3nTeisei.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnDaichokin.Index].Value.ToString() == "1"))
                {
                    res = false;
                    break;
                }

                // 各確認検査種別の更新区分に"1"がある場合
                if ((dgvr.Cells[koshinKbnSsTr.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnBodTr.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnEnkaIon.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnAnmonia.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnAnmoniaTn.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnCodOver.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoPh.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoSs.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoBodA.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoNh4n.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoCl.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoCod.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoHekisanA.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoMlss.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoTnA.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoAbsA.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoTpA.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoRinsan.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoNo2nTeiryo.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoNo3nTeiryo.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoAbsB.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoTnB.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoTpB.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoShikido.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoBodB.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoHekisanKoyu.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoHekisanDoshoku.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoHekisanB.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoNamari.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoAen.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoHouso.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoZanen.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoGaikan.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoShuki.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoTr.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoNo2nTeisei.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoNo3nTeisei.Index].Value.ToString() == "1")
                    || (dgvr.Cells[koshinKbnKakoDaichokin.Index].Value.ToString() == "1")
                    )
                {
                    res = false;
                    break;
                }
            }

            // 正常
            return res;
        }
        #endregion

        #region 検索条件の初期化
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SearchConditionClear
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/04　宗        新規作成
        /// 2015/01/27  宗        取得する支所マスタを全件から事務局以外に変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SearchConditionClear()
        {
            DateTime systemDt = Common.Common.GetCurrentTimestamp();

            //// 20150120 sou Start
            //shishoComboBox.SelectedValue = LoginUserShozokuShishoCd;
            //// 20150120 sou End
            if (LoginUserShozokuShishoCd == "0")
            {
                shishoComboBox.SelectedIndex = 0;
            }
            else
            {
                shishoComboBox.SelectedValue = LoginUserShozokuShishoCd;
            }

            // 20150115 habu 年度を初期設定するように変更
            nendoTextBox.Text = Utility.DateUtility.GetNendo(Common.Common.GetCurrentTimestamp()).ToString();
            //nendoTextBox.Text = string.Empty;

            iraiUketsukeDtCheckBox.Checked = false;
            iraiUketsukeDtFromDateTimePicker.Value = systemDt;
            iraiUketsukeDtToDateTimePicker.Value = systemDt;

            iraiNoFromTextBox.Text = string.Empty;
            iraiNoToTextBox.Text = string.Empty;
        }
        #endregion

        #region 試験項目コード取得
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetKmkCd
        /// <summary>
        /// 
        /// </summary>
        /// <input>
        /// string renban 定数マスタに設定している項目毎の連番
        /// </input>
        /// <output>
        /// string 試験項目コード
        /// </output>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetKmkCd(string renban)
        {
            string res = string.Empty;

            // 試験項目コードを設定
            foreach (DataRow dr in kmkCdDt.Rows)
            {
                if (dr[1].ToString() == renban)
                {
                    res = dr[3].ToString();
                    break;
                }
            }

            return res;
        }
        #endregion

        #region 検査項目の表示＆非表示を判定
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ChangeDisplayColumn
        /// <summary>
        /// 一覧全体で全く結果値が入力されていない列は非表示にする。初回と再検査はセットとして考える。
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/07　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ChangeDisplayColumn()
        {
            #region 初期化
            bool ph = false;
            bool ss = false;
            bool bodA = false;
            bool nh4n = false;
            bool cl = false;
            bool cod = false;
            bool hekisanA = false;
            bool mlss = false;
            bool tnA = false;
            bool absA = false;
            bool tpA = false;
            bool rinsan = false;
            bool no2nTeiryo = false;
            bool no3nTeiryo = false;
            bool absB = false;
            bool tnB = false;
            bool tpB = false;
            bool shikido = false;
            bool bodB = false;
            bool hekisanKoyu = false;
            bool hekisanDoshoku = false;
            bool hekisanB = false;
            bool namari = false;
            bool aen = false;
            bool houso = false;
            bool zanen = false;
            bool gaikan = false;
            bool shuki = false;
            bool tr = false;
            bool no2nTeisei = false;
            bool no3nTeisei = false;
            bool daichokin = false;

            int colCount = 0;
            #endregion

            #region 判定
            foreach (DataGridViewRow dgvr in listDataGridView.Rows)
            {
                // pH
                if ((dgvr.Cells[kekkaNyuryokuPh1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuPh2Col.Index].Value.ToString() != string.Empty))
                {
                    ph = true;
                }
                // SS
                if ((dgvr.Cells[kekkaNyuryokuSs1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuSs2Col.Index].Value.ToString() != string.Empty))
                {
                    ss = true;
                }
                // BOD（A）
                if ((dgvr.Cells[kekkaNyuryokuBodA1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuBodA2Col.Index].Value.ToString() != string.Empty))
                {
                    bodA = true;
                }
                // アンモニア性窒素
                if ((dgvr.Cells[kekkaNyuryokuNh4n1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuNh4n2Col.Index].Value.ToString() != string.Empty))
                {
                    nh4n = true;
                }
                // 塩化物イオン
                if ((dgvr.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuCl2Col.Index].Value.ToString() != string.Empty))
                {
                    cl = true;
                }
                // COD
                if ((dgvr.Cells[kekkaNyuryokuCod1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuCod2Col.Index].Value.ToString() != string.Empty))
                {
                    cod = true;
                }
                // ヘキサン抽出物質（A）
                if ((dgvr.Cells[kekkaNyuryokuHekisanA1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuHekisanA2Col.Index].Value.ToString() != string.Empty))
                {
                    hekisanA = true;
                }
                // MLSS
                if ((dgvr.Cells[kekkaNyuryokuMlss1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuMlss2Col.Index].Value.ToString() != string.Empty))
                {
                    mlss = true;
                }
                // 全窒素（A)
                if ((dgvr.Cells[kekkaNyuryokuTnA1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuTnA2Col.Index].Value.ToString() != string.Empty))
                {
                    tnA = true;
                }
                // 陰イオン界面活性剤（A）
                if ((dgvr.Cells[kekkaNyuryokuAbsA1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuAbsA2Col.Index].Value.ToString() != string.Empty))
                {
                    absA = true;
                }
                // 全りん（A)
                if ((dgvr.Cells[kekkaNyuryokuTpA1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuTpA2Col.Index].Value.ToString() != string.Empty))
                {
                    tpA = true;
                }
                // りん酸イオン
                if ((dgvr.Cells[kekkaNyuryokuRinsan1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuRinsan2Col.Index].Value.ToString() != string.Empty))
                {
                    rinsan = true;
                }
                // 亜硝酸性窒素（定量）
                if ((dgvr.Cells[kekkaNyuryokuNo2nTeiryo1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuNo2nTeiryo2Col.Index].Value.ToString() != string.Empty))
                {
                    no2nTeiryo = true;
                }
                // 硝酸性窒素（定量）
                if ((dgvr.Cells[kekkaNyuryokuNo3nTeiryo1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuNo3nTeiryo2Col.Index].Value.ToString() != string.Empty))
                {
                    no3nTeiryo = true;
                }
                // 陰イオン界面活性剤（B)
                if ((dgvr.Cells[kekkaNyuryokuAbsB1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuAbsB2Col.Index].Value.ToString() != string.Empty))
                {
                    absB = true;
                }
                // 全窒素（B)
                if ((dgvr.Cells[kekkaNyuryokuTnB1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuTnB2Col.Index].Value.ToString() != string.Empty))
                {
                    tnB = true;
                }
                // 全りん（B)
                if ((dgvr.Cells[kekkaNyuryokuTpB1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuTpB2Col.Index].Value.ToString() != string.Empty))
                {
                    tpB = true;
                }
                // 色度
                if ((dgvr.Cells[kekkaNyuryokuShikido1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuShikido2Col.Index].Value.ToString() != string.Empty))
                {
                    shikido = true;
                }
                // BOD（B）
                if ((dgvr.Cells[kekkaNyuryokuBodB1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuBodB2Col.Index].Value.ToString() != string.Empty))
                {
                    bodB = true;
                }
                // ヘキサン抽出物質（鉱油類）
                if ((dgvr.Cells[kekkaNyuryokuHekisanKoyu1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuHekisanKoyu2Col.Index].Value.ToString() != string.Empty))
                {
                    hekisanKoyu = true;
                }
                // ヘキサン抽出物質（動植物油類）
                if ((dgvr.Cells[kekkaNyuryokuHekisanDoshoku1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuHekisanDoshoku2Col.Index].Value.ToString() != string.Empty))
                {
                    hekisanDoshoku = true;
                }
                // ヘキサン抽出物質（B）
                if ((dgvr.Cells[kekkaNyuryokuHekisanB1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuHekisanB2Col.Index].Value.ToString() != string.Empty))
                {
                    hekisanB = true;
                }
                // 鉛
                if ((dgvr.Cells[kekkaNyuryokuNamari1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuNamari2Col.Index].Value.ToString() != string.Empty))
                {
                    namari = true;
                }
                // 亜鉛
                if ((dgvr.Cells[kekkaNyuryokuAen1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuAen2Col.Index].Value.ToString() != string.Empty))
                {
                    aen = true;
                }
                // ほう素
                if ((dgvr.Cells[kekkaNyuryokuHouso1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuHouso2Col.Index].Value.ToString() != string.Empty))
                {
                    houso = true;
                }
                // 残塩
                if ((dgvr.Cells[kekkaNyuryokuZanen1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuZanen2Col.Index].Value.ToString() != string.Empty))
                {
                    zanen = true;
                }
                // 外観
                if ((dgvr.Cells[kekkaNyuryokuGaikan1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuGaikan2Col.Index].Value.ToString() != string.Empty))
                {
                    gaikan = true;
                }
                // 臭気
                if ((dgvr.Cells[kekkaNyuryokuShuki1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuShuki2Col.Index].Value.ToString() != string.Empty))
                {
                    shuki = true;
                }
                // 透視度
                if ((dgvr.Cells[kekkaNyuryokuTr1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuTr2Col.Index].Value.ToString() != string.Empty))
                {
                    tr = true;
                }
                // 亜硝酸性窒素（定性）
                if ((dgvr.Cells[kekkaNyuryokuNo2nTeisei1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuNo2nTeisei2Col.Index].Value.ToString() != string.Empty))
                {
                    no2nTeisei = true;
                }
                // 硝酸性窒素（定性）
                if ((dgvr.Cells[kekkaNyuryokuNo3nTeisei1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuNo3nTeisei2Col.Index].Value.ToString() != string.Empty))
                {
                    no3nTeisei = true;
                }
                // 大腸菌群数
                if ((dgvr.Cells[kekkaNyuryokuDaichokin1Col.Index].Value.ToString() != string.Empty)
                    || (dgvr.Cells[kekkaNyuryokuDaichokin2Col.Index].Value.ToString() != string.Empty))
                {
                    daichokin = true;
                }
            }
            #endregion

            #region 項目毎の表示切替
            SetDisplayColumn(ph1Col.Index, ph);
            SetDisplayColumn(ss1Col.Index, ss);
            SetDisplayColumn(bodA1Col.Index, bodA);
            SetDisplayColumn(nh4n1Col.Index, nh4n);
            SetDisplayColumn(cl1Col.Index, cl);
            SetDisplayColumn(cod1Col.Index, cod);
            SetDisplayColumn(hekisanA1Col.Index, hekisanA);
            SetDisplayColumn(mlss1Col.Index, mlss);
            SetDisplayColumn(tnA1Col.Index, tnA);
            SetDisplayColumn(absA1Col.Index, absA);
            SetDisplayColumn(tpA1Col.Index, tpA);
            SetDisplayColumn(rinsan1Col.Index, rinsan);
            SetDisplayColumn(no2nTeiryo1Col.Index, no2nTeiryo);
            SetDisplayColumn(no3nTeiryo1Col.Index, no3nTeiryo);
            SetDisplayColumn(absB1Col.Index, absB);
            SetDisplayColumn(tnB1Col.Index, tnB);
            SetDisplayColumn(tpB1Col.Index, tpB);
            SetDisplayColumn(shikido1Col.Index, shikido);
            SetDisplayColumn(bodB1Col.Index, bodB);
            SetDisplayColumn(hekisanKoyu1Col.Index, hekisanKoyu);
            SetDisplayColumn(hekisanDoshoku1Col.Index, hekisanDoshoku);
            SetDisplayColumn(hekisanB1Col.Index, hekisanB);
            SetDisplayColumn(namari1Col.Index, namari);
            SetDisplayColumn(aen1Col.Index, aen);
            SetDisplayColumn(houso1Col.Index, houso);
            SetDisplayColumn(zanen1Col.Index, zanen);
            SetDisplayColumn(gaikan1Col.Index, gaikan);
            SetDisplayColumn(shuki1Col.Index, shuki);
            SetDisplayColumn(tr1Col.Index, tr);
            SetDisplayColumn(no2nTeisei1Col.Index, no2nTeisei);
            SetDisplayColumn(no3nTeisei1Col.Index, no3nTeisei);
            SetDisplayColumn(daichokin1Col.Index, daichokin);
            #endregion

            #region 表示項目のヘッダの背景色を設定
            if (ph) SetHeaderBackColor(ph1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (ss) SetHeaderBackColor(ss1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (bodA) SetHeaderBackColor(bodA1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (nh4n) SetHeaderBackColor(nh4n1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (cl) SetHeaderBackColor(cl1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (cod) SetHeaderBackColor(cod1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (hekisanA) SetHeaderBackColor(hekisanA1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (mlss) SetHeaderBackColor(mlss1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (tnA) SetHeaderBackColor(tnA1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (absA) SetHeaderBackColor(absA1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (tpA) SetHeaderBackColor(tpA1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (rinsan) SetHeaderBackColor(rinsan1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (no2nTeiryo) SetHeaderBackColor(no2nTeiryo1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (no3nTeiryo) SetHeaderBackColor(no3nTeiryo1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (absB) SetHeaderBackColor(absB1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (tnB) SetHeaderBackColor(tnB1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (tpB) SetHeaderBackColor(tpB1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (shikido) SetHeaderBackColor(shikido1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (bodB) SetHeaderBackColor(bodB1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (hekisanKoyu) SetHeaderBackColor(hekisanKoyu1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (hekisanDoshoku) SetHeaderBackColor(hekisanDoshoku1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (hekisanB) SetHeaderBackColor(hekisanB1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (namari) SetHeaderBackColor(namari1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (aen) SetHeaderBackColor(aen1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (houso) SetHeaderBackColor(houso1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (zanen) SetHeaderBackColor(zanen1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (gaikan) SetHeaderBackColor(gaikan1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (shuki) SetHeaderBackColor(shuki1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (tr) SetHeaderBackColor(tr1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (no2nTeisei) SetHeaderBackColor(no2nTeisei1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (no3nTeisei) SetHeaderBackColor(no3nTeisei1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (daichokin) SetHeaderBackColor(daichokin1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            #endregion
        }
        #endregion

        #region 検査項目の表示＆非表示設定
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDisplayColumn
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/12/07　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDisplayColumn(int index, bool disp)
        {
            if (index == ph1Col.Index)
            {
                listDataGridView.Columns[index].Visible = disp;
                listDataGridView.Columns[index + 1].Visible = disp;
                listDataGridView.Columns[index + 2].Visible = disp;
                listDataGridView.Columns[index + 3].Visible = disp;
                listDataGridView.Columns[index + 4].Visible = disp;

                listDataGridView.Columns[index + 7].Visible = disp;
                listDataGridView.Columns[index + 8].Visible = disp;
                listDataGridView.Columns[index + 9].Visible = disp;
                listDataGridView.Columns[index + 10].Visible = disp;
                listDataGridView.Columns[index + 11].Visible = disp;
            }
            //20150112 sou Start
            else if((index == gaikan1Col.Index )
                    || (index == shuki1Col.Index)
                    || (index == no2nTeisei1Col.Index)
                    || (index == no3nTeisei1Col.Index))
            {
                listDataGridView.Columns[index].Visible = false;
                listDataGridView.Columns[index + 1].HeaderText = listDataGridView.Columns[index].HeaderText;
                listDataGridView.Columns[index + 1].Visible = disp;
                listDataGridView.Columns[index + 2].Visible = disp;
                listDataGridView.Columns[index + 3].Visible = disp;

                listDataGridView.Columns[index + 6].Visible = false;
                listDataGridView.Columns[index + 7].HeaderText = listDataGridView.Columns[index + 6].HeaderText;
                listDataGridView.Columns[index + 7].Visible = disp;
                listDataGridView.Columns[index + 8].Visible = disp;
                listDataGridView.Columns[index + 9].Visible = disp;
            }
            //20150112 sou End
            else
            {
                listDataGridView.Columns[index].Visible = disp;
                listDataGridView.Columns[index + 1].Visible = disp;
                listDataGridView.Columns[index + 2].Visible = disp;
                listDataGridView.Columns[index + 3].Visible = disp;

                listDataGridView.Columns[index + 6].Visible = disp;
                listDataGridView.Columns[index + 7].Visible = disp;
                listDataGridView.Columns[index + 8].Visible = disp;
                listDataGridView.Columns[index + 9].Visible = disp;
            }
        }
        #endregion

        #region AddBlankRow
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： AddBlankRow
        /// <summary>
        /// DataTableの先頭に空白行を追加して返す ※水質結果名称マスタの形式にのみ対応
        /// </summary>
        /// <param name="dt"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/06  宗     　   新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private DataTable AddBlankRow(DataTable dt)
        {
            SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable sknmDt = new SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable();

            SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstRow newRow = sknmDt.NewSuishitsuKekkaNmMstRow();

            newRow.SuishitsuKekkaShishoCd = string.Empty;

            newRow.SuishitsuKekkaNm = " ";
            newRow.SuishitsuKekkaNmCd = "0";

            newRow.InsertDt = Common.Common.GetCurrentTimestamp();
            newRow.InsertUser = HostName;
            newRow.InsertTarm = LoginUser;
            newRow.UpdateDt = newRow.InsertDt;
            newRow.UpdateUser = newRow.InsertUser;
            newRow.UpdateTarm = newRow.InsertTarm;

            sknmDt.Rows.Add(newRow);

            foreach (SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstRow row in dt.Rows)
            {
                // コピー
                newRow = sknmDt.NewSuishitsuKekkaNmMstRow();
                newRow.ItemArray = row.ItemArray;
                // 追加
                sknmDt.Rows.Add(newRow);
            }

            return sknmDt;
        }
        #endregion

        #region
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ComboBoxListSet
        /// <summary>
        /// コンボボックスの選択リストを設定する
        /// </summary>
        /// <param name="dt"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/06  宗     　   新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ComboBoxListSet()
        {
            // 20150120 sou Start
            string shishoCd = string.Empty;
            if(_searchAlInput == null)
            {
                shishoCd = LoginUserShozokuShishoCd;
            }
            else
            {
                if (_searchAlInput.SearchCond.ShishoCd != shishoComboBox.SelectedValue.ToString())
                {
                    shishoCd = shishoComboBox.SelectedValue.ToString();
                }
                else
                {
                    // 初期設定以外で、支所が変更されていない場合は処理しない
                    return;
                }
            }
            // 20150120 sou End

            // コンボボックスの選択リスト取得
            IFormLoadALInput alInput = new FormLoadALInput();
            //alInput.ShishoCd = LoginUserShozokuShishoCd;
            alInput.ShishoCd = shishoCd;
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            DataTable kekkaNmDt = AddBlankRow(alOutput.SuishitsuKekkaNmMstDt);

            int idx = 0;

            // 外観１
            DataGridViewComboBoxColumn dgvCmbGaikan1 = new DataGridViewComboBoxColumn();
            dgvCmbGaikan1.DataSource = kekkaNmDt;
            dgvCmbGaikan1.DisplayMember = "SuishitsuKekkaNm";
            dgvCmbGaikan1.ValueMember = "SuishitsuKekkaNmCd";

            idx = gaikan1KekkaCdCol.Index;
            listDataGridView.Columns.RemoveAt(idx);
            dgvCmbGaikan1.HeaderText = "";
            dgvCmbGaikan1.Name = "gaikan1KekkaCdCol";
            listDataGridView.Columns.Insert(idx, dgvCmbGaikan1);

            // 外観２
            DataGridViewComboBoxColumn dgvCmbGaikan2 = new DataGridViewComboBoxColumn();
            dgvCmbGaikan2.DataSource = kekkaNmDt;
            dgvCmbGaikan2.DisplayMember = "SuishitsuKekkaNm";
            dgvCmbGaikan2.ValueMember = "SuishitsuKekkaNmCd";

            idx = gaikan2KekkaCdCol.Index;
            listDataGridView.Columns.RemoveAt(idx);
            dgvCmbGaikan2.HeaderText = "";
            dgvCmbGaikan2.Name = "gaikan2KekkaCdCol";
            listDataGridView.Columns.Insert(idx, dgvCmbGaikan2);

            // 臭気１
            DataGridViewComboBoxColumn dgvCmbShuki1 = new DataGridViewComboBoxColumn();
            dgvCmbShuki1.DataSource = kekkaNmDt;
            dgvCmbShuki1.DisplayMember = "SuishitsuKekkaNm";
            dgvCmbShuki1.ValueMember = "SuishitsuKekkaNmCd";

            idx = shuki1KekkaCdCol.Index;
            listDataGridView.Columns.RemoveAt(idx);
            dgvCmbShuki1.HeaderText = "";
            dgvCmbShuki1.Name = "shuki1KekkaCdCol";
            listDataGridView.Columns.Insert(idx, dgvCmbShuki1);

            // 臭気２
            DataGridViewComboBoxColumn dgvCmbShuki2 = new DataGridViewComboBoxColumn();
            dgvCmbShuki2.DataSource = kekkaNmDt;
            dgvCmbShuki2.DisplayMember = "SuishitsuKekkaNm";
            dgvCmbShuki2.ValueMember = "SuishitsuKekkaNmCd";

            idx = shuki2KekkaCdCol.Index;
            listDataGridView.Columns.RemoveAt(idx);
            dgvCmbShuki2.HeaderText = "";
            dgvCmbShuki2.Name = "shuki2KekkaCdCol";
            listDataGridView.Columns.Insert(idx, dgvCmbShuki2);

            return;
        }
        #endregion

        #endregion
    }
    #endregion
}
