using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zynas.Control
{
    // TODO プロジェクト固有の処理が必要なものはここに記述する
    // TODO 次回以降のシステムで、システム固有部分の分離を検討する

    //public enum ZControlDomain
    //{

    //}

    // TODO 以下の設定が必要
    // TODO length, imeControl, align, format, lengthErrorMessage, formatErrorMessage

    /// <summary>
    /// アプリケーション固有のコントロールドメイン・パラメータ定義
    /// </summary>
    public class ZControlDomainDef
    {
        public static Dictionary<Zynas.Control.Common.ZControlDomain, object[]> domainDefMap;

        static ZControlDomainDef()
        {
            domainDefMap = new Dictionary<Common.ZControlDomain, object[]>();

            // TODO 
            domainDefMap.Add(
                Common.ZControlDomain.ZT_HOKENJO_CD
                , new object[] { 

                });

        }
    }
}
