Imports System.IO
Imports ChuangChi
Public Class Form1

#Region "辅助功能"
    'textbox：
    Delegate Sub AddShowTextBoxDelegate(textbox As System.Windows.Forms.TextBox, str As String) '//托管程序
    ''' <summary>
    ''' 修改TextBox中内容
    ''' </summary>
    ''' <param name="textbox">TextBox控件的名称</param>
    ''' <param name="str">需要修改的值</param>
    ''' <remarks></remarks>
    Private Sub DG_ChangeTextBoxValue(textbox As System.Windows.Forms.TextBox, str As String) '//托管程序
        If (textbox.InvokeRequired) Then
            Dim d As New AddShowTextBoxDelegate(AddressOf DG_ChangeTextBoxValue)
            textbox.Invoke(d, textbox, str)
        Else
            textbox.Text = str
        End If
    End Sub
#End Region

#Region "相机信息相关"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_readcamera.Click
        GetCamerainfo()
    End Sub

    Sub GetCamerainfo()
        Try
            Dim DeviceList As System.Collections.Generic.List(Of ThridLibray.IDeviceInfo) =
                (ThridLibray.Enumerator.EnumerateDevices())
            MessageBox.Show("发现相机数量：" + DeviceList.Count.ToString())
            If DeviceList.Count > 0 Then
                Dim info As String = ""
                info = "Index,Key,ManufactureInfo,Model,Name,SerialNumber,Vendor,Version" + Environment.NewLine
                For Each device In DeviceList
                    info += device.Index.ToString() + ","
                    info += device.Key.ToString() + ","
                    info += device.ManufactureInfo.ToString() + ","
                    info += device.Model.ToString() + ","
                    info += device.Name.ToString() + ","
                    info += device.SerialNumber.ToString() + ","
                    info += device.Vendor.ToString() + ","
                    info += device.Version.ToString()
                    info += Environment.NewLine
                Next
                DG_ChangeTextBoxValue(TextBox1, info)
            End If
        Catch ex As Exception
            DG_ChangeTextBoxValue(TextBox1, "在加载相机过程中失败：" + ex.ToString())
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles bt_writeCamerainfoToCSV.Click
        Dim filePath As String = "LocalCameraInfo.csv"
        Dim content As String = TextBox1.Text
        SaveCSV(filePath, content)
        '' 检查文件是否存在
        'If File.Exists(filePath) Then
        '    Dim result As DialogResult = MessageBox.Show("文件已存在。是否覆盖？", "提示", MessageBoxButtons.YesNo)

        '    If result = DialogResult.Yes Then
        '        WriteToFile(filePath, content, True) ' 覆盖现有文件
        '    End If
        'Else
        '    WriteToFile(filePath, content, False) ' 创建新文件
        'End If
    End Sub
#End Region

