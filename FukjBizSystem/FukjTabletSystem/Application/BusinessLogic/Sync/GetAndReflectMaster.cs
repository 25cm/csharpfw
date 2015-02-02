using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.Sync.Mst;
using FukjTabletSystem.Application.DataAccess.SQLCE.ConstMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.FunctionMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.GyoshaMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.HokenjoMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.HoteiKanriMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.KatashikiBetsuTaniSochiMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.KatashikiMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.KenchikuyotoDaibunruiMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.KenchikuyotoMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.KenchikuyotoShobunruiMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.MemoDaibunruiMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.MemoMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.MonitoringGroupMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.MonitoringShosaiMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.NameMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.ShokenMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.ShokuinMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.ShoriHoshikiMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.ShoriHoshikiSuishitsuKensaJisshiMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.TaniSochiGroupMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.TaniSochiKensaJokyoMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.TaniSochiKensaJokyoTeidoMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.TaniSochiKensaKomokuMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.TaniSochiMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.WarekiMst;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.Utility;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Sync
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetAndReflectMasterDataBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetAndReflectMasterDataBLInput
    {
        /// <summary>
        /// 更新対象のマスタ（指定なしの場合は全マスタを対象とする）
        /// </summary>
        List<string> TargetMasterList { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetAndReflectMasterDataBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetAndReflectMasterDataBLInput : IGetAndReflectMasterDataBLInput
    {
        /// <summary>
        /// 更新対象のマスタ（指定なしの場合は全マスタを対象とする）
        /// </summary>
        public List<string> TargetMasterList { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetAndReflectMasterDataBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetAndReflectMasterDataBLOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetAndReflectMasterDataBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetAndReflectMasterDataBLOutput : IGetAndReflectMasterDataBLOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetAndReflectMasterDataBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetAndReflectMasterDataBusinessLogic : BaseBusinessLogic<IGetAndReflectMasterDataBLInput, IGetAndReflectMasterDataBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetAndReflectMasterDataBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetAndReflectMasterDataBusinessLogic()
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
        /// 2014/09/05　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetAndReflectMasterDataBLOutput Execute(IGetAndReflectMasterDataBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetAndReflectMasterDataBLOutput output = new GetAndReflectMasterDataBLOutput();

            string ErroMessages = string.Empty;

            try
            {
                #region 定数マスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_ConstMst))
                {
                    // サーバから取得
                    ISelectConstMstDAOutput selectOutput = new SelectConstMstDataAccess().Execute(new SelectConstMstDAInput());

                    // ローカルを削除
                    new DeleteAllConstMstDataAccess().Execute(new DeleteAllConstMstDAInput());

                    // ローカルに登録
                    IUpdateConstMstDAInput updateInput = new UpdateConstMstDAInput();

                    updateInput.ConstMst = new DataSet.SQLCE.ConstMstDataSet.ConstMstDataTable();

                    foreach (DataRow row in selectOutput.ConstMst)
                    {
                        ConstMstDataSet.ConstMstRow newRow = updateInput.ConstMst.NewConstMstRow();

                        foreach (DataColumn col in updateInput.ConstMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.ConstMst.AddConstMstRow(newRow);
                    }

                    new UpdateConstMstDataAccess().Execute(updateInput);
                }

                #endregion

                #region 機能マスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_FunctionMst))
                {
                    // サーバから取得
                    ISelectFunctionMstDAOutput selectOutput = new SelectFunctionMstDataAccess().Execute(new SelectFunctionMstDAInput());

                    // ローカルを削除
                    new DeleteAllFunctionMstDataAccess().Execute(new DeleteAllFunctionMstDAInput());

                    // ローカルに登録
                    IUpdateFunctionMstDAInput updateInput = new UpdateFunctionMstDAInput();

                    updateInput.FunctionMst = new DataSet.SQLCE.FunctionMstDataSet.FunctionMstDataTable();

                    foreach (DataRow row in selectOutput.FunctionMst)
                    {
                        FunctionMstDataSet.FunctionMstRow newRow = updateInput.FunctionMst.NewFunctionMstRow();

                        foreach (DataColumn col in updateInput.FunctionMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.FunctionMst.AddFunctionMstRow(newRow);
                    }

                    new UpdateFunctionMstDataAccess().Execute(updateInput);
                }

                #endregion
                
                #region 業者マスタ（製造、工事、保守点検、清掃、持込、収集、取扱）

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_GyoshaMst))
                {
                    // 2015.01.13 toyoda Modify Start 業者マスタの差分更新対応

                    // ローカルを全取得
                    ISelectGyoshaMstDAOutput selectLcOutput = new SelectGyoshaMstDataAccess().Execute(new SelectGyoshaMstDAInput());

                    // 最終更新日
                    object maxUpdateDt = selectLcOutput.GyoshaMstDataTable.Compute("Max(UpdateDt)", string.Empty);
                    DateTime lastUpdateDt = (maxUpdateDt == DBNull.Value || maxUpdateDt == null) ? new DateTime(1900, 1, 1, 0, 0, 0) : (DateTime)selectLcOutput.GyoshaMstDataTable.Compute("Max(UpdateDt)", string.Empty);

                    // 最終更新日以降に更新されたマスタを取得
                    ISelectGyoshaMstByLastUpdateDtDAInput selectInput = new SelectGyoshaMstByLastUpdateDtDAInput();
                    selectInput.LastUpdateDt = lastUpdateDt;
                    ISelectGyoshaMstByLastUpdateDtDAOutput selectOutput = new SelectGyoshaMstByLastUpdateDtDataAccess().Execute(selectInput);

                    if (selectOutput.GyoshaMst.Count > 0)
                    {
                        // ローカルに登録
                        IUpdateGyoshaMstDAInput updateInput = new UpdateGyoshaMstDAInput();

                        updateInput.GyoshaMst = selectLcOutput.GyoshaMstDataTable;

                        foreach (DataRow row in selectOutput.GyoshaMst)
                        {
                            // 既存のレコード有無
                            GyoshaMstDataSet.GyoshaMstRow curRow = updateInput.GyoshaMst.FindByGyoshaCd(row["GyoshaCd"].ToString());

                            // 更新
                            if (curRow != null)
                            {
                                foreach (DataColumn col in updateInput.GyoshaMst.Columns)
                                {
                                    try
                                    {
                                        curRow[col.ColumnName] = row[col.ColumnName];
                                    }
                                    catch
                                    {
                                        ErroMessages += string.Format("\r\n{0}.{1}", curRow.Table.TableName, col.ColumnName);

                                        if (col.DataType == typeof(string))
                                        {
                                            curRow[col.ColumnName] = string.Empty;
                                        }
                                        else
                                        {
                                            curRow[col.ColumnName] = 0;
                                        }
                                    }
                                }
                            }
                            // 新規
                            else
                            {
                                GyoshaMstDataSet.GyoshaMstRow newRow = updateInput.GyoshaMst.NewGyoshaMstRow();

                                foreach (DataColumn col in updateInput.GyoshaMst.Columns)
                                {
                                    try
                                    {
                                        newRow[col.ColumnName] = row[col.ColumnName];
                                    }
                                    catch
                                    {
                                        ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                        if (col.DataType == typeof(string))
                                        {
                                            newRow[col.ColumnName] = string.Empty;
                                        }
                                        else
                                        {
                                            newRow[col.ColumnName] = 0;
                                        }
                                    }
                                }

                                updateInput.GyoshaMst.AddGyoshaMstRow(newRow);
                            }
                        }

                        new UpdateGyoshaMstDataAccess().Execute(updateInput);
                    }

                    // 2015.01.13 toyoda Modify End
                }

                #endregion

                #region 保健所マスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_HokenjoMst))
                {
                    // サーバから取得
                    ISelectHokenjoMstDAOutput selectOutput = new SelectHokenjoMstDataAccess().Execute(new SelectHokenjoMstDAInput());

                    // ローカルを削除
                    new DeleteAllHokenjoMstDataAccess().Execute(new DeleteAllHokenjoMstDAInput());

                    // ローカルに登録
                    IUpdateHokenjoMstDAInput updateInput = new UpdateHokenjoMstDAInput();

                    updateInput.HokenjoMst = new DataSet.SQLCE.HokenjoMstDataSet.HokenjoMstDataTable();

                    foreach (DataRow row in selectOutput.HokenjoMst)
                    {
                        HokenjoMstDataSet.HokenjoMstRow newRow = updateInput.HokenjoMst.NewHokenjoMstRow();

                        foreach (DataColumn col in updateInput.HokenjoMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.HokenjoMst.AddHokenjoMstRow(newRow);
                    }

                    new UpdateHokenjoMstDataAccess().Execute(updateInput);
                }

                #endregion

                #region 型式マスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_KatashikiMst))
                {
                    // サーバから取得
                    ISelectKatashikiMstDAOutput selectOutput = new SelectKatashikiMstDataAccess().Execute(new SelectKatashikiMstDAInput());

                    // ローカルを削除
                    new DeleteAllKatashikiMstDataAccess().Execute(new DeleteAllKatashikiMstDAInput());

                    // ローカルに登録
                    IUpdateKatashikiMstDAInput updateInput = new UpdateKatashikiMstDAInput();

                    updateInput.KatashikiMst = new DataSet.SQLCE.KatashikiMstDataSet.KatashikiMstDataTable();

                    foreach (DataRow row in selectOutput.KatashikiMst)
                    {
                        KatashikiMstDataSet.KatashikiMstRow newRow = updateInput.KatashikiMst.NewKatashikiMstRow();

                        foreach (DataColumn col in updateInput.KatashikiMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.KatashikiMst.AddKatashikiMstRow(newRow);
                    }

                    new UpdateKatashikiMstDataAccess().Execute(updateInput);
                }

                #endregion

                #region 型式別単位装置マスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_KatashikiBetsuTaniSochiMst))
                {
                    // サーバから取得
                    ISelectKatashikiBetsuTaniSochiMstDAOutput selectOutput = new SelectKatashikiBetsuTaniSochiMstDataAccess().Execute(new SelectKatashikiBetsuTaniSochiMstDAInput());

                    // ローカルを削除
                    new DeleteAllKatashikiBetsuTaniSochiMstDataAccess().Execute(new DeleteAllKatashikiBetsuTaniSochiMstDAInput());

                    // ローカルに登録
                    IUpdateKatashikiBetsuTaniSochiMstDAInput updateInput = new UpdateKatashikiBetsuTaniSochiMstDAInput();

                    updateInput.KatashikiBetsuTaniSochiMst = new DataSet.SQLCE.KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiMstDataTable();

                    foreach (DataRow row in selectOutput.KatashikiBetsuTaniSochiMst)
                    {
                        KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiMstRow newRow = updateInput.KatashikiBetsuTaniSochiMst.NewKatashikiBetsuTaniSochiMstRow();

                        foreach (DataColumn col in updateInput.KatashikiBetsuTaniSochiMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.KatashikiBetsuTaniSochiMst.AddKatashikiBetsuTaniSochiMstRow(newRow);
                    }

                    new UpdateKatashikiBetsuTaniSochiMstDataAccess().Execute(updateInput);
                }

                #endregion

                #region 建築用途大分類マスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_KenchikuyotoDaibunruiMst))
                {
                    // サーバから取得
                    ISelectKenchikuyotoDaibunruiMstDAOutput selectOutput = new SelectKenchikuyotoDaibunruiMstDataAccess().Execute(new SelectKenchikuyotoDaibunruiMstDAInput());

                    // ローカルを削除
                    new DeleteAllKenchikuyotoDaibunruiMstDataAccess().Execute(new DeleteAllKenchikuyotoDaibunruiMstDAInput());

                    // ローカルに登録
                    IUpdateKenchikuyotoDaibunruiMstDAInput updateInput = new UpdateKenchikuyotoDaibunruiMstDAInput();

                    updateInput.KenchikuyotoDaibunruiMst = new DataSet.SQLCE.KenchikuyotoDaibunruiMstDataSet.KenchikuyotoDaibunruiMstDataTable();

                    foreach (DataRow row in selectOutput.KenchikuyotoDaibunruiMst)
                    {
                        KenchikuyotoDaibunruiMstDataSet.KenchikuyotoDaibunruiMstRow newRow = updateInput.KenchikuyotoDaibunruiMst.NewKenchikuyotoDaibunruiMstRow();

                        foreach (DataColumn col in updateInput.KenchikuyotoDaibunruiMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.KenchikuyotoDaibunruiMst.AddKenchikuyotoDaibunruiMstRow(newRow);
                    }

                    new UpdateKenchikuyotoDaibunruiMstDataAccess().Execute(updateInput);
                }

                #endregion

                #region 建築用途マスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_KenchikuyotoMst))
                {
                    // サーバから取得
                    ISelectKenchikuyotoMstDAOutput selectOutput = new SelectKenchikuyotoMstDataAccess().Execute(new SelectKenchikuyotoMstDAInput());

                    // ローカルを削除
                    new DeleteAllKenchikuyotoMstDataAccess().Execute(new DeleteAllKenchikuyotoMstDAInput());

                    // ローカルに登録
                    IUpdateKenchikuyotoMstDAInput updateInput = new UpdateKenchikuyotoMstDAInput();

                    updateInput.KenchikuyotoMst = new DataSet.SQLCE.KenchikuyotoMstDataSet.KenchikuyotoMstDataTable();

                    foreach (DataRow row in selectOutput.KenchikuyotoMst)
                    {
                        KenchikuyotoMstDataSet.KenchikuyotoMstRow newRow = updateInput.KenchikuyotoMst.NewKenchikuyotoMstRow();

                        foreach (DataColumn col in updateInput.KenchikuyotoMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.KenchikuyotoMst.AddKenchikuyotoMstRow(newRow);
                    }

                    new UpdateKenchikuyotoMstDataAccess().Execute(updateInput);
                }

                #endregion

                #region 建築用途小分類マスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_KenchikuyotoShobunruiMst))
                {
                    // サーバから取得
                    ISelectKenchikuyotoShobunruiMstDAOutput selectOutput = new SelectKenchikuyotoShobunruiMstDataAccess().Execute(new SelectKenchikuyotoShobunruiMstDAInput());

                    // ローカルを削除
                    new DeleteAllKenchikuyotoShobunruiMstDataAccess().Execute(new DeleteAllKenchikuyotoShobunruiMstDAInput());

                    // ローカルに登録
                    IUpdateKenchikuyotoShobunruiMstDAInput updateInput = new UpdateKenchikuyotoShobunruiMstDAInput();

                    updateInput.KenchikuyotoShobunruiMst = new DataSet.SQLCE.KenchikuyotoShobunruiMstDataSet.KenchikuyotoShobunruiMstDataTable();

                    foreach (DataRow row in selectOutput.KenchikuyotoShobunruiMst)
                    {
                        KenchikuyotoShobunruiMstDataSet.KenchikuyotoShobunruiMstRow newRow = updateInput.KenchikuyotoShobunruiMst.NewKenchikuyotoShobunruiMstRow();

                        foreach (DataColumn col in updateInput.KenchikuyotoShobunruiMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.KenchikuyotoShobunruiMst.AddKenchikuyotoShobunruiMstRow(newRow);
                    }

                    new UpdateKenchikuyotoShobunruiMstDataAccess().Execute(updateInput);
                }

                #endregion
                
                #region メモ大分類マスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_MemoDaibunruiMst))
                {
                    // サーバから取得
                    ISelectMemoDaibunruiMstDAOutput selectOutput = new SelectMemoDaibunruiMstDataAccess().Execute(new SelectMemoDaibunruiMstDAInput());

                    // ローカルを削除
                    new DeleteAllMemoDaibunruiMstDataAccess().Execute(new DeleteAllMemoDaibunruiMstDAInput());

                    // ローカルに登録
                    IUpdateMemoDaibunruiMstDAInput updateInput = new UpdateMemoDaibunruiMstDAInput();

                    updateInput.MemoDaibunruiMst = new DataSet.SQLCE.MemoDaibunruiMstDataSet.MemoDaibunruiMstDataTable();

                    foreach (DataRow row in selectOutput.MemoDaibunruiMst)
                    {
                        MemoDaibunruiMstDataSet.MemoDaibunruiMstRow newRow = updateInput.MemoDaibunruiMst.NewMemoDaibunruiMstRow();

                        foreach (DataColumn col in updateInput.MemoDaibunruiMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.MemoDaibunruiMst.AddMemoDaibunruiMstRow(newRow);
                    }

                    new UpdateMemoDaibunruiMstDataAccess().Execute(updateInput);
                }

                #endregion

                #region メモマスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_MemoMst))
                {
                    // サーバから取得
                    ISelectMemoMstDAOutput selectOutput = new SelectMemoMstDataAccess().Execute(new SelectMemoMstDAInput());

                    // ローカルを削除
                    new DeleteAllMemoMstDataAccess().Execute(new DeleteAllMemoMstDAInput());

                    // ローカルに登録
                    IUpdateMemoMstDAInput updateInput = new UpdateMemoMstDAInput();

                    updateInput.MemoMst = new DataSet.SQLCE.MemoMstDataSet.MemoMstDataTable();

                    foreach (DataRow row in selectOutput.MemoMst)
                    {
                        MemoMstDataSet.MemoMstRow newRow = updateInput.MemoMst.NewMemoMstRow();

                        foreach (DataColumn col in updateInput.MemoMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.MemoMst.AddMemoMstRow(newRow);
                    }

                    new UpdateMemoMstDataAccess().Execute(updateInput);
                }

                #endregion

                #region モニタリンググループマスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_MonitoringGroupMst))
                {
                    // サーバから取得
                    ISelectMonitoringGroupMstDAOutput selectOutput = new SelectMonitoringGroupMstDataAccess().Execute(new SelectMonitoringGroupMstDAInput());

                    // ローカルを削除
                    new DeleteAllMonitoringGroupMstDataAccess().Execute(new DeleteAllMonitoringGroupMstDAInput());

                    // ローカルに登録
                    IUpdateMonitoringGroupMstDAInput updateInput = new UpdateMonitoringGroupMstDAInput();

                    updateInput.MonitoringGroupMst = new DataSet.SQLCE.MonitoringGroupMstDataSet.MonitoringGroupMstDataTable();

                    foreach (DataRow row in selectOutput.MonitoringGroupMst)
                    {
                        MonitoringGroupMstDataSet.MonitoringGroupMstRow newRow = updateInput.MonitoringGroupMst.NewMonitoringGroupMstRow();

                        foreach (DataColumn col in updateInput.MonitoringGroupMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.MonitoringGroupMst.AddMonitoringGroupMstRow(newRow);
                    }

                    new UpdateMonitoringGroupMstDataAccess().Execute(updateInput);
                }

                #endregion

                #region モニタリング詳細マスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_MonitoringShosaiMst))
                {
                    // サーバから取得
                    ISelectMonitoringShosaiMstDAOutput selectOutput = new SelectMonitoringShosaiMstDataAccess().Execute(new SelectMonitoringShosaiMstDAInput());

                    // ローカルを削除
                    new DeleteAllMonitoringShosaiMstDataAccess().Execute(new DeleteAllMonitoringShosaiMstDAInput());

                    // ローカルに登録
                    IUpdateMonitoringShosaiMstDAInput updateInput = new UpdateMonitoringShosaiMstDAInput();

                    updateInput.MonitoringShosaiMst = new DataSet.SQLCE.MonitoringShosaiMstDataSet.MonitoringShosaiMstDataTable();

                    foreach (DataRow row in selectOutput.MonitoringShosaiMst)
                    {
                        MonitoringShosaiMstDataSet.MonitoringShosaiMstRow newRow = updateInput.MonitoringShosaiMst.NewMonitoringShosaiMstRow();

                        foreach (DataColumn col in updateInput.MonitoringShosaiMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.MonitoringShosaiMst.AddMonitoringShosaiMstRow(newRow);
                    }

                    new UpdateMonitoringShosaiMstDataAccess().Execute(updateInput);
                }

                #endregion

                #region 名称マスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_NameMst))
                {
                    // サーバから取得
                    ISelectNameMstDAOutput selectOutput = new SelectNameMstDataAccess().Execute(new SelectNameMstDAInput());

                    // ローカルを削除
                    new DeleteAllNameMstDataAccess().Execute(new DeleteAllNameMstDAInput());

                    // ローカルに登録
                    IUpdateNameMstDAInput updateInput = new UpdateNameMstDAInput();

                    updateInput.NameMst = new DataSet.SQLCE.NameMstDataSet.NameMstDataTable();

                    foreach (DataRow row in selectOutput.NameMst)
                    {
                        NameMstDataSet.NameMstRow newRow = updateInput.NameMst.NewNameMstRow();

                        foreach (DataColumn col in updateInput.NameMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.NameMst.AddNameMstRow(newRow);
                    }

                    new UpdateNameMstDataAccess().Execute(updateInput);
                }

                #endregion
                
                #region 所見マスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_ShokenMst))
                {
                    // サーバから取得
                    ISelectShokenMstDAOutput selectOutput = new SelectShokenMstDataAccess().Execute(new SelectShokenMstDAInput());

                    // ローカルを削除
                    new DeleteAllShokenMstDataAccess().Execute(new DeleteAllShokenMstDAInput());

                    // ローカルに登録
                    IUpdateShokenMstDAInput updateInput = new UpdateShokenMstDAInput();

                    updateInput.ShokenMst = new DataSet.SQLCE.ShokenMstDataSet.ShokenMstDataTable();

                    foreach (DataRow row in selectOutput.ShokenMst)
                    {
                        ShokenMstDataSet.ShokenMstRow newRow = updateInput.ShokenMst.NewShokenMstRow();

                        foreach (DataColumn col in updateInput.ShokenMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.ShokenMst.AddShokenMstRow(newRow);
                    }

                    new UpdateShokenMstDataAccess().Execute(updateInput);
                }

                #endregion

                #region 職員マスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_ShokuinMst))
                {
                    // サーバから取得
                    ISelectShokuinMstDAOutput selectOutput = new SelectShokuinMstDataAccess().Execute(new SelectShokuinMstDAInput());

                    // ローカルを削除
                    new DeleteAllShokuinMstDataAccess().Execute(new DeleteAllShokuinMstDAInput());

                    // ローカルに登録
                    IUpdateShokuinMstDAInput updateInput = new UpdateShokuinMstDAInput();

                    updateInput.ShokuinMst = new DataSet.SQLCE.ShokuinMstDataSet.ShokuinMstDataTable();

                    foreach (DataRow row in selectOutput.ShokuinMst)
                    {
                        ShokuinMstDataSet.ShokuinMstRow newRow = updateInput.ShokuinMst.NewShokuinMstRow();

                        foreach (DataColumn col in updateInput.ShokuinMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.ShokuinMst.AddShokuinMstRow(newRow);
                    }

                    new UpdateShokuinMstDataAccess().Execute(updateInput);
                }

                #endregion

                #region 処理方式マスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_ShoriHoshikiMst))
                {
                    // サーバから取得
                    ISelectShoriHoshikiMstDAOutput selectOutput = new SelectShoriHoshikiMstDataAccess().Execute(new SelectShoriHoshikiMstDAInput());

                    // ローカルを削除
                    new DeleteAllShoriHoshikiMstDataAccess().Execute(new DeleteAllShoriHoshikiMstDAInput());

                    // ローカルに登録
                    IUpdateShoriHoshikiMstDAInput updateInput = new UpdateShoriHoshikiMstDAInput();

                    updateInput.ShoriHoshikiMst = new DataSet.SQLCE.ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable();

                    foreach (DataRow row in selectOutput.ShoriHoshikiMst)
                    {
                        ShoriHoshikiMstDataSet.ShoriHoshikiMstRow newRow = updateInput.ShoriHoshikiMst.NewShoriHoshikiMstRow();

                        foreach (DataColumn col in updateInput.ShoriHoshikiMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.ShoriHoshikiMst.AddShoriHoshikiMstRow(newRow);
                    }

                    new UpdateShoriHoshikiMstDataAccess().Execute(updateInput);
                }

                #endregion

                #region 処理方式別水質検査実施マスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_ShoriHoshikiSuishitsuKensaJisshiMst))
                {
                    // サーバから取得
                    ISelectShoriHoshikiSuishitsuKensaJisshiMstDAOutput selectOutput = new SelectShoriHoshikiSuishitsuKensaJisshiMstDataAccess().Execute(new SelectShoriHoshikiSuishitsuKensaJisshiMstDAInput());

                    // ローカルを削除
                    new DeleteAllShoriHoshikiSuishitsuKensaJisshiMstDataAccess().Execute(new DeleteAllShoriHoshikiSuishitsuKensaJisshiMstDAInput());

                    // ローカルに登録
                    IUpdateShoriHoshikiSuishitsuKensaJisshiMstDAInput updateInput = new UpdateShoriHoshikiSuishitsuKensaJisshiMstDAInput();

                    updateInput.ShoriHoshikiSuishitsuKensaJisshiMst = new DataSet.SQLCE.ShoriHoshikiSuishitsuKensaJisshiMstDataSet.ShoriHoshikiSuishitsuKensaJisshiMstDataTable();

                    foreach (DataRow row in selectOutput.ShoriHoshikiSuishitsuKensaJisshiMst)
                    {
                        ShoriHoshikiSuishitsuKensaJisshiMstDataSet.ShoriHoshikiSuishitsuKensaJisshiMstRow newRow = updateInput.ShoriHoshikiSuishitsuKensaJisshiMst.NewShoriHoshikiSuishitsuKensaJisshiMstRow();

                        foreach (DataColumn col in updateInput.ShoriHoshikiSuishitsuKensaJisshiMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.ShoriHoshikiSuishitsuKensaJisshiMst.AddShoriHoshikiSuishitsuKensaJisshiMstRow(newRow);
                    }

                    new UpdateShoriHoshikiSuishitsuKensaJisshiMstDataAccess().Execute(updateInput);
                }

                #endregion
                
                #region 単位装置グループマスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_TaniSochiGroupMst))
                {
                    // サーバから取得
                    ISelectTaniSochiGroupMstDAOutput selectOutput = new SelectTaniSochiGroupMstDataAccess().Execute(new SelectTaniSochiGroupMstDAInput());

                    // ローカルを削除
                    new DeleteAllTaniSochiGroupMstDataAccess().Execute(new DeleteAllTaniSochiGroupMstDAInput());

                    // ローカルに登録
                    IUpdateTaniSochiGroupMstDAInput updateInput = new UpdateTaniSochiGroupMstDAInput();

                    updateInput.TaniSochiGroupMst = new DataSet.SQLCE.TaniSochiGroupMstDataSet.TaniSochiGroupMstDataTable();

                    foreach (DataRow row in selectOutput.TaniSochiGroupMst)
                    {
                        TaniSochiGroupMstDataSet.TaniSochiGroupMstRow newRow = updateInput.TaniSochiGroupMst.NewTaniSochiGroupMstRow();

                        foreach (DataColumn col in updateInput.TaniSochiGroupMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.TaniSochiGroupMst.AddTaniSochiGroupMstRow(newRow);
                    }

                    new UpdateTaniSochiGroupMstDataAccess().Execute(updateInput);
                }

                #endregion

                #region 単位装置検査項目別状況マスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_TaniSochiKensaJokyoMst))
                {
                    // サーバから取得
                    ISelectTaniSochiKensaJokyoMstDAOutput selectOutput = new SelectTaniSochiKensaJokyoMstDataAccess().Execute(new SelectTaniSochiKensaJokyoMstDAInput());

                    // ローカルを削除
                    new DeleteAllTaniSochiKensaJokyoMstDataAccess().Execute(new DeleteAllTaniSochiKensaJokyoMstDAInput());

                    // ローカルに登録
                    IUpdateTaniSochiKensaJokyoMstDAInput updateInput = new UpdateTaniSochiKensaJokyoMstDAInput();

                    updateInput.TaniSochiKensaJokyoMst = new DataSet.SQLCE.TaniSochiKensaJokyoMstDataSet.TaniSochiKensaJokyoMstDataTable();

                    foreach (DataRow row in selectOutput.TaniSochiKensaJokyoMst)
                    {
                        TaniSochiKensaJokyoMstDataSet.TaniSochiKensaJokyoMstRow newRow = updateInput.TaniSochiKensaJokyoMst.NewTaniSochiKensaJokyoMstRow();

                        foreach (DataColumn col in updateInput.TaniSochiKensaJokyoMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.TaniSochiKensaJokyoMst.AddTaniSochiKensaJokyoMstRow(newRow);
                    }

                    new UpdateTaniSochiKensaJokyoMstDataAccess().Execute(updateInput);
                }

                #endregion

                #region 単位装置検査状況別程度マスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_TaniSochiKensaJokyoTeidoMst))
                {
                    // サーバから取得
                    ISelectTaniSochiKensaJokyoTeidoMstDAOutput selectOutput = new SelectTaniSochiKensaJokyoTeidoMstDataAccess().Execute(new SelectTaniSochiKensaJokyoTeidoMstDAInput());

                    // ローカルを削除
                    new DeleteAllTaniSochiKensaJokyoTeidoMstDataAccess().Execute(new DeleteAllTaniSochiKensaJokyoTeidoMstDAInput());

                    // ローカルに登録
                    IUpdateTaniSochiKensaJokyoTeidoMstDAInput updateInput = new UpdateTaniSochiKensaJokyoTeidoMstDAInput();

                    updateInput.TaniSochiKensaJokyoTeidoMst = new DataSet.SQLCE.TaniSochiKensaJokyoTeidoMstDataSet.TaniSochiKensaJokyoTeidoMstDataTable();

                    foreach (DataRow row in selectOutput.TaniSochiKensaJokyoTeidoMst)
                    {
                        TaniSochiKensaJokyoTeidoMstDataSet.TaniSochiKensaJokyoTeidoMstRow newRow = updateInput.TaniSochiKensaJokyoTeidoMst.NewTaniSochiKensaJokyoTeidoMstRow();

                        foreach (DataColumn col in updateInput.TaniSochiKensaJokyoTeidoMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.TaniSochiKensaJokyoTeidoMst.AddTaniSochiKensaJokyoTeidoMstRow(newRow);
                    }

                    new UpdateTaniSochiKensaJokyoTeidoMstDataAccess().Execute(updateInput);
                }

                #endregion

                #region 単位装置検査項目マスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_TaniSochiKensaKomokuMst))
                {
                    // サーバから取得
                    ISelectTaniSochiKensaKomokuMstDAOutput selectOutput = new SelectTaniSochiKensaKomokuMstDataAccess().Execute(new SelectTaniSochiKensaKomokuMstDAInput());

                    // ローカルを削除
                    new DeleteAllTaniSochiKensaKomokuMstDataAccess().Execute(new DeleteAllTaniSochiKensaKomokuMstDAInput());

                    // ローカルに登録
                    IUpdateTaniSochiKensaKomokuMstDAInput updateInput = new UpdateTaniSochiKensaKomokuMstDAInput();

                    updateInput.TaniSochiKensaKomokuMst = new DataSet.SQLCE.TaniSochiKensaKomokuMstDataSet.TaniSochiKensaKomokuMstDataTable();

                    foreach (DataRow row in selectOutput.TaniSochiKensaKomokuMst)
                    {
                        TaniSochiKensaKomokuMstDataSet.TaniSochiKensaKomokuMstRow newRow = updateInput.TaniSochiKensaKomokuMst.NewTaniSochiKensaKomokuMstRow();

                        foreach (DataColumn col in updateInput.TaniSochiKensaKomokuMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.TaniSochiKensaKomokuMst.AddTaniSochiKensaKomokuMstRow(newRow);
                    }

                    new UpdateTaniSochiKensaKomokuMstDataAccess().Execute(updateInput);
                }

                #endregion

                #region 単位装置マスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_TaniSochiMst))
                {
                    // サーバから取得
                    ISelectTaniSochiMstDAOutput selectOutput = new SelectTaniSochiMstDataAccess().Execute(new SelectTaniSochiMstDAInput());

                    // ローカルを削除
                    new DeleteAllTaniSochiMstDataAccess().Execute(new DeleteAllTaniSochiMstDAInput());

                    // ローカルに登録
                    IUpdateTaniSochiMstDAInput updateInput = new UpdateTaniSochiMstDAInput();

                    updateInput.TaniSochiMst = new DataSet.SQLCE.TaniSochiMstDataSet.TaniSochiMstDataTable();

                    foreach (DataRow row in selectOutput.TaniSochiMst)
                    {
                        TaniSochiMstDataSet.TaniSochiMstRow newRow = updateInput.TaniSochiMst.NewTaniSochiMstRow();

                        foreach (DataColumn col in updateInput.TaniSochiMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.TaniSochiMst.AddTaniSochiMstRow(newRow);
                    }

                    new UpdateTaniSochiMstDataAccess().Execute(updateInput);
                }

                #endregion
                
                #region 和暦マスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_WarekiMst))
                {
                    // サーバから取得
                    ISelectWarekiMstDAOutput selectOutput = new SelectWarekiMstDataAccess().Execute(new SelectWarekiMstDAInput());

                    // ローカルを削除
                    new DeleteAllWarekiMstDataAccess().Execute(new DeleteAllWarekiMstDAInput());

                    // ローカルに登録
                    IUpdateWarekiMstDAInput updateInput = new UpdateWarekiMstDAInput();

                    updateInput.WarekiMst = new DataSet.SQLCE.WarekiMstDataSet.WarekiMstDataTable();

                    foreach (DataRow row in selectOutput.WarekiMst)
                    {
                        WarekiMstDataSet.WarekiMstRow newRow = updateInput.WarekiMst.NewWarekiMstRow();

                        foreach (DataColumn col in updateInput.WarekiMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.WarekiMst.AddWarekiMstRow(newRow);
                    }

                    new UpdateWarekiMstDataAccess().Execute(updateInput);
                }

                #endregion

                #region 法定管理マスタ

                if (input.TargetMasterList == null || input.TargetMasterList.Count == 0 || input.TargetMasterList.Contains(Constants.TABLENAME_HoteiKanriMst))
                {
                    // サーバから取得
                    ISelectHoteiKanriMstDAOutput selectOutput = new SelectHoteiKanriMstDataAccess().Execute(new SelectHoteiKanriMstDAInput());

                    // ローカルを削除
                    new DeleteAllHoteiKanriMstDataAccess().Execute(new DeleteAllHoteiKanriMstDAInput());

                    // ローカルに登録
                    IUpdateHoteiKanriMstDAInput updateInput = new UpdateHoteiKanriMstDAInput();

                    updateInput.HoteiKanriMst = new DataSet.SQLCE.HoteiKanriMstDataSet.HoteiKanriMstDataTable();

                    foreach (DataRow row in selectOutput.HoteiKanriMst)
                    {
                        HoteiKanriMstDataSet.HoteiKanriMstRow newRow = updateInput.HoteiKanriMst.NewHoteiKanriMstRow();

                        foreach (DataColumn col in updateInput.HoteiKanriMst.Columns)
                        {
                            try
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                            catch
                            {
                                ErroMessages += string.Format("\r\n{0}.{1}", newRow.Table.TableName, col.ColumnName);

                                if (col.DataType == typeof(string))
                                {
                                    newRow[col.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    newRow[col.ColumnName] = 0;
                                }
                            }
                        }

                        updateInput.HoteiKanriMst.AddHoteiKanriMstRow(newRow);
                    }

                    new UpdateHoteiKanriMstDataAccess().Execute(updateInput);
                }

                #endregion

                if (!string.IsNullOrEmpty(ErroMessages))
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Warn, string.Format("定義の不一致があります。\r\n規定値(ゼロ、Empty)を使用します。{0}", ErroMessages));
                }
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
