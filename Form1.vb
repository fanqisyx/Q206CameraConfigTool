Imports System.IO
Public Class Form1
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim filePath As String = "LocalCameraInfo.csv"
        Dim content As String = TextBox1.Text

        ' 检查文件是否存在
        If File.Exists(filePath) Then
            Dim result As DialogResult = MessageBox.Show("文件已存在。是否覆盖？", "提示", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                WriteToFile(filePath, content, True) ' 覆盖现有文件
            End If
        Else
            WriteToFile(filePath, content, False) ' 创建新文件
        End If
    End Sub



    Sub WriteToFile(ByVal filePath As String, ByVal content As String, ByVal overwrite As Boolean)
        Using writer As StreamWriter = New StreamWriter(filePath, overwrite)
            writer.Write(content)
        End Using

        Console.WriteLine("内容已写入文件。")
    End Sub
End Class
