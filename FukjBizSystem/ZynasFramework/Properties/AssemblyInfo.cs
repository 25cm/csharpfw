using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("Zynas.Framework")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("ザイナス")]
[assembly: AssemblyProduct("Zynas.Framework")]
[assembly: AssemblyCopyright("Copyright ©  2011 Zynas corporation. All Rights Reserved.")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// ComVisible を false に設定すると、その型はこのアセンブリ内で COM コンポーネントから 
// 参照不可能になります。COM からこのアセンブリ内の型にアクセスする場合は、 
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible(false)]

// 次の GUID は、このプロジェクトが COM に公開される場合の、typelib の ID です
[assembly: Guid("a5c1d266-2da5-42d5-8470-64f9c12773f9")]

// アセンブリのバージョン情報は、以下の 4 つの値で構成されています:
//
//      FukjBizSystem Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("1.0.0.4")]
[assembly: AssemblyFileVersion("1.0.0.4")]
// ログ
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
