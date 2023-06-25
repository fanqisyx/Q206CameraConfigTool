<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.bt_readcamera = New System.Windows.Forms.Button()
        Me.bt_writeCamerainfoToCSV = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bt_writeConfigFileinfoToCSV = New System.Windows.Forms.Button()
        Me.bt_Readconfig = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1058, 625)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TextBox1)
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1050, 599)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "相机信息读写"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Location = New System.Drawing.Point(3, 33)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(1044, 563)
        Me.TextBox1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.bt_readcamera)
        Me.Panel2.Controls.Add(Me.bt_writeCamerainfoToCSV)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1044, 30)
        Me.Panel2.TabIndex = 3
        '
        'bt_readcamera
        '
        Me.bt_readcamera.Location = New System.Drawing.Point(3, 3)
        Me.bt_readcamera.Name = "bt_readcamera"
        Me.bt_readcamera.Size = New System.Drawing.Size(91, 23)
        Me.bt_readcamera.TabIndex = 0
        Me.bt_readcamera.Text = "相机信息读取"
        Me.bt_readcamera.UseVisualStyleBackColor = True
        '
        'bt_writeCamerainfoToCSV
        '
        Me.bt_writeCamerainfoToCSV.Location = New System.Drawing.Point(100, 3)
        Me.bt_writeCamerainfoToCSV.Name = "bt_writeCamerainfoToCSV"
        Me.bt_writeCamerainfoToCSV.Size = New System.Drawing.Size(91, 23)
        Me.bt_writeCamerainfoToCSV.TabIndex = 2
        Me.bt_writeCamerainfoToCSV.Text = "写入csv"
        Me.bt_writeCamerainfoToCSV.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TextBox2)
        Me.TabPage2.Controls.Add(Me.Panel1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1050, 599)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "本地信息读写"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox2.Location = New System.Drawing.Point(3, 35)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(1044, 561)
        Me.TextBox2.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.bt_writeConfigFileinfoToCSV)
        Me.Panel1.Controls.Add(Me.bt_Readconfig)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1044, 32)
        Me.Panel1.TabIndex = 3
        '
        'bt_writeConfigFileinfoToCSV
        '
        Me.bt_writeConfigFileinfoToCSV.Location = New System.Drawing.Point(130, 3)
        Me.bt_writeConfigFileinfoToCSV.Name = "bt_writeConfigFileinfoToCSV"
        Me.bt_writeConfigFileinfoToCSV.Size = New System.Drawing.Size(91, 23)
        Me.bt_writeConfigFileinfoToCSV.TabIndex = 3
        Me.bt_writeConfigFileinfoToCSV.Text = "写入csv"
        Me.bt_writeConfigFileinfoToCSV.UseVisualStyleBackColor = True
        '
        'bt_Readconfig
        '
        Me.bt_Readconfig.Location = New System.Drawing.Point(5, 3)
        Me.bt_Readconfig.Name = "bt_Readconfig"
        Me.bt_Readconfig.Size = New System.Drawing.Size(119, 23)
        Me.bt_Readconfig.TabIndex = 0
        Me.bt_Readconfig.Text = "读取本地配置文件"
        Me.bt_Readconfig.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1050, 599)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "汇总信息读写"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1058, 625)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents bt_readcamera As Button
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents bt_writeCamerainfoToCSV As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents bt_Readconfig As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents bt_writeConfigFileinfoToCSV As Button
End Class
