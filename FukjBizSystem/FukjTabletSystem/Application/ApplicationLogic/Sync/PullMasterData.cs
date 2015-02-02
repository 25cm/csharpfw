using System.Collections.Generic;
using System.IO;
using System.Reflection;
using FukjBizSystem;
using FukjTabletSystem.Application.BusinessLogic.Sync;
using FukjTabletSystem.Properties;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.ApplicationLogic.Sync
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPullMasterDataALInput
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
    interface IPullMasterDataALInput : IBseALInput, IGetAndReflectMasterDataBLInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PullMasterDataALInput
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
    class PullMasterDataALInput : IPullMasterDataALInput
    {
        /// <summary>
        /// 更新対象のマスタ（指定なしの場合は全マスタを対象とする）
        /// </summary>
        public List<string> TargetMasterList { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                if(TargetMasterList.Count == 0)
                {
                    return string.Empty;
                }
                else
                {
                    string target = "対象マスタ[ ";

                    foreach (string name in TargetMasterList)
                    {
                        target += name + ", ";
                    }

                    target += "]";

                    return target;
                }

            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPullMasterDataALOutput
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
    interface IPullMasterDataALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PullMasterDataALOutput
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
    class PullMasterDataALOutput : IPullMasterDataALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PullMasterDataApplicationLogic
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
    class PullMasterDataApplicationLogic : BaseApplicationLogic<IPullMasterDataALInput, IPullMasterDataALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "TopMenu：PullMasterData";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PullMasterDataApplicationLogic
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
        public PullMasterDataApplicationLogic()
        {
        }
        #endregion

        #region メソッド(protected)

        #region GetFunctionName
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetFunctionName
        /// <summary>
        /// 機能名取得
        /// </summary>
        /// <returns>機能名</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override string GetFunctionName()
        {
            return FunctionName;
        }
        #endregion

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
        public override IPullMasterDataALOutput Execute(IPullMasterDataALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IPullMasterDataALOutput output = new PullMasterDataALOutput();

            try
            {
                try
                {
                    //// トランザクション開始
                    //StartTransactionCe();

                    // 同期処理
                    IGetAndReflectMasterDataBLOutput blOutput = new GetAndReflectMasterDataBusinessLogic().Execute(input);

                    //// コミット
                    //CompleteTransactionCe();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    //// トランザクション終了
                    //EndTransactionCe();
                }

                #region 帳票テンプレートファイルのコピー

                // 検査結果書
                string sourcePath = Path.Combine(SettingReader.PrintFormatFolder, SettingReader.KensaKekkashoFormatFile);
                string targetPath = Path.Combine(Settings.Default.PrintFormatFolder, SettingReader.KensaKekkashoFormatFile);
                
                try
                {
                    // ローカルファイルの削除
                    if (File.Exists(targetPath))
                    {
                        File.Delete(targetPath);
                    }

                    // ファイルコピー
                    File.Copy(sourcePath, targetPath, true);
                }
                catch
                {
                    // 何もしない
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
