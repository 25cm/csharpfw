Set objShell = WScript.CreateObject("WScript.Shell")

'�uCtrl�{Esc�v�L�[�iWindows�L�[�Ɠ��l�̓����j
objShell.SendKeys "^{ESC}"

WScript.Sleep 300
 
'�ua�v�L�[�ƁuBS�v�L�[�i�����{�b�N�X�\���j

objShell.SendKeys "a"

WScript.Sleep 100

objShell.SendKeys "{BS}"

WScript.Sleep 100

'�N���b�v�{�[�h�Ƀe�L�X�g�ݒ�
objShell.Run "cmd.exe /c echo " & "�J����" & "| clip", 0, TRUE

'�uCtrl�{v�v�L�[�i�\��t���j
objShell.SendKeys "^v"

WScript.Sleep 300

'�uEnter�v�L�[�i�J�����A�v�����s�j
objShell.SendKeys "{ENTER}"