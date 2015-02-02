Set objShell = WScript.CreateObject("WScript.Shell")

'「Ctrl＋Esc」キー（Windowsキーと同様の動き）
objShell.SendKeys "^{ESC}"

WScript.Sleep 300
 
'「a」キーと「BS」キー（検索ボックス表示）

objShell.SendKeys "a"

WScript.Sleep 100

objShell.SendKeys "{BS}"

WScript.Sleep 100

'クリップボードにテキスト設定
objShell.Run "cmd.exe /c echo " & "カメラ" & "| clip", 0, TRUE

'「Ctrl＋v」キー（貼り付け）
objShell.SendKeys "^v"

WScript.Sleep 300

'「Enter」キー（カメラアプリ実行）
objShell.SendKeys "{ENTER}"