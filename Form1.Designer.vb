<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.SalesProduct.SplashScreen1), True, True)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.SkinEngine1 = New Sunisoft.IrisSkin.SkinEngine()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonMiniToolbar1 = New DevExpress.XtraBars.Ribbon.RibbonMiniToolbar(Me.components)
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.ApplicationMenu1 = New DevExpress.XtraBars.Ribbon.ApplicationMenu(Me.components)
        Me.ToolboxControl1 = New DevExpress.XtraToolbox.ToolboxControl()
        Me.NavBarControl1 = New DevExpress.XtraNavBar.NavBarControl()
        Me.NavBarGroup1 = New DevExpress.XtraNavBar.NavBarGroup()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ApplicationMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(349, 37)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(186, 65)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "شاشة العملاء"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(840, 37)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(186, 65)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "شاشة الموردين"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(568, 37)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(186, 65)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "شاشة الاصناف"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(568, 128)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(186, 65)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "شاشة التوريد"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(876, 502)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(186, 20)
        Me.TextBox1.TabIndex = 5
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(660, 528)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(402, 20)
        Me.TextBox2.TabIndex = 6
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(568, 218)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(186, 65)
        Me.Button5.TabIndex = 7
        Me.Button5.Text = "شاشة إتلاف الاصناف"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(840, 128)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(186, 65)
        Me.Button6.TabIndex = 8
        Me.Button6.Text = "شاشة كشف تفصيلى لمورد"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(840, 218)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(186, 65)
        Me.Button7.TabIndex = 9
        Me.Button7.Text = "شاشة ايصال دفع مالى"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(349, 128)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(186, 65)
        Me.Button8.TabIndex = 10
        Me.Button8.Text = "شاشة المبيعات"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'SkinEngine1
        '
        Me.SkinEngine1.__DrawButtonFocusRectangle = True
        Me.SkinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray
        Me.SkinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText
        Me.SkinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.SkinEngine1.SerialNumber = ""
        Me.SkinEngine1.SkinFile = Nothing
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.BarButtonItem1})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 2
        Me.RibbonControl1.MiniToolbars.Add(Me.RibbonMiniToolbar1)
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013
        Me.RibbonControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RibbonControl1.Size = New System.Drawing.Size(1159, 141)
        Me.RibbonControl1.StatusBar = Me.RibbonStatusBar1
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "BarButtonItem1"
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "RibbonPage1"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "RibbonPageGroup1"
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.ItemLinks.Add(Me.BarButtonItem1)
        Me.RibbonStatusBar1.Location = New System.Drawing.Point(0, 566)
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Me.RibbonControl1
        Me.RibbonStatusBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RibbonStatusBar1.Size = New System.Drawing.Size(1159, 27)
        '
        'ApplicationMenu1
        '
        Me.ApplicationMenu1.Name = "ApplicationMenu1"
        Me.ApplicationMenu1.Ribbon = Me.RibbonControl1
        '
        'ToolboxControl1
        '
        Me.ToolboxControl1.Caption = ""
        Me.ToolboxControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolboxControl1.Location = New System.Drawing.Point(0, 141)
        Me.ToolboxControl1.Name = "ToolboxControl1"
        Me.ToolboxControl1.Size = New System.Drawing.Size(260, 425)
        Me.ToolboxControl1.TabIndex = 13
        '
        'NavBarControl1
        '
        Me.NavBarControl1.ActiveGroup = Me.NavBarGroup1
        Me.NavBarControl1.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.NavBarGroup1})
        Me.NavBarControl1.Location = New System.Drawing.Point(281, 199)
        Me.NavBarControl1.Name = "NavBarControl1"
        Me.NavBarControl1.Size = New System.Drawing.Size(140, 300)
        Me.NavBarControl1.TabIndex = 3
        Me.NavBarControl1.Text = "NavBarControl1"
        '
        'NavBarGroup1
        '
        Me.NavBarGroup1.Caption = "NavBarGroup1"
        Me.NavBarGroup1.Expanded = True
        Me.NavBarGroup1.Name = "NavBarGroup1"
        '
        'SplashScreenManager1
        '
        SplashScreenManager1.ClosingDelay = 500
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1159, 593)
        Me.Controls.Add(Me.NavBarControl1)
        Me.Controls.Add(Me.ToolboxControl1)
        Me.Controls.Add(Me.RibbonStatusBar1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ApplicationMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents SkinEngine1 As Sunisoft.IrisSkin.SkinEngine
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonMiniToolbar1 As DevExpress.XtraBars.Ribbon.RibbonMiniToolbar
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents ApplicationMenu1 As DevExpress.XtraBars.Ribbon.ApplicationMenu
    Friend WithEvents ToolboxControl1 As DevExpress.XtraToolbox.ToolboxControl
    Friend WithEvents NavBarControl1 As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents NavBarGroup1 As DevExpress.XtraNavBar.NavBarGroup

End Class
