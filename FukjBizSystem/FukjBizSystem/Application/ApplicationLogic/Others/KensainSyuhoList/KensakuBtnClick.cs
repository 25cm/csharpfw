using System;
using System.Collections.Generic;
using System.Reflection;
using FukjBizSystem.Application.Boundary.Others;
using FukjBizSystem.Application.BusinessLogic.Others.KensainSyuhoList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Others.KensainSyuhoList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensakuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/30  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// ListDateStr
        /// </summary>
        List<string> ListDateStr { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/30  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALInput : IKensakuBtnClickALInput
    {
        /// <summary>
        /// ListDateStr
        /// </summary>
        public List<string> ListDateStr { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("ListDateStr[{0}]", new string[] { ListDateStr[0].ToString() });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensakuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/30  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALOutput
    {
        /// <summary>
        /// KensainSyuhoListDataTable
        /// </summary>
        KensainSyuhoListDataSet.KensainSyuhoListDataTable KensainSyuhoListDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/30  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALOutput : IKensakuBtnClickALOutput
    {
        /// <summary>
        /// KensainSyuhoListDataTable
        /// </summary>
        public KensainSyuhoListDataSet.KensainSyuhoListDataTable KensainSyuhoListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/30  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickApplicationLogic : BaseApplicationLogic<IKensakuBtnClickALInput, IKensakuBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensainSyuhoList：KensakuBtnClickApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensakuBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/30  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensakuBtnClickApplicationLogic()
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
        /// 2014/08/30  DatNT　  新規作成
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
        /// 2014/08/30  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKensakuBtnClickALOutput Execute(IKensakuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKensakuBtnClickALOutput output = new KensakuBtnClickALOutput();

            try
            {
                // Display Data table
                KensainSyuhoListDataSet.KensainSyuhoListDataTable kensainSyuhoListDT = new KensainSyuhoListDataSet.KensainSyuhoListDataTable();

                // Get ShokuinNm & ShishoNm
                IGetShokuinNmShishoNmKensainSyuhoListBLInput shokuinNmInput = new GetShokuinNmShishoNmKensainSyuhoListBLInput();
                IGetShokuinNmShishoNmKensainSyuhoListBLOutput shokuinNmOutput = new GetShokuinNmShishoNmKensainSyuhoListBusinessLogic().Execute(shokuinNmInput);

                if (shokuinNmOutput.ShokuinNmShishoNmKensainSyuhoListDT != null && shokuinNmOutput.ShokuinNmShishoNmKensainSyuhoListDT.Count > 0)
                {
                    foreach (ShokuinMstDataSet.ShokuinNmShishoNmKensainSyuhoListRow row in shokuinNmOutput.ShokuinNmShishoNmKensainSyuhoListDT)
                    {
                        KensainSyuhoListDataSet.KensainSyuhoListRow dispRow = kensainSyuhoListDT.NewKensainSyuhoListRow();

                        // 支所
                        dispRow.ShisyoCol = row.ShishoNm;
                        dispRow.ShishoCd = row.ShishoCd;

                        // 検査員
                        dispRow.KensainNmCol = row.ShokuinNm;
                        dispRow.ShokuinCd = row.ShokuinCd;

                        #region 7条

                        for (int i = 1; i <= input.ListDateStr.Count; i++)
                        {
                            IGetCountBySyubetsuKensaDtKensainCdBLInput countInput1 = new GetCountBySyubetsuKensaDtKensainCdBLInput();
                            countInput1.NippoDtlKensaSyubetsu = "1";
                            countInput1.NippoDtlKensaDt = input.ListDateStr[i - 1];
                            countInput1.NippoDtlKensainCd = row.ShokuinCd;
                            IGetCountBySyubetsuKensaDtKensainCdBLOutput countOutput1 = new GetCountBySyubetsuKensaDtKensainCdBusinessLogic().Execute(countInput1);

                            switch (i)
                            {
                                case 1 :
                                    // 7条/月曜日
                                    dispRow.Week1_7JoCol = countOutput1.CountNumber != 0 ? countOutput1.CountNumber.ToString() : string.Empty;
                                    break;

                                case 2 :
                                    // 7条/火曜日
                                    dispRow.Week2_7JoCol = countOutput1.CountNumber != 0 ? countOutput1.CountNumber.ToString() : string.Empty;
                                    break;

                                case 3 :
                                    // 7条/水曜日
                                    dispRow.Week3_7JoCol = countOutput1.CountNumber != 0 ? countOutput1.CountNumber.ToString() : string.Empty;
                                    break;

                                case 4 :
                                    // 7条/木曜日
                                    dispRow.Week4_7JoCol = countOutput1.CountNumber != 0 ? countOutput1.CountNumber.ToString() : string.Empty;
                                    break;

                                case 5 :
                                    // 7条/金曜日
                                    dispRow.Week5_7JoCol = countOutput1.CountNumber != 0 ? countOutput1.CountNumber.ToString() : string.Empty;
                                    break;

                                case 6:
                                    // 7条/土曜日
                                    dispRow.Week6_7JoCol = countOutput1.CountNumber != 0 ? countOutput1.CountNumber.ToString() : string.Empty;
                                    break;

                                default:
                                    break;
                            }
                        }
                        #endregion

                        #region 11条

                        for (int j = 1; j <= input.ListDateStr.Count; j++)
                        {
                            IGetCountBySyubetsuKensaDtKensainCdBLInput countInput2 = new GetCountBySyubetsuKensaDtKensainCdBLInput();
                            countInput2.NippoDtlKensaSyubetsu = "2";
                            countInput2.NippoDtlKensaDt = input.ListDateStr[j - 1];
                            countInput2.NippoDtlKensainCd = row.ShokuinCd;
                            IGetCountBySyubetsuKensaDtKensainCdBLOutput countOutput2 = new GetCountBySyubetsuKensaDtKensainCdBusinessLogic().Execute(countInput2);

                            switch (j)
                            {
                                case 1:
                                    // 11条/月曜日
                                    dispRow.Week1_11JoCol = countOutput2.CountNumber != 0 ? countOutput2.CountNumber.ToString() : string.Empty;
                                    break;

                                case 2:
                                    // 11条/火曜日
                                    dispRow.Week2_11JoCol = countOutput2.CountNumber != 0 ? countOutput2.CountNumber.ToString() : string.Empty;
                                    break;

                                case 3:
                                    // 11条/水曜日
                                    dispRow.Week3_11JoCol = countOutput2.CountNumber != 0 ? countOutput2.CountNumber.ToString() : string.Empty;
                                    break;

                                case 4:
                                    // 11条/木曜日
                                    dispRow.Week4_11JoCol = countOutput2.CountNumber != 0 ? countOutput2.CountNumber.ToString() : string.Empty;
                                    break;

                                case 5:
                                    // 11条/金曜日
                                    dispRow.Week5_11JoCol = countOutput2.CountNumber != 0 ? countOutput2.CountNumber.ToString() : string.Empty;
                                    break;

                                case 6:
                                    // 11条/土曜日
                                    dispRow.Week6_11JoCol = countOutput2.CountNumber != 0 ? countOutput2.CountNumber.ToString() : string.Empty;
                                    break;

                                default:
                                    break;
                            }
                        }
                        #endregion

                        #region 計

                        // 計/月曜日
                        if (!string.IsNullOrEmpty(dispRow.Week1_7JoCol) || !string.IsNullOrEmpty(dispRow.Week1_11JoCol))
                        {
                            dispRow.Week1_TotalCol = ((!string.IsNullOrEmpty(dispRow.Week1_7JoCol) ? Convert.ToInt32(dispRow.Week1_7JoCol) : 0)
                                                    + (!string.IsNullOrEmpty(dispRow.Week1_11JoCol) ? Convert.ToInt32(dispRow.Week1_11JoCol) : 0)).ToString();
                        }

                        // 計/火曜日
                        if (!string.IsNullOrEmpty(dispRow.Week2_7JoCol) || !string.IsNullOrEmpty(dispRow.Week2_11JoCol))
                        {
                            dispRow.Week2_TotalCol = ((!string.IsNullOrEmpty(dispRow.Week2_7JoCol) ? Convert.ToInt32(dispRow.Week2_7JoCol) : 0)
                                                    + (!string.IsNullOrEmpty(dispRow.Week2_11JoCol) ? Convert.ToInt32(dispRow.Week2_11JoCol) : 0)).ToString();
                        }

                        // 計/水曜日
                        if (!string.IsNullOrEmpty(dispRow.Week3_7JoCol) || !string.IsNullOrEmpty(dispRow.Week3_11JoCol))
                        {
                            dispRow.Week3_TotalCol = ((!string.IsNullOrEmpty(dispRow.Week3_7JoCol) ? Convert.ToInt32(dispRow.Week3_7JoCol) : 0)
                                                    + (!string.IsNullOrEmpty(dispRow.Week3_11JoCol) ? Convert.ToInt32(dispRow.Week3_11JoCol) : 0)).ToString();
                        }

                        // 計/木曜日
                        if (!string.IsNullOrEmpty(dispRow.Week4_7JoCol) || !string.IsNullOrEmpty(dispRow.Week4_11JoCol))
                        {
                            dispRow.Week4_TotalCol = ((!string.IsNullOrEmpty(dispRow.Week4_7JoCol) ? Convert.ToInt32(dispRow.Week4_7JoCol) : 0)
                                                    + (!string.IsNullOrEmpty(dispRow.Week4_11JoCol) ? Convert.ToInt32(dispRow.Week4_11JoCol) : 0)).ToString();
                        }

                        // 11条/金曜日
                        if (!string.IsNullOrEmpty(dispRow.Week5_7JoCol) || !string.IsNullOrEmpty(dispRow.Week5_11JoCol))
                        {
                            dispRow.Week5_TotalCol = ((!string.IsNullOrEmpty(dispRow.Week5_7JoCol) ? Convert.ToInt32(dispRow.Week5_7JoCol) : 0)
                                                    + (!string.IsNullOrEmpty(dispRow.Week5_11JoCol) ? Convert.ToInt32(dispRow.Week5_11JoCol) : 0)).ToString();
                        }

                        // 計/土曜日
                        if (!string.IsNullOrEmpty(dispRow.Week6_7JoCol) || !string.IsNullOrEmpty(dispRow.Week6_11JoCol))
                        {
                            dispRow.Week6_TotalCol = ((!string.IsNullOrEmpty(dispRow.Week6_7JoCol) ? Convert.ToInt32(dispRow.Week6_7JoCol) : 0)
                                                    + (!string.IsNullOrEmpty(dispRow.Week6_11JoCol) ? Convert.ToInt32(dispRow.Week6_11JoCol) : 0)).ToString();
                        }
                        #endregion

                        #region 合計

                        // 7条/合計
                        if (!string.IsNullOrEmpty(dispRow.Week1_7JoCol)
                            || !string.IsNullOrEmpty(dispRow.Week2_7JoCol)
                            || !string.IsNullOrEmpty(dispRow.Week3_7JoCol)
                            || !string.IsNullOrEmpty(dispRow.Week4_7JoCol)
                            || !string.IsNullOrEmpty(dispRow.Week5_7JoCol)
                            || !string.IsNullOrEmpty(dispRow.Week6_7JoCol))
                        {
                            dispRow.Gokei_7JoCol = ((!string.IsNullOrEmpty(dispRow.Week1_7JoCol) ? Convert.ToInt32(dispRow.Week1_7JoCol) : 0)
                                                    + (!string.IsNullOrEmpty(dispRow.Week2_7JoCol) ? Convert.ToInt32(dispRow.Week2_7JoCol) : 0)
                                                    + (!string.IsNullOrEmpty(dispRow.Week3_7JoCol) ? Convert.ToInt32(dispRow.Week3_7JoCol) : 0)
                                                    + (!string.IsNullOrEmpty(dispRow.Week4_7JoCol) ? Convert.ToInt32(dispRow.Week4_7JoCol) : 0)
                                                    + (!string.IsNullOrEmpty(dispRow.Week5_7JoCol) ? Convert.ToInt32(dispRow.Week5_7JoCol) : 0)
                                                    + (!string.IsNullOrEmpty(dispRow.Week6_7JoCol) ? Convert.ToInt32(dispRow.Week6_7JoCol) : 0)).ToString();
                        }

                        // 11条/合計
                        if (!string.IsNullOrEmpty(dispRow.Week1_11JoCol)
                            || !string.IsNullOrEmpty(dispRow.Week2_11JoCol)
                            || !string.IsNullOrEmpty(dispRow.Week3_11JoCol)
                            || !string.IsNullOrEmpty(dispRow.Week4_11JoCol)
                            || !string.IsNullOrEmpty(dispRow.Week5_11JoCol)
                            || !string.IsNullOrEmpty(dispRow.Week6_11JoCol))
                        {
                            dispRow.Gokei_11JoCol = ((!string.IsNullOrEmpty(dispRow.Week1_11JoCol) ? Convert.ToInt32(dispRow.Week1_11JoCol) : 0)
                                                    + (!string.IsNullOrEmpty(dispRow.Week2_11JoCol) ? Convert.ToInt32(dispRow.Week2_11JoCol) : 0)
                                                    + (!string.IsNullOrEmpty(dispRow.Week3_11JoCol) ? Convert.ToInt32(dispRow.Week3_11JoCol) : 0)
                                                    + (!string.IsNullOrEmpty(dispRow.Week4_11JoCol) ? Convert.ToInt32(dispRow.Week4_11JoCol) : 0)
                                                    + (!string.IsNullOrEmpty(dispRow.Week5_11JoCol) ? Convert.ToInt32(dispRow.Week5_11JoCol) : 0)
                                                    + (!string.IsNullOrEmpty(dispRow.Week6_11JoCol) ? Convert.ToInt32(dispRow.Week6_11JoCol) : 0)).ToString();
                        }

                        // 計/合計
                        if (!string.IsNullOrEmpty(dispRow.Gokei_7JoCol) || !string.IsNullOrEmpty(dispRow.Gokei_11JoCol))
                        {
                            dispRow.Gokei_TotalCol = ((!string.IsNullOrEmpty(dispRow.Gokei_7JoCol) ? Convert.ToInt32(dispRow.Gokei_7JoCol) : 0)
                                                    + (!string.IsNullOrEmpty(dispRow.Gokei_11JoCol) ? Convert.ToInt32(dispRow.Gokei_11JoCol) : 0)).ToString();
                        }

                        #endregion

                        // 平均（件数/日）
                        dispRow.AveCol = CalcAveCol(dispRow);

                        kensainSyuhoListDT.AddKensainSyuhoListRow(dispRow);

                        dispRow.AcceptChanges();

                        dispRow.SetAdded();

                    }
                }

                output.KensainSyuhoListDT = kensainSyuhoListDT;

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

        #region プライベート(private)

        #region CalcAveCol
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CalcAveCol
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/30  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string CalcAveCol(KensainSyuhoListDataSet.KensainSyuhoListRow row)
        {
            int i = 0;

            if (!string.IsNullOrEmpty(row.Week1_7JoCol) || !string.IsNullOrEmpty(row.Week1_11JoCol))
            {
                i++;
            }

            if (!string.IsNullOrEmpty(row.Week2_7JoCol) || !string.IsNullOrEmpty(row.Week2_11JoCol))
            {
                i++;
            }

            if (!string.IsNullOrEmpty(row.Week3_7JoCol) || !string.IsNullOrEmpty(row.Week3_11JoCol))
            {
                i++;
            }

            if (!string.IsNullOrEmpty(row.Week4_7JoCol) || !string.IsNullOrEmpty(row.Week4_11JoCol))
            {
                i++;
            }

            if (!string.IsNullOrEmpty(row.Week5_7JoCol) || !string.IsNullOrEmpty(row.Week5_11JoCol))
            {
                i++;
            }

            if (!string.IsNullOrEmpty(row.Week6_7JoCol) || !string.IsNullOrEmpty(row.Week6_11JoCol))
            {
                i++;
            }

            if (i == 0)
            {
                return string.Empty;
            }
            else
            {
                decimal ave = Math.Round(Convert.ToDecimal(row.Gokei_TotalCol) / i, 1, MidpointRounding.AwayFromZero);

                return ave.ToString();
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
