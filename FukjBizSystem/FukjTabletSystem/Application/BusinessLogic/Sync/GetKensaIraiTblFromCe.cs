using System;
using System.Data;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using FukjTabletSystem.Application.DataAccess.SQLCE.KensaIraiTbl;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Sync
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaIraiTblFromCeBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/24　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaIraiTblFromCeBLInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaIraiTblFromCeBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/24　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaIraiTblFromCeBLInput : IGetKensaIraiTblFromCeBLInput
    {
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaIraiTblFromCeBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/24　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaIraiTblFromCeBLOutput
    {
        /// <summary>
        /// KensaIraiTbl
        /// </summary>
        KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTbl { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaIraiTblFromCeBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/24　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaIraiTblFromCeBLOutput : IGetKensaIraiTblFromCeBLOutput
    {
        /// <summary>
        /// KensaIraiTbl
        /// </summary>
        public KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTbl { get; set; }
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaIraiTblFromCeBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/24　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaIraiTblFromCeBusinessLogic : BaseBusinessLogic<IGetKensaIraiTblFromCeBLInput, IGetKensaIraiTblFromCeBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaIraiTblFromCeBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/24　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensaIraiTblFromCeBusinessLogic()
        {

        }
        #endregion

        #region メソッド(public)

        #region Execute
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： Execute
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/24　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaIraiTblFromCeBLOutput Execute(IGetKensaIraiTblFromCeBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaIraiTblFromCeBLOutput output = new GetKensaIraiTblFromCeBLOutput();

            try
            {
                // 検査依頼
                output.KensaIraiTbl = new KensaIraiTblDataSet.KensaIraiTblDataTable();
                
                #region 検査依頼

                // 検査依頼をローカルデータベースより取得
                ISelectKensaIraiTblInKensaIraiDAInput selectKensaIraiTblInput = new SelectKensaIraiTblInKensaIraiDAInput();
                // 検索
                ISelectKensaIraiTblInKensaIraiDAOutput selectKensaIraiTblOutput = new SelectKensaIraiTblInKensaIraiDataAccess().Execute(selectKensaIraiTblInput);

                // 検査依頼を一件毎に処理する
                foreach (DataRow KensaIraiTblRow in selectKensaIraiTblOutput.KensaIraiTbl)
                {
                    // レコードの追加
                    KensaIraiTblDataSet.KensaIraiTblRow newKensaIraiTblRow = output.KensaIraiTbl.NewKensaIraiTblRow();

                    // 値の詰め替え
                    foreach (DataColumn col in output.KensaIraiTbl.Columns)
                    {
                        newKensaIraiTblRow[col.ColumnName] = KensaIraiTblRow[col.ColumnName];
                    }

                    newKensaIraiTblRow.UpdateDt = DateTime.Now;
                    newKensaIraiTblRow.UpdateTarm = Dns.GetHostName();
                    newKensaIraiTblRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                    // レコードの登録
                    output.KensaIraiTbl.AddKensaIraiTblRow(newKensaIraiTblRow);
                    newKensaIraiTblRow.AcceptChanges();
                    newKensaIraiTblRow.SetModified();
                }

                #endregion

            }
            catch
            {
                throw;
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion
    }
    #endregion
}