#Region "CSV操作"
    Private Sub SaveCSV(CSVfilename As String, mytext As String)
        ' 检查文件是否存在
        If File.Exists(CSVfilename) Then
            Dim result As DialogResult = MessageBox.Show("文件已存在。是否覆盖？", "提示", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                WriteToFile(CSVfilename, mytext, False) ' 覆盖现有文件
            End If
        Else
            WriteToFile(CSVfilename, mytext, False) ' 创建新文件
        End If
    End Sub
    Sub WriteToFile(ByVal filePath As String, ByVal content As String, ByVal overwrite As Boolean)
        Using writer As StreamWriter = New StreamWriter(filePath, overwrite)
            writer.Write(content)
        End Using
        Console.WriteLine("内容已写入文件。")
    End Sub

#End Region

#Region "本地已有config文件操作"
    Public IniFiles() As String
    Private Sub bt_Readconfig_Click(sender As Object, e As EventArgs) Handles bt_Readconfig.Click
        IniFiles = FindIniFiles()
        Dim info As String = "index,DeviceName,Exposure" + Environment.NewLine
        Dim n As Integer = 0
        For Each IniFile In IniFiles
            Dim myindex As Integer = GetIndex(IniFile)
            info += myindex.ToString() + "," + GetIniParameter(IniFile) + Environment.NewLine
        Next
        DG_ChangeTextBoxValue(TextBox2, info)
    End Sub
    Private Function GetIndex(ConfigFilePath As String) As Integer
        Dim fileName As String = Path.GetFileNameWithoutExtension(ConfigFilePath)
        Dim idstring As String = fileName.Remove(0, 6)
        Dim id As Integer = Integer.Parse(idstring)
        Return id
    End Function

    Private Function FindIniFiles() As String()
        Dim folderPath As String = Application.StartupPath ' 获取程序所在文件夹路径
        Dim files() As String = Directory.GetFiles(folderPath, "*.ini") ' 获取所有INI文件
        Dim myfiles As List(Of String) = New List(Of String)
        For Each file As String In files
            Dim fileName As String = Path.GetFileNameWithoutExtension(file) ' 获取文件名（不包括扩展名）
            If fileName.StartsWith("Camera") AndAlso fileName.Substring(6).All(Function(c) Char.IsDigit(c)) Then
                myfiles.Add(file)
            End If
        Next
        Return myfiles.ToArray()
    End Function

    Public Function GetIniParameter(ConfigFilePath As String) As String
        Dim myini As ChuangChi.CC_IniFileIO = New CC_IniFileIO()
        myini.Path = ConfigFilePath
        Dim myinfo As String = ""
        myinfo += myini.Read("DevicePara", "DeviceName", CC_IniFileIO.mytype.CC_String) + ","
        myinfo += myini.Read("DevicePara", "Exposure", CC_IniFileIO.mytype.CC_String)
        Return myinfo
    End Function

    Private Sub bt_writeConfigFileinfoToCSV_Click(sender As Object, e As EventArgs) Handles bt_writeConfigFileinfoToCSV.Click
        Dim filePath As String = "LocalConfigFileInfo.csv"
        Dim content As String = TextBox2.Text
        SaveCSV(filePath, content)
    End Sub

    Private title() As String
    Private ConfigInfo() As Dictionary(Of String, String)
    Private Sub bt_ReadCSV_Click(sender As Object, e As EventArgs) Handles bt_ReadCSV.Click
        OpenFileDialog1.Filter = "CSV 文件 (*.csv)|*.csv"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim lines() As String = File.ReadAllLines(OpenFileDialog1.FileName) ' 读取CSV文件的所有行
            'ReDim ConfigInfo(lines.Length - 2)
            Dim info As String = ""
            For Each line As String In lines
                Dim values() As String = line.Split(","c) ' 根据逗号分隔每一行的值
                Dim index As Integer
                If Integer.TryParse(values(0), index) = False Then
                    ReDim title(values.Length - 1)
                    title = values
                    info += line + Environment.NewLine
                End If
            Next
            Dim diclist As List(Of Dictionary(Of String, String)) = New List(Of Dictionary(Of String, String))
            For Each line As String In lines
                Dim values() As String = line.Split(","c) ' 根据逗号分隔每一行的值
                Dim index As Integer
                If Integer.TryParse(values(0), index) = True Then
                    Dim mydictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)
                    info += line + Environment.NewLine
                    For n = 0 To values.Length - 1
                        mydictionary.Add(title(n), values(n))
                    Next
                    diclist.Add(mydictionary)
                End If
            Next
            ConfigInfo = diclist.ToArray()
            DG_ChangeTextBoxValue(TextBox3, info)
        End If
    End Sub

    Private Sub bt_WriteCameraConfigFile_Click(sender As Object, e As EventArgs) Handles bt_WriteCameraConfigFile.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            ' 检查文件是否存在
            Dim fileName As String = FolderBrowserDialog1.SelectedPath + "\Camera0.ini"
            If File.Exists(fileName) Then
                Dim result As DialogResult = MessageBox.Show("文件已存在。是否覆盖？", "提示", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    Return
                End If
            End If
            Try
                For index = 0 To ConfigInfo.Length - 1
                    Dim mydis As Dictionary(Of String, String) = ConfigInfo(index)
                    Dim myini As New ChuangChi.CC_IniFileIO
                    myini.Path = FolderBrowserDialog1.SelectedPath + "\Camera" + mydis.Item("index") + ".ini"
                    myini.Write("DevicePara", mydis.Keys(1), mydis.Item(mydis.Keys(1)))
                    myini.Write("DevicePara", mydis.Keys(2), mydis.Item(mydis.Keys(2)))
                Next
                MessageBox.Show("写入成功")
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        End If
    End Sub


#End Region

End Class
